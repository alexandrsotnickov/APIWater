using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiCZ
{
    public partial class ReportForm : Form
    {

        //Tuple<string, string, bool> repStatusResponse;
        markWS.СтатусВводаВОборот repStatusResponseCirc;
        WebService1C webs = new WebService1C();
        DataBase dB = new DataBase(Properties.Settings.Default.host, Properties.Settings.Default.port, Properties.Settings.Default.database, Properties.Settings.Default.user, Properties.Settings.Default.password);
        List<string> info = new List<string>();
        List<string> quantity = new List<string>();
        public int countTickTimer = 0;
        public ReportForm()
        {
 
            InitializeComponent();
            WebService1C.reportResult = new markWS.РезультатОбработкиОтчетаКМ();
            WebService1C.codes.Clear();
            checkTimer.Enabled = false;
            nameProdCmBox.Items.Clear();
            info.Clear();
            //api.ProductSearch();

            for (int i = 0; i < Properties.Settings.Default.name.Count; i++)
            {
                info.Add(Properties.Settings.Default.gtin[i] + ", " + Properties.Settings.Default.name[i]);
            }

            if (info.Count() != 0)
            {
                nameProdCmBox.Enabled = true;
                nameProdCmBox.Items.AddRange(info.ToArray());
                nameProdCmBox.SelectedIndex = 0;
            }
            else
            {
                nameProdCmBox.Enabled = false;
            }

            int indexItem = nameProdCmBox.SelectedIndex;
            if (indexItem != -1)
            {
                try
                {
                    quantity = dB.GetQuantityFromDB(Properties.Settings.Default.gtin[indexItem], dateTimePicker.Value);
                    //sQuantityLabel.Text = quantity[0];
                    circulationLabel.Text = quantity[0];
                }
                catch
                {
                    MessageWindow msg = new MessageWindow("Нет связи с БД. Проверьте подключение и повторите попытку.", 1);
                    msg.Show();
                    GenForm gf = new GenForm();
                    gf.Show();
                    this.Hide();
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GenForm gf = new GenForm();
            gf.Show();
            this.Hide();
        }
        private void updateSynchButton_Click(object sender, EventArgs e)
        {
            int indexItem = nameProdCmBox.SelectedIndex;
            if (indexItem != -1)
            {
                try
                {
                    quantity = dB.GetQuantityFromDB(Properties.Settings.Default.gtin[indexItem], dateTimePicker.Value);
                    circulationLabel.Text = quantity[0];
                }
                catch
                {
                    MessageWindow msg = new MessageWindow("Нет связи с БД. Проверьте подключение и повторите попытку.", 1);
                    msg.Show();
                    GenForm gf = new GenForm();
                    gf.Show();
                    this.Close();
                }
            }

            
            
        }

       

        private void putCircButton_Click(object sender, EventArgs e)
        {
            int indexItem = nameProdCmBox.SelectedIndex;
            if (indexItem != -1)
            {
                try
                {
                    quantity = dB.GetQuantityFromDB(Properties.Settings.Default.gtin[indexItem], dateTimePicker.Value);
                    circulationLabel.Text = quantity[0];

                    if (quantity[0] != "0")
                    {
                        errorLabel.Text = "";
                        DocumentWindowWater dww = new DocumentWindowWater();
                        dww.Show();
                        checkTimer.Enabled = true;
                    }
                    else
                        errorLabel.Text = "Нет готовых для ввода в оборот КМ выбранной продукции за это число";
                }
                catch
                {
                    MessageWindow msg = new MessageWindow("Нет связи с БД. Проверьте подключение и повторите попытку.", 1);
                    msg.Show();
                    GenForm gf = new GenForm();
                    gf.Show();
                    this.Close();
                }
            }
           
           
        }

   

        private void putCircTimer_Tick(object sender, EventArgs e)
        {
            countTickTimer++;
            if (WebService1C.reportResult != null)
            {
                repStatusResponseCirc = webs.ReportStatusCirc();
                if (repStatusResponseCirc.Статус == "[CHECKED_OK] Обработан")
                {
                    putCircTimer.Enabled = false;
                    //this.Enabled = true;
                    updateSynchButton.Enabled = true;
                    backButton.Enabled = true;
                    closeButton.Enabled = true;
                    putCircButton.Enabled = true;
                    nameProdCmBox.Enabled = true;
                    dateTimePicker.Enabled = true;
                    putCircButton.Text = "Ввести коды в оборот";
                    putCircButton.ButtonColor = Color.FromArgb(15, 100, 178);
                    int indexItem = nameProdCmBox.SelectedIndex;
                    dB.UpdateStatusCirc(Properties.Settings.Default.gtin[indexItem], dateTimePicker.Value);

                    if (indexItem != -1)
                    {
                        try
                        {
                            quantity = dB.GetQuantityFromDB(Properties.Settings.Default.gtin[indexItem], dateTimePicker.Value);
                            //sQuantityLabel.Text = quantity[0];
                            circulationLabel.Text = quantity[0];
                        }
                        catch
                        {
                            MessageWindow msg = new MessageWindow("Нет связи с БД. Проверьте подключение и повторите попытку.", 1);
                            msg.Show();
                            GenForm gf = new GenForm();
                            gf.Show();
                            this.Close();
                        }
                    }

                    MessageWindow msg2 = new MessageWindow("Коды успешно введены в оборот! ReportId: " + WebService1C.reportResult.Items[2], 3);
                    msg2.Show();
                    //ReportForm rf = new ReportForm();
                    //rf.Show();
                    //this.Close();
                }
                else if (repStatusResponseCirc.Статус == "[CHECKED_NOT_OK] Обработан с ошибками")
                {
                    putCircTimer.Enabled = false;
                    putCircButton.Enabled = true;
                    updateSynchButton.Enabled = true;
                    backButton.Enabled = true;
                    closeButton.Enabled = true;
                    nameProdCmBox.Enabled = true;
                    dateTimePicker.Enabled = true;
                    //this.Enabled = true;
                    putCircButton.Text = "Ввести коды в оборот";
                    putCircButton.ButtonColor = Color.FromArgb(15, 100, 178);
                    int indexItem = nameProdCmBox.SelectedIndex;
                    dB.UpdateStatusCirc(Properties.Settings.Default.gtin[indexItem], dateTimePicker.Value);

                    if (indexItem != -1)
                    {
                        try
                        {
                            quantity = dB.GetQuantityFromDB(Properties.Settings.Default.gtin[indexItem], dateTimePicker.Value);
                            //sQuantityLabel.Text = quantity[0];
                            circulationLabel.Text = quantity[0];
                        }
                        catch
                        {
                            MessageWindow msg = new MessageWindow("Нет связи с БД. Проверьте подключение и повторите попытку.", 1);
                            msg.Show();
                            GenForm gf = new GenForm();
                            gf.Show();
                            this.Close();
                        }
                    }
                    MessageWindow msg2 = new MessageWindow("Ошибка отправки отчета:" + repStatusResponseCirc.Комментарий + "Исправьте все ошибки и произведите повторную отправку отчёта в 1С", 1);
                    msg2.Show();
                }
                else if (countTickTimer == 20)
                {
                    putCircTimer.Enabled = false;
                    putCircButton.Enabled = true;
                    updateSynchButton.Enabled = true;
                    backButton.Enabled = true;
                    closeButton.Enabled = true;
                    nameProdCmBox.Enabled = true;
                    dateTimePicker.Enabled = true;
                    //this.Enabled = true;
                    putCircButton.Text = "Ввести коды в оборот";
                    putCircButton.ButtonColor = Color.FromArgb(15, 100, 178);
                    countTickTimer = 0;
                    int indexItem = nameProdCmBox.SelectedIndex;
                    dB.UpdateStatusCirc(Properties.Settings.Default.gtin[indexItem], dateTimePicker.Value);

                    if (indexItem != -1)
                    {
                        try
                        {
                            quantity = dB.GetQuantityFromDB(Properties.Settings.Default.gtin[indexItem], dateTimePicker.Value);
                            //sQuantityLabel.Text = quantity[0];
                            circulationLabel.Text = quantity[0];
                        }
                        catch
                        {
                            MessageWindow msg = new MessageWindow("Нет связи с БД. Проверьте подключение и повторите попытку.", 1);
                            msg.Show();
                            GenForm gf = new GenForm();
                            gf.Show();
                            this.Close();
                        }
                    }
                    MessageWindow msg2 = new MessageWindow("Предупреждение! Проверьте статус отчёта в 1С самостоятельно. При необходимости исправьте ошибки" , 2);
                    msg2.Show();
                }
                else if (repStatusResponseCirc == null)
                {
                    putCircTimer.Enabled = false;
                    //putCircButton.Enabled = true;
                    //this.Enabled = true;
                    updateSynchButton.Enabled = true;
                    backButton.Enabled = true;
                    closeButton.Enabled = true;
                    putCircButton.Enabled = true;
                    nameProdCmBox.Enabled = true;
                    dateTimePicker.Enabled = true;
                    putCircButton.Text = "Ввести коды в оборот";
                    putCircButton.ButtonColor = Color.FromArgb(15, 100, 178);
                    MessageWindow msg = new MessageWindow("Ошибка соединения с web-сервисом. Обратитесь к системному администратору", 1);
                    msg.Show();
                    //ReportForm rf = new ReportForm();
                    //rf.Show();
                    //this.Close();
                }
            }
            else
            {
                putCircTimer.Enabled = false;
                //putCircButton.Enabled = true;
                //this.Enabled = true;
                updateSynchButton.Enabled = true;
                backButton.Enabled = true;
                closeButton.Enabled = true;
                putCircButton.Enabled = true;
                nameProdCmBox.Enabled = true;
                dateTimePicker.Enabled = true;
                putCircButton.Text = "Ввести коды в оборот";
                putCircButton.ButtonColor = Color.FromArgb(15, 100, 178);
                MessageWindow msg = new MessageWindow("Ошибка соединения с web-сервисом. Обратитесь к системному администратору", 1);
                msg.Show();
                WebService1C.reportResult = new markWS.РезультатОбработкиОтчетаКМ();
                ReportForm rf = new ReportForm();
                rf.Show();
                this.Close();
            }
        }

        private void checkTimer_Tick(object sender, EventArgs e)
        {
            if(DocumentWindowWater.check == true)
            {
                checkTimer.Enabled = false;
                DocumentWindowWater.check = false;
                int indexItem = nameProdCmBox.SelectedIndex;
                if (indexItem != -1)
                {
                    webs.ReportCirc(Properties.Settings.Default.gtin[indexItem], dateTimePicker.Value);
                }

                //this.Enabled = false;
                updateSynchButton.Enabled = false;
                backButton.Enabled = false;
                closeButton.Enabled = false;
                putCircButton.Enabled = false;
                nameProdCmBox.Enabled = false;
                dateTimePicker.Enabled = false;
                putCircButton.ButtonColor = Color.Gray;
                putCircButton.Text = "Пожалуйста, подождите...";
                putCircTimer.Enabled = true;
            }
     
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            
            int indexItem = nameProdCmBox.SelectedIndex;
            if (indexItem != -1)
            {
                try
                {
                    quantity = dB.GetQuantityFromDB(Properties.Settings.Default.gtin[indexItem], dateTimePicker.Value);
                    //sQuantityLabel.Text = quantity[0];

                    circulationLabel.Text = quantity[0];
                }
                catch
                {
                    MessageWindow msg = new MessageWindow("Нет связи с БД. Проверьте подключение и повторите попытку.", 1);
                    msg.Show();
                    GenForm gf = new GenForm();
                    gf.Show();
                    this.Close();
                }
            }
             
            
        }

        private void nameProdCmBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexItem = nameProdCmBox.SelectedIndex;

            if (indexItem != -1)
            {
                try
                {
                    quantity = dB.GetQuantityFromDB(Properties.Settings.Default.gtin[indexItem], dateTimePicker.Value);
                    circulationLabel.Text = quantity[0];
                }
                catch
                {
                    MessageWindow msg = new MessageWindow("Нет связи с БД. Проверьте подключение и повторите попытку.", 1);
                    msg.Show();
                    GenForm gf = new GenForm();
                    gf.Show();
                    this.Close();
                }
            }
        }

        private void closeButton_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.Image = Properties.Resources.close_icon;
        }

        private void hideButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void hideButton_MouseLeave(object sender, EventArgs e)
        {
            hideButton.Image = Properties.Resources.hide_icon;
        }

        private void closeButton_MouseMove(object sender, MouseEventArgs e)
        {
            closeButton.Image = Properties.Resources.close_icon2;
        }

        private void hideButton_MouseMove(object sender, MouseEventArgs e)
        {
            hideButton.Image = Properties.Resources.hide_icon2;
        }
    }
}
