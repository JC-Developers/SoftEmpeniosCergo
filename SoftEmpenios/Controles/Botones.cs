using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CasaEmpeñosprt.Controles
{
    public partial class Botones : RadioButton
    {
        private bool _isMouseOver;
        private bool _lineaInferior;

        public Botones()
        {
            InitializeComponent();
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Cursor = Cursors.Hand;

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics graphics = pe.Graphics;
            Rectangle clientRectangle = base.ClientRectangle;
            Color color = Color.FromArgb(227, 239, 255);
            Color color2 = Color.FromArgb(196, 221, 255);
            Color color3 = Color.FromArgb(173, 209, 255);
            Color color4 = Color.FromArgb(192, 219, 255);
            if (base.Checked)
            {
                color = Color.FromArgb(255, 217, 170);
                color2 = Color.FromArgb(255, 187, 110);
                color3 = Color.FromArgb(255, 171, 63);
                color4 = Color.FromArgb(254, 225, 122);
            }
            else if (this._isMouseOver)
            {
                color = Color.FromArgb(255, 254, 228);
                color2 = Color.FromArgb(255, 232, 167);
                color3 = Color.FromArgb(255, 215, 103);
                color4 = Color.FromArgb(255, 230, 158);
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(clientRectangle, color, color3, LinearGradientMode.Vertical))
            {
                ColorBlend blend = new ColorBlend();
                blend.Colors = new Color[] { color, color2, color3, color4 };
                blend.Positions = new float[] { 0, .38f, .39f, 1 };
                brush.InterpolationColors = blend;
                graphics.FillRectangle(brush, clientRectangle);
            }
            using (Pen pen = new Pen(Color.FromArgb(101, 147, 207), 1))
            {
                graphics.DrawLine(pen, clientRectangle.X, clientRectangle.Y, clientRectangle.Width - 1, clientRectangle.Y);
                if (this._lineaInferior)
                {
                    graphics.DrawLine(pen, clientRectangle.X, (clientRectangle.Y + clientRectangle.Height) - 1, clientRectangle.Width - 1, (clientRectangle.Y + clientRectangle.Height) - 1);
                }
                graphics.DrawLine(pen, clientRectangle.X, clientRectangle.Y, clientRectangle.X, (clientRectangle.Y + clientRectangle.Height) - 1);
                graphics.DrawLine(pen, clientRectangle.Width - 1, clientRectangle.Y, clientRectangle.Width - 1, (clientRectangle.Y + clientRectangle.Height) - 1);
            }
            if (base.Image != null)
            {
                Rectangle destRect = new Rectangle(0, 0, base.Image.Width, base.Image.Height);
                destRect.X = (clientRectangle.Width - destRect.Width) / 2;
                destRect.Y = (clientRectangle.Height - base.Image.Height) / 2;
                graphics.DrawImage(base.Image, destRect, new Rectangle(0, 0, base.Image.Width, base.Image.Height), GraphicsUnit.Pixel);
            }
            using (SolidBrush brush2 = new SolidBrush(this.ForeColor))
            {
                SizeF ef = graphics.MeasureString(this.Text, this.Font);
                RectangleF layoutRectangle = new RectangleF();
                layoutRectangle.X = (clientRectangle.Width - ef.Width) / 2f;
                layoutRectangle.Y = (clientRectangle.Height - ef.Height) / 2f;
                if (base.Image != null)
                {
                    layoutRectangle.Y = base.Image.Height + 30;
                }
                layoutRectangle.Width = clientRectangle.Width - layoutRectangle.X;
                layoutRectangle.Height = ef.Height;
                StringFormat format = new StringFormat(StringFormatFlags.NoClip);
                format.Trimming = StringTrimming.EllipsisCharacter;
                graphics.DrawString(this.Text, this.Font, brush2, layoutRectangle, format);
            }

        }
        

        protected override void OnMouseEnter(EventArgs eventargs)
        {
            base.OnMouseEnter(eventargs);
            this._isMouseOver = true;
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            base.OnMouseLeave(eventargs);
            this._isMouseOver = false;
        }
        // Properties
        [Category("Appearance")]
        public bool LineaInferior
        {
            get
            {
                return this._lineaInferior;
            }
            set
            {
                this._lineaInferior = value;
            }
        }




    }
}
