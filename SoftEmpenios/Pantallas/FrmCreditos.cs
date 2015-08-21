using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Funciones;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;
using SoftEmpenios.Dialogos;
using SoftEmpenios.LogicaNegocios;
using SoftEmpenios.Reportes;
using Word = Microsoft.Office.Interop.Word;

namespace SoftEmpenios.Pantallas
{
    public partial class FrmCreditos : DevExpress.XtraEditors.XtraForm, iPantalla
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        private DataTable dtIntegrantesGrupo;
        Word.Application oWord;
        Word.Document oDoc;
        public FrmCreditos()
        {
            InitializeComponent();
            dtIntegrantesGrupo = new DataTable("Detalles");
            dtIntegrantesGrupo.Columns.Add("Clave", typeof(int));//0
            dtIntegrantesGrupo.Columns.Add("Nombre", typeof(string));//1
            dtIntegrantesGrupo.Columns.Add("Solicitado", typeof(decimal));//2
            dtIntegrantesGrupo.Columns.Add("Aprobado", typeof(decimal));//3
            dtIntegrantesGrupo.Columns.Add("Base", typeof(decimal));//4
            dtIntegrantesGrupo.Columns.Add("Image1", typeof(Image));//5
            dtIntegrantesGrupo.Columns.Add("Image2", typeof(Image));//6
            dtIntegrantesGrupo.Columns.Add("Image3", typeof(Image));//7
            dtIntegrantesGrupo.Columns.Add("PagoPuntual", typeof(decimal));//8
            dtIntegrantesGrupo.Columns.Add("PagoAtrasado", typeof(decimal));//9

            gridIntegrantes.DataSource = dtIntegrantesGrupo;
            grvIntegrantes.Columns[2].ColumnEdit = txtSolicitado;
            grvIntegrantes.Columns[3].ColumnEdit = txtAprobado;
            grvIntegrantes.Columns[5].Visible = false;
            grvIntegrantes.Columns[6].Visible = false;
            grvIntegrantes.Columns[7].Visible = false;
            //grvIntegrantes.Columns[4].ColumnEdit = txtBase;
            //grvIntegrantes.Columns[5].ColumnEdit = imgUno;
            //grvIntegrantes.Columns[6].ColumnEdit = imgDos;
            //grvIntegrantes.Columns[7].ColumnEdit = imgTres;

            grvIntegrantes.Columns[0].OptionsColumn.AllowEdit = false;
            grvIntegrantes.Columns[1].OptionsColumn.AllowEdit = false;
            grvIntegrantes.Columns[4].OptionsColumn.AllowEdit = false;
            grvIntegrantes.Columns[2].OptionsColumn.AllowEdit = false;
            grvIntegrantes.Columns[3].OptionsColumn.AllowEdit = false;
            grvIntegrantes.Columns[8].OptionsColumn.AllowEdit = false;
            grvIntegrantes.Columns[9].OptionsColumn.AllowEdit = false;
            grvIntegrantes.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
            grvIntegrantes.Columns[4].DisplayFormat.FormatString = "$ #,##0.00";
            grvIntegrantes.Columns[8].DisplayFormat.FormatType = FormatType.Numeric;
            grvIntegrantes.Columns[8].DisplayFormat.FormatString = "$ #,##0.00";
            grvIntegrantes.Columns[9].DisplayFormat.FormatType = FormatType.Numeric;
            grvIntegrantes.Columns[9].DisplayFormat.FormatString = "$ #,##0.00";
            //grvIntegrantes.Columns[8].Visible = true;
            //grvIntegrantes.Columns[9].Visible = true;
        }

        private void btnBuscarGrupo_Click(object sender, EventArgs e)
        {
            FrmBuscar buscRef = new FrmBuscar();
            buscRef.CriteriosDeBusqueda("GruposFinanciera");
            buscRef.DevolverString += ClienteDevuelto;
            buscRef.ShowDialog(this);
            buscRef.DevolverString += ClienteDevuelto;
            buscRef.Close();
            CalcularTotalCredito();
        }
        private void ClienteDevuelto(string clave)
        {
            dtIntegrantesGrupo.Rows.Clear();
            FinancieraGrupo grupo = _entidades.FinancieraGrupos.First(cl => cl.Clave == Convert.ToInt32(clave));
            txtCveGrupo.EditValue = grupo.Clave;
            txtNombreGrupo.EditValue = grupo.Nombre;
            txtEstado.EditValue = grupo.Estado;
            IQueryable<FinancieraGruposDetalle> detgrupo =
                _entidades.FinancieraGruposDetalles.Where(
                    dg => dg.CveGrupo == Convert.ToInt32(txtCveGrupo.EditValue));
            foreach (var detGrupo in detgrupo)
            {
                decimal pagoPuntual = decimal.Round(obtenerPagoXletra(detGrupo.Aprobado), 1);
                decimal pagoAtrasado = decimal.Round((pagoPuntual + (pagoPuntual * Convert.ToDecimal(txtRecargoG.EditValue))), 1);
                dtIntegrantesGrupo.Rows.Add(new object[] { detGrupo.CveCliente, detGrupo.FinancieraCliente.Nombre, detGrupo.Solicitado, detGrupo.Aprobado, detGrupo.Base, null, null, null, pagoPuntual, pagoAtrasado });
            }
        }

        public void Buscar()
        {
            throw new NotImplementedException();
        }

        public void Eliminar()
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            //if (HasNull(dtIntegrantesGrupo))
            //{
            //    XtraMessageBox.Show("No puede guardar el crédito si no especifica las fotos de los integrantes");
            //    return;
            //}
            try
            {

           
            if ((int)txtCveCredito.EditValue == 0)
            {
                FinancieraCredito credito = new FinancieraCredito
                {
                    CveGrupo = Convert.ToInt32(txtCveGrupo.EditValue),
                    FechaInicio = dtpFechaInicio.DateTime.Date,
                    FechaFinal = dtpFechaFinal.DateTime.Date,
                    Prestamo = Convert.ToDecimal(txtCantidadCredito.EditValue),
                    Pago = Convert.ToDecimal(txtMontoPago.EditValue),
                    TotalPago = Convert.ToDecimal(txtTotalCredito.EditValue),
                    SaldoActual = Convert.ToDecimal(txtTotalCredito.EditValue),
                    Plazos = cboPlazo.Text,
                    NumeroPlazos = Convert.ToInt32(txtNumPlazos.EditValue),
                    Estado = "Activo",
                    CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IdUsuarioApp")),
                    Base = Convert.ToDecimal(txtBase.EditValue),
                    FechaModificacion = DateTime.Today.Date
                };
                txtCveCredito.EditValue = new LogicaCreditos().AgregarCredito(credito);
                ImprimirReportes(credito);
                ActualizarGrupo(Convert.ToInt32(txtCveGrupo.EditValue));
            }
            else
            {
                FinancieraCredito credito =
                    _entidades.FinancieraCreditos.Single(c => c.Clave == Convert.ToInt32(txtCveCredito.EditValue));
                ImprimirReportes(credito);
            }
                cboPlazo.Enabled = txtNumPlazos.Enabled = false;
            }
             
            catch (ValidationException vex)
            {
                XtraMessageBox.Show(vex.Message,"Validando Datos");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error de al guardar");
            }
        }

        private void ActualizarGrupo(int p)
        {
            FinancieraGrupo grupomod = _entidades.FinancieraGrupos.First(g => g.Clave == p);
            FinancieraGrupo grupo = new FinancieraGrupo()
            {
                Clave = grupomod.Clave,
                Nombre = txtNombreGrupo.Text,
                Estado = "ACTIVO",
                FechaModificacion = DateTime.Today,
                CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IdUsuarioApp")),
            };
            new LogicaGrupos().ActualizarGrupo(grupo, grupomod);
            //new LogicaGrupos().EliminarDetalles(grupomod.Clave);
            //foreach (DataRow fila in dtIntegrantesGrupo.Rows)
            //{
            //    FinancieraGruposDetalle detGrupo = new FinancieraGruposDetalle()
            //    {
            //        CveGrupo = Convert.ToInt32(txtCveGrupo.EditValue),
            //        CveCliente = Convert.ToInt32(fila[0]),
            //        Solicitado = Convert.ToDecimal(fila[2]),
            //        Aprobado = Convert.ToDecimal(fila[3]),
            //        Base = Convert.ToDecimal(fila[4]),
            //        Tipo = fila[5].ToString(),
            //        FechaModificacion = DateTime.Today.Date,
            //    };
            //    new LogicaGrupos().AgregarIntegranteGrupo(detGrupo);
            //}
        }
        public static bool HasNull(DataTable table)
        {
            return table.Columns.Cast<DataColumn>().Any(column => table.Rows.OfType<DataRow>().Any(r => r.IsNull(column)));
        }
        public byte[] CbToBytesA(Bitmap bitmap)
        {
            byte[] result = null;

            if (bitmap != null)
            {
                MemoryStream stream = new MemoryStream();
                bitmap.Save(stream, bitmap.RawFormat);
                result = stream.ToArray();
            }

            return result;
        }
        private void ImprimirReportes(FinancieraCredito credito)
        {
            FinancieraDS financieraDS = new FinancieraDS();
            DateTime fechapago = dtpFechaInicio.DateTime.Date;
            decimal pagoPuntual = decimal.Round(Convert.ToDecimal(txtMontoPago.EditValue), 1);
            decimal pagoAtrasado = decimal.Round(
                (pagoPuntual + (pagoPuntual * Convert.ToDecimal(txtRecargoG.EditValue))), 1);
            for (int i = 0; i < Convert.ToInt32(txtNumPlazos.EditValue); i++)
            {
                switch (cboPlazo.Text)
                {
                    case "SEMANAL":
                        financieraDS.Tables[0].Rows.Add(new object[] { null, fechapago.AddDays(7).Date, pagoPuntual, pagoAtrasado });
                        fechapago = fechapago.AddDays(7).Date;
                        break;
                    case "QUINCENAL":
                        financieraDS.Tables[0].Rows.Add(new object[] { null, fechapago.AddDays(15).Date, pagoPuntual, pagoAtrasado });
                        fechapago = fechapago.AddDays(15).Date;
                        break;
                    case "MENSUAL":
                        financieraDS.Tables[0].Rows.Add(new object[] { null, fechapago.AddMonths(1).Date, pagoPuntual, pagoAtrasado });
                        fechapago = fechapago.AddMonths(1).Date;
                        break;
                }

            }
            XrptControlPagosGrupal control = new XrptControlPagosGrupal();
            control.DataSource = financieraDS.Tables[0];
            control.DatosGrupo.DataSource = credito;
            control.MontoCredito.Value = Convert.ToDecimal(txtCantidadCredito.EditValue);
            control.DiasPago.Value = string.Format("LOS {0} DE CADA SEMANA (CON PRORROGA HASTA EL {1})", dtpFechaInicio.DateTime.ToString("dddd").ToUpper(), dtpFechaInicio.DateTime.AddDays(Convert.ToInt32(txtProrrogaG.EditValue)).ToString("dddd").ToUpper());
            //control.ShowPreviewDialog();
            control.Print(new clsModificarConfiguracion().configGetValue("ImpresoraBoletas"));
            control.Print(new clsModificarConfiguracion().configGetValue("ImpresoraBoletas"));

            foreach (DataRow fila in dtIntegrantesGrupo.Rows)
            {
                fechapago = dtpFechaInicio.DateTime.Date;
                financieraDS.Tables[1].Rows.Clear();
                financieraDS.Tables[1].AcceptChanges();
                financieraDS.Tables[1].Columns["Pago"].AutoIncrementSeed = -1;
                financieraDS.Tables[1].Columns["Pago"].AutoIncrementStep = -1;
                financieraDS.Tables[1].Columns["Pago"].AutoIncrementSeed = 1;
                financieraDS.Tables[1].Columns["Pago"].AutoIncrementStep = 1;
                for (int i = 0; i < Convert.ToInt32(txtNumPlazos.EditValue); i++)
                {
                    switch (cboPlazo.Text)
                    {
                        case "SEMANAL":
                            financieraDS.Tables[1].Rows.Add(new[] { fila[1], fila[8], fila[9], fila[3], fechapago.AddDays(7).Date, null });
                            fechapago = fechapago.AddDays(7).Date;
                            break;
                        case "QUINCENAL":
                            financieraDS.Tables[1].Rows.Add(new[] { fila[1], fila[8], fila[9], fila[3], fechapago.AddDays(15).Date, null });
                            fechapago = fechapago.AddDays(15).Date;
                            break;
                        case "MENSUAL":
                            financieraDS.Tables[1].Rows.Add(new[] { fila[1], fila[8], fila[9], fila[3], fechapago.AddMonths(1).Date, null });
                            fechapago = fechapago.AddMonths(1).Date;
                            break;
                    }
                }
                XrptControlPagosPersonal control1 = new XrptControlPagosPersonal();
                control1.DataSource = financieraDS.Tables[1];
                control1.DatosGrupo.DataSource = credito;
                control1.MontoCredito.Value = Convert.ToDecimal(txtCantidadCredito.EditValue);
                control1.DiasPago.Value = string.Format("LOS {0} DE CADA SEMANA (CON PRORROGA HASTA EL {1})", dtpFechaInicio.DateTime.ToString("dddd").ToUpper(), dtpFechaInicio.DateTime.AddDays(Convert.ToInt32(txtProrrogaG.EditValue)).ToString("dddd").ToUpper());
                control1.Print(new clsModificarConfiguracion().configGetValue("ImpresoraBoletas"));
                //financieraDS.Tables[2].Rows.Add(new[] { fila[1],CbToBytesA((Bitmap)fila[5]), CbToBytesA((Bitmap)fila[6]), CbToBytesA((Bitmap)fila[7])});
            }
            financieraDS.Tables[1].Rows.Clear();
            foreach (DataRow fila in dtIntegrantesGrupo.Rows)
            {
                financieraDS.Tables[1].Rows.Add(new[] { fila[1], fila[8], fila[9], fila[3], fechapago.AddDays(7).Date, null });
            }
            XrptHistrorialPagoPersonal historial = new XrptHistrorialPagoPersonal();
            historial.DataSource = financieraDS;
            historial.DatosGrupo.DataSource = credito;
            historial.MontoCredito.Value = Convert.ToDecimal(txtCantidadCredito.EditValue);
            historial.DiasPago.Value = dtpFechaInicio.DateTime.ToString("dddd").ToUpper();
            XRSubreport detailReport = historial.Bands[BandKind.ReportHeader].FindControl("xrSubreport1", true) as XRSubreport;
            detailReport.ReportSource.DataSource = financieraDS.Tables[1];

            //for (int i = 0; i < dtIntegrantesGrupo.Rows.Count; i++)
            //{
            historial.Print(new clsModificarConfiguracion().configGetValue("ImpresoraBoletas"));
            historial.Print(new clsModificarConfiguracion().configGetValue("ImpresoraBoletas"));
            //}
            XrptPoderCobranza poder = new XrptPoderCobranza();
            poder.DataSource = credito;
            //poder.ShowPreviewDialog();
            poder.Print(new clsModificarConfiguracion().configGetValue("ImpresoraBoletas"));
            XrptReglamento reglamento = new XrptReglamento();
            reglamento.DataSource = credito;
            reglamento.BaseLetras.Value = String.Format("{0} ({1}) ", txtBase.Text, Conversiones.NumeroALetras(txtBase.EditValue.ToString()));
            reglamento.Presidenta.Value =
                credito.FinancieraGrupo.FinancieraGruposDetalles.First(p => p.Tipo == "PRESIDENTA").FinancieraCliente.Nombre;
            reglamento.Tesorera.Value =
                credito.FinancieraGrupo.FinancieraGruposDetalles.First(p => p.Tipo == "TESORERA").FinancieraCliente.Nombre;
            reglamento.Print(new clsModificarConfiguracion().configGetValue("ImpresoraBoletas"));
            reglamento.Print(new clsModificarConfiguracion().configGetValue("ImpresoraBoletas"));
            //reglamento.ShowPreviewDialog();
            //control.Pages.AddRange(historial.Pages);
            this.oWord = new Word.Application();
            this.oWord.Visible = false;


            // Ubicación de la plantilla en el disco duro  
            oDoc = oWord.Documents.Add(Application.StartupPath + @"\Reglamento.dotx");
            oDoc.Bookmarks["Sucursal"].Range.Text = new clsModificarConfiguracion().configGetValue("Empresa");
            oDoc.Bookmarks["Direccion"].Range.Text = new clsModificarConfiguracion().configGetValue("Direccion");
            object m = System.Reflection.Missing.Value;
            object copies = 2;
            oWord.ActivePrinter = new clsModificarConfiguracion().configGetValue("ImpresoraBoletas");
            oWord.PrintOut(m, m, m, m, m, m, m, copies, m, m, m, m, m, m, m, m, m, m, m);
            object doNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
            oDoc.Close(ref doNotSaveChanges, m, m);

            //////XrptFotosGrupos fotos=new XrptFotosGrupos {DataSource = financieraDS.Tables[2]};
            ////////fotos.ShowPreviewDialog(new clsModificarConfiguracion().configGetValue("ImpresoraBoletas"));
            //////fotos.Print(new clsModificarConfiguracion().configGetValue("ImpresoraBoletas"));

        }

        public void Nuevo()
        {
            new ManejadorControles().DesectivarTextBox(gpoContenedor, true);
            new ManejadorControles().LimpiarControles(gpoContenedor);
            cboPlazo.Focus();
            dtIntegrantesGrupo.Rows.Clear();
            dtpFechaCredito.DateTime = DateTime.Today.Date;
            dtpFechaInicio.DateTime = DateTime.Today.Date;
            Financiamiento f = _entidades.Financiamientos.Single(fin => fin.Tipo == "Grupal");
            txtInteresG.EditValue = f.Interes;
            txtProrrogaG.EditValue = f.Prorroga;
            txtRecargoG.EditValue = f.Recargo;
            txtBaseG.EditValue = f.Enganche;
            cboPlazo.SelectedIndex = 0;
            txtNumPlazos.SelectedIndex = 0;
            //txtTotalAPagar.EditValue = 0;
            //txtPagoMensual.EditValue = 0;
            //throw new NotImplementedException();
            cboPlazo.Enabled = txtNumPlazos.Enabled = true;
        }

        public string nombrePantalla
        {
            get { return "Créditos"; }
        }

        private void grvIntegrantes_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            //CalcularTotalCredito();


        }

        private void CalcularTotalCredito()
        {

            decimal cantCredito = dtIntegrantesGrupo.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["Aprobado"]);
            decimal baseCredito = dtIntegrantesGrupo.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["Base"]);
            txtCantidadCredito.EditValue = cantCredito;
            txtBase.EditValue = baseCredito;
            //decimal interesPrestamo = cantCredito * Convert.ToDecimal(txtInteresG.EditValue);
            txtMontoPago.EditValue = obtenerPagoXletra();
            txtTotalCredito.EditValue = obtenerPagoXletra() * Convert.ToInt32(txtNumPlazos.EditValue);
            foreach (DataRow fila in dtIntegrantesGrupo.Rows)
            {
                decimal pagoPuntual = decimal.Round(obtenerPagoXletra(Convert.ToDecimal(fila["Aprobado"])), 1);
                decimal pagoAtrasado = decimal.Round((pagoPuntual + (pagoPuntual * Convert.ToDecimal(txtRecargoG.EditValue))), 1);
                fila["PagoPuntual"] = pagoPuntual;
                fila["PagoAtrasado"] = pagoAtrasado;
            }

        }
        decimal porcentajeInteres, interesXpago, cantidadApagar;
        private decimal obtenerPagoXletra()
        {
            if (Convert.ToInt32(txtNumPlazos.EditValue) == 0)
                return 0;
            porcentajeInteres = 0; interesXpago = 0; cantidadApagar = 0;

            switch (cboPlazo.Text)
            {
                case "SEMANAL":
                    interesXpago = Convert.ToDecimal(txtInteresG.EditValue) / 4;//.95 semanal
                    break;
                case "QUINCENAL":
                    interesXpago = Convert.ToDecimal(txtInteresG.EditValue) / 2;//1.9 semanal
                    break;
                case "MENSUAL":
                    interesXpago = Convert.ToDecimal(txtInteresG.EditValue);//3.8 semanal
                    break;
            }
            cantidadApagar = (Convert.ToDecimal(txtCantidadCredito.EditValue) * interesXpago);
            cantidadApagar += Convert.ToDecimal(txtCantidadCredito.EditValue) / Convert.ToInt32(txtNumPlazos.EditValue);
            return decimal.Round(cantidadApagar, 2);
        }
        private decimal obtenerPagoXletra(decimal cantidad)
        {
            if (Convert.ToInt32(txtNumPlazos.EditValue) == 0)
                return 0;
            porcentajeInteres = 0; interesXpago = 0; cantidadApagar = 0;

            switch (cboPlazo.Text)
            {
                case "SEMANAL":
                    interesXpago = Convert.ToDecimal(txtInteresG.EditValue) / 4;//.95 semanal
                    break;
                case "QUINCENAL":
                    interesXpago = Convert.ToDecimal(txtInteresG.EditValue) / 2;//1.9 semanal
                    break;
                case "MENSUAL":
                    interesXpago = Convert.ToDecimal(txtInteresG.EditValue);//3.8 semanal
                    break;
            }
            cantidadApagar = (cantidad * interesXpago);
            cantidadApagar += cantidad / Convert.ToInt32(txtNumPlazos.EditValue);
            return decimal.Round(cantidadApagar, 2);
        }
        private void grvIntegrantes_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            decimal baseCred = Convert.ToDecimal(dtIntegrantesGrupo.Rows[e.RowHandle]["Aprobado"]) * Convert.ToDecimal(txtBaseG.EditValue);
            dtIntegrantesGrupo.Rows[e.RowHandle]["Base"] = baseCred;
            CalcularTotalCredito();

        }

        private void FrmCreditos_Shown(object sender, EventArgs e)
        {
            Nuevo();
            Financiamiento f = _entidades.Financiamientos.Single(fin => fin.Tipo == "Grupal");
            txtInteresG.EditValue = f.Interes;
            txtProrrogaG.EditValue = f.Prorroga;
            txtRecargoG.EditValue = f.Recargo;
            txtBaseG.EditValue = f.Enganche;
            dtpFechaInicio.DateTime = DateTime.Today.Date;


        }

        private void txtNumPlazos_EditValueChanged(object sender, EventArgs e)
        {
            CalcularTotalCredito();
            int dias = 0;
            switch (cboPlazo.Text)
            {
                case "SEMANAL":
                    dias = 7 * Convert.ToInt32(txtNumPlazos.EditValue);//.95 semanal
                    dtpFechaFinal.DateTime = dtpFechaInicio.DateTime.AddDays(dias);
                    break;
                case "QUINCENAL":
                    dias = 14 * Convert.ToInt32(txtNumPlazos.EditValue);//1.9 semanal
                    dtpFechaFinal.DateTime = dtpFechaInicio.DateTime.AddDays(dias);
                    break;
                case "MENSUAL":
                    dtpFechaFinal.DateTime = dtpFechaInicio.DateTime.AddMonths(Convert.ToInt32(txtNumPlazos.EditValue));//3.8 semanal
                    break;
            }
        }

        private void cboPlazo_EditValueChanged(object sender, EventArgs e)
        {

            CalcularTotalCredito();
            int dias = 0;
            switch (cboPlazo.Text)
            {
                case "SEMANAL":
                    dias = 7 * Convert.ToInt32(txtNumPlazos.EditValue);//.95 semanal
                    dtpFechaFinal.DateTime = dtpFechaInicio.DateTime.AddDays(dias);
                    break;
                case "QUINCENAL":
                    dias = 14 * Convert.ToInt32(txtNumPlazos.EditValue);//1.9 semanal
                    dtpFechaFinal.DateTime = dtpFechaInicio.DateTime.AddDays(dias);
                    break;
                case "MENSUAL":
                    dtpFechaFinal.DateTime = dtpFechaInicio.DateTime.AddMonths(Convert.ToInt32(txtNumPlazos.EditValue));//3.8 semanal
                    break;
            }
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            if (!ClsVerificarCaja.CajaEstado())
            {
                MessageBox.Show("La Caja del Dia de hoy ya se ha cerrado\n SISTEMA BLOQUEADO", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (ClsVerificarCaja.SaldoEnCaja() >
                    ((decimal)txtCantidadCredito.EditValue))
            {
                Guardar();
            }
            else
                MessageBox.Show("Lo disponible en caja es menor a lo que desea financiar", Application.ProductName);
        }

        private void dtpFechaInicio_DateTimeChanged(object sender, EventArgs e)
        {
            int dias = 0;
            switch (cboPlazo.Text)
            {
                case "SEMANAL":
                    dias = 7 * Convert.ToInt32(txtNumPlazos.EditValue);//.95 semanal
                    dtpFechaFinal.DateTime = dtpFechaInicio.DateTime.AddDays(dias);
                    break;
                case "QUINCENAL":
                    dias = 14 * Convert.ToInt32(txtNumPlazos.EditValue);//1.9 semanal
                    dtpFechaFinal.DateTime = dtpFechaInicio.DateTime.AddDays(dias);
                    break;
                case "MENSUAL":
                    dtpFechaFinal.DateTime = dtpFechaInicio.DateTime.AddMonths(Convert.ToInt32(txtNumPlazos.EditValue));//3.8 semanal
                    break;
            }
        }

        private void BotonNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }
    }
}