using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;
using SoftEmpenios.LogicaNegocios;
using SoftEmpenios.Reportes;

namespace SoftEmpenios.Pantallas
{
    public partial class FrmEmpeñosAtrasadas : XtraForm, iPantalla
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        DataTable _dtBoletas = new DataTable();
        public FrmEmpeñosAtrasadas()
        {
            InitializeComponent();
        }

        public void Buscar()
        {
            
        }

        public void Eliminar()
        {
            
        }

        public void Guardar()
        {
            
        }

        public void Nuevo()
        {
            
        }

        public string nombrePantalla
        {
            get
            {
                return "Empeños Atrasados";
            }
        }

        private void FrmEmpeñosAtrasadas_Shown(object sender, EventArgs e)
        {
            
            LlenarGrid();
            
        }

        private void LlenarGrid()
        {
            try
            {
                DateTime fechalimite = DateTime.Today.AddDays(-
                    Convert.ToInt32(new clsModificarConfiguracion().configGetValue("DiasVencimiento")));
                var atra = _entidades.Boletas.Where(b => b.EstadoBoleta == "Vigente")
                    .Select(
                        b =>
                            new
                            {
                                b.Folio,
                                b.Cliente,
                                b.FechaPrestamo,
                                b.Articulos,
                                b.Prestamo,
                                TipoEmpeño = SacarTipos(b),
                                b.PesoEmpeño,
                                FechaUltimoPago = b.FechaPrestamo.AddMonths(b.PagosInteres.Count(pi => pi.Estado))
                            })
                    .Where(
                        b =>b.FechaUltimoPago.Date <fechalimite.Date);

                _dtBoletas.Rows.Clear();
               
                _dtBoletas = new LinqToDataTable().ObtenerDataTable2(atra);
                _dtBoletas.Columns.Add("S", Type.GetType("System.Boolean"));
                foreach (DataRow fila in _dtBoletas.Rows)
                {
                    fila["S"] = false;
                }
                _dtBoletas.Columns["S"].SetOrdinal(0);
                gridEmpenios.DataSource = _dtBoletas;
                using (Cursor.Current = Cursors.WaitCursor)
                {
                    SacarTotalesMetal();
                }
                txtTotalBoletas.EditValue = _dtBoletas.Rows.Count;
                txtTotalPrestamo.EditValue = _dtBoletas.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["Prestamo"]);
                if (_dtBoletas.Rows.Count == 0) return;
                grvBoletas.Columns[0].Width = 20;
                grvBoletas.Columns["Folio"].Width = 50;
                grvBoletas.Columns["Articulos"].Width = 250;
                grvBoletas.Columns["Cliente"].Width = 200;
                grvBoletas.Columns["Folio"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                grvBoletas.Columns["PesoEmpeño"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                grvBoletas.Columns["TipoEmpeño"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                grvBoletas.Columns["FechaPrestamo"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                grvBoletas.Columns["FechaUltimoPago"].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

                grvBoletas.Columns["FechaPrestamo"].DisplayFormat.FormatType = FormatType.DateTime;
                grvBoletas.Columns["FechaPrestamo"].DisplayFormat.FormatString = "dd-MMM-yyyy";
                grvBoletas.Columns["FechaUltimoPago"].DisplayFormat.FormatType = FormatType.DateTime;
                grvBoletas.Columns["FechaUltimoPago"].DisplayFormat.FormatString = "dd-MMM-yyyy";
                grvBoletas.Columns["Prestamo"].DisplayFormat.FormatType = FormatType.Numeric;
                grvBoletas.Columns["Prestamo"].DisplayFormat.FormatString = "$ #,##0.00";

                grvBoletas.Columns[1].OptionsColumn.AllowEdit = false;
                grvBoletas.Columns[2].OptionsColumn.AllowEdit = false;
                grvBoletas.Columns[3].OptionsColumn.AllowEdit = false;
                grvBoletas.Columns[4].OptionsColumn.AllowEdit = false;
                grvBoletas.Columns[5].OptionsColumn.AllowEdit = false;
                grvBoletas.Columns[6].OptionsColumn.AllowEdit = false;

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

        private string SacarTipos(Boleta bole)
        {
            
            if (bole.DetallesBoletas.Any())
            {
                string tipo = "";
                foreach (DetallesBoleta det in bole.DetallesBoletas)
                {
                    string nstring ;
                    switch (det.Prenda.Tipo)
                    {
                        case "Oro 10Kt Rojo":
                            nstring = det.Prenda.Tipo.Substring(4, 4) + "R";
                            break;
                        case "Oro 10Kt Amarillo":
                            nstring = det.Prenda.Tipo.Substring(4, 4) + "A";
                            break;
                        case "Oro 14Kt":
                            nstring = det.Prenda.Tipo.Substring(4, 4);
                            break;
                        case "Oro 18Kt":
                            nstring = det.Prenda.Tipo.Substring(4, 4);
                            break;
                        case "Oro 22Kt":
                            nstring = det.Prenda.Tipo.Substring(4, 4);
                            break;
                        case "Oro 24Kt":
                            nstring = det.Prenda.Tipo.Substring(4, 4);
                            break;
                        default:
                            nstring = det.Prenda.Tipo;
                            break;
                    }
                    tipo = tipo + nstring + ";";

                }
                return tipo;
            }
            return bole.TipoEmpeño;
        }

        private void botonUnselectAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow fila in _dtBoletas.Rows)
                fila["S"] = false;
        }

        private void botonSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow fila in _dtBoletas.Rows)
                fila["S"] = true;
        }

        private void botonDeleteSelected_Click(object sender, EventArgs e)
        {
            foreach (DataRow t in from DataRow t in _dtBoletas.Rows where (bool)t["S"] select t)
            {
                new LogicaBoletas().EstadoVencido(t["Folio"].ToString());
            }
            LlenarGrid();
        }

        private void botonDeleteAll_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(
                    "Cambiar estado de Boletas. \x00bfConfirme si quiere poner como vencidas todas las Boletas Atrasadas",
                    "SoftEmpeños", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.Yes)
                foreach (DataRow t in _dtBoletas.Rows)
                    new LogicaBoletas().EstadoVencido(t["Folio"].ToString());
            else
                MessageBox.Show("No se Realizo ningun Cambio", "SoftEmpeños");
            LlenarGrid();
        }
        private List<Decimal> SacarTotalesMetal()
        {
            decimal oropeso10A = 0;
            decimal oropeso10R = 0;
            decimal oropeso14 = 0;
            decimal oropeso18 = 0;
            decimal oropeso22 = 0;
            decimal oropeso24 = 0;
            decimal platapeso = 0;
            decimal medallon = 0;
            int motos = 0;
            int autos = 0;
            int varios = 0;
            decimal oro = 0;

            foreach (Boleta bol in from DataRow boleta in _dtBoletas.Rows select _entidades.Boletas.Single(b => b.Folio == boleta["Folio"].ToString()))
            {
                if (bol.DetallesBoletas.Any())
                {

                    oropeso10R += (decimal)bol.DetallesBoletas.Where(b => b.Prenda != null && b.Prenda.Tipo == "Oro 10Kt Rojo").Sum(b => (decimal?)b.Prenda.Peso);
                    oropeso10A += (decimal)bol.DetallesBoletas.Where(b => b.Prenda != null && b.Prenda.Tipo == "Oro 10Kt Amarillo").Sum(b => (decimal?)b.Prenda.Peso);
                    oropeso14 += (decimal)bol.DetallesBoletas.Where(b => b.Prenda != null && b.Prenda.Tipo == "Oro 14Kt").Sum(b => (decimal?)b.Prenda.Peso);
                    oropeso18 += (decimal)bol.DetallesBoletas.Where(b => b.Prenda != null && b.Prenda.Tipo == "Oro 18Kt").Sum(b => (decimal?)b.Prenda.Peso);
                    oropeso22 += (decimal)bol.DetallesBoletas.Where(b => b.Prenda != null && b.Prenda.Tipo == "Oro 22Kt").Sum(b => (decimal?)b.Prenda.Peso);
                    oropeso24 += (decimal)bol.DetallesBoletas.Where(b => b.Prenda != null && b.Prenda.Tipo == "Oro 24Kt").Sum(b => (decimal?)b.Prenda.Peso);
                    platapeso += (decimal)bol.DetallesBoletas.Where(b => b.Prenda != null && b.Prenda.Tipo == "Plata").Sum(b => (decimal?)b.Prenda.Peso);
                    medallon += (decimal)bol.DetallesBoletas.Where(b => b.Prenda != null && b.Prenda.Tipo == "Medallon").Sum(b => (decimal?)b.Prenda.Peso);
                    motos += (int)bol.DetallesBoletas.Where(b => b.Prenda != null && b.Prenda.Tipo == "Motocicleta").Sum(b => (decimal?)b.Prenda.Peso);
                    autos += (int)bol.DetallesBoletas.Where(b => b.Prenda != null && b.Prenda.Tipo == "Automovil").Sum(b => (decimal?)b.Prenda.Peso);
                    varios += (int)bol.DetallesBoletas.Where(b => b.Prenda != null && b.Prenda.Tipo == "Varios").Sum(b => (decimal?)b.Prenda.Peso);

                }
                else
                {
                    switch (bol.TipoEmpeño)
                    {
                        case "Medallon":
                            medallon += bol.PesoEmpeño;
                            break;
                        case "Oro":
                            oro += bol.PesoEmpeño;
                            break;
                        case "Motocicleta":
                            motos += (int)bol.PesoEmpeño;
                            break;
                        case "Automovil":
                            autos += (int)bol.PesoEmpeño;
                            break;
                        case "Plata":
                            platapeso += bol.PesoEmpeño;
                            break;
                    }

                }
            }
            txtPlata.EditValue = platapeso;
            txtOro.EditValue = oro;
            txtOro10KtA.EditValue = oropeso10A;
            txtOro10KtR.EditValue = oropeso10R;
            txtOro14Kt.EditValue = oropeso14;
            txtOro18Kt.EditValue = oropeso18;
            txtOro22Kt.EditValue = oropeso22;
            txtOro24Kt.EditValue = oropeso24;
            txtAutos.EditValue = autos;
            txtMotos.EditValue = motos;
            txtVarios.EditValue = varios;
            txtMedallon.EditValue = medallon;
            return null;
        }

        private void botonImprimir_Click(object sender, EventArgs e)
        {
            if (_dtBoletas.Rows.Count>0)
            {
                XrptEmpeñosAtrasados rptbol = new XrptEmpeñosAtrasados
                {
                    DatosInforme = {DataSource = _dtBoletas},
                    Oro = {Value = txtOro.EditValue},
                    Plata = {Value = txtPlata.EditValue},
                    Medallon = {Value = txtMedallon.EditValue},
                    Oro10R = {Value = txtOro10KtR.EditValue},
                    Oro10A = {Value = txtOro10KtA.EditValue},
                    Oro14 = {Value = txtOro14Kt.EditValue},
                    Oro18 = {Value = txtOro18Kt.EditValue},
                    Oro22 = {Value = txtOro22Kt.EditValue},
                    Oro24 = {Value = txtOro24Kt.EditValue},
                    Moto = {Value = txtMotos.EditValue},
                    Auto = {Value = txtAutos.EditValue},
                    Varios = {Value = txtVarios.EditValue}
                };

                rptbol.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");

        }

        private void segundoPlano_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
           e.Result= SacarTotalesMetal();
        }

        private void segundoPlano_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            List<decimal> totales = (List<decimal>) e.Result;
            txtPlata.EditValue = totales[0];
            txtOro.EditValue = totales[1];
            txtOro10KtA.EditValue = totales[2];
            txtOro10KtR.EditValue = totales[3];
            txtOro14Kt.EditValue = totales[4];
            txtOro18Kt.EditValue = totales[5];
            txtOro22Kt.EditValue = totales[6];
            txtOro24Kt.EditValue = totales[7];
            txtAutos.EditValue = totales[8];
            txtMotos.EditValue = totales[9];
            txtVarios.EditValue = totales[10];
            txtMedallon.EditValue = totales[11];
        }
    }
}