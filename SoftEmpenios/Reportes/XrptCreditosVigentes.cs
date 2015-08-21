using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.Reportes
{
    public partial class XrptCreditosVigentes : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptCreditosVigentes()
        {
            InitializeComponent();
        }

        private void xrTableCell7_AfterPrint(object sender, EventArgs e)
        {
        //    string clave = DetailReport.GetCurrentColumnValue("FinancieraCreditos.Clave").ToString();
        //    FinancieraCredito fina =
        //            new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraCreditos.FirstOrDefault(
        //                p => p.Clave == Convert.ToInt32(clave));
        //    int pagos = fina.NumeroPlazos - fina.FinancieraPagos.Count;
        //    LetrasRestantes.Value = pagos;
        }

        private void xrTableCell7_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

    }
}
