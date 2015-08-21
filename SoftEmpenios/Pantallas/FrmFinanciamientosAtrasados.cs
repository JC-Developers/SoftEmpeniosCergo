using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using SoftEmpenios.DBComun;
using SoftEmpenios.Clases;

namespace SoftEmpenios.Pantallas
{
    public partial class FrmFinanciamientosAtrasados : Form, iPantalla
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        readonly DataTable _atrasadosDt = new DataTable();
        readonly DataTable _pagosRealizadosDt = new DataTable();

        public FrmFinanciamientosAtrasados()
        {
            InitializeComponent();
            _atrasadosDt.Columns.Add("Clave", Type.GetType("System.Int32"));
            _atrasadosDt.Columns.Add("Folio", Type.GetType("System.Int32"));
            _atrasadosDt.Columns.Add("Tipo", Type.GetType("System.String"));
            _atrasadosDt.Columns.Add("Nombre", Type.GetType("System.String"));
            _atrasadosDt.Columns.Add("Telefono", Type.GetType("System.String"));
            _atrasadosDt.Columns.Add("Prestamo", Type.GetType("System.Decimal"));
            _atrasadosDt.Columns.Add("Saldo", Type.GetType("System.Decimal"));
            _atrasadosDt.Columns.Add("FechaPrestamo", Type.GetType("System.DateTime"));
            _atrasadosDt.Columns.Add("UltimaFechaPago", Type.GetType("System.DateTime"));
            _atrasadosDt.Columns.Add("LetrasPagadas", Type.GetType("System.Int32"));
            _atrasadosDt.Columns.Add("LetrasAtrasadas", Type.GetType("System.Int32"));

            _pagosRealizadosDt.Columns.Add("Clave", Type.GetType("System.Int32"));
            _pagosRealizadosDt.Columns.Add("CvePrestamo", Type.GetType("System.Int32"));
            _pagosRealizadosDt.Columns.Add("Cantidad", Type.GetType("System.Decimal"));
            _pagosRealizadosDt.Columns.Add("Recargo", Type.GetType("System.Decimal"));
            _pagosRealizadosDt.Columns.Add("AbonoCapital", Type.GetType("System.Decimal"));
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
                return "Financiamientos";
            }
        }

        #endregion
        private void frmFinanciamientosAtrasados_Shown(object sender, EventArgs e)
        {
            var financiamientos = _entidades.Prestamos.Where(finan => finan.Estado == "Vigente").Select(finan => new
            {
                finan.Clave,
                finan.FolioFinanciamiento,
                finan.Tipo,
                finan.Cliente.Nombre,
                finan.Cliente.Telefono,
                finan.Cantidad,
                finan.Saldo,
                finan.FechaPrestamo,
                PagosRealizados =
                    _entidades.PagosFinanciamientos.Count(pago => pago.CvePrestamo == finan.Clave),
                finan.Financiamiento.Vencimiento,
                UltimoPago =
                    finan.PagosFinanciamientos != null && (finan.PagosFinanciamientos.Max(t => t.FechaPago).Date == null)
                        ? finan.FechaPrestamo
                        : finan.PagosFinanciamientos.Max(t => t.FechaPago).Date,
                        finan.Meses,
            });
            
            foreach (var item in financiamientos)
            {
                int meses;
                if (item.FechaPrestamo.AddMonths(item.PagosRealizados).Date.AddMonths(item.Vencimiento) < DateTime.Today.Date)
                {
                    if (item.FechaPrestamo.AddMonths(item.Meses) < DateTime.Today.Date)
                    {
                        int dias = item.FechaPrestamo.AddMonths(item.Meses).Date.Subtract(item.FechaPrestamo.AddMonths(item.PagosRealizados).Date).Days;
                        meses = dias / 30;
                    }
                    else
                    {
                        int dias = DateTime.Today.Date.Subtract(item.FechaPrestamo.AddMonths(item.PagosRealizados).Date).Days;
                         meses = dias / 30;
                    }
                    
                    _atrasadosDt.Rows.Add(new object[] {item.Clave,item.FolioFinanciamiento, item.Tipo, item.Nombre, item.Telefono, item.Cantidad, item.Saldo, item.FechaPrestamo, item.UltimoPago, item.PagosRealizados, meses});
                    var pagos = from pa in _entidades.PagosFinanciamientos
                                where pa.Estado  && pa.CvePrestamo == item.Clave
                                select new { pa.Clave, pa.CvePrestamo, pa.Cantidad, pa.Recargo, pa.AbonoPrestamo, pa.TotalPago, pa.Usuario.Nombre, pa.FechaPago };
                    foreach (var p in pagos)
                    {
                        _pagosRealizadosDt.Rows.Add(new object[] { p.Clave, p.CvePrestamo, p.Cantidad, p.Recargo, p.AbonoPrestamo, p.TotalPago, p.FechaPago, p.Nombre });
                    }
                }

                
            }
            DataSet financiamientosDS = new DataSet();
            financiamientosDS.Tables.Add(_atrasadosDt);
            financiamientosDS.Tables.Add(_pagosRealizadosDt);

            //Set up a master-detail relationship between the DataTables
            DataColumn keyColumn = financiamientosDS.Tables[0].Columns["Clave"];
            DataColumn foreignKeyColumn = financiamientosDS.Tables[1].Columns["CvePrestamo"];
            financiamientosDS.Relations.Add("Pagos", keyColumn, foreignKeyColumn);
            //gridCrono.DataSource =AtrasadosDT;
            gridCrono.DataSource = financiamientosDS.Tables[0];
            gridCrono.ForceInitialize();

           
            //gridCrono.LevelTree.Nodes.Add("Pagos", crvPagos);
            grvPagos.PopulateColumns(financiamientosDS.Tables[1]);
            grvPagos.Columns["Cantidad"].DisplayFormat.FormatType = FormatType.Numeric;
            grvPagos.Columns["Cantidad"].DisplayFormat.FormatString = "c2";
            grvFinanciamientos.Columns[0].Visible = false;
            grvPagos.Columns[1].Visible = false;
            grvPagos.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
            grvPagos.Columns[2].DisplayFormat.FormatString = "$ #,##0.00";
            grvPagos.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
            grvPagos.Columns[3].DisplayFormat.FormatString = "$ #,##0.00";
            grvPagos.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
            grvPagos.Columns[4].DisplayFormat.FormatString = "$ #,##0.00";
            grvPagos.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
            grvPagos.Columns[5].DisplayFormat.FormatString = "$ #,##0.00";
            grvPagos.Columns[6].DisplayFormat.FormatType = FormatType.DateTime;
            grvPagos.Columns[6].DisplayFormat.FormatString = "dd-MMMM-yyyy";

            grvFinanciamientos.Columns[1].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//folio
            grvFinanciamientos.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//tipo
            grvFinanciamientos.Columns[4].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//telefono
            grvFinanciamientos.Columns[5].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;//prestamo
            grvFinanciamientos.Columns[6].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;//saldo
            grvFinanciamientos.Columns[7].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//fechaPrestamo
            grvFinanciamientos.Columns[8].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//ultimopago
            grvFinanciamientos.Columns[9].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//LPag
            grvFinanciamientos.Columns[10].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//lAtra

            grvFinanciamientos.Columns[3].Width = 250;
            //grid.Columns[0].Width = 40;


            grvFinanciamientos.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
            grvFinanciamientos.Columns[5].DisplayFormat.FormatString = "$ #,##0.00";
            grvFinanciamientos.Columns[6].DisplayFormat.FormatType = FormatType.Numeric;
            grvFinanciamientos.Columns[6].DisplayFormat.FormatString = "$ #,##0.00";
            grvFinanciamientos.Columns[8].DisplayFormat.FormatType = FormatType.DateTime;
            grvFinanciamientos.Columns[8].DisplayFormat.FormatString = "dd-MMMM-yyyy";
            grvFinanciamientos.Columns[7].DisplayFormat.FormatType = FormatType.DateTime;
            grvFinanciamientos.Columns[7].DisplayFormat.FormatString = "dd-MMMM-yyyy";
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
            if (grvFinanciamientos.FocusedRowHandle >= 0)
            {
                FrmPagosFinanciamiento pagoFin=new FrmPagosFinanciamiento();
                pagoFin.cveFin = (int) grvFinanciamientos.GetRowCellValue(grvFinanciamientos.FocusedRowHandle, "Clave");
                pagoFin.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                pagoFin.ShowDialog(this);
            }
        }
    }
}
