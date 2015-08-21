using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using SoftEmpenios.Dialogos;
using SoftEmpenios.DBComun;
using SoftEmpenios.Clases;
using System.ComponentModel.DataAnnotations;
using SoftEmpenios.LogicaNegocios;

namespace SoftEmpenios.Pantallas
{
    public partial class FrmAbonosVenta : Form, iPantalla
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        readonly DataTable _artic = new DataTable("articulos");
        public FrmAbonosVenta()
        {
            InitializeComponent();
        }
        #region de comando de Herencia
        public bool ConfirmarCierre()
        {
            switch (MessageBox.Show("\x00bfHa realizado cambios sin Guardar?. \x00bfDesea guardarlas?", "Muebleria", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                case DialogResult.Yes:
                    Guardar();
                    return true;

                case DialogResult.No:
                    return true;
            }
            return false;
        }

        public void Refrescar()
        {
        }
        public void Buscar()
        {
            Nuevo();
            FrmBuscar cliente = new FrmBuscar();
            cliente.CriteriosDeBusqueda("Ventas");
            cliente.DevolverString += VentaDevuelta;
            cliente.ShowDialog(this);
            cliente.DevolverString -= VentaDevuelta;
            cliente.Close();
        }

        public void Eliminar()
        {
        }
        public void Guardar()
        {
            try
            {
                if (!ClsVerificarCaja.CajaEstado())
                {
                    MessageBox.Show("La Caja del Dia de hoy ya se ha cerrado\n SISTEMA BLOQUEADO", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                if ((int)txtCveAbono.EditValue == 0)
                {
                   
                    PagosVenta abono = new PagosVenta
                    {
                        CveVenta = Convert.ToInt32(txtCveVenta.EditValue),
                        Abono = Convert.ToDecimal(txtAbono.EditValue),
                        Saldo = Convert.ToDecimal(Convert.ToDecimal(txtSaldo.EditValue) - Convert.ToDecimal(txtAbono.EditValue)),
                        FechaPago = dtpFechaAbono.DateTime.Date,
                        Estado = true,
                        CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp")),
                    };
                    txtCveAbono.EditValue = new LogicaAbonosVentas().AgregarAbono(abono);
                    Venta venta = _entidades.Ventas.Single(v => v.Clave == Convert.ToInt32(txtCveVenta.EditValue));
                    if (abono.Saldo == 0)
                    {
                        foreach (DetalleVenta detVta in venta.DetalleVentas)
                        {
                            Articulo art = detVta.Articulo;
                            art.Estado = "Vendido";
                        }
                        venta.Estado = "Pagado";
                    }
                    _entidades.SubmitChanges();
                    ImprimirTicketsAbono();
                    new ManejadorControles().DesectivarTextBox(gpoContenedor, false);
                    var pagos = from p in _entidades.PagosVentas
                                where p.Estado && p.CveVenta == venta.Clave
                                select
                                    new
                                    {
                                        p.Clave,
                                        p.Abono,
                                        p.FechaPago,
                                        Registró = p.Usuario.Nombre
                                    };
                    gridAbonos.DataSource = pagos;

                }
                else if ((int)txtCveAbono.EditValue > 0)
                {
                    ImprimirTicketsAbono();
                }
            }
            catch (ValidationException vex)
            {
                XtraMessageBox.Show(vex.Message, "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Nuevo()
        {
            new ManejadorControles().LimpiarControles(gpoContenedor);
            new ManejadorControles().DesectivarTextBox(gpoContenedor, true);
            txtAbono.Focus();
            _artic.Rows.Clear();
            gridAbonos.DataSource = null;
            _entidades.Connection.ConnectionString = new clsConeccionDB().StringConn();
        }
        public void Paginar(int primerRegistro)
        {
            //throw new NotImplementedException();
        }
        public string nombrePantalla
        {
            get
            {
                return "Abono a Ventas";
            }
        }

        #endregion

        private void VentaDevuelta(string cveVenta)
        {
            _artic.Rows.Clear();
            Venta venta = _entidades.Ventas.Single(v => v.Clave == Convert.ToInt32(cveVenta));
            if (venta != null)
            {
                txtCveVenta.Text = venta.Clave.ToString();
                txtCliente.Text = venta.Cliente;
                dtpFechaVenta.EditValue = venta.FechaVenta;
                txtTotalVenta.EditValue = venta.TotalVenta;
                txtEnganche.EditValue = venta.Enganche;
                foreach (DetalleVenta detvent in venta.DetalleVentas)
                {
                    DataRow filaarticulos = _artic.NewRow();
                    filaarticulos[0] = detvent.CveArticulo;
                    filaarticulos[1] = detvent.Articulo.Descripcion;
                    filaarticulos[2] = detvent.Articulo.Peso;
                    filaarticulos[3] = detvent.Articulo.Kilates;
                    filaarticulos[4] = detvent.Articulo.PrecioCredito;
                    _artic.Rows.Add(filaarticulos);
                    
                }
                grvArticulos.Columns[0].AppearanceCell.TextOptions.HAlignment=HorzAlignment.Center;
                grvArticulos.Columns[0].Width = 80;
                grvArticulos.Columns[1].Width = 250;
                grvArticulos.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                grvArticulos.Columns[2].Width = 80;
                grvArticulos.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                grvArticulos.Columns[4].DisplayFormat.FormatType=FormatType.Numeric;
                grvArticulos.Columns[4].DisplayFormat.FormatString = "$ #,##0.00";
                var pagos = from p in _entidades.PagosVentas
                    where p.Estado && p.CveVenta == venta.Clave
                    select
                        new
                        {
                            p.Clave,
                            p.Abono,
                            p.FechaPago,
                            Registró = p.Usuario.Nombre
                        };
                gridAbonos.DataSource = pagos;
                grvAbonos.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                grvAbonos.Columns[0].Width = 80;
                grvAbonos.Columns[3].Width = 250;
                grvAbonos.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                grvAbonos.Columns[1].DisplayFormat.FormatType = FormatType.Numeric;
                grvAbonos.Columns[1].DisplayFormat.FormatString = "$ #,##0.00";
                grvAbonos.Columns[2].DisplayFormat.FormatType = FormatType.DateTime;
                grvAbonos.Columns[2].DisplayFormat.FormatString = "dd-MMM-yyyy";
                
                txtSaldo.EditValue = venta.Saldo - (pagos.Sum(a => (decimal?) a.Abono) ?? 0);
                switch (venta.Estado)
                {
                    case "Moroso":
                        XtraMessageBox.Show("La prenda apartada ya a sobrepasado los meses de vencimiento y se ha dado de baja", "Cliente Moroso");
                        botonGuardar.Enabled = false;
                        break;
                    case  "Pagado":
                        XtraMessageBox.Show("Esta Venta ya esta Pagada no se le puede aplicar pagos", "Venta Saldada");
                        botonGuardar.Enabled = false;
                        break;
                    default:
                        botonGuardar.Enabled = true;
                        break;
                }
            }
            
        }

        private void frmAbonosVenta_Shown(object sender, EventArgs e)
        {
            _artic.Columns.Add("Clave", Type.GetType("System.Int32"));
            _artic.Columns.Add("Descripción", Type.GetType("System.String"));//1
            _artic.Columns.Add("Peso", Type.GetType("System.Decimal"));//2
            _artic.Columns.Add("Tipo", Type.GetType("System.String"));//3
            _artic.Columns.Add("Precio", Type.GetType("System.Decimal"));//5
            gridArticulos.DataSource = _artic;
            Nuevo();
        }
        void ImprimirTicketsAbono()
        {
            _entidades.Connection.ConnectionString = new clsConeccionDB().StringConn();
            Configuracione empre = (from em in _entidades.Configuraciones
                                   select em).FirstOrDefault();

            string empresa = new clsModificarConfiguracion().configGetValue("Empresa");
            string razonSocial = new clsModificarConfiguracion().configGetValue("RazonSocial");
            string rfc = new clsModificarConfiguracion().configGetValue("RFC");
            string curp = new clsModificarConfiguracion().configGetValue("CURP");
            if (empre != null)
            {
                string dirc = String.Format("{0} CP {1}", empre.Direccion, empre.CodigoPostal);
                
                int padRe = ((40 - empresa.Length) / 2) + empresa.Length;
                int padRrs = ((40 - razonSocial.Length) / 2) + razonSocial.Length;
                int padRrfc = ((40 - rfc.Length) / 2) + rfc.Length;
                int padRcurp = ((40 - curp.Length) / 2) + curp.Length;
                

                Ticket ticket = new Ticket(1);
                ticket.AddHeaderLine("            CASA  DE  EMPEÑOS           ");
                ticket.AddHeaderLine("                                        ");
                ticket.AddHeaderLine(empresa.PadLeft(padRe));
                ticket.AddHeaderLine(razonSocial.PadLeft(padRrs));
                ticket.AddHeaderLine(rfc.PadLeft(padRrfc));
                ticket.AddHeaderLine(curp.PadLeft(padRcurp));
                if (dirc.Length > 40)
                {
                    int currentChar = 0;
                    int itemLenght = dirc.Length;

                    while (itemLenght > 40)
                    {
                        ticket.AddHeaderLine(dirc.Substring(currentChar, 40));
                        currentChar += 40;
                        itemLenght -= 40;
                    }
                    ticket.AddHeaderLine(dirc.Substring(currentChar));

                }
                else
                {
                    ticket.AddHeaderLine(dirc);
                }
                ticket.AddHeaderLine(empre.Municipio);
                ticket.AddHeaderLine("            TICKET DE ABONO              ");


                ticket.AddSubHeaderLine("CLAVE PAGO: # " + txtCveAbono.Text);
                ticket.AddSubHeaderLine("CLAVE VENTA: # " + txtCveVenta.Text);
                Usuario usu = _entidades.Usuarios.FirstOrDefault(u => u.CveUsuario == Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp")));
                if (usu != null) ticket.AddSubHeaderLine("ATENDIO: " + usu.Nombre);
                ticket.AddSubHeaderLine("CLIENTE: " + txtCliente.Text);
                ticket.AddSubHeaderLine("SALDO ANTERIOR: " + double.Parse(txtSaldo.EditValue.ToString()).ToString("C"));
                ticket.AddSubHeaderLine("ABONO: " + double.Parse(txtAbono.EditValue.ToString()).ToString("C"));
                ticket.AddSubHeaderLine(String.Format("Fecha: {0} {1}", DateTime.Today.ToString("dd/MMM/yyyy"), DateTime.Now.ToShortTimeString()));

                for (int x = 0; x < _artic.Rows.Count; x++)
                    ticket.AddItem(_artic.Rows[x][0].ToString(), _artic.Rows[x][1].ToString(), double.Parse(_artic.Rows[x][4].ToString()).ToString("C"));
                decimal saldo = Convert.ToDecimal(txtSaldo.EditValue) - Convert.ToDecimal(txtAbono.EditValue);
                ticket.AddTotal("SALDO ACTUAL", double.Parse(saldo.ToString()).ToString("C"));

                ticket.AddFooterLine("          GRACIAS POR SU PAGO            ");
                ticket.AddFooterLine("");
                ticket.AddFooterLine("");
                ticket.AddFooterLine("");
                ticket.AddFooterLine("");
                ticket.PrintTicket(new clsModificarConfiguracion().configGetValue("ImpresoraTickets"));
            }
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void botonNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnBuscarPrestamo_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
