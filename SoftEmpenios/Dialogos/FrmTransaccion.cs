using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;
using SoftEmpenios.LogicaNegocios;

namespace SoftEmpenios.Dialogos
{
    public partial class FrmTransaccion : XtraForm
    {
        public FrmTransaccion()
        {
            InitializeComponent();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsVerificarCaja.CajaEstado())
                {
                    if ((int)txtCLave.EditValue == 0)
                    {
                        Transaccione tran = new Transaccione
                        {
                            CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioAPP")),
                            FechaTransaccion = DateTime.Today.Date,
                            TipoTransaccion = cboTipo.Text,
                            Cantidad = Convert.ToDecimal(txtCantidad.EditValue),
                            Concepto = txtConcepto.Text,
                            Estado = true
                        };
                        
                        txtCLave.EditValue = new LogicaTransacciones().AgregarTransaccion(tran);
                    }
                    ImprimirTikets();
                    new ManejadorControles().LimpiarControles(gpoContenedor);
                    txtCantidad.Focus();
                }
                else
                {
                    MessageBox.Show("La Caja del Día de hoy ya se ha cerrado\n SISTEMA BLOQUEADO", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show( ex.Message,"Validando datos");

            }
            catch (SqlException ex)
            {
                MessageBox.Show( ex.Message,"Ocurrió un error al querer realizar la transaccion");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocurrió un error al querer realizar el transaccion" );

            }
        }

        private void ImprimirTikets()
        {
            Configuracione empre = new EmpeñosDC(new clsConeccionDB().StringConn()).Configuraciones.First();

            string empresa = new clsModificarConfiguracion().configGetValue("Empresa");
            string razonSocial = new clsModificarConfiguracion().configGetValue("RazonSocial");
            string rfc = new clsModificarConfiguracion().configGetValue("RFC");
            string curp = new clsModificarConfiguracion().configGetValue("CURP");
            string dirc = String.Format("{0} CP {1} {2}", empre.Direccion, empre.CodigoPostal,empre.Municipio);
            
            int padRe = ((40 - empresa.Length) / 2) + empresa.Length;
            int padRrs = ((40 - razonSocial.Length) / 2) + razonSocial.Length;
            int padRrfc = ((40 - rfc.Length) / 2) + rfc.Length;
            int padRcurp = ((40 - curp.Length) / 2) + curp.Length;
            

            Ticket ticket = new Ticket(2);
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
            ticket.AddHeaderLine("           TICKET DE " + cboTipo.Text.ToUpper());

            ticket.AddSubHeaderLine("CLAVE: " + txtCLave.Text);
            ticket.AddSubHeaderLine("REALIZO: " + new clsModificarConfiguracion().configGetValue("UsuarioAPP"));
            ticket.AddSubHeaderLine(String.Format("FECHA: {0} {1}", DateTime.Today.ToString("dd/MMM/yyyy").ToUpper(), DateTime.Now.ToShortTimeString()));
            string[] lineas = txtConcepto.Text.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var linea in lineas )
            {
                ticket.AddItem("", linea, "");
            }
            //ticket.AddItem("", txtConcepto.Text, "");
            ticket.AddTotal("CANTIDAD:", Convert.ToDecimal(txtCantidad.EditValue).ToString("$ #,##0.00"));
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("________________________________________");
            ticket.AddFooterLine("                AUTORIZO                ");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");

            ticket.PrintTicket(new clsModificarConfiguracion().configGetValue("ImpresoraTickets"));
        }
    }
}