using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CasaEmpeñosprt.Controles
{
    public delegate void BotonClickedEventHandler(int botonIndex);

    public partial class PanelBotones : UserControl
    {
        public event BotonClickedEventHandler BotonClicked;


        public PanelBotones()
        {
            InitializeComponent();
        }
        private void btn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if ((button.Tag != null) && (button.Checked && (this.BotonClicked != null)))
            {
                int botonIndex = int.Parse(button.Tag.ToString());
                this.BotonClicked(botonIndex);
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                Graphics graphics = e.Graphics;
                Rectangle clientRectangle = base.ClientRectangle;
                Color color = Color.FromArgb(255, 230, 0);
                Color color2 = Color.FromArgb(247, 174, 0);
                //Color color = Color.FromArgb(0xff, 230, 0);
                //Color color2 = Color.FromArgb(0xf7, 0xae, 0);

                using (LinearGradientBrush brush = new LinearGradientBrush(clientRectangle, color, color2, LinearGradientMode.Vertical))
                {
                    graphics.FillRectangle(brush, clientRectangle);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


    }
}
