using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ApiCZ
{
    public partial class NewOrderForm : Form
    {
        Point lastPoint;
        List<string> arr = new List<string>();
        List<string> info = new List<string>();
        List<string> orgInn = new List<string>();

        WebService1C ws1c = new WebService1C();
        
        DataBase dB = new DataBase(Properties.Settings.Default.host, Properties.Settings.Default.port, Properties.Settings.Default.database, Properties.Settings.Default.user, Properties.Settings.Default.password);
        markWS.РезультатОбработкиЗаказа result;
        markWS.РезультатОбработкиЗаказа result2;
        markWS.РезультатОбработкиЗаказа result3;
        markWS.РезультатОбработкиЗаказа result4;
        markWS.РезультатОбработкиЗаказа result5;

        markWS.СписокКМ poolKM;
        markWS.СписокКМ poolKM2;
        markWS.СписокКМ poolKM3;
        markWS.СписокКМ poolKM4;
        markWS.СписокКМ poolKM5;

        public NewOrderForm()
        {
           
            InitializeComponent();

            dB.SelectProd();
            //timer1.Enabled = true;
            if (Properties.Settings.Default.name.Count != 0)
            {
                codeProdCmBox.Enabled = true;
                codeProdCmBox2.Enabled = true;
                codeProdCmBox3.Enabled = true;
                codeProdCmBox4.Enabled = true;
                codeProdCmBox5.Enabled = true;


                for (int i = 0; i < Properties.Settings.Default.name.Count; i++)
                {
                   //System.Collections.Specialized.StringCollection count = Properties.Settings.Default.name;
                    info.Add(Properties.Settings.Default.gtin[i] + ", " + Properties.Settings.Default.name[i]);
                }

                codeProdCmBox.Items.AddRange(info.ToArray());
                codeProdCmBox2.Items.AddRange(info.ToArray());
                codeProdCmBox3.Items.AddRange(info.ToArray());
                codeProdCmBox4.Items.AddRange(info.ToArray());
                codeProdCmBox5.Items.AddRange(info.ToArray());
                foreach(string s in Properties.Settings.Default.orgInn)
                {
                    orgInn.Add(s);
                }
                innCmBox.Items.AddRange(orgInn.ToArray());
            }
            else
            {
                codeProdCmBox.Enabled = false;
                codeProdCmBox2.Enabled = false;
                codeProdCmBox3.Enabled = false;
                codeProdCmBox4.Enabled = false;
                codeProdCmBox5.Enabled = false;
            }
            innCmBox.SelectedIndex = 0;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

        }

        private void orderButton_Click(object sender, EventArgs e)
        {

            int indexItem = codeProdCmBox.SelectedIndex;
            int indexItem2 = codeProdCmBox2.SelectedIndex;
            int indexItem3 = codeProdCmBox3.SelectedIndex;
            int indexItem4 = codeProdCmBox4.SelectedIndex;
            int indexItem5 = codeProdCmBox5.SelectedIndex;
            int indexInn = innCmBox.SelectedIndex;
            bool check = true;
           

            if ((quantityTextBox.Text != "" && indexItem != -1) || (quantityTextBox2.Text != "" && indexItem2 != -1) || (quantityTextBox3.Text != "" && indexItem3 != -1) || (quantityTextBox4.Text != "" && indexItem4 != -1) || (quantityTextBox5.Text != "" && indexItem5 != -1))
            {
                try
                {
                    if (indexItem != -1 && quantityTextBox.Text != "")
                    {
                        if (Convert.ToInt64(quantityTextBox.Text) <= 100000)
                        {
                            
                            result = ws1c.OrderCodes(Properties.Settings.Default.gtin[indexItem], quantityTextBox.Text, Properties.Settings.Default.orgInn[indexInn]);
                            timer1.Interval = Convert.ToInt16(result.ОжидаемоеВремяВыполнения) * 1000;
                            timer1.Enabled = true;
                            errorLabel.Text = "";
                        }
                        else
                        {
                            errorLabel.Text = "Количество КМ в одном заказе должно быть меньше 100 000!";
                            check = false;
                        }
                    }

                    if (indexItem2 != -1 && quantityTextBox2.Text != "")
                    {
                        if (Convert.ToInt64(quantityTextBox2.Text) <= 100000)
                        {
                            result2 = ws1c.OrderCodes(Properties.Settings.Default.gtin[indexItem2], quantityTextBox2.Text, Properties.Settings.Default.orgInn[indexInn]);
                            timer2.Interval = Convert.ToInt16(result2.ОжидаемоеВремяВыполнения) * 1000;
                            timer2.Enabled = true;
                            errorLabel.Text = "";
                        }
                        else
                        {
                            errorLabel.Text = "Количество КМ в одном заказе должно быть меньше 100 000!";
                            check = false;
                        }
                    }
                    if (indexItem3 != -1 && quantityTextBox3.Text != "")
                    {
                        if (Convert.ToInt64(quantityTextBox3.Text) <= 100000)
                         {
                            result3 = ws1c.OrderCodes(Properties.Settings.Default.gtin[indexItem3], quantityTextBox3.Text, Properties.Settings.Default.orgInn[indexInn]);
                            timer3.Interval = Convert.ToInt16(result3.ОжидаемоеВремяВыполнения) * 1000;
                            timer3.Enabled = true;
                            errorLabel.Text = "";
                        }
                        else
                        {
                            errorLabel.Text = "Количество КМ в одном заказе должно быть меньше 100 000!";
                            check = false;
                        }
                    }

                     if (indexItem4 != -1 && quantityTextBox4.Text != "")
                     {
                        if (Convert.ToInt64(quantityTextBox4.Text) <= 100000)
                        {
                            result4 = ws1c.OrderCodes(Properties.Settings.Default.gtin[indexItem4], quantityTextBox4.Text, Properties.Settings.Default.orgInn[indexInn]);
                            timer4.Interval = Convert.ToInt16(result4.ОжидаемоеВремяВыполнения) * 1000;
                            timer4.Enabled = true;
                            errorLabel.Text = "";
                        }
                        else
                        {
                            errorLabel.Text = "Количество КМ в одном заказе должно быть меньше 100 000!";
                            check = false;
                        }
                    }

                    if (indexItem5 != -1 && quantityTextBox5.Text != "")
                    {
                        if (Convert.ToInt64(quantityTextBox5.Text) <= 100000)
                        {
                            result5 = ws1c.OrderCodes(Properties.Settings.Default.gtin[indexItem5], quantityTextBox5.Text, Properties.Settings.Default.orgInn[indexInn]);
                            timer5.Interval = Convert.ToInt16(result5.ОжидаемоеВремяВыполнения) * 1000;
                            timer5.Enabled = true;
                            errorLabel.Text = "";
                        }
                        else
                        {
                            errorLabel.Text = "Количество КМ в одном заказе должно быть меньше 100 000!";
                            check = false;
                        }
                    }
                    if (check)
                    {
                        MessageWindow msg = new MessageWindow("Заказы созданы\r\nЧерез некоторое время они будут загружены в БД", false);
                        msg.Show();
                    }
                    }
                 catch
                 {
                    MessageWindow msg = new MessageWindow("Произошла ошибка заказа кодов. Повторите попытку.", true);
                    msg.Show();
                 }
                //OrderForm.endCheck2 = true;
                if (check)
                {
                    this.Hide();
                }
                
            }
            else
            {
                errorLabel.Text = "Заполните хотя бы один заказ, чтобы отправить его";
            }
            }
        
        public void GetCodes()
        {
            poolKM = ws1c.GetCodes(result);
            if (poolKM.Items.Length - 3 > 0 && poolKM != null)
            {
                dB.UploadKMToDB(poolKM);
                
                timer1.Enabled = false;
            }
            else
            {
                timer1.Interval = 30000;
            }
            
        }

        public void GetCodes2()
        {
            poolKM2 = ws1c.GetCodes(result2);
            if (poolKM2.Items.Length - 3 > 0 && poolKM2 != null)
            {
                dB.UploadKMToDB(poolKM2);
                timer2.Enabled = false;
            }
            else
            {
                timer2.Interval = 30000;
            }
            
        }

        public void GetCodes3()
        {
            poolKM3 = ws1c.GetCodes(result3);
            if (poolKM3.Items.Length - 3 > 0  && poolKM3 != null)
            {
                dB.UploadKMToDB(poolKM3);
                timer3.Enabled = false;
            }
            else
            {
                timer3.Interval = 30000;
            }
            
        }

        public void GetCodes4()
        {
            poolKM4 = ws1c.GetCodes(result4);
            if (poolKM4.Items.Length - 3 > 0  && poolKM4 != null)
            {
                dB.UploadKMToDB(poolKM4);
                timer4.Enabled = false;
            }
            else
            {
                timer4.Interval = 30000;
            }
        }
        public void GetCodes5()
        {
            poolKM5 = ws1c.GetCodes(result5 );
            if (poolKM5.Items.Length - 3 > 0 && poolKM5 != null)
            {
                dB.UploadKMToDB(poolKM5);
                timer5.Enabled = false;
            }
            else
            {
                timer5.Interval = 30000;
            }
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void closeButton_MouseMove(object sender, MouseEventArgs e)
        {
            closeButton.Image = Properties.Resources.close_icon2;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.Image = Properties.Resources.close_icon;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        //private void innTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    Properties.Settings.Default.inn = innTextBox.Text;
        //    Properties.Settings.Default.Save();
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetCodes();
            //Thread myThread = new Thread(GetCodes);
            //myThread.Start();
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            GetCodes2();
            //Thread myThread2 = new Thread(GetCodes2);
            //myThread2.Start();

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            GetCodes3();
            //Thread myThread3 = new Thread(GetCodes3);
            //myThread3.Start();

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            GetCodes4();
            //Thread myThread4 = new Thread(GetCodes4);
            //myThread4.Start();

        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            GetCodes5();
            //Thread myThread5 = new Thread(GetCodes5);
            //myThread5.Start();
        }

    
    }
}
