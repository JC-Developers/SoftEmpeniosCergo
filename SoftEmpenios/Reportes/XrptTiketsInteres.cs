using System.Linq;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.Reportes
{
    public partial class XrptTiketsInteres : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptTiketsInteres()
        {
            InitializeComponent();
        }

        private void XrptTiketsInteres_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Configuracione config = new EmpeñosDC(new clsConeccionDB().StringConn()).Configuraciones.FirstOrDefault();
            DatosConfig.DataSource = config;
            PageHeight = 520 + (33*((Cotizacion) DatosInforme.DataSource).Tables[1].Rows.Count);
        }
    }
}
