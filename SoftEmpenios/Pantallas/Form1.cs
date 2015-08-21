using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.Pantallas
{
    public partial class Form1 : Form
    {
        private XYDiagram _diagram;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpFechaInicial.EditValue = dtpFechaFinal.EditValue = DateTime.Today.Date;


        }

        private void botonVerGrafica_Click(object sender, EventArgs e)
        {
            chartControl1.Series.Clear();
            var grafica =
                new EmpeñosDC(new clsConeccionDB().StringConn()).Cajas.Where(
                    c =>
                        c.FechaCajaAbierto.Date >= dtpFechaInicial.DateTime.Date &&
                        c.FechaCajaAbierto.Date <= dtpFechaFinal.DateTime.Date);
            switch (cboTipoDato.SelectedIndex)
            {
                case 0:
                    {
                        Series empeño = new Series("Empeños", ViewType.Line);
                        switch (cboTipoMuestra.SelectedIndex)
                        {
                            case 0:
                                
                                foreach (var caja in grafica)
                                {
                                    empeño.Points.Add(new SeriesPoint(caja.FechaCajaAbierto.ToString("dd-MMM-yy"), caja.TotalEmpenios));
                                }
                                chartControl1.Series.Add(empeño);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "dd-MMM-yy";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                            case 1:
                                var empMes = from em in grafica
                                             group em by new
                                             {
                                                 Column1 =em.FechaCajaAbierto.Month
                                             }
                                                 into g
                                                 select new
                                                 {
                                                     Mes = g.Key.Column1,
                                                     Total = (Decimal?)g.Sum(em => em.TotalEmpenios)
                                                 };
                                foreach (var caja in empMes)
                                {
                                    empeño.Points.Add(new SeriesPoint(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(caja.Mes), caja.Total));
                                }
                                chartControl1.Series.Add(empeño);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                 _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "MMM";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                            case 2:
                                var empAnio = from em in grafica
                                             group em by new
                                             {
                                                 Column1 =em.FechaCajaAbierto.Year
                                             }
                                                 into g
                                                 select new
                                                 {
                                                     Mes = g.Key.Column1,
                                                     Total = (Decimal?)g.Sum(em => em.TotalEmpenios)
                                                 };
                                foreach (var caja in empAnio)
                                {
                                    empeño.Points.Add(new SeriesPoint(caja.Mes, caja.Total));
                                }
                                chartControl1.Series.Add(empeño);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "yyyy";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                        }
                    }
                    break;
                case 1:
                    {
                        Series intSeries = new Series("Intereses", ViewType.Line);
                        switch (cboTipoMuestra.SelectedIndex)
                        {
                            case 0:

                                foreach (var caja in grafica)
                                {
                                    intSeries.Points.Add(new SeriesPoint(caja.FechaCajaAbierto.ToString("dd-MMM-yy"), caja.InteresCobrados));
                                }
                                chartControl1.Series.Add(intSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "dd-MMM-yy";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                            case 1:
                                var empMes = from em in grafica
                                             group em by new
                                             {
                                                 Column1 = em.FechaCajaAbierto.Month
                                             }
                                                 into g
                                                 select new
                                                 {
                                                     Mes = g.Key.Column1,
                                                     Total = (Decimal?)g.Sum(em => em.InteresCobrados)
                                                 };
                                foreach (var caja in empMes)
                                {
                                    intSeries.Points.Add(new SeriesPoint(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(caja.Mes), caja.Total));
                                }
                                chartControl1.Series.Add(intSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "MMM";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                            case 2:
                                var empAnio = from em in grafica
                                              group em by new
                                              {
                                                  Column1 = em.FechaCajaAbierto.Year
                                              }
                                                  into g
                                                  select new
                                                  {
                                                      Mes = g.Key.Column1,
                                                      Total = (Decimal?)g.Sum(em => em.InteresCobrados)
                                                  };
                                foreach (var caja in empAnio)
                                {
                                    intSeries.Points.Add(new SeriesPoint(caja.Mes, caja.Total));
                                }
                                chartControl1.Series.Add(intSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "yyyy";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                        }
                    }
                    break;
                case 2:
                    {
                        Series desSeries = new Series("Desempeños", ViewType.Line);
                        switch (cboTipoMuestra.SelectedIndex)
                        {
                            case 0:

                                foreach (var caja in grafica)
                                {
                                    desSeries.Points.Add(new SeriesPoint(caja.FechaCajaAbierto.ToString("dd-MMM-yy"), caja.Desempenios));
                                }
                                chartControl1.Series.Add(desSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "dd-MMM-yy";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                            case 1:
                                var empMes = from em in grafica
                                             group em by new
                                             {
                                                 Column1 = em.FechaCajaAbierto.Month
                                             }
                                                 into g
                                                 select new
                                                 {
                                                     Mes = g.Key.Column1,
                                                     Total = (Decimal?)g.Sum(em => em.Desempenios)
                                                 };
                                foreach (var caja in empMes)
                                {
                                    desSeries.Points.Add(new SeriesPoint(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(caja.Mes), caja.Total));
                                }
                                chartControl1.Series.Add(desSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "MMM";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                            case 2:
                                var empAnio = from em in grafica
                                              group em by new
                                              {
                                                  Column1 = em.FechaCajaAbierto.Year
                                              }
                                                  into g
                                                  select new
                                                  {
                                                      Mes = g.Key.Column1,
                                                      Total = (Decimal?)g.Sum(em => em.Desempenios)
                                                  };
                                foreach (var caja in empAnio)
                                {
                                    desSeries.Points.Add(new SeriesPoint(caja.Mes, caja.Total));
                                }
                                chartControl1.Series.Add(desSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "yyyy";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                        }
                    }
                    break;
                case 3:
                    {
                        Series comSeries = new Series("Compras", ViewType.Line);
                        switch (cboTipoMuestra.SelectedIndex)
                        {
                            case 0:

                                foreach (var caja in grafica)
                                {
                                    comSeries.Points.Add(new SeriesPoint(caja.FechaCajaAbierto.ToString("dd-MMM-yy"), caja.TotalCompras));
                                }
                                chartControl1.Series.Add(comSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "dd-MMM-yy";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                            case 1:
                                var empMes = from em in grafica
                                             group em by new
                                             {
                                                 Column1 = em.FechaCajaAbierto.Month
                                             }
                                                 into g
                                                 select new
                                                 {
                                                     Mes = g.Key.Column1,
                                                     Total = (Decimal?)g.Sum(em => em.TotalCompras)
                                                 };
                                foreach (var caja in empMes)
                                {
                                    comSeries.Points.Add(new SeriesPoint(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(caja.Mes), caja.Total));
                                }
                                chartControl1.Series.Add(comSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "MMM";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                            case 2:
                                var empAnio = from em in grafica
                                              group em by new
                                              {
                                                  Column1 = em.FechaCajaAbierto.Year
                                              }
                                                  into g
                                                  select new
                                                  {
                                                      Mes = g.Key.Column1,
                                                      Total = (Decimal?)g.Sum(em => em.TotalCompras)
                                                  };
                                foreach (var caja in empAnio)
                                {
                                    comSeries.Points.Add(new SeriesPoint(caja.Mes, caja.Total));
                                }
                                chartControl1.Series.Add(comSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "yyyy";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                        }
                    }
                    break;
                case 4:
                    {
                        Series comSeries = new Series("Ventas", ViewType.Line);
                        switch (cboTipoMuestra.SelectedIndex)
                        {
                            case 0:

                                foreach (var caja in grafica)
                                {
                                    comSeries.Points.Add(new SeriesPoint(caja.FechaCajaAbierto.ToString("dd-MMM-yy"), caja.TotalVentas));
                                }
                                chartControl1.Series.Add(comSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "dd-MMM-yy";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                            case 1:
                                var empMes = from em in grafica
                                             group em by new
                                             {
                                                 Column1 = em.FechaCajaAbierto.Month
                                             }
                                                 into g
                                                 select new
                                                 {
                                                     Mes = g.Key.Column1,
                                                     Total = (Decimal?)g.Sum(em => em.TotalVentas)
                                                 };
                                foreach (var caja in empMes)
                                {
                                    comSeries.Points.Add(new SeriesPoint(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(caja.Mes), caja.Total));
                                }
                                chartControl1.Series.Add(comSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "MMM";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                            case 2:
                                var empAnio = from em in grafica
                                              group em by new
                                              {
                                                  Column1 = em.FechaCajaAbierto.Year
                                              }
                                                  into g
                                                  select new
                                                  {
                                                      Mes = g.Key.Column1,
                                                      Total = (Decimal?)g.Sum(em => em.TotalVentas)
                                                  };
                                foreach (var caja in empAnio)
                                {
                                    comSeries.Points.Add(new SeriesPoint(caja.Mes, caja.Total));
                                }
                                chartControl1.Series.Add(comSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "yyyy";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                        }
                    }
                    break;
                case 5:
                    {
                        Series comSeries = new Series("Pagos a Venta", ViewType.Line);
                        switch (cboTipoMuestra.SelectedIndex)
                        {
                            case 0:

                                foreach (var caja in grafica)
                                {
                                    comSeries.Points.Add(new SeriesPoint(caja.FechaCajaAbierto.ToString("dd-MMM-yy"), caja.TotalPagosVentas));
                                }
                                chartControl1.Series.Add(comSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "dd-MMM-yy";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                            case 1:
                                var empMes = from em in grafica
                                             group em by new
                                             {
                                                 Column1 = em.FechaCajaAbierto.Month
                                             }
                                                 into g
                                                 select new
                                                 {
                                                     Mes = g.Key.Column1,
                                                     Total = (Decimal?)g.Sum(em => em.TotalPagosVentas)
                                                 };
                                foreach (var caja in empMes)
                                {
                                    comSeries.Points.Add(new SeriesPoint(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(caja.Mes), caja.Total));
                                }
                                chartControl1.Series.Add(comSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "MMM";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                            case 2:
                                var empAnio = from em in grafica
                                              group em by new
                                              {
                                                  Column1 = em.FechaCajaAbierto.Year
                                              }
                                                  into g
                                                  select new
                                                  {
                                                      Mes = g.Key.Column1,
                                                      Total = (Decimal?)g.Sum(em => em.TotalPagosVentas)
                                                  };
                                foreach (var caja in empAnio)
                                {
                                    comSeries.Points.Add(new SeriesPoint(caja.Mes, caja.Total));
                                }
                                chartControl1.Series.Add(comSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "yyyy";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                        }
                    }
                    break;
                case 6:
                    {
                        Series comSeries = new Series("Financiamientos", ViewType.Line);
                        switch (cboTipoMuestra.SelectedIndex)
                        {
                            case 0:

                                foreach (var caja in grafica)
                                {
                                    comSeries.Points.Add(new SeriesPoint(caja.FechaCajaAbierto.ToString("dd-MMM-yy"), caja.TotalFinanciamientos));
                                }
                                chartControl1.Series.Add(comSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "dd-MMM-yy";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                            case 1:
                                var empMes = from em in grafica
                                             group em by new
                                             {
                                                 Column1 = em.FechaCajaAbierto.Month
                                             }
                                                 into g
                                                 select new
                                                 {
                                                     Mes = g.Key.Column1,
                                                     Total = (Decimal?)g.Sum(em => em.TotalFinanciamientos)
                                                 };
                                foreach (var caja in empMes)
                                {
                                    comSeries.Points.Add(new SeriesPoint(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(caja.Mes), caja.Total));
                                }
                                chartControl1.Series.Add(comSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "MMM";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                            case 2:
                                var empAnio = from em in grafica
                                              group em by new
                                              {
                                                  Column1 = em.FechaCajaAbierto.Year
                                              }
                                                  into g
                                                  select new
                                                  {
                                                      Mes = g.Key.Column1,
                                                      Total = (Decimal?)g.Sum(em => em.TotalFinanciamientos)
                                                  };
                                foreach (var caja in empAnio)
                                {
                                    comSeries.Points.Add(new SeriesPoint(caja.Mes, caja.Total));
                                }
                                chartControl1.Series.Add(comSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "yyyy";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                        }
                    }
                    break;
                case 7:
                    {
                        Series comSeries = new Series("Pagos a Financiamientos", ViewType.Line);
                        switch (cboTipoMuestra.SelectedIndex)
                        {
                            case 0:

                                foreach (var caja in grafica)
                                {
                                    comSeries.Points.Add(new SeriesPoint(caja.FechaCajaAbierto.ToString("dd-MMM-yy"), caja.TotalPagosFinanciamiento));
                                }
                                chartControl1.Series.Add(comSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "dd-MMM-yy";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                            case 1:
                                var empMes = from em in grafica
                                             group em by new
                                             {
                                                 Column1 = em.FechaCajaAbierto.Month
                                             }
                                                 into g
                                                 select new
                                                 {
                                                     Mes = g.Key.Column1,
                                                     Total = (Decimal?)g.Sum(em => em.TotalPagosFinanciamiento)
                                                 };
                                foreach (var caja in empMes)
                                {
                                    comSeries.Points.Add(new SeriesPoint(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(caja.Mes), caja.Total));
                                }
                                chartControl1.Series.Add(comSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "MMM";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                            case 2:
                                var empAnio = from em in grafica
                                              group em by new
                                              {
                                                  Column1 = em.FechaCajaAbierto.Year
                                              }
                                                  into g
                                                  select new
                                                  {
                                                      Mes = g.Key.Column1,
                                                      Total = (Decimal?)g.Sum(em => em.TotalPagosFinanciamiento)
                                                  };
                                foreach (var caja in empAnio)
                                {
                                    comSeries.Points.Add(new SeriesPoint(caja.Mes, caja.Total));
                                }
                                chartControl1.Series.Add(comSeries);
                                _diagram = (XYDiagram)chartControl1.Diagram;
                                _diagram.AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
                                _diagram.AxisX.DateTimeOptions.FormatString = "yyyy";
                                _diagram.AxisY.NumericOptions.Format = NumericFormat.Currency;
                                _diagram.AxisY.NumericOptions.Precision = 1;
                                break;
                        }
                    }
                    break;
            }
        }
    }
}
