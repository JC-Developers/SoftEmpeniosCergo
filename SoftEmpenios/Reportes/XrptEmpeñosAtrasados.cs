using System;
using SoftEmpenios.Clases;

namespace SoftEmpenios.Reportes
{
    public partial class XrptEmpeñosAtrasados : DevExpress.XtraReports.UI.XtraReport
    {
        int dias = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("DiasVencimiento"));
        public XrptEmpeñosAtrasados()
        {
            InitializeComponent();
            
        }
    }
}
