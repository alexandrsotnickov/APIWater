using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiCZ.Controls
{
    public partial class RoundButton : Control
    {
        #region --Переменные--
        public Color mainBackColor { get; set; } = Color.DimGray;
        protected Pen borderPen = new Pen(Color.Black, 1);
        protected SolidBrush fontBrush = new SolidBrush(Color.Black);
        protected StringFormat stringFormat = new StringFormat();
        protected SolidBrush fillBrush = new SolidBrush(Color.Black);
        #endregion
        #region --Свойства--
        public Color borderColor { get; set; } = Color.Black;
        public int borderSize { get; set; } = 2;
        public Color onHover { get; set; } = Color.FromArgb(15, 100, 178);
        public DialogResult dialogResult { get; set; }
        public bool rounded { get; set; } = false;
        public int rounding { get; set; } = 50;
        public Image Icon { get; set; } = Properties.Resources._null;
        public Color ButtonColor { get; set; } = Color.DimGray;
        #endregion
        public RoundButton()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            this.DoubleBuffered = true;
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            fillBrush.Color = this.ButtonColor;
            fontBrush.Color = this.ForeColor;
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            mainBackColor = ButtonColor;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            fillBrush.Color = this.ButtonColor;
            Graphics graph = e.Graphics;
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            RectangleF rect = e.ClipRectangle;
            rect.X = rect.X + this.Margin.All;
            rect.Y = rect.Y + this.Margin.All;
            rect.Height = rect.Height - this.Margin.All * 2;
            rect.Width = rect.Width - this.Margin.All * 2;
            RectangleF rectNow = rect;

            try
            {
                if (!rounded)
                    throw new Exception();
                RectangleF ellRect = new RectangleF(rect.X, rect.Y, rounding * rect.Height / 100, rounding * rect.Height / 100);
                graph.FillEllipse(fillBrush, ellRect);
                ellRect.X += rect.Width - rounding * rect.Height / 100;
                graph.FillEllipse(fillBrush, ellRect);
                ellRect.Y += rect.Height - rounding * rect.Height / 100;
                graph.FillEllipse(fillBrush, ellRect);
                ellRect.X = rect.X;
                graph.FillEllipse(fillBrush, ellRect);
                rect.Width -= rounding * rect.Height / 100;
                rect.X += rounding * rect.Height / 200;
                graph.FillRectangle(fillBrush, rect);
                rect.Width += rounding * rect.Height / 100;
                rect.X -= rounding * rect.Height / 200;
                rect.Y += rounding * rect.Height / 200;
                rect.Height -= rounding * rect.Height / 100;
                graph.FillRectangle(fillBrush, rect);
                if (borderSize > 0)
                {
                    rect = rectNow;
                    borderPen.Color = borderColor;
                    borderPen.Width = borderSize;
                    rect.X = rect.X + borderSize / 2;
                    rect.Y = -1 + rect.Y + borderSize / 2;
                    rect.Width = 1 + rect.Width - borderSize;
                    rect.Height = 1 + rect.Height - borderSize;
                    graph.DrawLine(borderPen, rect.X + rounding * rect.Height / 200, rect.Y, rect.X + rect.Width - rounding * rect.Height / 200, rect.Y);
                    graph.DrawLine(borderPen, rect.X + rect.Width, rect.Y + rounding * rect.Height / 200, rect.X + rect.Width, rect.Y + rect.Height - rounding * rect.Height / 200);
                    graph.DrawLine(borderPen, rect.X + rect.Width - rounding * rect.Height / 200, rect.Height + rect.Y, rect.X + rounding * rect.Height / 200, rect.Height + rect.Y);
                    graph.DrawLine(borderPen, rect.X, rect.Y + rounding * rect.Height / 200, rect.X, rect.Y + rect.Height - rounding * rect.Height / 200);
                    RectangleF pieRect = new RectangleF(rect.X, rect.Y, rounding * rect.Height / 100, rounding * rect.Height / 100);
                    graph.DrawArc(borderPen, pieRect, -90, -90);
                    pieRect.X += rect.Width - rounding * rect.Height / 100;
                    graph.DrawArc(borderPen, pieRect, 0, -90);
                    pieRect.Y += rect.Height - rounding * rect.Height / 100;
                    graph.DrawArc(borderPen, pieRect, 0, 90);
                    pieRect.X = rect.X;
                    graph.DrawArc(borderPen, pieRect, -180, -90);
                }
            }
            catch
            {
                graph.FillRectangle(fillBrush, rectNow);
                if (borderSize > 0)
                {
                    borderPen.Color = borderColor;
                    borderPen.Width = borderSize;
                    rect.X = rect.X + borderSize / 2;
                    rect.Y = rect.Y + borderSize / 2;
                    rect.Width = rect.Width - borderSize;
                    rect.Height = rect.Height - borderSize;
                    RectangleF[] rectangleFs = { rect };
                    graph.DrawRectangles(borderPen, rectangleFs);
                }
            }
            graph.DrawImage(Icon, 7 * this.Size.Width / 100, 20 * this.Size.Height / 100, 25, 25);
            graph.DrawString(this.Text, this.Font, fontBrush, rectNow, stringFormat);
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            ButtonColor = onHover;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            ButtonColor = mainBackColor;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Margin = this.Margin + new System.Windows.Forms.Padding(1);
            ButtonColor = mainBackColor;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.Margin = this.Margin - new System.Windows.Forms.Padding(1);
            ButtonColor = onHover;
            Invalidate();
        }
        protected override void Dispose(bool disposing)
        {
            stringFormat.Dispose();
            fontBrush.Dispose();
            borderPen.Dispose();
            fillBrush.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RoundBut
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(80)))), ((int)(((byte)(158)))));
            this.ResumeLayout(false);

        }
    }
}
