using System;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using DevExpress.Utils;
using SoftEmpenios.DBComun;
using SoftEmpenios.Clases;

namespace SoftEmpenios.Pantallas
{
    public partial class FrmCreditosAtrasados : Form, iPantalla
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        readonly DataTable _atrasadosDt = new DataTable();
        readonly DataTable _pagosRealizadosDt = new DataTable();

        public FrmCreditosAtrasados()
        {
            InitializeComponent();
            _atrasadosDt.Columns.Add("Clave", Type.GetType("System.Int32"));
            //_atrasadosDt.Columns.Add("Folio", Type.GetType("System.Int32"));
            //_atrasadosDt.Columns.Add("Tipo", Type.GetType("System.String"));
            _atrasadosDt.Columns.Add("Grupo", Type.GetType("System.String"));
            //_atrasadosDt.Columns.Add("Telefono", Type.GetType("System.String"));
            _atrasadosDt.Columns.Add("Prestamo", Type.GetType("System.Decimal"));
            _atrasadosDt.Columns.Add("TotalPago", Type.GetType("System.Decimal"));
            _atrasadosDt.Columns.Add("Saldo", Type.GetType("System.Decimal"));
            _atrasadosDt.Columns.Add("FechaPrestamo", Type.GetType("System.DateTime"));
            _atrasadosDt.Columns.Add("UltimaFechaPago", Type.GetType("System.DateTime"));
            _atrasadosDt.Columns.Add("LetrasPagadas", Type.GetType("System.Int32"));
            _atrasadosDt.Columns.Add("LetrasAtrasadas", Type.GetType("System.Int32"));

            _pagosRealizadosDt.Columns.Add("Clave", Type.GetType("System.Int32"));
            _pagosRealizadosDt.Columns.Add("CveCredito", Type.GetType("System.Int32"));
            _pagosRealizadosDt.Columns.Add("Cantidad", Type.GetType("System.Decimal"));
            _pagosRealizadosDt.Columns.Add("Recargo", Type.GetType("System.Decimal"));
            //_pagosRealizadosDt.Columns.Add("AbonoCapital", Type.GetType("System.Decimal"));
            _pagosRealizadosDt.Columns.Add("TotalPago", Type.GetType("System.Decimal"));
            _pagosRealizadosDt.Columns.Add("FechaPago", Type.GetType("System.DateTime"));
            _pagosRealizadosDt.Columns.Add("Registró", Type.GetType("System.String"));
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

        }
        public void Eliminar()
        {
        }
        public void Guardar()
        {
        }
        public void Nuevo()
        {

        }
        public void Paginar(int primerRegistro)
        {
            throw new NotImplementedException();
        }
        public string nombrePantalla
        {
            get
            {
                return "Créditos Atrasados";
            }
        }

        #endregion
        private void frmFinanciamientosAtrasados_Shown(object sender, EventArgs e)
        {
            Financiamiento f = _entidades.Financiamientos.Single(fin => fin.Tipo == "Grupal");
            var creditos = _entidades.FinancieraCreditos.Where(cre => cre.Estado == "Activo").Select(cre => new
            {
                cre.Clave,
                Grupo = cre.FinancieraGrupo.Nombre,
                cre.Prestamo,cre.TotalPago,
                cre.SaldoActual,
                FechaCredito = cre.FechaInicio,
                PagosRealizados = cre.FinancieraPagos.Count(p=>p.Estado),
                UltimoPago = (cre.FinancieraPagos.Count == 0) ? cre.FechaInicio : cre.FinancieraPagos.Max(pc => pc.FechaPago),
                cre.Plazos,
                cre.FechaFinal
            });
            foreach (var c in creditos)
            {
                switch (c.Plazos)
                {
                    case "SEMANAL":{
                            if (c.FechaCredito.AddDays(((c.PagosRealizados==0?1:c.PagosRealizados)*7)).Date.AddDays(f.Vencimiento*7) <
                                DateTime.Today.Date)
                            {

                                int letras;
                                if (c.FechaFinal.Date < DateTime.Today.Date)
                                {
                                    int dias = c.FechaFinal.Date.Subtract(//DateTime.Today.Date.Subtract(
                                        c.FechaCredito.AddDays(c.PagosRealizados * 7))//c.FechaCredito.AddDays(((c.PagosRealizados == 0 ? 1 : c.PagosRealizados) * 7)).Date)//.AddDays(f.Vencimiento).Date)
                                        .Days;
                                     letras = dias / 7;
                                }
                                else
                                {
                                    int dias = DateTime.Today.Date.Subtract(
                                        c.FechaCredito.AddDays(((c.PagosRealizados == 0 ? 1 : c.PagosRealizados) * 7)).Date)//.AddDays(f.Vencimiento).Date)
                                        .Days;
                                     letras = dias / 7;
                                }


                                _atrasadosDt.Rows.Add(c.Clave, c.Grupo, c.Prestamo, c.TotalPago,
                                    c.SaldoActual,
                                    c.FechaCredito, c.UltimoPago, c.PagosRealizados, letras);

                                var pagos = from pa in _entidades.FinancieraPagos
                                    where pa.Estado && pa.CveCredito == c.Clave
                                    select
                                        new
                                        {
                                            pa.Clave,
                                            pa.CveCredito,
                                            pa.Pago,
                                            pa.Recargo,
                                            pa.TotalPago,
                                            pa.Usuario.Nombre,
                                            pa.FechaPago
                                        };
                                foreach (var p in pagos)
                                {
                                    _pagosRealizadosDt.Rows.Add(new object[]
                                    {p.Clave, p.CveCredito, p.Pago, p.Recargo, p.TotalPago, p.FechaPago, p.Nombre});
                                }
                            }
                        }
                        break;
                    case "QUINCENAL":
                        {
                            if (c.FechaCredito.AddDays(((c.PagosRealizados == 0 ? 1 : c.PagosRealizados) * 14)).Date.AddDays(f.Vencimiento * 14) <
                                DateTime.Today.Date)
                            {
                                int letras;
                                if (c.FechaFinal.Date < DateTime.Today.Date)
                                {
                                    int dias = c.FechaFinal.Date.Subtract(//DateTime.Today.Date.Subtract(
                                        c.FechaCredito.AddDays(c.PagosRealizados * 14))//c.FechaCredito.AddDays(((c.PagosRealizados == 0 ? 1 : c.PagosRealizados) * 7)).Date)//.AddDays(f.Vencimiento).Date)
                                        .Days;
                                    letras = dias / 14;
                                }
                                else
                                {
                                    int dias = DateTime.Today.Date.Subtract(
                                        c.FechaCredito.AddDays(((c.PagosRealizados == 0 ? 1 : c.PagosRealizados) * 14)).Date)//.AddDays(f.Vencimiento).Date)
                                        .Days;
                                    letras = dias / 14;
                                }
                                _atrasadosDt.Rows.Add(c.Clave, c.Grupo, c.Prestamo, c.TotalPago,
                                    c.SaldoActual,
                                    c.FechaCredito, c.UltimoPago, c.PagosRealizados, letras);
                                var pagos = from pa in _entidades.FinancieraPagos
                                    where pa.Estado && pa.CveCredito == c.Clave
                                    select
                                        new
                                        {
                                            pa.Clave,
                                            pa.CveCredito,
                                            pa.Pago,
                                            pa.Recargo,
                                            pa.TotalPago,
                                            pa.Usuario.Nombre,
                                            pa.FechaPago
                                        };
                                foreach (var p in pagos)
                                {
                                    _pagosRealizadosDt.Rows.Add(new object[]
                                    {p.Clave, p.CveCredito, p.Pago, p.Recargo, p.TotalPago, p.FechaPago, p.Nombre});
                                }
                            }
                        }
                        break;
                    case "MENSUAL":
                    {
                        if (c.FechaCredito.AddMonths((c.PagosRealizados)).Date.AddMonths(3) <
                            DateTime.Today.Date)
                        {
                            int dias =
                                DateTime.Today.Date.Subtract(
                                    c.FechaCredito.AddMonths(c.PagosRealizados))
                                    .Days;
                            int letras = dias/30;
                            _atrasadosDt.Rows.Add(c.Clave, c.Grupo, c.Prestamo, c.TotalPago,
                                c.SaldoActual,
                                c.FechaCredito, c.UltimoPago, c.PagosRealizados, letras);

                            var pagos = from pa in _entidades.FinancieraPagos
                                where pa.Estado && pa.CveCredito == c.Clave
                                select
                                    new
                                    {
                                        pa.Clave,
                                        pa.CveCredito,
                                        pa.Pago,
                                        pa.Recargo,
                                        pa.TotalPago,
                                        pa.Usuario.Nombre,
                                        pa.FechaPago
                                    };
                            foreach (var p in pagos)
                            {
                                _pagosRealizadosDt.Rows.Add(new object[]
                                {p.Clave, p.CveCredito, p.Pago, p.Recargo, p.TotalPago, p.FechaPago, p.Nombre});
                            }
                        }
                    }
                        break;

                }
            }

            //foreach (var item in financiamientos)
            //{

            //    if (item.FechaPrestamo.AddMonths(item.PagosRealizados).Date.AddMonths(item.Vencimiento) < DateTime.Today.Date)
            //    {
            //        int dias = DateTime.Today.Date.Subtract(item.FechaPrestamo.AddMonths(item.PagosRealizados).Date).Days;
            //        int meses = dias / 30;
            //        _atrasadosDt.Rows.Add(new object[] {item.Clave,item.FolioFinanciamiento, item.Tipo, item.Nombre, item.Telefono, item.Cantidad, item.Saldo, item.FechaPrestamo, item.UltimoPago, item.PagosRealizados, meses});
            //        var pagos = from pa in _entidades.PagosFinanciamientos
            //                    where pa.Estado  && pa.CvePrestamo == item.Clave
            //                    select new { pa.Clave, pa.CvePrestamo, pa.Cantidad, pa.Recargo, pa.AbonoPrestamo, pa.TotalPago, pa.Usuario.Nombre, pa.FechaPago };
            //        foreach (var p in pagos)
            //        {
            //            _pagosRealizadosDt.Rows.Add(new object[] { p.Clave, p.CvePrestamo, p.Cantidad, p.Recargo, p.AbonoPrestamo, p.TotalPago, p.FechaPago, p.Nombre });
            //        }
            //    }


            //}
            DataSet financiamientosDS = new DataSet();
            financiamientosDS.Tables.Add(_atrasadosDt);
            financiamientosDS.Tables.Add(_pagosRealizadosDt);

            //Set up a master-detail relationship between the DataTables
            DataColumn keyColumn = financiamientosDS.Tables[0].Columns["Clave"];
            DataColumn foreignKeyColumn = financiamientosDS.Tables[1].Columns["CveCredito"];
            financiamientosDS.Relations.Add("Pagos", keyColumn, foreignKeyColumn);
            //gridCrono.DataSource =AtrasadosDT;
            gridCrono.DataSource = financiamientosDS.Tables[0];
            gridCrono.ForceInitialize();


            ////gridCrono.LevelTree.Nodes.Add("Pagos", crvPagos);
            //grvPagos.PopulateColumns(financiamientosDS.Tables[1]);
            //grvPagos.Columns["Cantidad"].DisplayFormat.FormatType = FormatType.Numeric;
            //grvPagos.Columns["Cantidad"].DisplayFormat.FormatString = "c2";
            //grvCreditos.Columns[0].Visible = false;
            //grvPagos.Columns[1].Visible = false;
            //grvPagos.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
            //grvPagos.Columns[2].DisplayFormat.FormatString = "$ #,##0.00";
            //grvPagos.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
            //grvPagos.Columns[3].DisplayFormat.FormatString = "$ #,##0.00";
            //grvPagos.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
            //grvPagos.Columns[4].DisplayFormat.FormatString = "$ #,##0.00";
            //grvPagos.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
            //grvPagos.Columns[5].DisplayFormat.FormatString = "$ #,##0.00";
            //grvPagos.Columns[6].DisplayFormat.FormatType = FormatType.DateTime;
            //grvPagos.Columns[6].DisplayFormat.FormatString = "dd-MMMM-yyyy";

            //grvCreditos.Columns[1].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//folio
            //grvCreditos.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//tipo
            //grvCreditos.Columns[4].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//telefono
            //grvCreditos.Columns[5].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;//prestamo
            //grvCreditos.Columns[6].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;//saldo
            //grvCreditos.Columns[7].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//fechaPrestamo
            //grvCreditos.Columns[8].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//ultimopago
            //grvCreditos.Columns[9].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//LPag
            //grvCreditos.Columns[10].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//lAtra

            //grvCreditos.Columns[3].Width = 250;
            ////grid.Columns[0].Width = 40;


            grvCreditos.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
            grvCreditos.Columns[2].DisplayFormat.FormatString = "$ #,##0.00";
            grvCreditos.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
            grvCreditos.Columns[3].DisplayFormat.FormatString = "$ #,##0.00";
            grvCreditos.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
            grvCreditos.Columns[4].DisplayFormat.FormatString = "$ #,##0.00";
            grvCreditos.Columns[5].DisplayFormat.FormatType = FormatType.DateTime;
            grvCreditos.Columns[5].DisplayFormat.FormatString = "dd-MMMM-yyyy";
            grvCreditos.Columns[6].DisplayFormat.FormatType = FormatType.DateTime;
            grvCreditos.Columns[6].DisplayFormat.FormatString = "dd-MMMM-yyyy";
            //grid.Columns[1].Group();
            //grid.SetGroupLevelExpanded(0, true, true);
        }

        private void botonImprimir_Click(object sender, EventArgs e)
        {
            printableComponentLink1.CreateDocument();

            // Show the Print Preview for the gridControl1. 
            printableComponentLink1.ShowPreview();
        }

        private void gridCrono_DoubleClick(object sender, EventArgs e)
        {
            if (grvCreditos.FocusedRowHandle >= 0)
            {
                FrmPagosCreditos pagoFin = new FrmPagosCreditos();
                pagoFin.cveCredito = (int)grvCreditos.GetRowCellValue(grvCreditos.FocusedRowHandle, "Clave");
                pagoFin.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                pagoFin.ShowDialog(this);
            }
        }
    }
}
