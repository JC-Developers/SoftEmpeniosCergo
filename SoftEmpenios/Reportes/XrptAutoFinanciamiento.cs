using System.Linq;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.Reportes
{
    public partial class XrptAutoFinanciamiento : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptAutoFinanciamiento()
        {
            InitializeComponent();
        }

        private void rptAutoFinanciamiento_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Prestamo pre=new EmpeñosDC(new clsConeccionDB().StringConn()).Prestamos.FirstOrDefault(c=>c.Clave==(int)CvePrestamo.Value);
            DatosInforme.DataSource = pre;
        }

    }
}
