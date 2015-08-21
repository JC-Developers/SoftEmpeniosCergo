using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using SoftEmpenios.DBComun;
using SoftEmpenios.Clases;
using System.Data.SqlClient;

namespace SoftEmpenios.Dialogos
{
    public partial class FrmCancelaciones : Form
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
       
        public FrmCancelaciones()
        {
            InitializeComponent();
        }
        private void CancelarDesempeño()
        {
            Desempeño entity = (from de in _entidades.Desempeños
                                where de.Clave == Convert.ToInt32(grvDatos.GetFocusedRowCellDisplayText("Clave"))
                                select de).Single();
            if (MessageBox.Show(String.Format("Si Cancela el desempeño la boleta quedara Vigente \n SE CANCELARA EL DESEMPEÑO {0}\nConfirme Cancelacion", grvDatos.GetFocusedRowCellDisplayText("Clave")), "Confirmar Cancelacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Boleta boletas = _entidades.Boletas.First(bol => bol.Folio == grvDatos.GetFocusedRowCellDisplayText("FolioBoleta"));
                boletas.EstadoBoleta = "Vigente";
                boletas.Pagado = false;
                entity.Estado = false;
                _entidades.SubmitChanges();
                Insertarcancelacion("Desempeño", grvDatos.GetFocusedRowCellDisplayText("Clave"));
                
               
            }
        }

        private void CancelarPagoFinanciamiento()
        {
            PagosFinanciamiento pago = _entidades.PagosFinanciamientos.Single(p => p.Clave == Convert.ToInt32(grvDatos.GetFocusedRowCellDisplayText("Clave")));
            pago.Estado = false;
            _entidades.SubmitChanges();
            Insertarcancelacion("Pago " + pago.Prestamo.Tipo, pago.Clave.ToString());
            
               ModificarSaldoFinanciamiento(pago.CvePrestamo, (pago.Cantidad + pago.AbonoPrestamo));
        }
        private void ModificarSaldoFinanciamiento(int cveprestamo, decimal totaldescontar)
        {
            Prestamo prs = _entidades.Prestamos.FirstOrDefault(p => p.Clave == cveprestamo);
            if (prs != null)
            {
                prs.Saldo = prs.Saldo + totaldescontar;
                prs.Estado = "Vigente";
            }
            _entidades.SubmitChanges();
        }
        private void CancelarFinanciamiento()
        {
            Prestamo finan = _entidades.Prestamos.SingleOrDefault(f => f.Clave == Convert.ToInt32(grvDatos.GetFocusedRowCellDisplayText("Clave")));
            if (finan != null) finan.Estado = "Cancelado";

            _entidades.SubmitChanges();
            if (finan != null) Insertarcancelacion(finan.Tipo, finan.FolioFinanciamiento.ToString());
            
        }
        private void CancelarTransaccion()
        {
            Transaccione tran = _entidades.Transacciones.First(t => t.Clave == Convert.ToInt32(grvDatos.GetFocusedRowCellDisplayText("Clave")));
            tran.Estado = false;
            _entidades.SubmitChanges();
            Insertarcancelacion("Transaccion", tran.Clave.ToString());
            
        }
        private void CancelarEmpeño()
        {
            Boleta entity = _entidades.Boletas.First(bol => bol.Folio == grvDatos.GetFocusedRowCellDisplayText("Folio"));
            if ((from pag in _entidades.PagosInteres
                 where pag.FolioBoleta == grvDatos.GetFocusedRowCellDisplayText("Folio")
                 select pag).Any())
            {
                if (MessageBox.Show("La boleta contiene Pagos ya registrados \n Confirme Cancelacion", "Confirmar Cancelacion", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //mapeoCasaEmpenios.BoletasDC.DeleteOnSubmit(entity);
                    entity.EstadoBoleta = "Cancelado";
                    _entidades.SubmitChanges();
                    Insertarcancelacion("Empeño", grvDatos.GetFocusedRowCellDisplayText("Folio"));
                   
                    
                }
            }
            else
            {
             
                entity.EstadoBoleta = "Cancelado";
                _entidades.SubmitChanges();
                Insertarcancelacion("Empeño", grvDatos.GetFocusedRowCellDisplayText("Folio"));
                
            }
        }
        private void CancelarVenta()
        {
            Venta entity = _entidades.Ventas.First(pi => pi.Clave == Convert.ToInt32(grvDatos.GetFocusedRowCellDisplayText("Clave")));
            entity.Estado = "Cancelado";//mapeoCasaEmpenios.PagosVentas.DeleteOnSubmit(entity);
            _entidades.SubmitChanges();
            Insertarcancelacion("Venta", grvDatos.GetFocusedRowCellDisplayText("Clave"));
           
            
            foreach (DetalleVenta detvent in entity.DetalleVentas)
            {
                Articulo art = _entidades.Articulos.Single(a=>a.Clave== detvent.CveArticulo);
                art.Estado = "Disponible";
            }
            _entidades.SubmitChanges();
        }
        private void CancelarPagoInteres()
        {
            PagosIntere entity = _entidades.PagosInteres.First(pi => pi.Clave == Convert.ToInt32(grvDatos.GetFocusedRowCellDisplayText("Clave")));
            //mapeoCasaEmpenios.PagosInteresDC.DeleteOnSubmit(entity);
            entity.Estado = false;
            _entidades.SubmitChanges();
            Insertarcancelacion("PagoInteres", grvDatos.GetFocusedRowCellDisplayText("Clave"));
            
            
        }
        private void CancelarPagoVenta()
        {
            PagosVenta entity = _entidades.PagosVentas.First(pi => pi.Clave == Convert.ToInt32(grvDatos.GetFocusedRowCellDisplayText("Clave")));
            entity.Estado = false;//mapeoCasaEmpenios.PagosVentas.DeleteOnSubmit(entity);
            _entidades.SubmitChanges();
            Insertarcancelacion("PagoVenta", grvDatos.GetFocusedRowCellDisplayText("Clave"));
            
        }
        private void CancelarCompras()
        {
            Compra com = _entidades.Compras.First(co => co.CveCompra == Convert.ToInt32(grvDatos.GetFocusedRowCellDisplayText("Clave")));
            com.Estado = false;
            _entidades.SubmitChanges();
            Insertarcancelacion("Compras", grvDatos.GetFocusedRowCellDisplayText("Clave"));
            
        }
        private void Insertarcancelacion(string tipo, string folio)
        {
            try
            {
                if (!ClsVerificarCaja.CajaEstado())
                {
                    MessageBox.Show("La Caja del Dia de hoy ya se ha cerrado\n SISTEMA BLOQUEADO", "Caja Cerrada",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                Cancelacione canc = new Cancelacione
                    {
                        CveCancelada = folio,
                        FechaCancelacion = DateTime.Today.Date,
                        TipoCancelacion = tipo,
                        CajeroCancelo = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp"))
                    };
                _entidades.Cancelaciones.InsertOnSubmit(canc);
                _entidades.SubmitChanges();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar la cancelacion");
            }


        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ClsVerificarCaja.CajaEstado())
            {
                MessageBox.Show("La Caja del Dia de hoy ya se ha cerrado\n SISTEMA BLOQUEADO", "Caja Cerrada",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            switch (cboTipoCancelacion.SelectedIndex)
            {
                case 0:
                    CancelarEmpeño();

                    break;

                case 1:
                    CancelarPagoInteres();

                    break;

                case 2:
                    CancelarDesempeño();

                    break;
                case 3:
                    CancelarCompras();

                    break;
                case 4: case 5:
                    CancelarTransaccion();
                    break;

                case 6:
                    CancelarVenta();
                    break;
                case 7:
                    CancelarPagoVenta();
                    break;
                case 8:
                    CancelarFinanciamiento();
                    break;
                case 9:
                    CancelarPagoFinanciamiento();
                    break;
                case 10:
                    CancelarCredito();
                    break;
                case 11:
                    CancelarPagosCredito();
                    break;
            }
            cboTipoCancelacion_SelectedIndexChanged(null, null);
        }

        private void CancelarPagosCredito()
        {
            FinancieraPago pcredito =
                _entidades.FinancieraPagos.First(
                    cre => cre.Clave == Convert.ToInt32(grvDatos.GetFocusedRowCellDisplayText("Clave")));
            pcredito.Estado = false;
            //_entidades.SubmitChanges();
            FinancieraCredito credito =
                _entidades.FinancieraCreditos.First(
                    cre => cre.Clave == pcredito.CveCredito);
            credito.SaldoActual=credito.SaldoActual+pcredito.Pago;
            credito.Estado = "Activo";
            FinancieraGrupo grupo = _entidades.FinancieraGrupos.Single(fg => fg.Clave == credito.CveGrupo);
            grupo.Estado = "ACTIVO";
            _entidades.SubmitChanges();
            Insertarcancelacion("Pagos Credito", grvDatos.GetFocusedRowCellDisplayText("Clave"));
        }

        private void CancelarCredito()
        {
            FinancieraCredito credito =
                _entidades.FinancieraCreditos.First(
                    cre => cre.Clave == Convert.ToInt32(grvDatos.GetFocusedRowCellDisplayText("Clave")));
            credito.Estado = "Cancelado";
            FinancieraGrupo grupo = _entidades.FinancieraGrupos.Single(c => c.Clave == credito.CveGrupo);
            grupo.Estado = "INACTIVO";
            _entidades.SubmitChanges();
            
            Insertarcancelacion("Crédito", grvDatos.GetFocusedRowCellDisplayText("Clave"));
        }

        private void cboTipoCancelacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            grvDatos.Columns.Clear();
            grvDatos.OptionsView.ColumnAutoWidth = false;
            if (cboTipoCancelacion.SelectedIndex >= 0)
            {
                switch (cboTipoCancelacion.SelectedIndex)
                {
                    case 0:
                        {
                            var queryable = from em in _entidades.Boletas
                                            where em.EstadoBoleta == "Vigente"
                                            orderby em.Folio descending
                                            select new { em.Folio, em.Cliente, em.FechaPrestamo, em.Articulos, em.TipoEmpeño, Peso = em.PesoEmpeño, em.Prestamo, em.Interes };
                            gridDatos.DataSource = queryable;
                            grvDatos.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[1].Width = 200;
                            grvDatos.Columns[3].Width = 200;
                            grvDatos.Columns[2].DisplayFormat.FormatType = FormatType.DateTime;
                            grvDatos.Columns[2].DisplayFormat.FormatString = "dd-MMM-yyyy";
                            grvDatos.Columns[6].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[6].DisplayFormat.FormatString = "c2";
                            grvDatos.Columns[7].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[7].DisplayFormat.FormatString = "c2";
                            break;

                        }
                    case 1:
                        {
                            var queryable2 = from pi in _entidades.PagosInteres
                                             where pi.Estado
                                             orderby pi.Clave descending
                                             select new {pi.Clave, pi.FolioBoleta, pi.Boleta.Cliente, pi.FechaPago, pi.Interes, pi.Recargos, pi.TotalPagar };
                            gridDatos.DataSource = queryable2;
                            grvDatos.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[1].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[2].Width = 200;
                            grvDatos.Columns[3].DisplayFormat.FormatType = FormatType.DateTime;
                            grvDatos.Columns[3].DisplayFormat.FormatString = "dd-MMM-yyyy";
                            grvDatos.Columns[6].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[6].DisplayFormat.FormatString = "c2";
                            grvDatos.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[5].DisplayFormat.FormatString = "c2";
                            grvDatos.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[4].DisplayFormat.FormatString = "c2";
                            break;
                        }
                    case 2:
                        {
                            var queryable3 = from de in _entidades.Desempeños
                                             where de.Estado
                                             orderby de.Clave descending
                                             select new { de.Clave, de.FolioBoleta, de.Boleta.Cliente, de.FechaDesempeño, de.InteresTotal, de.Recargos, de.TotalPagar };
                            gridDatos.DataSource = queryable3;
                            grvDatos.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[1].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[2].Width = 200;
                            grvDatos.Columns[3].DisplayFormat.FormatType = FormatType.DateTime;
                            grvDatos.Columns[3].DisplayFormat.FormatString = "dd-MMM-yyyy";
                            grvDatos.Columns[6].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[6].DisplayFormat.FormatString = "c2";
                            grvDatos.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[5].DisplayFormat.FormatString = "c2";
                            grvDatos.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[4].DisplayFormat.FormatString = "c2";

                            break;
                        }
                    case 3:
                        var query4 = from co in _entidades.Compras
                                     where co.Estado
                                     orderby co.CveCompra descending
                                     select new { Clave = co.CveCompra, co.FechaCompra, co.TotalCompra, Compro = co.Usuario.Nombre };
                        gridDatos.DataSource = query4;
                        grvDatos.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                        grvDatos.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                        grvDatos.Columns[1].DisplayFormat.FormatType = FormatType.DateTime;
                        grvDatos.Columns[1].DisplayFormat.FormatString = "dd-MMM-yyyy";
                        grvDatos.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
                        grvDatos.Columns[2].DisplayFormat.FormatString = "c2";
                        grvDatos.Columns[3].Width = 200;
                        grvDatos.OptionsView.ColumnAutoWidth = true;
                        //cancelaciones += 1;
                        break;
                    case 4:
                        {
                            var trans = from t in _entidades.Transacciones
                                        where t.Estado && t.TipoTransaccion == "Deposito" || t.TipoTransaccion == "Base"
                                        orderby t.FechaTransaccion descending
                                        select new { t.Clave, t.Concepto, t.Cantidad,t.FechaTransaccion,Registró =t.Usuario.Nombre };
                            gridDatos.DataSource = trans;
                            grvDatos.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[1].Width = 400;
                            grvDatos.Columns[4].Width = 150;
                            grvDatos.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[2].DisplayFormat.FormatString = "c2";
                            grvDatos.Columns[3].DisplayFormat.FormatType = FormatType.DateTime;
                            grvDatos.Columns[3].DisplayFormat.FormatString = "dd-MMM-yyyy";
                            break;
                        }
                    case 5:
                        {
                            var trans = from t in _entidades.Transacciones
                                        where t.Estado && t.TipoTransaccion=="Retiro"
                                        orderby t.FechaTransaccion descending
                                        select new { t.Clave, t.Concepto, t.Cantidad, t.FechaTransaccion, Registró = t.Usuario.Nombre };
                            gridDatos.DataSource = trans;
                            grvDatos.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[1].Width = 400;
                            grvDatos.Columns[4].Width = 150;
                            grvDatos.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[2].DisplayFormat.FormatString = "c2";
                            grvDatos.Columns[3].DisplayFormat.FormatType = FormatType.DateTime;
                            grvDatos.Columns[3].DisplayFormat.FormatString = "dd-MMM-yyyy";
                            break;
                        }
                    case 6:
                        {
                            var queryable5 = from abo in _entidades.Ventas
                                             where abo.Estado == "Pagado" || abo.Estado == "Apartado"
                                             orderby abo.Clave descending
                                             select new { abo.Clave, abo.Cliente, abo.TotalVenta, abo.FechaVenta, Registró = abo.Usuario.Nombre };

                            gridDatos.DataSource = queryable5;
                            grvDatos.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[1].Width = 200;
                            grvDatos.Columns[4].Width = 200;
                            grvDatos.Columns[3].DisplayFormat.FormatType = FormatType.DateTime;
                            grvDatos.Columns[3].DisplayFormat.FormatString = "dd-MMM-yyyy";
                            grvDatos.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[2].DisplayFormat.FormatString = "c2";
                            grvDatos.OptionsView.ColumnAutoWidth = true;
                            break;
                        }
                    case 7:
                        {
                            var queryable5 = from abo in _entidades.PagosVentas
                                             where abo.Estado
                                             orderby abo.Clave descending

                                             select new { abo.Clave, abo.Venta.Cliente, abo.FechaPago, abo.Abono, abo.Saldo, Registró = abo.Usuario.Nombre };
                            gridDatos.DataSource = queryable5;
                            grvDatos.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[1].Width = 200;
                            grvDatos.Columns[5].Width = 200;
                            grvDatos.Columns[2].DisplayFormat.FormatType = FormatType.DateTime;
                            grvDatos.Columns[2].DisplayFormat.FormatString = "dd-MMM-yyyy";
                            grvDatos.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[3].DisplayFormat.FormatString = "c2";
                            grvDatos.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[4].DisplayFormat.FormatString = "c2";
                            break;
                        }
                    case 8:
                        {
                            var fina = from f in _entidades.Prestamos
                                       where f.Estado == "Vigente"
                                       orderby f.Clave descending
                                       select new { Folio = f.FolioFinanciamiento, Cliente = f.Cliente.Nombre, f.Tipo, Prestamo = f.Cantidad, Registró = f.Usuario.Nombre, f.FechaPrestamo, f.Clave };
                            gridDatos.DataSource = fina;
                            grvDatos.Columns[5].Visible = false;

                            grvDatos.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[4].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[1].Width = 200;
                            grvDatos.Columns[4].Width = 200;
                            grvDatos.Columns[5].DisplayFormat.FormatType = FormatType.DateTime;
                            grvDatos.Columns[5].DisplayFormat.FormatString = "dd-MMM-yyyy";
                            grvDatos.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[3].DisplayFormat.FormatString = "c2";

                        } break;
                    case 9:
                        {
                            var pagos = from p in _entidades.PagosFinanciamientos
                                        where p.Estado
                                        orderby p.Clave descending
                                        select new { p.Clave, Cliente = p.Prestamo.Cliente.Nombre, p.TotalPago, p.FechaPago, Registro = p.Usuario.Nombre };
                            gridDatos.DataSource = pagos;
                            grvDatos.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[1].Width = 200;
                            grvDatos.Columns[4].Width = 200;
                            grvDatos.Columns[3].DisplayFormat.FormatType = FormatType.DateTime;
                            grvDatos.Columns[3].DisplayFormat.FormatString = "dd-MMM-yyyy";
                            grvDatos.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[2].DisplayFormat.FormatString = "c2";

                        } break;
                    case 10:
                        {
                            var pagos = from p in _entidades.FinancieraCreditos
                                        where p.Estado=="Activo"
                                        orderby p.Clave descending
                                        select new { p.Clave, Grupo=p.FinancieraGrupo.Nombre, p.Prestamo, p.FechaInicio, Registro = p.Usuario.Nombre };
                            gridDatos.DataSource = pagos;
                            grvDatos.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[1].Width = 200;
                            grvDatos.Columns[4].Width = 200;
                            grvDatos.Columns[3].DisplayFormat.FormatType = FormatType.DateTime;
                            grvDatos.Columns[3].DisplayFormat.FormatString = "dd-MMM-yyyy";
                            grvDatos.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[2].DisplayFormat.FormatString = "c2";

                        } break;
                    case 11:
                        {
                            var pagos = from p in _entidades.FinancieraPagos
                                        where p.Estado
                                        orderby p.Clave descending
                                        select new { p.Clave, Grupo = p.FinancieraCredito.FinancieraGrupo.Nombre,p.Pago,p.Recargo, p.TotalPago, p.FechaPago, Registro = p.Usuario.Nombre };
                            gridDatos.DataSource = pagos;
                            grvDatos.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                            grvDatos.Columns[1].Width = 200;
                            grvDatos.Columns[4].Width = 200;
                            grvDatos.Columns[5].DisplayFormat.FormatType = FormatType.DateTime;
                            grvDatos.Columns[5].DisplayFormat.FormatString = "dd-MMM-yyyy";
                            grvDatos.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[2].DisplayFormat.FormatString = "c2";
                            grvDatos.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[3].DisplayFormat.FormatString = "c2";
                            grvDatos.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
                            grvDatos.Columns[4].DisplayFormat.FormatString = "c2";

                        } break;
                }

            }
        }

    }
}
