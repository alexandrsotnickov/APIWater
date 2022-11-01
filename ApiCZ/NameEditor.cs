using Microsoft.VisualBasic.FileIO;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ApiCZ
{
    public partial class NameEditor : Form /*: TemplateForm*/
    {
        //Form parentForm;
        DataBase dB = new DataBase(Properties.Settings.Default.host, Properties.Settings.Default.port, Properties.Settings.Default.database, Properties.Settings.Default.user, Properties.Settings.Default.password);
        DataTable productTable = new DataTable();
        MySqlConnection conn = null;
        MySqlDataAdapter mySql_dataAdapter = null;
        MySqlCommand cmd = null;
        private static string ErrCheck = null;
        public NameEditor(/*Form form*/)
        {
            InitializeComponent();
            //parentForm = form;
            LoadGrid();
        }

       
        private void addRowButton_Click(object sender, EventArgs e)
        {
            try
            {
                productTable.Rows.Add("*Название продукта*", 0, 0, "", 0);
            }
            catch
            {
                MessageBox.Show("Не удалось добавить строку. Таблица не подгружена.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void deleteRowButton_Click(object sender, EventArgs e)
        {
            try
            {
                var collection = dataGrid.SelectedRows.GetEnumerator();
                while (collection.MoveNext())
                {
                    var resault = MessageBox.Show("Вы действительно хотите удалить строку? Вместе с ней удалятся и все коды, которые были закреплены за соответствующим GTIN-ом", "Подтвердите операцию", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resault == DialogResult.No)
                        return;
                    DataGridViewRow row = (DataGridViewRow)collection.Current;
                    dataGrid.Rows.Remove(row);
                }
            }
            catch
            {
                MessageBox.Show("Не удалось удалить строку. Таблица не подгружена.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadGrid()
        {
            productTable.Dispose();
            productTable = new DataTable();
            try
            {
                conn = DBUtils.GetDBConnection();
                conn.Open();
                string sqll = "DELETE FROM main WHERE StatusId = 0 AND (NOW() > DATE_ADD(DateImport, INTERVAL 25 DAY));UPDATE gtin SET CountAviable = COALESCE((SELECT COUNT(GtinId) from main t1 WHERE t1.GtinId = gtin.GtinId AND t1.StatusId = 0 group by t1.GtinId LIMIT 0, 1), 0);";

                var cmd = new MySqlCommand
                {
                    Connection = conn,
                    CommandTimeout = 43200,
                    CommandText = sqll
                };
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //UPDATE main SET StatusId = 0, DatePrint = NULL WHERE StatusId = 1 AND (NOW() > DATE_ADD(DatePrint, INTERVAL 2 DAY));
                //DELETE FROM main WHERE StatusId = 0 AND (NOW() > DATE_ADD(DateImport, INTERVAL 20 DAY));
                string sql = /*"UPDATE printer_base SET StatusId = 0, DatePrint = NULL WHERE StatusId = 1 AND (NOW() > DATE_ADD(DatePrint, INTERVAL 2 DAY));*/"UPDATE gtin SET CountAviable = COALESCE((SELECT COUNT(GtinId) from main t1 WHERE t1.GtinId = gtin.GtinId AND t1.StatusId = 0 group by t1.GtinId LIMIT 0, 1), 0);";

                cmd = new MySqlCommand
                {
                    Connection = conn,
                    CommandTimeout = 43200,
                    CommandText = sql
                };
                DoWorkCmd(cmd);
                mySql_dataAdapter = new MySqlDataAdapter("SELECT t1.GtinName as 'Наименование', t1.GtinId as 'GTIN', t1.CountAviable AS 'Количество', t1.TemplateLabel as 'Шаблон', t1.ExpirationDate as 'Срок годности' FROM gtin AS t1;", conn);
                mySql_dataAdapter.SelectCommand.CommandTimeout = 600;
                mySql_dataAdapter.Fill(productTable);
                dataGrid.DataSource = productTable;
                dataGrid.Columns["GTIN"].DefaultCellStyle.Format = "D14";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Сообщение.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (mySql_dataAdapter != null)
                    mySql_dataAdapter.Dispose();
                if (conn != null)
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    conn.Dispose();
                }
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            LoadGrid();
            dataGrid.Update();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
            GenForm gf = new GenForm();
            gf.Show();
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.Image = Properties.Resources.close_icon;
        }

        private void closeButton_MouseMove(object sender, MouseEventArgs e)
        {
            closeButton.Image = Properties.Resources.close_icon2;
        }
        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell selectedCell = ((DataGridView)sender).CurrentCell;
            switch (e.ColumnIndex)
            {
                case 3:
                    OpenFileDialog dialog = new OpenFileDialog
                    {
                        InitialDirectory = "C:\\"
                    };
                    if (dialog.ShowDialog() != DialogResult.Cancel)
                        selectedCell.Value = dialog.FileName;
                    dialog.Dispose();
                    break;
                case 4:
                    OpenFileDialog dialogg = new OpenFileDialog
                    {
                        InitialDirectory = "C:\\"
                    };
                    if (dialogg.ShowDialog() != DialogResult.Cancel)
                        selectedCell.Value = dialogg.FileName;
                    dialogg.Dispose();
                    break;
                default:
                    break;
            }
        }

        private void dataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewCell selectedCell = ((DataGridView)sender).CurrentCell;
            switch (e.ColumnIndex)
            {
                case 2:
                    e.Cancel = true;
                    break;
                case 3:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }

        private void dataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var grid = (DataGridView)sender;
            grid.CancelEdit();
            MessageBox.Show(e.Exception.Message, "Сообщение.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            var resault = MessageBox.Show("Применить изменения? Вы можете нажать клавишу \"Отмена\" на панели, чтобы подгрузить старые данные. После подтверждения текущей операции данные обновятся. ", "Подтвердите операцию", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resault == DialogResult.No)
                return;
            try
            {
                conn = DBUtils.GetDBConnection();
                conn.Open();
                mySql_dataAdapter = new MySqlDataAdapter();
                mySql_dataAdapter.UpdateCommand = new MySqlCommand($"UPDATE gtin SET GtinName = @name, ExpirationDate = @exdate, CountAviable = @count, TemplateLabel = @template WHERE GtinId = @gtin;", conn);
                mySql_dataAdapter.InsertCommand = new MySqlCommand($"INSERT INTO gtin (GtinId, GtinName, ExpirationDate, CountAviable, TemplateLabel) VALUES (@gtin, @name, @exdate, @count, @template);", conn);
                mySql_dataAdapter.DeleteCommand = new MySqlCommand($"DELETE FROM gtin WHERE GtinId = @gtin;", conn);
                MySqlParameter parameter = new MySqlParameter("@name", MySqlDbType.VarChar);
                parameter.SourceColumn = "Наименование";
                mySql_dataAdapter.InsertCommand.Parameters.Add(parameter);
                mySql_dataAdapter.UpdateCommand.Parameters.Add(parameter);

                parameter = new MySqlParameter("@exdate", MySqlDbType.UInt32);
                parameter.SourceColumn = "Срок годности";
                mySql_dataAdapter.InsertCommand.Parameters.Add(parameter);
                mySql_dataAdapter.UpdateCommand.Parameters.Add(parameter);

                parameter = new MySqlParameter("@count", MySqlDbType.UInt32);
                parameter.SourceColumn = "Количество";
                mySql_dataAdapter.InsertCommand.Parameters.Add(parameter);
                mySql_dataAdapter.UpdateCommand.Parameters.Add(parameter);

                parameter = new MySqlParameter("@template", MySqlDbType.VarChar);
                parameter.SourceColumn = "Шаблон";
                mySql_dataAdapter.InsertCommand.Parameters.Add(parameter);
                mySql_dataAdapter.UpdateCommand.Parameters.Add(parameter);

                parameter = new MySqlParameter("@gtin", MySqlDbType.UInt64);
                parameter.SourceColumn = "GTIN";
                mySql_dataAdapter.InsertCommand.Parameters.Add(parameter);
                mySql_dataAdapter.UpdateCommand.Parameters.Add(parameter);
                mySql_dataAdapter.DeleteCommand.Parameters.Add(parameter);
                mySql_dataAdapter.ContinueUpdateOnError = true;
                mySql_dataAdapter.Update((DataTable)dataGrid.DataSource);
                productTable.AcceptChanges();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Сообщение.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (mySql_dataAdapter != null)
                    mySql_dataAdapter.Dispose();
                if (conn != null)
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    conn.Dispose();
                }
            }
        }

        private async void backButton_Click(object sender, EventArgs e)
        {
            if (productTable != null)
                productTable.Dispose();
            //this.DialogResult = DialogResult.OK;
            this.Enabled = false;
            //parentForm.Show();
            await Task.Delay(500);
            this.Hide();
            this.Enabled = true;
            this.Close();
            //this.Dispose();
        }

        private void importButton_Click(object sender, EventArgs e)
        {

            this.TopMost = false;
            conn = DBUtils.GetDBConnection();
            StreamReader streamFile = null;
            DataTable gtinTable = null;
            MySqlDataAdapter mySql_dataAdapter_main = new MySqlDataAdapter();
            DataTable insertData = new DataTable();
            mySql_dataAdapter = new MySqlDataAdapter("SELECT * FROM gtin;", conn);
            DataTable streamMessage = new DataTable();
            streamMessage.Columns.Add("Файл", System.Type.GetType("System.String"));
            streamMessage.Columns.Add("Сообщение от потока", System.Type.GetType("System.String"));
            DataTable addGtines = new DataTable();
            addGtines.Columns.Add("GTIN", System.Type.GetType("System.UInt64"));
            try
            {
                conn.Open();
                mySql_dataAdapter_main.InsertCommand = new MySqlCommand("INSERT INTO main (Code, GtinId, DateImport) VALUES (@code, @gtin, @date);", conn);
                insertData.Columns.Add("Code", System.Type.GetType("System.String"));
                insertData.Columns.Add("GTIN", System.Type.GetType("System.UInt64"));
                insertData.Columns.Add("DateImport", System.Type.GetType("System.DateTime"));
                MySqlParameter parameter = new MySqlParameter("@code", MySqlDbType.VarChar);
                parameter.SourceColumn = "Code";
                mySql_dataAdapter_main.InsertCommand.Parameters.Add(parameter);
                parameter = new MySqlParameter("@gtin", MySqlDbType.UInt64);
                parameter.SourceColumn = "GTIN";
                mySql_dataAdapter_main.InsertCommand.Parameters.Add(parameter);
                parameter = new MySqlParameter("@date", MySqlDbType.DateTime);
                parameter.SourceColumn = "DateImport";
                mySql_dataAdapter_main.InsertCommand.Parameters.Add(parameter);
                mySql_dataAdapter = new MySqlDataAdapter("SELECT * FROM gtin;", conn);
                gtinTable = new DataTable();
                mySql_dataAdapter.Fill(gtinTable);
                UInt64 gtinCode;
                var files = Directory.GetFiles(Properties.Settings.Default.ImportPath, "*.csv");
                if (files.Length == 0)
                    throw new Exception("Нет файлов.");
                foreach (string file in files)
                {
                    bool errCheck = false;
                    try
                    {
                        streamFile = File.OpenText(file);
                        string s = null;
                        while ((s = streamFile.ReadLine()) != null)
                        {
                            try
                            {
                                gtinCode = System.Convert.ToUInt64(s.Substring(2, 14));
                                var query = from r in gtinTable.AsEnumerable() where r.Field<UInt64>("GtinId") == gtinCode select new { GtinId = r.Field<UInt64>("GtinId") };
                                if (query.AsEnumerable().Count() == 0)
                                {
                                    addGtines.Rows.Add(gtinCode);
                                    throw new Exception($"GTIN {gtinCode.ToString("D14")}: Похоже это новый товар, т.к. не удалось обнаружить запись с таким GTIN-ом.  Пожалуйста, создайте для него запись в \"редакторе наименований\" и повторите попытку.");
                                }
                                DateTime dateImport;
                                try
                                {
                                    dateImport = File.GetCreationTime(file); //DateTime.ParseExact(streamFile.ReadLine().Replace("date_", ""), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                                }
                                catch
                                {
                                    dateImport = DateTime.Now;
                                }
                                string dataMatrixCode = s;
                                do
                                {
                                    if (dataMatrixCode == "")
                                    {
                                        break;
                                    }
                                    dataMatrixCode = dataMatrixCode.Split('\t')[0];
                                    insertData.Rows.Add(dataMatrixCode, gtinCode, dateImport);
                                } while (((dataMatrixCode = streamFile.ReadLine()) != null));
                            }
                            catch (Exception q)
                            {
                                errCheck = true;
                                while ((s = streamFile.ReadLine()) != null)
                                {
                                    if (s.StartsWith("close_"))
                                        break;
                                }
                                //добавить ещё форму обратной связи
                                streamMessage.Rows.Add(file, q.Message);
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        //MessageBox.Show(exc.Message, "Сообщение.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (streamFile != null)
                        {
                            streamFile.Close();
                            streamFile.Dispose();
                        }
                        if (!errCheck)
                        {
                            var spliting = file.Split('\\');
                            Random rand = new Random();
                            FileSystem.RenameFile(file, DateTime.Now.ToString("_dd_MM_yyyy_hh_mm_ss_") + rand.Next(0, 9999) + "_" + spliting.ElementAt(spliting.Length - 3) + ".txt");
                        }
                    }
                }
                mySql_dataAdapter_main.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
                mySql_dataAdapter_main.UpdateBatchSize = 10000;
                mySql_dataAdapter_main.ContinueUpdateOnError = true;

                int count = mySql_dataAdapter_main.Update(insertData);
                insertData.AcceptChanges();
                streamMessage.Rows.Add("Общее: ", "Добавлено " + count + " кодов из " + insertData.Rows.Count + ", представленных в файлах.");
                streamMessage.AcceptChanges();
            }
            catch (MySql.Data.MySqlClient.MySqlException exc)
            {
                MessageBox.Show(exc.Message, "Сообщение.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Сообщение.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (mySql_dataAdapter_main != null)
                {
                    mySql_dataAdapter_main.Dispose();
                }
                if (mySql_dataAdapter != null)
                {
                    mySql_dataAdapter.Dispose();
                }
                if (insertData != null)
                {
                    insertData.Dispose();
                }
                if (gtinTable != null)
                {
                    gtinTable.Dispose();
                }

                string sql = " DELETE FROM main WHERE StatusId = 0 AND (NOW() > DATE_ADD(DateImport, INTERVAL 25 DAY));UPDATE gtin SET CountAviable = COALESCE((SELECT COUNT(GtinId) from main t1 WHERE t1.GtinId = gtin.GtinId AND t1.StatusId = 0 group by t1.GtinId LIMIT 0, 1), 0);";

                cmd = new MySqlCommand
                {
                    Connection = conn,
                    CommandTimeout = 43200,
                    CommandText = sql
                };
                DoWorkCmd(cmd);
                if (conn != null)
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    conn.Dispose();
                }
                GC.Collect();
            }
            this.Hide();
            ImportResaultDialog importResault = new ImportResaultDialog(streamMessage);
            importResault.ShowDialog();
            this.Show();
            importResault.Dispose();
            streamMessage.Dispose();
            if (addGtines.Rows.Count > 0)
            {
                var res = MessageBox.Show("В последней операции импорта были обнаружены новые gtin. Добавить их автоматически?\nВы также можете их добавить вручную.", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    bool errno = false;
                    conn = DBUtils.GetDBConnection();
                    try
                    {

                        conn.Open();
                        mySql_dataAdapter = new MySqlDataAdapter();
                        mySql_dataAdapter.InsertCommand = new MySqlCommand("INSERT INTO gtin (GtinId, GtinName) VALUES (@gtin, '*Название продукта*')", conn);
                        var parameter = new MySqlParameter("@gtin", MySqlDbType.UInt64);
                        parameter.SourceColumn = "GTIN";
                        mySql_dataAdapter.ContinueUpdateOnError = true;
                        mySql_dataAdapter.InsertCommand.Parameters.Add(parameter);
                        mySql_dataAdapter.Update(addGtines);
                        addGtines.AcceptChanges();
                        errno = true;
                    }
                    finally
                    {
                        if (conn != null)
                        {
                            if (conn.State == ConnectionState.Open)
                                conn.Close();
                            conn.Dispose();
                            mySql_dataAdapter.Dispose();
                            addGtines.Dispose();
                        }
                        if (errno)
                            importButton_Click(sender, e);
                    }
                }
            }
            else
            {
                /*var files = Directory.GetFiles(Properties.Settings.Default.ImportPath, "*.csv");
                foreach (string file in files)
                {
                    File.Delete(file);
                }*/
            }
            cancelButton_Click(sender, e);
        }
        private static void DoWorkCmd(MySqlCommand cmd) //Execute comand
        {
            try
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception q)
            {

            }
        }
        private static void DoWorkFill(MySqlDataAdapter mySql_dataAdapter, DataTable table) //Execute comand
        {
            try
            {
                mySql_dataAdapter.Fill(table);
            }
            catch (Exception q)
            {
                ErrCheck = q.Message;
            }
        }
        static string ReplaceHexadecimalSymbols(string txt) //замена спецсимволов в строке для работы с xml
        {
            string r = @"[^\x09\x0A\x0D\x20-\uD7FF\uE000-\uFFFD\u10000-\u10FFFF]";
            return Regex.Replace(txt, r, "", RegexOptions.Compiled);
        }
        private async void exButton_Click(object sender, EventArgs e)
        {
            bool bgroup = false, btrans = false;
            MySqlConnection conn = DBUtils.GetDBConnection();
            string qmessage = "";
            try
            {
                conn.Open();
                string sql = "SELECT * FROM params WHERE name = 'GLN' OR name = 'Phone' OR name = 'address' OR name = 'org_name' OR name = 'INN' OR name = 'email';";

                cmd = new MySqlCommand
                {
                    Connection = conn,
                    CommandTimeout = 43200,
                    CommandText = sql
                };
                var reader = cmd.ExecuteReader();
                string GLN_str = null, phone_str = null, address_str = null, org_name_str = null, INN_str = null, email_str = null;
                this.TopMost = false;
                while (reader.Read())
                {
                    switch (reader["name"].ToString())
                    {
                        case "GLN":
                            GLN_str = reader["value"].ToString();
                            break;
                        case "phone":
                            phone_str = reader["value"].ToString();
                            break;
                        case "address":
                            address_str = reader["value"].ToString();
                            break;
                        case "org_name":
                            org_name_str = reader["value"].ToString();
                            break;
                        case "INN":
                            INN_str = reader["value"].ToString();
                            break;
                        case "email":
                            email_str = reader["value"].ToString();
                            break;
                        default:
                            break;
                    }
                }
                reader.Close();
                reader.Dispose();
                cmd.Dispose();
                MySqlDataAdapter mySql_dataAdapter = new MySqlDataAdapter("SELECT * FROM main WHERE StatusId = 2;", conn);
                DataTable table = new DataTable();

                await Task.Run(() => DoWorkFill(mySql_dataAdapter, table));

                if (ErrCheck != null)
                {
                    throw new Exception(ErrCheck);
                }
                if (table.Rows.Count > 0)
                {
                    string emission_write = "";
                    XDeclaration xDeclaration = new XDeclaration("1.0", "utf-8", "yes");
                    XDeclaration xDeclaration2 = new XDeclaration("1.0", "utf-8", "yes");
                    XDeclaration xDeclaration1 = new XDeclaration("1.0", "utf-8", "yes");
                    XElement unitpack = new XElement("unit_pack");
                    XElement unitpack1 = new XElement("unit_pack");
                    XAttribute file_date_time = new XAttribute("file_date_time", DateTime.UtcNow.ToString("yyyy-MM-ddThh-mm-ss+08:00"));
                    XAttribute file_date_time1 = new XAttribute("file_date_time", DateTime.UtcNow.ToString("yyyy-MM-ddThh-mm-ss+08:00"));
                    unitpack1.Add(file_date_time1);
                    unitpack.Add(file_date_time);
                    XElement document1 = new XElement("Document");
                    XElement document = new XElement("Document");
                    XAttribute doc_op_time1 = new XAttribute("operation_date_time", DateTime.UtcNow.ToString("yyyy-MM-ddThh-mm-ss+08:00"));
                    XAttribute doc_op_time = new XAttribute("operation_date_time", DateTime.UtcNow.ToString("yyyy-MM-ddThh-mm-ss+08:00"));
                    document.Add(doc_op_time);
                    document1.Add(doc_op_time1);
                    XElement org1 = new XElement("organisation");
                    XElement org = new XElement("organisation");
                    XElement info = new XElement("id_info");
                    XElement info1 = new XElement("id_info");

                    XElement lpinfo = new XElement("LP_info");
                    XElement lpinfo1 = new XElement("LP_info");

                    XAttribute org_name = new XAttribute("org_name", org_name_str);
                    XAttribute org_name1 = new XAttribute("org_name", org_name_str);

                    XAttribute LP_TIN = new XAttribute("LP_TIN", INN_str);
                    XAttribute LP_TIN1 = new XAttribute("LP_TIN", INN_str);

                    lpinfo.Add(LP_TIN);
                    lpinfo1.Add(LP_TIN1);
                    lpinfo.Add(org_name);
                    lpinfo1.Add(org_name1);
                    info.Add(lpinfo);
                    info1.Add(lpinfo1);
                    org.Add(info);
                    org1.Add(info1);
                    XElement addr1 = new XElement("Address");
                    XElement addr = new XElement("Address");
                    XElement location_address = new XElement("location_address");
                    XElement location_address1 = new XElement("location_address");
                    addr1.Add(location_address1);
                    addr.Add(location_address);
                    XAttribute country_code = new XAttribute("country_code", 643);
                    XAttribute country_code1 = new XAttribute("country_code", 643);
                    XAttribute text_address = new XAttribute("text_address", address_str);
                    XAttribute text_address1 = new XAttribute("text_address", address_str);
                    location_address1.Add(country_code1);
                    location_address1.Add(text_address1);
                    location_address.Add(country_code);
                    location_address.Add(text_address);
                    XElement contacts = new XElement("contacts");
                    XElement contacts1 = new XElement("contacts");
                    XAttribute phone_number1 = new XAttribute("phone_number", phone_str);
                    XAttribute phone_number = new XAttribute("phone_number", phone_str);
                    XAttribute email1 = new XAttribute("email", email_str);
                    XAttribute email = new XAttribute("email", email_str);
                    contacts1.Add(email1);
                    contacts.Add(email);
                    contacts.Add(phone_number);
                    contacts1.Add(phone_number1);
                    org1.Add(contacts1);
                    org.Add(contacts);
                    org1.Add(addr1);
                    org.Add(addr);
                    document1.Add(org1);
                    document.Add(org);
                    unitpack1.Add(document1);
                    unitpack.Add(document);
                    XDocument xDoc1 = new XDocument(xDeclaration1);
                    XDocument xDoc2 = new XDocument(xDeclaration1);
                    xDoc1.Add(unitpack);
                    xDoc2.Add(unitpack1);
                    XDocument xDoc = new XDocument(xDeclaration);

                    XElement xGeneral = new XElement("Products");

                    xDoc.Add(xGeneral);

                    XElement xRoot = new XElement("Second_aggregation");

                    xGeneral.Add(xRoot);

                    var query_SecAgg = from r in table.AsEnumerable()
                                       group r by new
                                       {
                                           SecondAgg = r.Field<UInt64?>("SAgg"),
                                       } into g
                                       select new
                                       {
                                           g.Key.SecondAgg,
                                       };

                    foreach (var Secitem in query_SecAgg)
                    {
                        XElement xSecondAgg = new XElement("Second_Aggregation");
                        XElement xElement2 = null;
                        if (Secitem.SecondAgg != null)
                        {
                            btrans = true;
                            xElement2 = new XElement("pack_content");

                            document1.Add(xElement2);
                            var xElement3 = new XElement("pack_code");
                            xElement2.Add(xElement3);
                            xElement3.Add("001" + GLN_str + System.Convert.ToUInt64(Secitem.SecondAgg).ToString("D8"));
                            //unitpack1.Add("001" + GLN + System.Convert.ToUInt64(Secitem.SecondAgg).ToString("D8"));
                            XAttribute SecCode = new XAttribute("Code", "001" + GLN_str + System.Convert.ToUInt64(Secitem.SecondAgg).ToString("D8"));
                            DataRow[] findResult = table.Select("SAgg = " + Secitem.SecondAgg);
                            XAttribute SecData = new XAttribute("Code_DateTime_Print", findResult[0]["SAggDatePrint"].ToString());
                            xSecondAgg.Add(SecData);
                            xSecondAgg.Add(SecCode);
                        }

                        var query_FirAgg = from r in table.AsEnumerable()
                                           where r.Field<UInt64?>("SAgg") == Secitem.SecondAgg
                                           group r by new
                                           {
                                               FirstAgg = r.Field<UInt64?>("FAgg")
                                           } into g
                                           select new
                                           {
                                               g.Key.FirstAgg
                                           };

                        foreach (var Firitem in query_FirAgg)
                        {
                            XElement xFirstAgg = new XElement("First_Aggregation");
                            XElement pack_content = new XElement("pack_content");
                            if (Firitem.FirstAgg != null)
                            {
                                bgroup = true;
                                XElement el = new XElement("cis");
                                el.Add("000" + GLN_str + System.Convert.ToUInt64(Firitem.FirstAgg).ToString("D8"));
                                if (xElement2 != null)
                                    xElement2.Add(el);
                                XElement firCode1 = new XElement("sscc");
                                XAttribute FirCode = new XAttribute("Code", "000" + GLN_str + System.Convert.ToUInt64(Firitem.FirstAgg).ToString("D8"));

                                var findResult = table.Select("FAgg = " + Firitem.FirstAgg);

                                XAttribute FirData = new XAttribute("Code_DateTime_Print", findResult[0]["FaggDatePrint"].ToString());
                                firCode1.Add("000" + GLN_str + System.Convert.ToUInt64(Firitem.FirstAgg).ToString("D8"));
                                xFirstAgg.Add(FirData);
                                xFirstAgg.Add(FirCode);
                                pack_content.Add(firCode1);
                            }
                            var query_DM = from r in table.AsEnumerable()
                                           where r.Field<UInt64?>("FAgg") == Firitem.FirstAgg
                                           select new
                                           {
                                               DM = r.Field<string>("Code")
                                           };

                            foreach (var DMitem in query_DM)
                            {
                                if (ReplaceHexadecimalSymbols(string.Join(null, DMitem.DM)).Length > 11)
                                {
                                    XElement xElement = new XElement("DataMatrix");

                                    XCData dm = new XCData(ReplaceHexadecimalSymbols(string.Join(null, DMitem.DM)));

                                    var findResult = table.Select("Code = '" + DMitem.DM.Replace("'", "''") + "'");
                                    findResult[0]["StatusId"] = 3;
                                    XAttribute dateDM = new XAttribute("Code_DateTime_Print", findResult[0]["DateVerify"].ToString());
                                    XAttribute weightDM = new XAttribute("Weight", 0);
                                    XAttribute GTINDM = new XAttribute("GTIN", System.Convert.ToUInt64(findResult[0]["GtinId"]).ToString("D14"));
                                    emission_write += DMitem.DM + "\n";
                                    xElement.Add(dateDM);
                                    xElement.Add(weightDM);
                                    xElement.Add(dm);
                                    xElement.Add(GTINDM);
                                    xFirstAgg.Add(xElement);
                                    XElement cis = new XElement("cis");
                                    XCData dmm = new XCData(DMitem.DM.Split((char)29)[0]);
                                    cis.Add(dmm);
                                    pack_content.Add(cis);
                                }
                            }
                            if (Firitem.FirstAgg != null)
                                document.Add(pack_content);

                            xSecondAgg.Add(xFirstAgg);
                        }
                        xRoot.Add(xSecondAgg);
                    }


                    string nameProd = "\\Product_emission_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Second + ".csv";
                    string path = Application.StartupPath + "\\temp\\export";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var fileem = File.OpenWrite(path + nameProd);
                    fileem.Write(System.Text.Encoding.UTF8.GetBytes(emission_write), 0, emission_write.Length - 1);
                    fileem.Close();
                    fileem.Dispose();
                    try
                    {
                        var movFiles = FileSystem.GetFiles(path, Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.csv");
                        foreach (var file in movFiles)
                        {
                            FileSystem.MoveFile(file, Properties.Settings.Default.ExportPath + "\\" + FileSystem.GetName(file));
                        }
                    }
                    catch (Exception ex)
                    {
                        qmessage = ex.Message;
                    }



                    nameProd = "\\Product_Group_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Second + ".xml";
                    path = Application.StartupPath + "\\temp\\FAGG";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    if (bgroup)
                        xDoc1.Save(path + nameProd);
                    try
                    {
                        var movFiles = FileSystem.GetFiles(path, Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.xml");
                        foreach (var file in movFiles)
                        {
                            FileSystem.MoveFile(file, Properties.Settings.Default.GroupPath + "\\" + FileSystem.GetName(file));
                        }
                    }
                    catch (Exception ex)
                    {
                        qmessage = ex.Message;
                    }

                    nameProd = "\\Product_Trans_" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Second + ".xml";
                    path = Application.StartupPath + "\\temp\\SAGG";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    if (btrans)
                        xDoc2.Save(path + nameProd);

                    try
                    {
                        var movFiles = FileSystem.GetFiles(path, Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.xml");
                        foreach (var file in movFiles)
                        {
                            FileSystem.MoveFile(file, Properties.Settings.Default.AggPath + "\\" + FileSystem.GetName(file));
                        }
                    }
                    catch (Exception ex)
                    {
                        qmessage = ex.Message;
                    }
                    mySql_dataAdapter.UpdateCommand = new MySqlCommand("UPDATE main SET StatusId = 3 WHERE Code = @code;", conn);
                    var parame = new MySqlParameter("@code", MySqlDbType.VarChar);
                    parame.SourceColumn = "Code";
                    mySql_dataAdapter.UpdateCommand.Parameters.Add(parame);
                    mySql_dataAdapter.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
                    mySql_dataAdapter.UpdateBatchSize = 1;
                    mySql_dataAdapter.Update(table);
                    //table.AcceptChanges();
                    cmd = new MySqlCommand("DELETE FROM main WHERE (DateImport < CURRENT_TIMESTAMP() - INTERVAL 2 MONTH);", conn)
                    {
                        CommandType = CommandType.Text,
                        CommandTimeout = 43200
                    };
                    await Task.Run(() => DoWorkCmd(cmd));
                    cmd = new MySqlCommand("INSERT INTO ;", conn)
                    {
                        CommandType = CommandType.Text,
                        CommandTimeout = 43200
                    };
                    await Task.Run(() => DoWorkCmd(cmd));


                    if (ErrCheck != null) throw new Exception(ErrCheck);
                    if (qmessage.Length == 0)
                        qmessage = "Экспорт завершен успешно!";
                    fileem.Close();
                }
                else
                {
                    qmessage = "Похоже, что в базе нет кодов, доступных для экспорта. Операция была отменена.";
                }
                table.Dispose();
                mySql_dataAdapter.Dispose();
            }
            catch (Exception exc)
            {
                qmessage = "Экспорт не был успешно завершен.\nСообщение от потока: " + exc.Message;
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
                if (mySql_dataAdapter != null)
                    mySql_dataAdapter.Dispose();
                ErrCheck = null;
                if (conn != null)
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    conn.Dispose();
                }
                MessageBox.Show(qmessage, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GC.Collect();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
