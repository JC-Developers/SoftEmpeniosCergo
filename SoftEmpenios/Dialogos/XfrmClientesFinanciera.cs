using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;
using SoftEmpenios.LogicaNegocios;

namespace SoftEmpenios.Dialogos
{
    public partial class XfrmClientesFinanciera : DevExpress.XtraEditors.XtraForm
    {
         readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
         public event EventDevolverClave EventDevolverClave;
        public XfrmClientesFinanciera()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscar buscRef = new FrmBuscar();
            buscRef.CriteriosDeBusqueda("ClientesFinanciera");
            buscRef.DevolverString += ClienteDevuelto;
            buscRef.ShowDialog(this);
            buscRef.DevolverString += ClienteDevuelto;
            buscRef.Close();
        }
        public void ClienteDevuelto(string clave)
        {
            FinancieraCliente cli = _entidades.FinancieraClientes.First(cl => cl.Clave ==Convert.ToInt32( clave));
            txtCveCliente.EditValue = cli.Clave;
            txtNombre.EditValue = cli.Nombre;
            txtDireccion.EditValue = cli.Domicilio;
            txtPoblacion.EditValue = cli.Poblacion;
            txtTelefono.EditValue = cli.Telefono;
            txtCelular.EditValue = cli.Celular;
            rgpoEstadoCivil.EditValue = cli.EstadoCivil;
            txtIngresos.EditValue = cli.Ingresos;
            txtConyuge.EditValue = cli.Conyuge;
            txtIngresos.EditValue = cli.IngresosConyuge;
            txtCelularConyuge.EditValue = cli.CelularConyuge;
            
            new ManejadorControles().DesectivarTextBox(gpoContenedor,true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((int) txtCveCliente.EditValue == 0)
                {
                    FinancieraCliente clie = new FinancieraCliente
                    {
                        Nombre = txtNombre.Text,
                        Ingresos = Convert.ToDecimal( txtIngresos.EditValue),
                        Domicilio = txtDireccion.Text,
                        Poblacion = txtPoblacion.Text,
                        Telefono = txtTelefono.Text,
                        Celular = txtCelular.Text,
                        EstadoCivil = rgpoEstadoCivil.EditValue.ToString(),
                        Conyuge = txtConyuge.Text,
                        IngresosConyuge = Convert.ToDecimal( txtIngresosConyuge.EditValue),
                        CelularConyuge = txtCelularConyuge.Text,
                        FechaModificacion = DateTime.Today.Date,
                    };
                    txtCveCliente.EditValue = new LogicaClientes().AgregarClienteFinanciera(clie);
                    EventDevolverClave(Convert.ToInt32(txtCveCliente.EditValue));
                }
                else
                {
                    FinancieraCliente cliMod =
                        _entidades.FinancieraClientes.First(c => c.Clave == Convert.ToInt32(txtCveCliente.EditValue));
                    FinancieraCliente clie = new FinancieraCliente
                    {
                        Clave = cliMod.Clave,
                        Nombre = txtNombre.Text,
                        Ingresos= Convert.ToDecimal( txtIngresos.EditValue),
                        Domicilio = txtDireccion.Text,
                        Poblacion = txtPoblacion.Text,
                        Telefono = txtTelefono.Text,
                        Celular = txtCelular.Text,
                        EstadoCivil = rgpoEstadoCivil.EditValue.ToString(),
                        Conyuge = txtConyuge.Text,
                        IngresosConyuge = Convert.ToDecimal( txtIngresosConyuge.EditValue),
                        CelularConyuge = txtCelularConyuge.Text,
                        FechaModificacion = DateTime.Today.Date,
                    };
                    new LogicaClientes().ModificarClienteFinanciera(clie,cliMod);

                    if (EventDevolverClave != null) EventDevolverClave(cliMod.Clave);
                }
                Close();
            }
            catch (ValidationException vex)
            {
                XtraMessageBox.Show(vex.Message, "Validando Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new ManejadorControles().LimpiarControles(gpoContenedor);
        }
    }
}