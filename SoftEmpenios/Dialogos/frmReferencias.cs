using System;
using System.Linq;
using System.Windows.Forms;
using SoftEmpenios.DBComun;
using SoftEmpenios.Clases;

namespace SoftEmpenios.Dialogos
{
    public delegate void EventDevolverClave(int clave);
    public partial class FrmReferencias : Form
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        public event EventDevolverClave EventDevolverClave;
        public FrmReferencias()
        {
            InitializeComponent();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((int)txtCveCliente.EditValue == 0)
                {
                    Referencia refe = new Referencia
                    {
                        Nombre = txtNombre.Text,
                        Direccion = txtDireccion.Text,
                        Poblacion = txtPoblacion.Text,
                        Telefono = txtTelefono.Text,
                        Celular = txtCelular.Text
                    };
                    _entidades.Referencias.InsertOnSubmit(refe);
                    _entidades.SubmitChanges();
                    txtCveCliente.EditValue = refe.CveReferencia;
                    EventDevolverClave(refe.CveReferencia);
                }
                else
                {
                    Referencia refe = _entidades.Referencias.Single(cl => cl.CveReferencia == (int)txtCveCliente.EditValue);
                    refe.Nombre = txtNombre.Text;
                    refe.Direccion = txtDireccion.Text;
                    refe.Poblacion = txtPoblacion.Text;
                    refe.Telefono = txtTelefono.Text;
                    refe.Celular = txtCelular.Text;
                    _entidades.SubmitChanges();
                    EventDevolverClave(refe.CveReferencia);                    
                }                
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al intentar Guardar la referencia \n"+ ex, "Error al guardar");
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscar buscRef = new FrmBuscar();
            buscRef.CriteriosDeBusqueda("Referencias");
            buscRef.DevolverString += ReferenciaEncontrada;
            buscRef.ShowDialog(this);
            buscRef.DevolverString += ReferenciaEncontrada;
            buscRef.Close();
        }
        private void ReferenciaEncontrada(string clave)
        {
            Referencia refe = _entidades.Referencias.First(cl => cl.CveReferencia ==Convert.ToDecimal( clave));
            txtCveCliente.EditValue = refe.CveReferencia;
            txtNombre.EditValue = refe.Nombre;
            txtDireccion.EditValue = refe.Direccion;
            txtPoblacion.EditValue = refe.Poblacion;
            txtTelefono.EditValue = refe.Telefono;
            txtCelular.EditValue = refe.Celular;
            new ManejadorControles().DesectivarTextBox(gpoContenedor,true);
        }

        private void BotonNuevo_Click(object sender, EventArgs e)
        {
            new ManejadorControles().LimpiarControles(gpoContenedor);
        }

    }
}
