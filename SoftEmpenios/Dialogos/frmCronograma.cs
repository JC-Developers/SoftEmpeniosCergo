using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.Utils;

namespace SoftEmpenios.Dialogos
{
    public partial class FrmCronograma : Form
    {
        public DataTable DtCronos = new DataTable();
        public string Tipo;
        public FrmCronograma()
        {
            InitializeComponent();
        }

        private void frmCronograma_Shown(object sender, EventArgs e)
        {
            gridCrono.DataSource = DtCronos;
            switch (Tipo)
            {
                case "Cronograma":
                    FormatearCronograma();
                    break;
                case "Pagos":
                    FormatearPagos();
                    break;
                case "PagosFinanciera":
                    FormatearPagosFinanciera();
                    break;
                case "Referencias":
                    FormatearReferencias();
                    break;
                case "PagosInteres":
                    FormatearIntereses();
                    break;
            }
        }

        private void FormatearIntereses()
        {
            grid.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//clave
            grid.Columns[1].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//MesesPagados
            grid.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;//Interes
            grid.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;//Recargo
            grid.Columns[4].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;//totalpagar
            grid.Columns[5].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//FechaPago
            grid.Columns[6].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;//Registro
            //grid.Columns[6].Width = 15;
            grid.Columns[0].Width = 60;
            grid.Columns[1].Width = 120;
            grid.Columns[6].Width = 120;
           
            grid.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
            grid.Columns[2].DisplayFormat.FormatString = "$ #,##0.00";
            grid.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
            grid.Columns[3].DisplayFormat.FormatString = "$ #,##0.00";
            grid.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
            grid.Columns[4].DisplayFormat.FormatString = "$ #,##0.00";
            grid.Columns[5].DisplayFormat.FormatType = FormatType.DateTime;
            grid.Columns[5].DisplayFormat.FormatString = "dd-MMM-yyyy";
            gpoContenedor.Text = "Pagos Registrados";
            Width = 700;
            labelControl1.Left = 685;
        }

        void FormatearCronograma()
        {
            grid.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grid.Columns[1].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            grid.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            grid.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            grid.Columns[4].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            grid.Columns[5].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            grid.Columns[6].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            //grid.Columns[6].Width = 15;
            grid.Columns[0].Width = 40;

            grid.Columns[1].DisplayFormat.FormatType = FormatType.Numeric;
            grid.Columns[1].DisplayFormat.FormatString = "$ #,##0.00";
            grid.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
            grid.Columns[2].DisplayFormat.FormatString = "$ #,##0.00";
            grid.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
            grid.Columns[3].DisplayFormat.FormatString = "$ #,##0.00";
            grid.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
            grid.Columns[4].DisplayFormat.FormatString = "$ #,##0.00";
            grid.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
            grid.Columns[5].DisplayFormat.FormatString = "$ #,##0.00";
            grid.Columns[6].DisplayFormat.FormatType = FormatType.DateTime;
            grid.Columns[6].DisplayFormat.FormatString = "dd-MMMM-yyyy";
            gpoContenedor.Text = "Historial de Pagos";
        }
        void FormatearPagos()
        {
            grid.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grid.Columns[1].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            grid.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            grid.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            grid.Columns[6].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grid.Columns[6].BestFit();
            grid.Columns[7].BestFit();
            grid.Columns[0].BestFit();

            grid.Columns[1].DisplayFormat.FormatType = FormatType.Numeric;
            grid.Columns[1].DisplayFormat.FormatString = "$ #,##0.00";
            grid.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
            grid.Columns[2].DisplayFormat.FormatString = "$ #,##0.00";
            grid.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
            grid.Columns[3].DisplayFormat.FormatString = "$ #,##0.00";
            grid.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
            grid.Columns[4].DisplayFormat.FormatString = "$ #,##0.00";
            grid.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
            grid.Columns[5].DisplayFormat.FormatString = "$ #,##0.00";
            grid.Columns[6].DisplayFormat.FormatType = FormatType.DateTime;
            grid.Columns[6].DisplayFormat.FormatString = "dd-MMM-yyyy";
            Width = 700;
            labelControl1.Left = 687;

        }
        void FormatearPagosFinanciera()
        {
            grid.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grid.Columns[1].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            grid.Columns[2].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            grid.Columns[3].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            //grid.Columns[6].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grid.Columns[5].BestFit();
            //grid.Columns[7].BestFit();
            //grid.Columns[0].BestFit();

            grid.Columns[1].DisplayFormat.FormatType = FormatType.Numeric;
            grid.Columns[1].DisplayFormat.FormatString = "$ #,##0.00";
            grid.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
            grid.Columns[2].DisplayFormat.FormatString = "$ #,##0.00";
            grid.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
            grid.Columns[3].DisplayFormat.FormatString = "$ #,##0.00";
            //grid.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
            //grid.Columns[4].DisplayFormat.FormatString = "$ #,##0.00";
            //grid.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
            //grid.Columns[5].DisplayFormat.FormatString = "$ #,##0.00";
            grid.Columns[4].DisplayFormat.FormatType = FormatType.DateTime;
            grid.Columns[4].DisplayFormat.FormatString = "dd-MMM-yyyy";
            Width = 700;
            labelControl1.Left = 687;

        }
        void FormatearReferencias()
        {
            gridCrono.MainView = referencias;
            gpoContenedor.Text = "Referencias del Prestamo";
            referencias.Columns[2].BestFit();
            referencias.Columns[0].BestFit();
            referencias.Columns[1].BestFit();
            referencias.Columns[3].BestFit();
            referencias.Columns[4].BestFit();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
