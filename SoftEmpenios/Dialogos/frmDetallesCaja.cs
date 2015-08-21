using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid;

namespace SoftEmpenios.Dialogos
{
    public partial class FrmDetallesCaja : Form
    {
        public DataTable DtCronos = new DataTable();
        public DataTable DtFinanciera = new DataTable();
        public string Tipo;
        public FrmDetallesCaja()
        {
            InitializeComponent();
        }

        private void frmCronograma_Shown(object sender, EventArgs e)
        {
            gridCrono.DataSource = DtCronos;
            //if (DtCronos.Rows.Count==0)
              //  return;
            switch (Tipo)
            {
                case "Financiamientos":
                    FormatearFinanciamiento();
                    break;
                case "PagosF":
                    FormatearPagos();
                    break;
                case "Depositos":
                    FormatearDepositos();
                    break;
                
            }
        }

        private void FormatearDepositos()
        {
            grid.ViewCaption = "Depositos";
            grvFinanciera.ViewCaption = "Base de Créditos ";
            if (DtCronos.Rows.Count > 0)
            {
                grid.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                //grid.Columns[1].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                //grid.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                grid.Columns[1].Width = 350;
                

                grid.Columns[0].DisplayFormat.FormatType = FormatType.Numeric;
                grid.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
                grid.Columns[2].DisplayFormat.FormatString = "$ #,##0.00";
                gpoContenedor.Text = "Detalle de Depositos";
                //grid.Columns[1].Group();
                //grid.SetGroupLevelExpanded(0, true, true);
                //GridGroupSummaryItem item = new GridGroupSummaryItem();
                //item.FieldName = "Cantidad";
                //item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //item.DisplayFormat = "Total: {0:c2}";
                //grid.GroupSummary.Add(item);
            }
            if (DtFinanciera.Rows.Count > 0)
            {
                gridFinanciera.DataSource = DtFinanciera;
                grvFinanciera.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                //grid.Columns[1].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                //grid.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                grvFinanciera.Columns[1].Width = 350;


                grvFinanciera.Columns[0].DisplayFormat.FormatType = FormatType.Numeric;
                grvFinanciera.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
                grvFinanciera.Columns[2].DisplayFormat.FormatString = "$ #,##0.00";
                //gpoContenedor.Text = "Detalle de Depositos";
                //grvFinanciera.Columns[1].Group();
                //grvFinanciera.SetGroupLevelExpanded(0, true, true);
                //GridGroupSummaryItem item = new GridGroupSummaryItem();
                //item.FieldName = "Cantidad";
                //item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //item.DisplayFormat = "Total: {0:c2}";
                //grvFinanciera.GroupSummary.Add(item);
                // Create and setup the second summary item.
            }
        }
        void FormatearFinanciamiento()
        {
            grid.ViewCaption = "Financiamientos";
            grvFinanciera.ViewCaption = "Creditos Grupales";
            if (DtCronos.Rows.Count > 0)
            {
                grid.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                grid.Columns[1].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                //grid.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                grid.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                grid.Columns[4].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                grid.Columns[5].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                grid.Columns[6].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                grid.Columns[7].Width = 200;
                grid.Columns[2].Width = 150;

                grid.Columns[0].DisplayFormat.FormatType = FormatType.Numeric;
                grid.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
                grid.Columns[3].DisplayFormat.FormatString = "$ #,##0.00";
                grid.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
                grid.Columns[4].DisplayFormat.FormatString = "$ #,##0.00";
                grid.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
                grid.Columns[5].DisplayFormat.FormatString = "$ #,##0.00";

                grid.Columns[6].DisplayFormat.FormatType = FormatType.Numeric;
                gpoContenedor.Text = "Historial de Pagos";
                grid.Columns[1].Group();
                grid.SetGroupLevelExpanded(0, true, true);
                GridGroupSummaryItem item = new GridGroupSummaryItem();
                item.FieldName = "Prestamo";
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                item.DisplayFormat = "Total: {0:c2}";
                grid.GroupSummary.Add(item);
            }
            if (DtFinanciera.Rows.Count > 0)
            {
                gridFinanciera.DataSource = DtFinanciera;
                grvFinanciera.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
                grvFinanciera.Columns[3].DisplayFormat.FormatString = "$ #,##0.00";
                grvFinanciera.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
                grvFinanciera.Columns[2].DisplayFormat.FormatString = "$ #,##0.00";
                grvFinanciera.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                grvFinanciera.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                // Create and setup the second summary item.
            }

        }
        void FormatearPagos()
        {
            
            grid.ViewCaption = "Pagos Financiamientos";
            grvFinanciera.ViewCaption = "Pagos Creditos Grupales";
            if (DtCronos.Rows.Count > 0)
            {
                grid.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                grid.Columns[1].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                //grid.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                grid.Columns[4].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                grid.Columns[3].Width = 200;
                grid.Columns[5].Width = 150;

                grid.Columns[0].DisplayFormat.FormatType = FormatType.Numeric;
                grid.Columns[1].DisplayFormat.FormatType = FormatType.Numeric;
                //grid.Columns[0].DisplayFormat.FormatString = "$ #,##0.00";
                //grid.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
                //grid.Columns[2].DisplayFormat.FormatString = "$ #,##0.00";

                grid.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
                grid.Columns[4].DisplayFormat.FormatString = "$ #,##0.00";



                gpoContenedor.Text = "Pagos de financiamientos del día";
                //grid.Columns[1].Group();
                //grid.SetGroupLevelExpanded(0, true, true);
                ////grid.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
                //// Create and setup the first summary item.
                //GridGroupSummaryItem item = new GridGroupSummaryItem();
                //item.FieldName = "TotalPago";
                //item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                //item.DisplayFormat = "Total Pago: {0:c2}";
                //grid.GroupSummary.Add(item);
            }
            if (DtFinanciera.Rows.Count > 0)
            {
                gridFinanciera.DataSource = DtFinanciera;
                grvFinanciera.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
                grvFinanciera.Columns[3].DisplayFormat.FormatString = "$ #,##0.00";
                grvFinanciera.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
                grvFinanciera.Columns[4].DisplayFormat.FormatString = "$ #,##0.00";
                grvFinanciera.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
                grvFinanciera.Columns[2].DisplayFormat.FormatString = "$ #,##0.00";
                grvFinanciera.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                grvFinanciera.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                grvFinanciera.Columns[4].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            }
        }        
        private void labelControl1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
