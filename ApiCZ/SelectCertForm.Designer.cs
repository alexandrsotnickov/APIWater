namespace ApiCZ
{
    partial class SelectCertForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectCertForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.certListBox = new System.Windows.Forms.ListBox();
            this.cancelButton = new ApiCZ.Controls.RoundButton();
            this.enterButton = new ApiCZ.Controls.RoundButton();
            this.topPanel = new System.Windows.Forms.TableLayoutPanel();
            this.closeButton = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.933718F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.4366F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.37342F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.192564F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.693367F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.4366F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.933718F));
            this.tableLayoutPanel1.Controls.Add(this.cancelButton, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.certListBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.enterButton, 5, 6);
            this.tableLayoutPanel1.Controls.Add(this.topPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.121265F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.451045F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.91829F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.451045F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.751565F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.751868F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // certListBox
            // 
            this.certListBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.certListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.certListBox, 5);
            this.certListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.certListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.certListBox.ForeColor = System.Drawing.Color.MidnightBlue;
            this.certListBox.FormattingEnabled = true;
            this.certListBox.ItemHeight = 20;
            this.certListBox.Location = new System.Drawing.Point(18, 115);
            this.certListBox.Name = "certListBox";
            this.certListBox.Size = new System.Drawing.Size(760, 261);
            this.certListBox.TabIndex = 3;
            this.certListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.certListBox_DrawItem);
            // 
            // cancelButton
            // 
            this.cancelButton.borderColor = System.Drawing.Color.Black;
            this.cancelButton.borderSize = 2;
            this.cancelButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.cancelButton.dialogResult = System.Windows.Forms.DialogResult.None;
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cancelButton.Icon = ((System.Drawing.Image)(resources.GetObject("cancelButton.Icon")));
            this.cancelButton.Location = new System.Drawing.Point(18, 389);
            this.cancelButton.mainBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.onHover = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(178)))));
            this.cancelButton.rounded = true;
            this.cancelButton.rounding = 40;
            this.cancelButton.Size = new System.Drawing.Size(125, 48);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Назад";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // enterButton
            // 
            this.enterButton.borderColor = System.Drawing.Color.Black;
            this.enterButton.borderSize = 2;
            this.enterButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.enterButton.dialogResult = System.Windows.Forms.DialogResult.None;
            this.enterButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enterButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.enterButton.Icon = ((System.Drawing.Image)(resources.GetObject("enterButton.Icon")));
            this.enterButton.Location = new System.Drawing.Point(653, 389);
            this.enterButton.mainBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.enterButton.Name = "enterButton";
            this.enterButton.onHover = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(100)))), ((int)(((byte)(178)))));
            this.enterButton.rounded = true;
            this.enterButton.rounding = 40;
            this.enterButton.Size = new System.Drawing.Size(125, 48);
            this.enterButton.TabIndex = 4;
            this.enterButton.Text = "ОК";
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.topPanel.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.topPanel, 7);
            this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 93.45088F));
            this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.549119F));
            this.topPanel.Controls.Add(this.closeButton, 1, 0);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(3, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.RowCount = 1;
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.topPanel.Size = new System.Drawing.Size(794, 35);
            this.topPanel.TabIndex = 6;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            // 
            // closeButton
            // 
            this.closeButton.Image = global::ApiCZ.Properties.Resources.close_icon;
            this.closeButton.Location = new System.Drawing.Point(745, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(46, 29);
            this.closeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeButton.TabIndex = 0;
            this.closeButton.TabStop = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            this.closeButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.closeButton_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(149, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(498, 49);
            this.label1.TabIndex = 7;
            this.label1.Text = "Выберите сертификат CryptoPro:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectCertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectCertForm";
            this.Text = "SelectCertForm";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox certListBox;
        private Controls.RoundButton enterButton;
        private Controls.RoundButton cancelButton;
        private System.Windows.Forms.TableLayoutPanel topPanel;
        private System.Windows.Forms.PictureBox closeButton;
        private System.Windows.Forms.Label label1;
        //private Controls.RoundBut enterButton;
    }
}