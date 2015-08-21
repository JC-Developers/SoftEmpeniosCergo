using System;
using System.Linq;
using SoftEmpenios.DBComun;
using SoftEmpenios.Clases;

namespace SoftEmpenios.Reportes
{
    public partial class XrptPagosFinanciamiento : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptPagosFinanciamiento()
        {
            InitializeComponent();
        }

        private void rptPagosFinanciamiento_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            IQueryable<PagosFinanciamiento> pagos = from p in new EmpeñosDC(new clsConeccionDB().StringConn()).PagosFinanciamientos
                                             where p.FechaPago.Date== DateTime.Today.Date && p.Estado ==true
                                             select p;
            DatosInforme.DataSource = pagos;
        }

    }
}
