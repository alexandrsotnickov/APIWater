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
    public partial class SelectCertForm : Form
    {
        public static string token;
        Point lastPoint;
        CSP csp = new CSP();
        API api = new API();
        Tuple<List<string>, List<string>> data;
       

        public SelectCertForm()
        {
            CSP csp = new CSP();
            API api = new API();
            
            InitializeComponent();
            data = csp.GetCertInfo();
            certListBox.Items.AddRange(data.Item1.ToArray());

        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            string cert = null;
            int indexItem = certListBox.SelectedIndex;
            Properties.Settings.Default.noTrimCert = data.Item2[indexItem];
            token = api.Token().Item1;
            cert = data.Item1[indexItem];

            int indexOfSubstring = cert.IndexOf("\"\"");

            if (indexOfSubstring != -1)
            {
                cert = cert.Substring(indexOfSubstring + 2);
                cert = cert.Substring(0, cert.Length - 3);
            }
           
            Properties.Settings.Default.cert = cert;
            Properties.Settings.Default.token = token;
            Properties.Settings.Default.Save();
           
            MessageWindow msg = new MessageWindow("OMS ID : " + ConfigurationManager.AppSettings.Get("omsID") + "\r\nУстановлено соединение с СУЗ", false);
            msg.Show();
            this.Hide();
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void closeButton_Click(object sender, EventArgs e)
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

        private void certListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.MidnightBlue);//Choose the color

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Draw the current item text
            e.Graphics.DrawString(certListBox.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }
    }
}
