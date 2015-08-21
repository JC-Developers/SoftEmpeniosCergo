using System;
using System.Linq;
using SoftEmpenios.DBComun;
using SoftEmpenios.Clases;

namespace SoftEmpenios.Reportes
{
    public partial class XrptPagosFinanciamientoFechas : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptPagosFinanciamientoFechas()
        {
            InitializeComponent();
        }
        
        private void rptPagosFinanciamiento_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            IQueryable<PagosFinanciamiento> pagos = from p in new EmpeñosDC(new clsConeccionDB().StringConn()).PagosFinanciamientos
                                                    where p.FechaPago.Date >= (DateTime)FechaInicial.Value && p.FechaPago.Date <= (DateTime)FechaFinal.Value && p.Estado == true
                                             select p;
            DatosInforme.DataSource = pagos;
        }

    }
}
