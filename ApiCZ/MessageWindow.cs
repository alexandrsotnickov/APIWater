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
    public partial class MessageWindow : Form
    {
        Point lastPoint;
        public MessageWindow(string message, int errorOrMessage)
        {
            
            InitializeComponent();
            messageLabel.Text = message;

            if (errorOrMessage == 1)
            {
                topPanel.BackColor = Color.Red;
                enterButton.ButtonColor = Color.Gray;
                enterButton.onHover = Color.DimGray;
                messageLabel.ForeColor = Color.Gray;
            }
            else if (errorOrMessage == 2)
            {
                topPanel.BackColor = Color.Yellow;
                enterButton.ButtonColor = Color.Gray;
                enterButton.onHover = Color.DimGray;
                messageLabel.ForeColor = Color.Gray;
            }
         
        }

        private void enterButton_Click(object sender, EventArgs e)
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
    }
}
