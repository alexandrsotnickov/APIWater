using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiCZ
{
    public partial class GenForm : Form
    {

       
        //API api = new API();
        public GenForm()
        {
            if (Properties.Settings.Default.path1C != "" && Application.OpenForms.Count == 0)
            {
                ProcessStartInfo start = new ProcessStartInfo(Properties.Settings.Default.path1C);
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                start.RedirectStandardError = true;
                start.Arguments = "ENTERPRISE /F " + Properties.Settings.Default.pathDb1C + " /N " + Properties.Settings.Default.login1C + " /P " + Properties.Settings.Default.password1C;
                start.CreateNoWindow = true;
                Process process = Process.Start(start);
                process.WaitForExit();
                process.Close();
                process.Dispose();
            }

            InitializeComponent();
            
            ////string d = Properties.Settings.Default.port;
            //DataBase dB = new DataBase(Properties.Settings.Default.host, Properties.Settings.Default.port, Properties.Settings.Default.database, Properties.Settings.Default.user, Properties.Settings.Default.password);
            if (Properties.Settings.Default.host == "" || Properties.Settings.Default.port == "" || Properties.Settings.Default.database == "" || Properties.Settings.Default.user == "" || Properties.Settings.Default.orgInn == null || Properties.Settings.Default.ownerInn == null || Properties.Settings.Default.employer == "")
            {
                SettingsForm sf = new SettingsForm();
                sf.Show();
            }
            
        }

        private void orderButton_Click(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.host != "" && Properties.Settings.Default.port != "" && Properties.Settings.Default.database != "" && Properties.Settings.Default.user != "" && Properties.Settings.Default.orgInn != null && Properties.Settings.Default.ownerInn != null && Properties.Settings.Default.employer != "")
            {
               
                    NewOrderForm newOrderForm = new NewOrderForm();
                    newOrderForm.Show();
                    
                }
                else
                {
                    messageLabel.Text = "Вход невозможен. Введите все данные в настройках и повторите попытку";
                }
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            
            if (Properties.Settings.Default.host != "" && Properties.Settings.Default.port != "" && Properties.Settings.Default.database != "" && Properties.Settings.Default.user != "" && Properties.Settings.Default.orgInn != null && Properties.Settings.Default.ownerInn != null && Properties.Settings.Default.employer != "")
            {
                ReportForm rf = new ReportForm();
                    rf.Show();
                    this.Hide();
                }
                else
                {
                    messageLabel.Text = "Вход невозможен. Введите все данные в настройках и повторите попытку";
                }   
        }

        private void nameEditorButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.host != "" && Properties.Settings.Default.port != "" && Properties.Settings.Default.database != "" && Properties.Settings.Default.user != "" && Properties.Settings.Default.orgInn != null && Properties.Settings.Default.ownerInn != null && Properties.Settings.Default.employer != "")
            {
                NameEditor ne = new NameEditor();
                ne.Show();
                this.Hide();
            }
            else
            {
                messageLabel.Text = "Вход невозможен. Введите все данные в настройках и повторите попытку";
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.Show();
        }

        private void closeButton_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.Image = Properties.Resources.close_icon;
        }

        private void closeButton_MouseMove(object sender, MouseEventArgs e)
        {
            closeButton.Image = Properties.Resources.close_icon2;
        }

        private void hideButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void hideButton_MouseLeave(object sender, EventArgs e)
        {
            hideButton.Image = Properties.Resources.hide_icon;
        }

        private void hideButton_MouseMove(object sender, MouseEventArgs e)
        {
            hideButton.Image = Properties.Resources.hide_icon2;
        }

        private void GenForm_Load(object sender, EventArgs e)
        {
           
        }
    }
}
