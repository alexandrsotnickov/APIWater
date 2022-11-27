using CsvHelper;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace ApiCZ
{
    class Parser
    {
        
        public System.Collections.Specialized.StringCollection ParserSettings(string settings)
        {
            System.Collections.Specialized.StringCollection parseSetting = new System.Collections.Specialized.StringCollection();
            string str;
            int index = 0;

            do
            {
                index = settings.IndexOf(",");
                if (index != -1)
                {
                    str = settings.Substring(0, index);
                    parseSetting.Add(str);
                    settings = settings.Substring(index + 2);
                }
                else
                {
                    parseSetting.Add(settings);
                }

            } while (index != -1);
            return parseSetting;

        }

        public string DeParseSettings(System.Collections.Specialized.StringCollection settings)
        {
            string str = null;
            for (int i = 0; i < settings.Count; i++)
            {
                if (i == 0)
                    str = settings[i];
                else
                    str = str + ", " + settings[i];

            }
            return str;

        }
    }
    class DataBase
    {
        public static MySql.Data.MySqlClient.MySqlConnection conn;
        public DataBase(string host, string port, string database, string username, string password)
        {
            string connString = "server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password + ";SSL Mode=None; convert zero datetime=True";
            conn = new MySqlConnection(connString);

        }
        
        public void OpenConnection()
        {
           conn.Open();   
        }

        public bool CloseConnection()
        {
            conn.Close();
            // Выбьет эксепшн если не может
            return true;
        }

        public void SelectProd()
        {
            string gtin = null;
            string name = null;
            List<string> gtins = new List<string>();
            List<string> names = new List<string>();
            
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT GtinId, GtinName FROM gtin", conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                gtin = reader["GtinId"].ToString();
                name = reader["GtinName"].ToString();
                gtins.Add(gtin);
                names.Add(name);
            }
            reader.Close();
            reader.Dispose();
            CloseConnection();
            Properties.Settings.Default.name = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.gtin = new System.Collections.Specialized.StringCollection();

            foreach (string n in names)
            {
                Properties.Settings.Default.name.Add(n);   
            }

            foreach (string g in gtins)
            {
                Properties.Settings.Default.gtin.Add("0" + g);
            }

            Properties.Settings.Default.Save();

        }
        public void UploadKMToDB(markWS.СписокКМ poolKM)
        {
            List<markWS.КМ> km = new List<markWS.КМ>();
            string count = null;
           for(int i = 0; i < poolKM.Items.Length - 3; i++)
           {
                km.Add((markWS.КМ)poolKM.Items[i]);
           }
            OpenConnection();
            //DateTime date1 = new DateTime(2022, 10, 19, 11, 30, 25);
            //DateTime date2 = new DateTime(2022, 10, 19, 8, 36, 12);
            //DateTime date3 = new DateTime(2022, 10, 20, 13, 30, 25);
            foreach (markWS.КМ k in km)
            {
               //try
               //{
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO main (Code, GtinId, DateImport) VALUES (@code, " + k.gtin + ", @date);", DataBase.conn);
                    //MySqlCommand cmd = new MySqlCommand("INSERT INTO main (Code, GtinId, DateImport, StatusId, DatePrint, DateVerify) VALUES (@code, " + k.gtin + ", @date, 1, @datePrint, @dateVerify);", DataBase.conn);
                    cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = k.Код.Replace("(/29)", "\u001d");
                    cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = DateTime.Now;
                    //cmd.Parameters.Add("@datePrint", MySqlDbType.DateTime).Value = date1;
                    //cmd.Parameters.Add("@dateVerify", MySqlDbType.DateTime).Value = date3;
                    cmd.ExecuteNonQuery();
               //}
               //catch(Exception ex) { }
            }
            MySqlCommand cmd2 = new MySqlCommand("SELECT COUNT(*) AS count FROM main WHERE GtinId = " + km[1].gtin +";", DataBase.conn);
            cmd2.ExecuteNonQuery();
            MySqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                count = reader["count"].ToString();
            }
            reader.Close();
            reader.Dispose();

            MySqlCommand cmd3 = new MySqlCommand("UPDATE gtin SET CountAviable = '" + count + "' WHERE  GtinId= " + km[1].gtin, DataBase.conn);
            cmd3.ExecuteNonQuery();
     
            CloseConnection();

        }

        

        public List<string> GetQuantityFromDB(string gtin, DateTime dateVerify)
        {
            List<string> quantity = new List<string>();
            string count = "";

            DateTime startTime = new DateTime(Convert.ToInt16(dateVerify.Year), Convert.ToInt16(dateVerify.Month), Convert.ToInt16(dateVerify.Day));
            DateTime endTime = startTime.AddDays(1);
            string startTimeStr = startTime.ToString("yyyy-MM-dd HH:mm:ss");
            string endTimeStr = endTime.ToString("yyyy-MM-dd HH:mm:ss");


            OpenConnection();
            //MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS 'count' FROM main WHERE (DateVerify BETWEEN '" + startTimeStr + "' AND '" + endTimeStr + "') AND GtinId = " + gtin + " AND StatusId = 2", conn);
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS 'count' FROM main WHERE (DatePrint BETWEEN '" + startTimeStr + "' AND '" + endTimeStr + "') AND GtinId = " + gtin + " AND StatusId = 2", conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count = reader["count"].ToString();
                quantity.Add(count);
            }
            reader.Close();
            reader.Dispose();
            CloseConnection();
            return quantity;

        }

        

        public void UpdateStatusCirc(string gtin, DateTime prodDate)
        {
            try
            {
                DateTime startTime = new DateTime(Convert.ToInt16(prodDate.Year), Convert.ToInt16(prodDate.Month), Convert.ToInt16(prodDate.Day));
                DateTime endTime = startTime.AddDays(1);
                string startTimeStr = startTime.ToString("yyyy-MM-dd HH:mm:ss");
                string endTimeStr = endTime.ToString("yyyy-MM-dd HH:mm:ss");
                string productionDate = startTime.ToString("yyyy-MM-dd");
                OpenConnection();
                foreach (string code in WebService1C.codes)
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE main SET StatusId = 7, DateExport = @dateExport WHERE Code = @code", conn);
                    cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = code.Replace("(/29)", "\u001d");
                    cmd.Parameters.Add("@dateExport", MySqlDbType.DateTime).Value = DateTime.Now;
                    cmd.ExecuteNonQuery();   
                }
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageWindow msg = new MessageWindow(ex.Message, 1);
                msg.Show();

            }
        }
    }
    class WebService1C
    {
       markWS.homeportPortTypeClient ws;

        public static markWS.РезультатОбработкиОтчетаКМ reportResult;
        DataBase dB = new DataBase(Properties.Settings.Default.host, Properties.Settings.Default.port, Properties.Settings.Default.database, Properties.Settings.Default.user, Properties.Settings.Default.password);
        public static string error;
        public static List<string> codes = new List<string>();
        public static List<string> appCodes = new List<string>();
        public static List<string> rejCodes = new List<string>();
        public markWS.РезультатОбработкиЗаказа OrderCodes(string gtin, string count, string inn)
        {
            markWS.РезультатОбработкиЗаказа resultOrder = null;
            ws = new markWS.homeportPortTypeClient("homeportSoap");
            ws.ClientCredentials.UserName.UserName = "ws";
            ws.ClientCredentials.UserName.Password = "123";

            markWS.Заказ order = new markWS.Заказ();
            markWS.Организация org = new markWS.Организация();
            markWS.СтрокаЗаказа strOrder = new markWS.СтрокаЗаказа();

            org.инн = inn;
            strOrder.gtin = gtin;
            strOrder.Количество = Convert.ToInt32(count);

            order.Items = new object[] { org, strOrder };
            resultOrder = ws.ЗаказатьКоды(order);
            return resultOrder;



        }
        public markWS.СписокКМ GetCodes(markWS.РезультатОбработкиЗаказа resultOrder)
        {
            markWS.СписокКМ poolKM = null;

            ws = new markWS.homeportPortTypeClient("homeportSoap");
            ws.ClientCredentials.UserName.UserName = "ws";
            ws.ClientCredentials.UserName.Password = "123";

            //try
            //{
            poolKM = ws.ПолучитьКоды(resultOrder.ИдЗаказаЧЗ);
            //poolKM = ws.ПолучитьКоды("5abcc95c-d5ae-4be8-ae31-dc196841419c");
            return poolKM;

            //}
            //catch {
            //    return poolKM;
            //}
        }
            public markWS.СтатусВводаВОборот ReportStatusCirc()
            {


                markWS.СтатусВводаВОборот reportStatus = new markWS.СтатусВводаВОборот();
                try
                {

                    ws = new markWS.homeportPortTypeClient("homeportSoap");
                    ws.ClientCredentials.UserName.UserName = "ws";
                    ws.ClientCredentials.UserName.Password = "123";
                    //masKM.Items = codes.ToArray();
                    //string info = ws.ПолучитьИнформациюПоКодам(masKM);
                    string str = reportResult.Items[2].ToString();
                    reportStatus = ws.ПолучитьСтатусВводаВОборот(str);


                }
                catch
                {
                    //return Tuple.Create(reportStatusCirc.status, reportStatusCirc.errors, false);
                    return null;
                }
                return reportStatus;
                /*Tuple.Create(reportStatusCirc.status, reportStatusCirc.errors, true);*/
            }



            public void ReportCirc(string gtin, DateTime prodDate)
            {

                codes.Clear();
                List<string> dates = new List<string>();
                DateTime startTime = new DateTime(Convert.ToInt16(prodDate.Year), Convert.ToInt16(prodDate.Month), Convert.ToInt16(prodDate.Day));
                DateTime endTime = startTime.AddDays(1);
                string startTimeStr = startTime.ToString("yyyy-MM-dd HH:mm:ss");
                string endTimeStr = endTime.ToString("yyyy-MM-dd HH:mm:ss");
                string productionDate = startTime.ToString("yyyy-MM-dd");
                int k = 0;
                try
                {
                    dB.OpenConnection();
                    //MySqlCommand cmd = new MySqlCommand("SELECT Code, DateVerify FROM main WHERE (DateVerify BETWEEN '" + startTimeStr + "' AND '" + endTimeStr + "') AND GtinId = " + gtin + " AND StatusId = 2", DataBase.conn);
                    MySqlCommand cmd = new MySqlCommand("SELECT Code, DatePrint FROM main WHERE (DatePrint BETWEEN '" + startTimeStr + "' AND '" + endTimeStr + "') AND GtinId = " + gtin + " AND StatusId = 2", DataBase.conn);
                    cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        k++;
                        if (k <= 29998)
                        {
                            codes.Add(reader["Code"].ToString().Replace("\u001d", "(/29)")/*.Substring(0, reader["Code"].ToString().Length - 7)*/);
                            //dates.Add(reader["DateVerify"].ToString());
                            dates.Add(reader["DatePrint"].ToString());
                        }
                        else
                            break;

                    }
                    reader.Close();
                    reader.Dispose();


                    dB.CloseConnection();

                    ws = new markWS.homeportPortTypeClient("homeportSoap");
                    ws.ClientCredentials.UserName.UserName = "ws";
                    ws.ClientCredentials.UserName.Password = "123";
                    markWS.СтрокаСтатусКМ[] kmArr = new markWS.СтрокаСтатусКМ[codes.Count()];
                    markWS.Организация org = new markWS.Организация();
                    markWS.ОтчетКМ report = new markWS.ОтчетКМ();
                    org.инн = Properties.Settings.Default.oINN;
                    object owner = Properties.Settings.Default.owINN;
                    List<object> list = new List<object>();
                    List<object> listKM = new List<object>();

                    for (int i = 0; i < codes.Count(); i++)
                    {
                        kmArr[i] = new markWS.СтрокаСтатусКМ();
                        kmArr[i].КМ = codes[i];
                        kmArr[i].ДатаПроизводства = Convert.ToDateTime(dates[i]);
                    }
                    list.Add(Properties.Settings.Default.wells);
                    list.Add(Properties.Settings.Default.certNumber);
                    list.Add(org);
                    list.Add(Properties.Settings.Default.employer);
                    list.Add(owner);
                    list.AddRange(kmArr.ToArray());
                    List<markWS.ItemsChoiceType1> choice = new List<markWS.ItemsChoiceType1>();

                    choice.Add(markWS.ItemsChoiceType1.НомерЛицензии);
                    choice.Add(markWS.ItemsChoiceType1.НомерСертификата);
                    choice.Add(markWS.ItemsChoiceType1.Организация);
                    choice.Add(markWS.ItemsChoiceType1.Ответственный);
                    choice.Add(markWS.ItemsChoiceType1.Собственник);
                    for (int i = 0; i < codes.Count(); i++)
                    {
                        choice.Add(markWS.ItemsChoiceType1.Строки);
                    }
                    report.ItemsElementName = choice.ToArray();
                    report.Items = list.ToArray();


                    reportResult = ws.ОтчетПоИспользованиюКМ(report);
                        
                }
                catch
                {
                    reportResult = null;
                }
            }
        }
    }
////class API
////{
////    public static List<string> codes = new List<string>();
////    public static string reportId;
////    public static string docId;
////    public static List<string> appCodes = new List<string>();
////    public static List<string> appDates = new List<string>();
////    public static List<string> rejCodes = new List<string>();
////    public static List<string> orders = new List<string>();
////    public static List<string> gtins = new List<string>();
////    public static markWS.МассивКМ masKM = new markWS.МассивКМ();

////    markWS.homeportPortTypeClient ws;
////    public static markWS.РезультатОбработкиОтчетаКМ reportResult;
////    DataBase dB = new DataBase(Properties.Settings.Default.host, Properties.Settings.Default.port, Properties.Settings.Default.database, Properties.Settings.Default.user, Properties.Settings.Default.password);





////}

