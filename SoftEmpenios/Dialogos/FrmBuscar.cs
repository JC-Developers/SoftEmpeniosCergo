using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.Dialogos
{
    public delegate void EventDevolverString(string cad);
    public partial class FrmBuscar : XtraForm
    {
        public event EventDevolverString DevolverString;
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        string _nombreBusqueda = "";
        private DataTable resultadoTable;
        public FrmBuscar()
        {
            InitializeComponent();
        }
        public void CriteriosDeBusqueda(string buscar)//metodo que servira para definir lods cambos y llenar el grid con lo que se valla a buscar
        {
            _nombreBusqueda = buscar;
            switch (buscar)
            {
                case "Empenios":
                    LLenarBoletas();
                    break;
                case "Ventas":
                    LLenarVentas();
                    break;
                case "Articulos":
                    LlenarArticulos();
                    break;
                case "Clientes":
                    LlenarClientes();
                    break;
                case "Referencias":
                    LlenarReferencias();
                    break;
                case "Financiamientos":
                    LlenarFinanciamientos();
                    break;
                case "ClientesFinanciera":
                    LlenarClientesFinanciera();
                    break;
                case "GruposFinanciera":
                    LlenarGruposFinanciera();
                    break;
                case "CreditosFinanciera":
                    LlenarCreditosFinanciera();
                    break;
            }

        }

        private void LlenarCreditosFinanciera()
        {
            DataSet gruposDS = new DataSet("Grupos");
            var creditos =
                _entidades.FinancieraCreditos.Select(
                    c => new {c.Clave, c.CveGrupo,Grupo= c.FinancieraGrupo.Nombre, c.Prestamo, c.Base, c.FechaModificacion,c.Estado});
            var integrantes = _entidades.FinancieraGruposDetalles.Select(g => new { g.CveGrupo, g.CveCliente, g.FinancieraCliente.Nombre, g.Solicitado, g.Aprobado, g.Base, g.Tipo });
            if (!creditos.Any()) return;
            DataTable gruposDT = new LinqToDataTable().ObtenerDataTable2(creditos);
            DataTable integratesDT = new LinqToDataTable().ObtenerDataTable2(integrantes);
            gruposDS.Tables.AddRange(new[] { gruposDT, integratesDT });

            //DataColumn keyColumn = gruposDS.Tables[0].Columns["Clave"];
            //DataColumn foreignKeyColumn = gruposDS.Tables[1].Columns["CveGrupo"];
            //gruposDS.Relations.Add("Pagos", keyColumn, foreignKeyColumn);
            //gruposDS.Relations.Add("Detalle", gruposDT.Columns[1], integratesDT.Columns[0]);
            cboCriterio.Properties.Items.AddRange(new object[] { "Grupo", "Clave" });
            cboCriterio.SelectedIndex = 0;
            grvResultado.OptionsFind.FindFilterColumns = cboCriterio.Text;
            gridBusqueda.DataSource = creditos; //gruposDS.Tables[0];
            gridBusqueda.ForceInitialize();
            grvDetalle.PopulateColumns(gruposDS.Tables[1]);
        }

        private void LlenarGruposFinanciera()
        {
            DataSet gruposDS = new DataSet("Grupos");
            var grupos = _entidades.FinancieraGrupos.Where(c => c.Estado == "Aprobado")
                .Select(g => new { g.Clave,Grupo= g.Nombre, g.Estado, g.FechaModificacion });
            var integrantes =
                _entidades.FinancieraGruposDetalles.Where(g => grupos.Select(gr => gr.Clave).Contains(g.CveGrupo))
                    .Select(
                        g =>
                            new
                            {
                                g.CveGrupo,
                                g.CveCliente,
                                g.FinancieraCliente.Nombre,
                                g.Solicitado,
                                g.Aprobado,
                                g.Base,
                                g.Tipo
                            });
            if (!grupos.Any()) return;
            DataTable gruposDT = new LinqToDataTable().ObtenerDataTable2(grupos);
            DataTable integratesDT = new LinqToDataTable().ObtenerDataTable2(integrantes);
            gruposDS.Tables.AddRange(new[] { gruposDT, integratesDT });

            //DataColumn keyColumn = gruposDS.Tables[0].Columns["Clave"];
            //DataColumn foreignKeyColumn = gruposDS.Tables[1].Columns["CveGrupo"];
            //gruposDS.Relations.Add("Pagos", keyColumn, foreignKeyColumn);
            gruposDS.Relations.Add("Detalle", gruposDT.Columns[0], integratesDT.Columns[0]);

            gridBusqueda.DataSource = gruposDS.Tables[0];
            gridBusqueda.ForceInitialize();
            grvDetalle.PopulateColumns(gruposDS.Tables[1]);
            cboCriterio.Properties.Items.AddRange(new object[] { "Grupo", "Clave" });
            cboCriterio.SelectedIndex = 0;
            grvResultado.OptionsFind.FindFilterColumns = cboCriterio.Text;
        }
        private void LlenarFinanciamientos()
        {try
            {
                var clientes = _entidades.Prestamos
                    .Select(p => new { p.Clave, Folio = p.FolioFinanciamiento, p.Cliente.Nombre, p.Tipo, Prestamo = p.Cantidad, p.Saldo, p.Estado });
                resultadoTable = new LinqToDataTable().ObtenerDataTable2(clientes);
                cboCriterio.Properties.Items.AddRange(new object[] { "Nombre","Folio" });
                cboCriterio.SelectedIndex = 0;
                grvResultado.OptionsFind.FindFilterColumns = cboCriterio.Text;
                gridBusqueda.DataSource = resultadoTable;//clientes;
                grvResultado.Columns[1].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                grvResultado.Columns[0].Visible = false;
                grvResultado.Columns[2].Width = 250;
                grvResultado.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
                grvResultado.Columns[3].DisplayFormat.FormatString = "$ #,##0.00";
                grvResultado.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
                grvResultado.Columns[4].DisplayFormat.FormatString = "#,##0.00";
                grvResultado.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
                grvResultado.Columns[5].DisplayFormat.FormatString = "$ #,##0.00";
                new MyFindPanelFilterHelper(grvResultado);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error en llenar clientes");
            }

        }
        private void LlenarReferencias()
        {
            try
            {
                var clientes = _entidades.Referencias
                    .Select(c => new { Clave = c.CveReferencia, c.Nombre, c.Poblacion, c.Telefono });
                resultadoTable = new LinqToDataTable().ObtenerDataTable2(clientes);
                cboCriterio.Properties.Items.AddRange(new object[] { "Nombre" });
                cboCriterio.SelectedIndex = 0;
                grvResultado.OptionsFind.FindFilterColumns = cboCriterio.Text;
                gridBusqueda.DataSource = resultadoTable;
                grvResultado.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                grvResultado.Columns[1].Width = 250;
                new MyFindPanelFilterHelper(grvResultado);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error en llenar clientes");
            }

        }
        private void LlenarClientes()
        {
            try
            {
                var clientes = _entidades.Clientes
                    .Select(c=>new {Clave=c.CveCliente,Cliente=c.Nombre,c.Poblacion,c.Telefono});
                resultadoTable = new LinqToDataTable().ObtenerDataTable2(clientes);
                cboCriterio.Properties.Items.AddRange(new object[] { "Cliente" });
                cboCriterio.SelectedIndex = 0;
                grvResultado.OptionsFind.FindFilterColumns = cboCriterio.Text;
                gridBusqueda.DataSource = resultadoTable;//clientes;
                if (clientes.Any())
                {
                    grvResultado.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    grvResultado.Columns[1].Width = 250;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error en llenar clientes");
            }

        }
        private void LlenarClientesFinanciera()
        {
            try
            {
                var clientes = _entidades.FinancieraClientes
                    .Select(c => new { c.Clave, Cliente = c.Nombre, c.Poblacion, c.Telefono });
                resultadoTable = new LinqToDataTable().ObtenerDataTable2(clientes);
                cboCriterio.Properties.Items.AddRange(new object[] { "Cliente" });
                cboCriterio.SelectedIndex = 0;
                grvResultado.OptionsFind.FindFilterColumns = cboCriterio.Text;
                gridBusqueda.DataSource = resultadoTable;
                if (clientes.Any())
                {
                    grvResultado.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    grvResultado.Columns[1].Width = 250;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error en llenar clientes");
            }

        }

        private void LLenarBoletas()
        {
            try
            {
                var boleta =
                    _entidades.Boletas.Select(
                        p =>
                            new
                            {
                                p.Folio,
                                p.Cliente,
                                p.Articulos,
                                p.Prestamo,
                                p.PesoEmpeño,
                                p.Interes,
                                p.FechaPrestamo,
                                UltimoPago =
                                    p.PagosInteres.Count > 0
                                        ? p.PagosInteres.OrderByDescending(pg => pg.FechaPago).First().FechaPago
                                        : p.FechaPrestamo,
                                p.EstadoBoleta
                            });
                cboCriterio.Properties.Items.AddRange(new object[] {"Cliente", "Articulos", "Prestamo", "EstadoBoleta"});
                cboCriterio.SelectedIndex = 0;
                resultadoTable = new LinqToDataTable().ObtenerDataTable2(boleta);
                grvResultado.OptionsFind.FindFilterColumns = cboCriterio.Text;
                gridBusqueda.DataSource = resultadoTable; //boleta;
                grvResultado.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                grvResultado.Columns[6].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                grvResultado.Columns[7].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                grvResultado.Columns[8].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                grvResultado.Columns[1].Width = 200;
                grvResultado.Columns[2].Width = 200;
                grvResultado.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
                grvResultado.Columns[3].DisplayFormat.FormatString = "$ #,##0.00";
                grvResultado.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
                grvResultado.Columns[4].DisplayFormat.FormatString = "#,##0.00";
                grvResultado.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
                grvResultado.Columns[5].DisplayFormat.FormatString = "$ #,##0.00";
                grvResultado.Columns[6].DisplayFormat.FormatType = FormatType.DateTime;
                grvResultado.Columns[6].DisplayFormat.FormatString = "dd/MMM/yyyy";
                grvResultado.Columns[7].DisplayFormat.FormatType = FormatType.DateTime;
                grvResultado.Columns[7].DisplayFormat.FormatString = "dd/MMM/yyyy";
                new MyFindPanelFilterHelper(grvResultado);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error en Llenar Boletas");
            }
        }

        private void LLenarVentas()
        {
            var ventas = _entidades.Ventas
                                        .Select(
                                            v =>
                                            new
                                            {
                                                Folio=v.Clave,
                                                v.Cliente,
                                                Articulos = ConcatenarArticulos(v.DetalleVentas),
                                                v.TotalVenta,
                                                v.Enganche,
                                                Saldo = Saldo(v.Saldo, v.PagosVentas),v.FechaVenta,
                                                v.TipoVenta,
                                                v.Estado,});
            cboCriterio.Properties.Items.AddRange(new object[] {"Folio","Cliente", "Articulos" });cboCriterio.SelectedIndex = 0;
            resultadoTable = new LinqToDataTable().ObtenerDataTable2(ventas);
            if (resultadoTable.Rows.Count == 0) return;
            grvResultado.OptionsFind.FindFilterColumns = cboCriterio.Text;
            gridBusqueda.DataSource = resultadoTable;//ventas;
            grvResultado.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grvResultado.Columns[6].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grvResultado.Columns[7].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grvResultado.Columns[8].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grvResultado.Columns[1].Width = 200;
            grvResultado.Columns[2].Width = 200;
            grvResultado.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
            grvResultado.Columns[3].DisplayFormat.FormatString = "$ #,##0.00";
            grvResultado.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
            grvResultado.Columns[4].DisplayFormat.FormatString = "#,##0.00";
            grvResultado.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
            grvResultado.Columns[5].DisplayFormat.FormatString = "$ #,##0.00";
            grvResultado.Columns[6].DisplayFormat.FormatType = FormatType.DateTime;
            grvResultado.Columns[6].DisplayFormat.FormatString = "dd/MMM/yyyy";
            new MyFindPanelFilterHelper(grvResultado);
        }

        private string ConcatenarArticulos(IEnumerable<DetalleVenta> detvta)
        {
            return detvta.Aggregate("", (current, a) => current + a.Articulo.Descripcion + "; ");
        }

        private decimal Saldo(decimal saldo, IEnumerable<PagosVenta> pgs)
        {
            var ret = pgs.Where(a=>a.Estado ).Sum(a => (decimal?)a.Abono);
            if (ret != null)
                return (saldo - ((decimal)ret));
            return saldo;}

        private void cboCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            grvResultado.OptionsFind.FindFilterColumns = cboCriterio.Text;
            grvResultado.ApplyFindFilter("");
        }

        private void LlenarArticulos()
        {
            var articulos = _entidades.Articulos.Where(a => a.Estado == "Disponible")
                .Select(a =>
                    new
                    {
                        a.Clave,
                        a.Descripcion,
                        Tipo = a.Kilates,
                        a.Peso,
                        PrecioContado = a.Precio,
                        PrecioApartado = a.PrecioCredito
                    }
                );
            cboCriterio.Properties.Items.AddRange(new object[] { "Clave", "Descripcion", "Tipo", "Peso" });
            cboCriterio.SelectedIndex = 0;
            resultadoTable = new LinqToDataTable().ObtenerDataTable2(articulos);
            if (resultadoTable.Rows.Count==0)return;
            grvResultado.OptionsFind.FindFilterColumns = cboCriterio.Text;
            gridBusqueda.DataSource = resultadoTable;//articulos;

            grvResultado.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grvResultado.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grvResultado.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            //grvResultado.Columns[0].Width = 80;
            grvResultado.Columns[1].Width = 250;
            grvResultado.Columns[5].Width = 120;
            grvResultado.Columns[4].Width = 120;
            grvResultado.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
            grvResultado.Columns[5].DisplayFormat.FormatString = "$ #,##0.00";
            grvResultado.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
            grvResultado.Columns[4].DisplayFormat.FormatString = "#,##0.00";
            new MyFindPanelFilterHelper(grvResultado);
        }

        private void gridBusqueda_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (grvResultado.FocusedRowHandle >= 0)
            {
                switch (_nombreBusqueda)
                {
                    case "Empenios" :case "Ventas":
                        DevolverString(grvResultado.GetFocusedRowCellDisplayText("Folio"));
                        break;
                    default:
                    //case "Articulos":
                    //    DevolverString(grvResultado.GetFocusedRowCellDisplayText("Clave"));
                    //    break;
                    //case "Ventas":
                    //    DevolverString(grvResultado.GetFocusedRowCellDisplayText("Clave"));
                    //    break;
                    //case "Clientes":
                    //    DevolverString(grvResultado.GetFocusedRowCellDisplayText("Clave"));
                    //    break;
                    //case "Referencias":
                    //    DevolverString(grvResultado.GetFocusedRowCellDisplayText("Clave"));
                    //    break;
                    //case "Financiamientos":
                        DevolverString(grvResultado.GetFocusedRowCellDisplayText("Clave"));
                        break;
                }
                Close();
            }
        }
    }
}
