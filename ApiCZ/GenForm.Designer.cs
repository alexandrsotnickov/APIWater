namespace ApiCZ
{
    partial class GenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.orderButton = new ApiCZ.Controls.RoundButton();
            this.reportButton = new ApiCZ.Controls.RoundButton();
            this.messageLabel = new System.Windows.Forms.Label();
            this.nameEditorButton = new ApiCZ.Controls.RoundButton();
            this.settingsButton = new ApiCZ.Controls.RoundButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hideButton = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hideButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.25652F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.52412F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.434747F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.52563F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.25898F));
            this.tableLayoutPanel1.Controls.Add(this.orderButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.reportButton, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.messageLabel, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.nameEditorButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.settingsButton, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.733797F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.23898F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.50182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.81574F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.50182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.2644F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.943453F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // orderButton
            // 
            this.orderButton.borderColor = System.Drawing.Color.Black;
            this.orderButton.borderSize = 2;
            this.orderButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.orderButton.dialogResult = System.Windows.Forms.DialogResult.None;
            this.orderButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orderButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.orderButton.Icon = ((System.Drawing.Image)(resources.GetObject("orderButton.Icon")));
            this.orderButton.Location = new System.Drawing.Point(101, 105);
            this.orderButton.mainBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.orderButton.Name = "orderButton";
            this.orderButton.onHover = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(178)))));
            this.orderButton.rounded = true;
            this.orderButton.rounding = 40;
            this.orderButton.Size = new System.Drawing.Size(270, 95);
            this.orderButton.TabIndex = 12;
            this.orderButton.Text = "Заказ кодов";
            this.orderButton.Click += new System.EventHandler(this.orderButton_Click);
            // 
            // reportButton
            // 
            this.reportButton.borderColor = System.Drawing.Color.Black;
            this.reportButton.borderSize = 2;
            this.reportButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.reportButton.dialogResult = System.Windows.Forms.DialogResult.None;
            this.reportButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.reportButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.reportButton.Icon = ((System.Drawing.Image)(resources.GetObject("reportButton.Icon")));
            this.reportButton.Location = new System.Drawing.Point(428, 105);
            this.reportButton.mainBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.reportButton.Name = "reportButton";
            this.reportButton.onHover = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(178)))));
            this.reportButton.rounded = true;
            this.reportButton.rounding = 40;
            this.reportButton.Size = new System.Drawing.Size(270, 95);
            this.reportButton.TabIndex = 12;
            this.reportButton.Text = "Выгрузка отчётов в ЧЗ";
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.messageLabel, 3);
            this.messageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageLabel.ForeColor = System.Drawing.Color.Red;
            this.messageLabel.Location = new System.Drawing.Point(101, 334);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(597, 68);
            this.messageLabel.TabIndex = 14;
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameEditorButton
            // 
            this.nameEditorButton.borderColor = System.Drawing.Color.Black;
            this.nameEditorButton.borderSize = 2;
            this.nameEditorButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.nameEditorButton.dialogResult = System.Windows.Forms.DialogResult.None;
            this.nameEditorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameEditorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameEditorButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.nameEditorButton.Icon = ((System.Drawing.Image)(resources.GetObject("nameEditorButton.Icon")));
            this.nameEditorButton.Location = new System.Drawing.Point(101, 236);
            this.nameEditorButton.mainBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.nameEditorButton.Name = "nameEditorButton";
            this.nameEditorButton.onHover = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(178)))));
            this.nameEditorButton.rounded = true;
            this.nameEditorButton.rounding = 40;
            this.nameEditorButton.Size = new System.Drawing.Size(270, 95);
            this.nameEditorButton.TabIndex = 13;
            this.nameEditorButton.Text = "Редактор наименований";
            this.nameEditorButton.Click += new System.EventHandler(this.nameEditorButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.borderColor = System.Drawing.Color.Black;
            this.settingsButton.borderSize = 2;
            this.settingsButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.settingsButton.dialogResult = System.Windows.Forms.DialogResult.None;
            this.settingsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingsButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.settingsButton.Icon = ((System.Drawing.Image)(resources.GetObject("settingsButton.Icon")));
            this.settingsButton.Location = new System.Drawing.Point(428, 236);
            this.settingsButton.mainBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.onHover = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(178)))));
            this.settingsButton.rounded = true;
            this.settingsButton.rounding = 40;
            this.settingsButton.Size = new System.Drawing.Size(270, 95);
            this.settingsButton.TabIndex = 13;
            this.settingsButton.Text = "Настройки";
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 5);
            this.panel1.Controls.Add(this.hideButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 28);
            this.panel1.TabIndex = 15;
            // 
            // hideButton
            // 
            this.hideButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideButton.Image = global::ApiCZ.Properties.Resources.hide_icon;
            this.hideButton.Location = new System.Drawing.Point(719, 0);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(30, 28);
            this.hideButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hideButton.TabIndex = 3;
            this.hideButton.TabStop = false;
            this.hideButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hideButton_MouseDown);
            this.hideButton.MouseLeave += new System.EventHandler(this.hideButton_MouseLeave);
            this.hideButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.hideButton_MouseMove);
            // 
            // closeButton
            // 
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(749, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(45, 28);
            this.closeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeButton.TabIndex = 2;
            this.closeButton.TabStop = false;
            this.closeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.closeButton_MouseDown);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            this.closeButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.closeButton_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 5);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 405);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 42);
            this.panel2.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::ApiCZ.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(794, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // GenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GenForm";
            this.Text = "GenForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GenForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hideButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.RoundButton orderButton;
        private Controls.RoundButton reportButton;
        private Controls.RoundButton nameEditorButton;
        private System.Windows.Forms.Label messageLabel;
        private Controls.RoundButton settingsButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox closeButton;
        private System.Windows.Forms.PictureBox hideButton;
    }
}