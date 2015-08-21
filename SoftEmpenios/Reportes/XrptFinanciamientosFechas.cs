using System;
using System.Linq;
using SoftEmpenios.DBComun;
using SoftEmpenios.Clases;

namespace SoftEmpenios.Reportes
{
    public partial class XrptFinanciamientosFechas : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptFinanciamientosFechas()
        {
            InitializeComponent();
        }

        private void rptFinanciamientos_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            IQueryable<Prestamo> prestamos = from p in new EmpeñosDC(new clsConeccionDB().StringConn()).Prestamos
                                             where p.FechaPrestamo.Date >= (DateTime)FechaInicial.Value && p.FechaPrestamo.Date <= (DateTime)FechaFinal.Value && p.Estado != "Cancelado"
                                             select p;
            DatosInforme.DataSource = prestamos;
            
        }
        

    }
}
