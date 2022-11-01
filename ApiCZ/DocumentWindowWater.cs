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
    public partial class DocumentWindowWater : Form
    {
        public static bool check = false;
        List<string> orgInn = new List<string>();
        List<string> ownerInn = new List<string>();
        Point lastPoint;
        public DocumentWindowWater()
        {
            InitializeComponent();
           
            //certNumberTextBox.Text = Properties.Settings.Default.certNumbers;
            //dateCertPicker.Value = Properties.Settings.Default.certDate;
            //wellTextBox.Text = Properties.Settings.Default.wells;
            foreach (string s in Properties.Settings.Default.orgInn)
            {
                orgInn.Add(s);
            }
            innOrgCmBox.Items.AddRange(orgInn.ToArray());
            foreach (string s in Properties.Settings.Default.ownerInn)
            {
                ownerInn.Add(s);
            }
             innOwnerCmbBox.Items.AddRange(ownerInn.ToArray());
            innOrgCmBox.SelectedIndex = 0;
            innOwnerCmbBox.SelectedIndex = 0;
        }

        private void uploadCircutton_Click(object sender, EventArgs e)
        {
            if (innOrgCmBox.SelectedIndex != -1 && innOwnerCmbBox.SelectedIndex != -1)
            {
                this.Hide();
                //Properties.Settings.Default.certNumbers = certNumberTextBox.Text;
                Properties.Settings.Default.owINN = Properties.Settings.Default.ownerInn[innOwnerCmbBox.SelectedIndex];
                Properties.Settings.Default.oINN = Properties.Settings.Default.orgInn[innOrgCmBox.SelectedIndex];
                check = true;
            }
            else
            {
                errorLabel.Text = "Введите все параметры и повторите попытку";
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

        private void closeButton_Click(object sender, EventArgs e)
        {

        }
    }
}
