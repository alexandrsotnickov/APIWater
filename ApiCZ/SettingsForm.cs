using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiCZ
{
    public partial class SettingsForm : Form
    {
        Point lastPoint;
        Parser prs = new Parser();
        public SettingsForm()
        {
            InitializeComponent();

            path1cTexbox.Text = Properties.Settings.Default.path1C;
            pathDb1CTextBox.Text = Properties.Settings.Default.pathDb1C;
            login1cTextBox.Text = Properties.Settings.Default.login1C;
            password1cTextBox.Text = Properties.Settings.Default.password1C;
            hostTextBox.Text = Properties.Settings.Default.host;
            portTextBox.Text = Properties.Settings.Default.port;
            dbTextBox.Text = Properties.Settings.Default.database;
            userTextBox.Text = Properties.Settings.Default.user;
            passwordTextBox.Text = Properties.Settings.Default.password;
            if(Properties.Settings.Default.orgInn != null)
                innOrgTextBox.Text = prs.DeParseSettings(Properties.Settings.Default.orgInn);
            if (Properties.Settings.Default.ownerInn != null)
                ownerInnTextBox.Text = prs.DeParseSettings(Properties.Settings.Default.ownerInn);
            
            certOfConfTextBox.Text = Properties.Settings.Default.certNumber;
            wellTextBox.Text = Properties.Settings.Default.wells;
            empTextBox.Text = Properties.Settings.Default.employer;
            Properties.Settings.Default.Save();
        }


        private void timerToken_Tick(object sender, EventArgs e)
        {
            innOrgTextBox.Text= SelectCertForm.token;
            
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            if (hostTextBox.Text != "" && portTextBox.Text != "" && dbTextBox.Text != "" && userTextBox.Text != "" && innOrgTextBox.Text != "" && ownerInnTextBox.Text != "" && empTextBox.Text != "")
            {
                //Properties.Settings.Default.kpp = kppTextBox.Text;
                //Properties.Settings.Default.fias = fiasTextBox.Text;
                Properties.Settings.Default.orgInn = prs.ParserSettings(innOrgTextBox.Text);
                Properties.Settings.Default.ownerInn = prs.ParserSettings(ownerInnTextBox.Text);
                Properties.Settings.Default.certNumber = certOfConfTextBox.Text;
                Properties.Settings.Default.wells = wellTextBox.Text;
                Properties.Settings.Default.employer = empTextBox.Text;

                Properties.Settings.Default.host = hostTextBox.Text;
                Properties.Settings.Default.port = portTextBox.Text;
                Properties.Settings.Default.database = dbTextBox.Text;
                Properties.Settings.Default.user = userTextBox.Text;
                Properties.Settings.Default.password = passwordTextBox.Text;

                Properties.Settings.Default.path1C = path1cTexbox.Text;
                Properties.Settings.Default.pathDb1C = pathDb1CTextBox.Text;
                Properties.Settings.Default.login1C = login1cTextBox.Text;
                Properties.Settings.Default.password1C = password1cTextBox.Text;

                //Properties.Settings.Default.producerInn = producerInnTextBox.Text;
                //Properties.Settings.Default.ownerInn = ownerInnTextBox.Text;
                //Properties.Settings.Default.inn = innTextBox.Text;
                //Properties.Settings.Default.gln = GLNTextBox.Text;
                //Properties.Settings.Default.token = tokenTextBox.Text;
                //Properties.Settings.Default.idConn = idConnTextBox.Text;
                //Properties.Settings.Default.omsID = idOMSTextBox.Text;
                //Properties.Settings.Default.urlServer = serverTextBox.Text;
                //Properties.Settings.Default.urlSUZ = serverSUZTextBox.Text;
                Properties.Settings.Default.Save();

                errorLabel.ForeColor = Color.FromArgb(7, 80, 157);
                errorLabel.Text = "Настройки успешно обновлены.";
                this.Close();
            }
            else
            {
                errorLabel.ForeColor = Color.Red;
                errorLabel.Text = "Введите все параметры";
            }
            
            
        }

        private void closeButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.Image = Properties.Resources.close_icon;
        }

        private void closeButton_MouseMove(object sender, MouseEventArgs e)
        {
            closeButton.Image = Properties.Resources.close_icon2;
        }

        private void tableLayoutPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void tableLayoutPanel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
