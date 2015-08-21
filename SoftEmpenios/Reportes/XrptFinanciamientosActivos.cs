using System.Linq;
using SoftEmpenios.DBComun;
using SoftEmpenios.Clases;

namespace SoftEmpenios.Reportes
{
    public partial class XrptFinanciamientosActivos : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptFinanciamientosActivos()
        {
            InitializeComponent();
        }
        private void rptFinanciamientos_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var prestamos =
                new EmpeñosDC(new clsConeccionDB().StringConn()).Prestamos.Where(
                    finan => finan.Estado == "Vigente").Select(finan => finan); 
            DatosInforme.DataSource = prestamos;

        }
    }
}
