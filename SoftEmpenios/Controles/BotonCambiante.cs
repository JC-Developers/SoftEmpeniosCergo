using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SoftEmpenios.Controles
{
    public partial class BotonCambiante : Button
    {
        private Image _press; //Imagen a mostrar cuando se ha precionado nuestro control
        private Image _over; //Imagen a mostrar cuando el puntero del mouse esta encima del control
        private Image _normal; //Imagen a mostrar cuando nuestro control esta en estado normal
        private Image _Desabilitado; //Imagen a mostrar cuando nuestro control esta deshabilitado
        private readonly ToolTip etiquetaInteligente = new ToolTip(); //Etiqueta a mostrar cuando esta selecionado el control
        private string _etiqueta = "Etiqueta del boton";
        public BotonCambiante()
        {
            InitializeComponent();
        }
        #region agregar cuatro propiedades de tipo imagen a control y etiqueta inteligente

            [Category("Mis Propiedades")]
            [Description("Etiqueta Inteligente a mostrar al Pasar el Mouse en el control")]
            public String EtiquetaBoton
            {
                get { return _etiqueta; }
                set { _etiqueta = value; }
            }
            [Category("Mis Propiedades")]
            [Description("Imagen A mostrar al Precionar el control")]
            public Image imgPrecionado
            {
                get { return _press; }
                set { _press = value; }
            }
            [Category("Mis Propiedades")]
            [Description("Imagen cuando el mouse esta en el area del control")]
            public Image imgencima
            {
                get { return _over; }
                set { _over = value; }
            }
            [Category("Mis Propiedades")]
            [Description("Imagen cuando el control estado en un estado normal")]
            public Image imgnormal
            {
                get { return _normal; }
                set { _normal = value; }
            }
            [Category("Mis Propiedades")]
            [Description("Imagen a mostrar cuando el control esta desahabilitado")]
            public Image imgDisable
            {
                get { return _Desabilitado; }
                set { _Desabilitado = value; }
            }
        #endregion

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }
        protected override void OnClick(EventArgs e)
        {
            //sobreescribir el metodo
            //para que cuando se de clik
            //sobre el control cambie de imagen
            base.Image = imgPrecionado;
            base.OnClick(e);
        }
        protected override void OnMouseHover(EventArgs e)
        {

            //sobreescribir el metodo
            //para que cuando el puntero del
            //mouse pase sobre el control
            //la imagen cambie y tambien
            //se muestre nuestra propiedad
            //creada de etiqueta inteligente
            base.Image = imgencima;
            etiquetaInteligente.SetToolTip(this, EtiquetaBoton);
            base.OnMouseHover(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            /*sobrescribimos el metodo cuando
            * el puntero del mouse deja el
            * control y nuestro control
            * regresa a tener la imagen que
            * tendra en estado normal
            */
            base.Image = imgnormal;
            base.OnMouseLeave(e);
        }
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.Image = imgPrecionado;
            base.OnMouseDown(mevent);
        }
        protected override void OnCreateControl()
        {
            //esta se ha modificado por
            //conveniencia y para especificar
            //algunas caracteristicas por default
            //que tendra el control
            base.OnCreateControl();
            base.Image = imgnormal;
            base.FlatStyle = FlatStyle.Flat;
            base.FlatAppearance.MouseDownBackColor = Color.Transparent;
            base.FlatAppearance.MouseOverBackColor = Color.Transparent;
            base.FlatAppearance.BorderSize = 0;
            //base.Text = "NombreBoton";
            base.TextAlign = ContentAlignment.BottomCenter;
            base.ImageAlign = ContentAlignment.TopCenter;
            //base.Height = 40;
            //base.Width = 40;
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            /*sobrescribimos el metodo
            * cuando nuestro control
            * esta en estado desactivado
            * es decir cuando la propiedad
            * enable=false y cambie de imagen
            * a mostrar y cuando la propiedad
            * en cuestion se true la imagen
            * a mostrar se la del estado normal
            */
            base.OnEnabledChanged(e);
            if (base.Enabled)
                base.Image = imgnormal;
            else
                base.Image = imgDisable;

        }

    }
}
