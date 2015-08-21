using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Charts.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;
using SoftEmpenios.LogicaNegocios;
using SoftEmpenios.Pantallas;
using SoftEmpenios.Reportes;

namespace SoftEmpenios.Dialogos
{
    public partial class XfrmGrupo : DevExpress.XtraEditors.XtraForm, iPantalla
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        private DataTable dtIntegrantesGrupo;
        public int CveGrupo;

        public XfrmGrupo()
        {
            InitializeComponent();
            dtIntegrantesGrupo = new DataTable("Detalles");
            dtIntegrantesGrupo.Columns.Add("Clave", typeof(int));
            dtIntegrantesGrupo.Columns.Add("Nombre", typeof(string));
            dtIntegrantesGrupo.Columns.Add("Solicitado", typeof(decimal));
            dtIntegrantesGrupo.Columns.Add("Aprobado", typeof(decimal));
            dtIntegrantesGrupo.Columns.Add("Base", typeof(decimal));
            dtIntegrantesGrupo.Columns.Add("Tipo", typeof(string));
            //dtIntegrantesGrupo.Columns.Add("Image1", typeof(Image));
            //dtIntegrantesGrupo.Columns.Add("Image2", typeof(Image));
            //dtIntegrantesGrupo.Columns.Add("Image3", typeof(Image));

            gridIntegrantes.DataSource = dtIntegrantesGrupo;
            grvIntegrantes.Columns[2].ColumnEdit = repSolicitado;
            grvIntegrantes.Columns[3].ColumnEdit = repAprobado;//txtAprobado;
            grvIntegrantes.Columns[4].ColumnEdit = txtBase;
            grvIntegrantes.Columns[5].ColumnEdit = cboTipo;
            //grvIntegrantes.Columns[5].ColumnEdit = imgUno;
            //grvIntegrantes.Columns[6].ColumnEdit = imgDos;
            //grvIntegrantes.Columns[7].ColumnEdit = imgTres;
            grvIntegrantes.Columns[0].OptionsColumn.AllowEdit = false;
            grvIntegrantes.Columns[1].OptionsColumn.AllowEdit = false;
            grvIntegrantes.Columns["Base"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Base", "Total Base={0:$ #,##0.00}");
            grvIntegrantes.Columns["Aprobado"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Aprobado", "Total={0:$ #,##0.00}");
            grvIntegrantes.Columns["Nombre"].Summary.Add(DevExpress.Data.SummaryItemType.Count, "Nombre", "Integrantes={0}");

            grvIntegrantes.Columns[0].BestFit();
            grvIntegrantes.Columns[1].Width = 200;
            grvIntegrantes.Columns[3].Width = 150;
            grvIntegrantes.Columns[4].Width = 150;
        }
        #region Metodos Heredados iPantalla
        public void Buscar()
        {
            //throw new NotImplementedException();
        }

        public void Eliminar()
        {
            //throw new NotImplementedException();
        }

        private bool ChecarCantidad()
        {
            foreach (DataRow row in dtIntegrantesGrupo.Rows)
            {


                if ((int)txtCveGrupo.EditValue == 0)
                {
                    if ((decimal) row["Aprobado"] > 5000)
                    {
                        XtraMessageBox.Show("Este es un grupo nuevo no puede otorgar mas de $ 5,000.00");
                        return false;
                    }
                }
                else
                {
                    int numCre =
                        _entidades.FinancieraCreditos.Count(
                            c => c.CveGrupo == Convert.ToInt32(txtCveGrupo.EditValue) && c.Estado != "Cancelado");
                    switch (numCre)
                    {
                        case 0:
                            if ((decimal) row["Aprobado"] > 5000)
                            {
                                XtraMessageBox.Show("Este es un grupo nuevo no puede otorgar mas de $ 5,000.00");
                                return false;
                            }
                            break;
                        case 1:
                            if ((decimal)row["Aprobado"] > 1000)
                            {
                                XtraMessageBox.Show("Este es su segundo crédito no puede otorgar mas de $ 10,000.00");
                            return false;
                                }
                            break;
                        case 2:
                            if ((decimal) row["Aprobado"] > 15000)
                            {
                                XtraMessageBox.Show("Este es es su tercer crédito no puede otorgar mas de $ 15,000.00");
                                return false;
                            }
                            break;
                    }
                }
            }
            return true;
        }

        public void Guardar()
        {
            //if (!ChecarCantidad())
            //    return;
            if ((int)txtCveGrupo.EditValue == 0)
            {
                FinancieraGrupo grupo = new FinancieraGrupo()
                {
                    Nombre = txtNombreGrupo.Text,
                    Estado = "PROCESO",
                    FechaModificacion = DateTime.Today,
                    CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IdUsuarioApp")),
                };
                txtCveGrupo.EditValue = new LogicaGrupos().AgregarGrupo(grupo);
                foreach (DataRow fila in dtIntegrantesGrupo.Rows)
                {
                    FinancieraGruposDetalle detGrupo = new FinancieraGruposDetalle()
                    {
                        CveGrupo = Convert.ToInt32(txtCveGrupo.EditValue),
                        CveCliente = Convert.ToInt32(fila[0]),
                        Solicitado = Convert.ToDecimal(fila[2]),
                        Aprobado = 0M,
                        Base = 0M,
                        Tipo = fila[5].ToString(),
                        FechaModificacion = DateTime.Today.Date,
                    };
                    new LogicaGrupos().AgregarIntegranteGrupo(detGrupo);
                }
                cboEstado.Text = "PROCESO";
            }
            else
            {
                FinancieraGrupo grupomod = _entidades.FinancieraGrupos.First(g => g.Clave == Convert.ToInt32(txtCveGrupo.EditValue));
                //FinancieraGrupo grupo = new FinancieraGrupo()
                //{
                //    Clave = grupomod.Clave,
                //    Nombre = txtNombreGrupo.Text,
                //    Estado = cboEstado.Text,
                //    FechaModificacion = DateTime.Today,
                //    CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IdUsuarioApp")),
                //};
                //new LogicaGrupos().ActualizarGrupo(grupo, grupomod);
                grupomod.Nombre = txtNombreGrupo.Text;
                grupomod.Estado = cboEstado.Text;
                grupomod.CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IdUsuarioApp"));
                _entidades.SubmitChanges();
                new LogicaGrupos().EliminarDetalles(grupomod.Clave);
                foreach (DataRow fila in dtIntegrantesGrupo.Rows)
                {
                    FinancieraGruposDetalle detGrupo = new FinancieraGruposDetalle()
                    {
                        CveGrupo = Convert.ToInt32(txtCveGrupo.EditValue),
                        CveCliente = Convert.ToInt32(fila[0]),
                        Solicitado = Convert.ToDecimal(fila[2]),
                        Aprobado = Convert.ToDecimal(fila[3]),
                        Base = Convert.ToDecimal(fila[4]),
                        Tipo = fila[5].ToString(),
                        FechaModificacion = DateTime.Today.Date,
                    };
                    new LogicaGrupos().AgregarIntegranteGrupo(detGrupo);
                }
                if (grvIntegrantes.Columns["Base"].Visible)
                    btnImprimirDeposito.Enabled = true;
            }
            btnImprimirSocioEconomico.Enabled = true;
            
        }

        public void Nuevo()
        {
            new ManejadorControles().LimpiarControles(gpoContenedor);
            dtIntegrantesGrupo.Rows.Clear();
            txtNombreGrupo.Focus();
            btnAgregarIntegrante.Enabled = true;
            btnNuevoIntegrante.Enabled = true;
            gridIntegrantes.Enabled = true;
        }

        public string nombrePantalla
        {

            get
            {
                return "Grupos Financiera";
            }
        }
        #endregion

        private void btnNuevoIntegrante_Click(object sender, EventArgs e)
        {
            XfrmClientesFinanciera cli = new XfrmClientesFinanciera();
            cli.EventDevolverClave += ClienteDevuelto;
            cli.ShowDialog(this);
            cli.EventDevolverClave -= ClienteDevuelto;
            cli.Close();
        }

        private void ClienteDevuelto(int clave)
        {
            FinancieraCliente cli = _entidades.FinancieraClientes.First(cl => cl.Clave == clave);
            if (dtIntegrantesGrupo.Rows.Cast<DataRow>().Any(fila => (int)fila[0] == cli.Clave))
            {
                XtraMessageBox.Show(cli.Nombre + "\n Ya se encuentra en la lista del grupo", "Validando Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            IQueryable<FinancieraGruposDetalle> detgrupo =
                _entidades.FinancieraGruposDetalles.Where(
                    dg => dg.CveCliente == cli.Clave && dg.CveGrupo != Convert.ToInt32(txtCveGrupo.EditValue));
            if (detgrupo.Any())
            {
                XtraMessageBox.Show(cli.Nombre + "\n Ya es parte de un grupo no puede agregarlo en este", "Validando Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dtIntegrantesGrupo.Rows.Add(new object[] { cli.Clave, cli.Nombre, cli.Ingresos, 0, 0 });
        }
        private void ClienteDevuelto(string clave)
        {
            FinancieraCliente cli = _entidades.FinancieraClientes.First(cl => cl.Clave == Convert.ToInt32(clave));
            if (dtIntegrantesGrupo.Rows.Cast<DataRow>().Any(fila => (int)fila[0] == cli.Clave))
            {
                XtraMessageBox.Show(cli.Nombre + "\n Ya se encuentra en la lista del grupo", "Validando Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            IQueryable<FinancieraGruposDetalle> detgrupo =
                _entidades.FinancieraGruposDetalles.Where(
                    dg => dg.CveCliente == cli.Clave && dg.CveGrupo != Convert.ToInt32(txtCveGrupo.EditValue));
            if (detgrupo.Any())
            {
                if (Enumerable.Any(detgrupo, det => det.FinancieraGrupo.Estado != "INACTIVO"))
                {
                    XtraMessageBox.Show(cli.Nombre + "\n Ya es parte de un grupo  no puede agregarlo en este", "Validando Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Enumerable.Any(detgrupo, det => det.FinancieraGrupo.Estado == "INACTIVO"))
                {
                    if (
                        XtraMessageBox.Show(
                            cli.Nombre +
                            "\n Ya es parte de un grupo desea incluirlo en este\nSe Borrara Automaticamente del grupo Anterior",
                            "Validando Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _entidades.FinancieraGruposDetalles.DeleteOnSubmit(detgrupo.Single(d => d.CveCliente == cli.Clave));
                    }
                    else
                    {
                        return;
                    }
                }
            }
            dtIntegrantesGrupo.Rows.Add(new object[] { cli.Clave, cli.Nombre, 0, 0, 0 });
        }

        private void btnAgregarIntegrante_Click(object sender, EventArgs e)
        {
            FrmBuscar buscRef = new FrmBuscar();
            buscRef.CriteriosDeBusqueda("ClientesFinanciera");
            buscRef.DevolverString += ClienteDevuelto;
            buscRef.ShowDialog(this);
            buscRef.DevolverString += ClienteDevuelto;
            buscRef.Close();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void XfrmGrupo_Shown(object sender, EventArgs e)
        {
            if (CveGrupo == 0)
            {
                Nuevo();
                grvIntegrantes.Columns[3].Visible = false;
                grvIntegrantes.Columns[4].Visible = false;
                btnImprimirDeposito.Enabled = false;
            }
            else
            {
                FinancieraGrupo grupo = _entidades.FinancieraGrupos.First(g => g.Clave == CveGrupo);
                txtCveGrupo.EditValue = grupo.Clave;
                txtNombreGrupo.EditValue = grupo.Nombre;
                cboEstado.EditValue = grupo.Estado == "INACTIVO" ? "PROCESO" : grupo.Estado;
                foreach (FinancieraGruposDetalle detgpo in grupo.FinancieraGruposDetalles)
                {
                    dtIntegrantesGrupo.Rows.Add(new object[] { detgpo.CveCliente, detgpo.FinancieraCliente.Nombre, detgpo.Solicitado, detgpo.Aprobado, detgpo.Base, detgpo.Tipo });
                }
                //grvIntegrantes.Columns[2].OptionsColumn.AllowEdit = false;
                grvIntegrantes.Columns[4].OptionsColumn.AllowEdit = false;
                if (grupo.Estado == "ACTIVO" || grupo.Estado == "APROBADO")
                {
                    botonGuardar.Enabled = false;
                    btnImprimirDeposito.Enabled = false;
                }
            }
        }

        private void botonNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void grvIntegrantes_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            decimal porcBase = (decimal)_entidades.Financiamientos.Single(fin => fin.Tipo == "Grupal").Enganche;
            decimal baseCred = Convert.ToDecimal(dtIntegrantesGrupo.Rows[e.RowHandle]["Aprobado"]) * porcBase;
            dtIntegrantesGrupo.Rows[e.RowHandle]["Base"] = baseCred;
        }

        private void editarDatosIntegrante_Click(object sender, EventArgs e)
        {
            if (grvIntegrantes.FocusedRowHandle < 0) return;
            XfrmClientesFinanciera cli = new XfrmClientesFinanciera();
            cli.ClienteDevuelto(grvIntegrantes.GetFocusedRowCellValue("Clave").ToString());
            cli.ShowDialog(this);

            cli.Close();
        }

        private void eliminarDelGrupo_Click(object sender, EventArgs e)
        {
            if (grvIntegrantes.FocusedRowHandle < 0) return;
            if (
                XtraMessageBox.Show(
                    "Eliminar Integrante del Grupo. \x00bfConfirme si desea eliminar al integrante selecionado",
                    "SoftEmpeños", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.Yes)
            {
                //FinancieraGruposDetalle detgpo=_entidades.FinancieraGruposDetalles
                //    .SingleOrDefault(dg => dg.CveGrupo == CveGrupo && dg.CveCliente == Convert.ToInt32(grvIntegrantes.GetFocusedRowCellValue("Clave")));
                //if (detgpo!=null)
                //    _entidades.FinancieraGruposDetalles.DeleteOnSubmit(detgpo);
                //    _entidades.SubmitChanges();
                dtIntegrantesGrupo.Rows.Remove(dtIntegrantesGrupo.Rows[grvIntegrantes.FocusedRowHandle]);

            }
        }

        private void btnImprimirSocioEconomico_Click(object sender, EventArgs e)
        {
            FinancieraGrupo grupo = _entidades.FinancieraGrupos.First(g => g.Clave == Convert.ToInt32(txtCveGrupo.EditValue));
            XrptSocioEconomico rptEconomico = new XrptSocioEconomico { DatosInforme = { DataSource = grupo } };
            rptEconomico.ShowPreviewDialog();
        }
        public static bool HasEmnty(DataTable table)
        {
            return table.Columns.Cast<DataColumn>().Any(column => table.Rows.OfType<DataRow>().Any(r => r.IsNull(column)));
        }
        private void btnImprimirDeposito_Click(object sender, EventArgs e)
        {
            if (dtIntegrantesGrupo.Rows.Cast<DataRow>().Any(f => Convert.ToDecimal(f["Aprobado"])==0))
            {
                XtraMessageBox.Show("Indique el monto a aprobar " , "Indicar Monto Aprobado");
                return;
            }
            if (dtIntegrantesGrupo.Rows.Cast<DataRow>().Any(f => String.IsNullOrEmpty( f["Tipo"].ToString())))
            {
                XtraMessageBox.Show("Indique que cargo tendra el integrante", "Eligir Tipo");
                return;
            }
            if (dtIntegrantesGrupo.Rows.Cast<DataRow>().Count(f => Convert.ToString(f["Tipo"]) == "PRESIDENTA")==0)
            {
                XtraMessageBox.Show("Indique quien sera la presidenta ", "Indicar Monto Aprobado");
                return;
            }
            if (dtIntegrantesGrupo.Rows.Cast<DataRow>().Count(f => Convert.ToString(f["Tipo"]) == "TESORERA") == 0)
            {
                XtraMessageBox.Show("Indique quien sera la Tesorera ", "Indicar Monto Aprobado");
                return;
            }
            if (dtIntegrantesGrupo.Rows.Cast<DataRow>().Count(f => Convert.ToString(f["Tipo"]) == "PRESIDENTA") >1)
            {
                XtraMessageBox.Show("No puede haber mas de una Presidenta ", "Indicar Monto Aprobado");
                return;
            }
            if (dtIntegrantesGrupo.Rows.Cast<DataRow>().Count(f => Convert.ToString(f["Tipo"]) == "TESORERA") > 1)
            {
                XtraMessageBox.Show("No puede haber mas de una Tesorera ", "Indicar Monto Aprobado");
                return;
            }

            if (
                XtraMessageBox.Show(
                    "Aprobar grupo. \x00bfConfirme si desea aprobar el grupo para otorgar el credito\nUna vez aprobado el grupo no se podra modificar\nSe hara un deposito de la base",
                    "SoftEmpeños", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.Yes)
            {
                cboEstado.EditValue = "APROBADO";
                Guardar();
                decimal baseCredito = dtIntegrantesGrupo.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["Base"]);
                Transaccione tran = new Transaccione
                {
                    CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioAPP")),
                    FechaTransaccion = DateTime.Today.Date,
                    TipoTransaccion = "Base",
                    Cantidad = baseCredito,
                    Concepto = string.Format("DEPOSITO DE BASE DEL GRUPO {0}-{1} PARA OTORGAR CREDITO",txtCveGrupo.Text ,txtNombreGrupo.Text),
                    Estado = true
                };

                new LogicaTransacciones().AgregarTransaccion(tran);
                ImprimirTikets(tran.Clave, tran.Concepto, tran.Cantidad);
                new ManejadorControles().DesectivarTextBox(gpoContenedor, true);
                gridIntegrantes.Enabled = false;
                btnImprimirDeposito.Enabled = false;
                botonGuardar.Enabled = false;
                btnAgregarIntegrante.Enabled = false;
                btnNuevoIntegrante.Enabled = false;

            }
        }

        private void ImprimirTikets(int clave, string concepto, decimal cantidad)
        {
            Configuracione empre = new EmpeñosDC(new clsConeccionDB().StringConn()).Configuraciones.First();

            string empresa = new clsModificarConfiguracion().configGetValue("Empresa");
            string razonSocial = new clsModificarConfiguracion().configGetValue("RazonSocial");
            string rfc = new clsModificarConfiguracion().configGetValue("RFC");
            string curp = new clsModificarConfiguracion().configGetValue("CURP");
            string dirc = String.Format("{0} CP {1} {2}", empre.Direccion, empre.CodigoPostal, empre.Municipio);

            int padRe = ((40 - empresa.Length) / 2) + empresa.Length;
            int padRrs = ((40 - razonSocial.Length) / 2) + razonSocial.Length;
            int padRrfc = ((40 - rfc.Length) / 2) + rfc.Length;
            int padRcurp = ((40 - curp.Length) / 2) + curp.Length;


            Ticket ticket = new Ticket(2);
            ticket.AddHeaderLine("            CASA  DE  EMPEÑOS           ");
            ticket.AddHeaderLine("                                        ");
            ticket.AddHeaderLine(empresa.PadLeft(padRe));
            ticket.AddHeaderLine(razonSocial.PadLeft(padRrs));
            ticket.AddHeaderLine(rfc.PadLeft(padRrfc));
            ticket.AddHeaderLine(curp.PadLeft(padRcurp));
            if (dirc.Length > 40)
            {
                int currentChar = 0;
                int itemLenght = dirc.Length;

                while (itemLenght > 40)
                {
                    ticket.AddHeaderLine(dirc.Substring(currentChar, 40));
                    currentChar += 40;
                    itemLenght -= 40;
                }
                ticket.AddHeaderLine(dirc.Substring(currentChar));

            }
            else
            {
                ticket.AddHeaderLine(dirc);
            }
            ticket.AddHeaderLine("           TICKET DE DEPOSITO");

            ticket.AddSubHeaderLine("CLAVE: " + clave);
            ticket.AddSubHeaderLine("REALIZO: " + new clsModificarConfiguracion().configGetValue("UsuarioAPP"));
            ticket.AddSubHeaderLine(String.Format("FECHA: {0} {1}", DateTime.Today.ToString("dd/MMM/yyyy").ToUpper(), DateTime.Now.ToShortTimeString()));
            string[] lineas = concepto.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var linea in lineas)
            {
                ticket.AddItem("", linea, "");
            }
            //ticket.AddItem("", txtConcepto.Text, "");
            ticket.AddTotal("CANTIDAD:", cantidad.ToString("$ #,##0.00"));
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("________________________________________");
            ticket.AddFooterLine("                AUTORIZO                ");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");

            ticket.PrintTicket(new clsModificarConfiguracion().configGetValue("ImpresoraTickets"));
        }

        private void btnAprobado_Click(object sender, EventArgs e)
        {
            //grvIntegrantes.SetRowCellValue(grvIntegrantes.FocusedRowHandle, "Aprobado", Convert.ToDecimal(txtCantidadAprobada.EditValue));
            dtIntegrantesGrupo.Rows[grvIntegrantes.FocusedRowHandle]["Aprobado"] =
              Convert.ToDecimal(txtCantidadAprobada.EditValue);
            decimal porcBase = (decimal)_entidades.Financiamientos.Single(fin => fin.Tipo == "Grupal").Enganche;
            decimal baseCred = Convert.ToDecimal(dtIntegrantesGrupo.Rows[grvIntegrantes.FocusedRowHandle]["Aprobado"]) * porcBase;
            dtIntegrantesGrupo.Rows[grvIntegrantes.FocusedRowHandle]["Base"] = baseCred;
            popupContainerControl1.OwnerEdit.ClosePopup();
            SendKeys.Send("{TAB}");
        }

        private void repAprobado_Popup(object sender, EventArgs e)
        {
            txtCantidadAprobada.EditValue = Convert.ToDecimal(grvIntegrantes.GetFocusedRowCellValue("Aprobado"));
            popupContainerControl1.SelectNextControl(txtCantidadAprobada, true, true, true, true);
        }

        private void grvIntegrantes_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            }

        private void repAprobado_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void repSolicitado_Popup(object sender, EventArgs e)
        {
            txtCantidadSolicitada.EditValue = Convert.ToDecimal(grvIntegrantes.GetFocusedRowCellValue("Solicitado"));
            popupContainerControl2.SelectNextControl(txtCantidadSolicitada, true, true, true, true);
        }

        private void btnSolicitado_Click(object sender, EventArgs e)
        {
            dtIntegrantesGrupo.Rows[grvIntegrantes.FocusedRowHandle]["Solicitado"] =
             Convert.ToDecimal(txtCantidadSolicitada.EditValue);
            popupContainerControl2.OwnerEdit.ClosePopup();
            SendKeys.Send("{TAB}");
        }

        private void grvIntegrantes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                GridView gridView = sender as GridView;
                int rowHandle = gridView.FocusedRowHandle;
                GridColumn column = gridView.FocusedColumn;
                if (rowHandle < gridView.RowCount - 1)
                {
                    rowHandle++;
                }
                else
                {
                    rowHandle = 0;
                    if (column.VisibleIndex < gridView.VisibleColumns.Count - 1)
                        column = gridView.VisibleColumns[gridView.FocusedColumn.VisibleIndex + 1];
                    else
                        column = gridView.VisibleColumns[0];
                }
                gridView.FocusedColumn = column;
                gridView.FocusedRowHandle = rowHandle;
                e.Handled = true;
            }
        }
    }
}