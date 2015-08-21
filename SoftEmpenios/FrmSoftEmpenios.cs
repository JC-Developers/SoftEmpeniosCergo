using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data.Linq.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;
using SoftEmpenios.Dialogos;
using SoftEmpenios.Pantallas;
using SoftEmpenios.Reportes;

namespace SoftEmpenios
{
    public partial class FrmSoftEmpenios : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private iPantalla _pantallaActual;
        public FrmSoftEmpenios()
        {
            InitializeComponent();
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.softempeos25).Assembly);
            //DevExpress.UserSkins.BonusSkins.Register();
            //SkinHelper.InitSkinGallery(galeriaTemas, true);
            //SkinHelper.InitSkinPopupMenu(popupMenu1);

            defaultLookAndFeel1.LookAndFeel.SkinName = "TemaRojo";
        }
        public void MostrarPantalla(Form pantalla)
        {
            if (VerificarLogeo())
            {
                if (_pantallaActual != null)
                {
                    ((IDisposable)_pantallaActual).Dispose();
                }
                _pantallaActual = (iPantalla)pantalla;
                if (pantalla != null)
                {
                    pantalla.MdiParent = this;
                    pantalla.Dock = DockStyle.Fill;
                    pantalla.Show();
                }
            }
        }
        private void vtnEmpenios_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarPantalla(new FrmBoletas());
        }

        private void vtnConfiguracion_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmConfiguraciones config = new FrmConfiguraciones();
            config.ShowDialog(this);
        }

        private void FrmSoftEmpenios_Shown(object sender, EventArgs e)
        {
            new clsModificarConfiguracion().configSetValue("IDUsuarioApp", "");
            new clsModificarConfiguracion().configSetValue("UsuarioApp", "");
            new clsModificarConfiguracion().configSetValue("ContraseniaApp", "");
            new clsModificarConfiguracion().configSetValue("PermisosApp", "");
            VerificarLogeo();
        }
        private bool VerificarLogeo()
        {
            string str = new clsModificarConfiguracion().configGetValue("IDUsuarioApp");
            string str2 = new clsModificarConfiguracion().configGetValue("UsuarioApp");
            if ((str == "") && (str2 == ""))
            {
                new FrmIniciarSesion().ShowDialog(this);
                txtUsuarioLogueado.Caption = "Usuario: " + new clsModificarConfiguracion().configGetValue("UsuarioApp");
                HabilitarPermisos();
                return false;
            }
            HabilitarPermisos();
            return true;
            
        }

        private void HabilitarPermisos()
        {
            switch (new clsModificarConfiguracion().configGetValue("PermisosApp"))
            {
                case "Usuario":
                    pageSistema.Visible = false;
                    pageHerramientas.Visible = false;
                    vtnBoletasAtrasadas.Enabled = false;
                    pageReportes.Visible = true;
                    gpoReportesEspeciales.Visible = false;
                    break;
                case "Gerente":
                     pageSistema.Visible = true;
                    pageHerramientas.Visible = true;
                    vtnConfiguracion.Enabled = false;
                    vtnUsuarios.Enabled = false;rptEmpeñosVigentes.Enabled = false;
                    vtnCancelaciones.Enabled = true;
                    botonInventario.Enabled = true;
                    vtnRestaurar.Enabled = false;
                    vtnBoletasAtrasadas.Enabled = false;
                    pageReportes.Visible = true;
                    gpoReportesEspeciales.Visible = true;
                    rptEmpeñosVigentes.Enabled = false;
                    rptFinanciamientosActivos.Enabled = false;
                    rptCreditosVigentes.Enabled = false;
                    break;
                case "Administrador":
                     pageSistema.Visible = true;
                    pageHerramientas.Visible = true;
                    vtnConfiguracion.Enabled = true;
                    vtnUsuarios.Enabled = true;
                    rptEmpeñosVigentes.Enabled = true;
                    vtnCancelaciones.Enabled = true;
                    botonInventario.Enabled = true;
                    vtnRestaurar.Enabled = true;
                    vtnBoletasAtrasadas.Enabled = true;
                    pageReportes.Visible = true;
                    gpoReportesEspeciales.Visible = true;
                    rptEmpeñosVigentes.Enabled = true;
                    rptFinanciamientosActivos.Enabled = true;
                    rptCreditosVigentes.Enabled = true;
                    break;
                default:
                     pageSistema.Visible = false;
                    pageHerramientas.Visible = false;
                    pageReportes.Visible = false;
                
                    break;

            }
        }

        private void vtnInteres_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarPantalla(new FrmPagosInteres());
        }

        private void vtnDesempenio_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarPantalla(new FrmPagoDesempeño());
        }

        private void vtnCompras_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarPantalla(new FrmCompras());
        }

        private void vtnTransacciones_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTransaccion transaccion = new FrmTransaccion();
            transaccion.ShowDialog(this);
        }

        private void vtnBoletasAtrasadas_ItemClick(object sender, ItemClickEventArgs e)
        {
            
                MostrarPantalla(new FrmEmpeñosAtrasadas());
            
        }

        private void vtnCaja_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarPantalla(new FrmCaja());
        }

        private void vtnArticulos_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarPantalla(new FrmArticulos());
        }

        private void vtnVentas_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarPantalla(new FrmVentas());
        }

        private void vtnAbonos_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarPantalla(new FrmAbonosVenta());
        }

        private void vtnFinanciamiento_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarPantalla(new FrmFinanciamiento());
        }

        private void vtnPagosFinanciamientos_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarPantalla(new FrmPagosFinanciamiento());
        }

        private void vtnClientesAtrasados_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarPantalla(new FrmFinanciamientosAtrasados());
        }

        private void vtnUsuarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUsuarios usuarios = new FrmUsuarios();
            usuarios.ShowDialog(this);
        }

        private void vtnIniciarSesión_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FrmIniciarSesion().ShowDialog(this);
            txtUsuarioLogueado.Caption = "Usuario: " + new clsModificarConfiguracion().configGetValue("UsuarioApp");
            HabilitarPermisos();
        }

        private void vtnNuevo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_pantallaActual != null)
                _pantallaActual.Nuevo();
        }

        private void vtnBuscar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_pantallaActual != null)
                _pantallaActual.Buscar();
        }

        private void vtnCancelaciones_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FrmCancelaciones().ShowDialog(this);
        }
        #region Respaldo y restauracion
        private void vtnRespaldar_ItemClick(object sender, ItemClickEventArgs e)
        {
            string rutaresplado = DialogoSaveFile();
            if (rutaresplado == string.Empty)
                return;
            Cursor = Cursors.WaitCursor;
            proRestoreBackup.Caption = "Respaldando";
            proRestoreBackup.Visibility = BarItemVisibility.Always;
            BackupDataBase(new clsModificarConfiguracion().configGetValue("BasedeDatos"), rutaresplado);
            Cursor = Cursors.Default;
        }

        private void vtnRestaurar_ItemClick(object sender, ItemClickEventArgs e)
        {
            string rutaresplado = DialogoOpenFile();
            if (rutaresplado == string.Empty)
                return;
            Cursor = Cursors.WaitCursor;
            proRestoreBackup.Caption = "Restaurando";
            proRestoreBackup.Visibility = BarItemVisibility.Always;
            RestoreDataBase(rutaresplado, new clsModificarConfiguracion().configGetValue("BasedeDatos"), GetServer().Information.RootDirectory + @"\Data", new clsModificarConfiguracion().configGetValue("BasedeDatos"), new clsModificarConfiguracion().configGetValue("BasedeDatos") + "_log");
            Cursor = Cursors.Default;
        }
        private static Server GetServer()
        {
            clsModificarConfiguracion configuracion = new clsModificarConfiguracion();
            string serverInstance = configuracion.configGetValue("ServidorDB");

            string userName = configuracion.configGetValue("UsuarioDB");
            string password = configuracion.configGetValue("ContraseniaDB");
            return new Server(new ServerConnection(serverInstance, userName, password));
        }
        public void BackupDataBase(string databaseName, string destinationPath)
        {
            Server srv = GetServer();
            Backup backup = new Backup
            {
                Action = BackupActionType.Database,
                Database = databaseName
            };
            try
            {
                destinationPath = Path.Combine(destinationPath, databaseName + ".bak");
                backup.Devices.Add(new BackupDeviceItem(destinationPath, DeviceType.File));
                backup.Initialize = true;
                backup.Checksum = true;
                backup.ContinueAfterError = true;
                backup.Incremental = false;
                backup.LogTruncation = BackupTruncateLogType.Truncate;
                backup.PercentCompleteNotification = 5;
                backup.PercentComplete += Progreso_PercentComplete;
                backup.Complete += Progreso_Complete;
                backup.SqlBackup(srv);
            }
            catch (SqlException sqlex)
            {
                XtraMessageBox.Show(sqlex.Message, "Respaldando Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error al Respaldar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void RestoreDataBase(string backupFilePath, string destinationDatabaseName, string databaseFolder, string databaseFileName, string databaseLogFileName)
        {
            try
            {
                Server srv = GetServer();
                Restore restore = new Restore { Database = destinationDatabaseName, Action = RestoreActionType.Database };
                Database database = srv.Databases[destinationDatabaseName];

                if (database != null)
                {
                    srv.KillAllProcesses(destinationDatabaseName);
                    string primaryFilePath = database.PrimaryFilePath;
                    if (backupFilePath != null) restore.Devices.AddDevice(backupFilePath, DeviceType.File);
                    DataTable datosbackup = restore.ReadFileList(srv);
                    restore.ReplaceDatabase = true;

                    //restore.NoRecovery = true;

                    string physicalFileName = String.Format(@"{0}\{1}.mdf", primaryFilePath, destinationDatabaseName);
                    string str3 = String.Format(@"{0}\{1}_log.ldf", primaryFilePath, destinationDatabaseName);
                    restore.RelocateFiles.Add(new RelocateFile(datosbackup.Rows[0][0].ToString(), physicalFileName));
                    restore.RelocateFiles.Add(new RelocateFile(datosbackup.Rows[1][0].ToString(), str3));
                }

                //restore.ReplaceDatabase = true;
                restore.PercentCompleteNotification = 5;
                restore.PercentComplete += Progreso_PercentComplete;
                restore.Complete += Progreso_Complete;
                restore.SqlRestore(srv);
                srv.Databases[destinationDatabaseName].SetOnline();
                srv.Databases[destinationDatabaseName].Refresh();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static string DialogoOpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "SQLBackup Files (*.bak) | *.bak"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return "";
        }

        private static string DialogoSaveFile()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            //Server server = GetServer();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.SelectedPath;
            }
            return "";
        }
        public void Progreso_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            proRestoreBackup.EditValue = e.Percent;
        }
        public void Progreso_Complete(object sender, ServerMessageEventArgs e)
        {
            if (proRestoreBackup.Caption != "Respaldando")
            {
                Form[] child = MdiChildren;
                foreach (Form frm in child)
                {
                    frm.Close();
                }
            }
            MessageBox.Show(proRestoreBackup.Caption == "Respaldando"
                                ? "Respaldo de base de datos finalizado con éxito"
                                : "Restauración de base de datos finalizado con éxito");
            proRestoreBackup.EditValue = 0;
            proRestoreBackup.Visibility = BarItemVisibility.Never;
        }
        #endregion
        #region reportes sistema
        private void rptEmpeños_ItemClick(object sender, ItemClickEventArgs e)
        {
            var bol = new EmpeñosDC(new clsConeccionDB().StringConn()).Boletas.Where(b => b.FechaPrestamo == DateTime.Today && b.EstadoBoleta != "Cancelado");
            if (bol.Any())
            {
                XrptEmpeñosDia rptbol = new XrptEmpeñosDia { DataSource = bol };
                rptbol.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
        }

        private void rptIntereses_ItemClick(object sender, ItemClickEventArgs e)
        {
            var inte = new EmpeñosDC(new clsConeccionDB().StringConn()).PagosInteres.Where(b => b.FechaPago == DateTime.Today && b.Estado == true);
            if (inte.Any())
            {
                XrptInteresesDia rptbol = new XrptInteresesDia { DataSource = inte };
                rptbol.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");

        }

        private void rptDesempenios_ItemClick(object sender, ItemClickEventArgs e)
        {
            var des = new EmpeñosDC(new clsConeccionDB().StringConn()).Desempeños.Where(b => b.FechaDesempeño == DateTime.Today && b.Estado == true);
            if (des.Any())
            {
                XrptDesempeniosDia rptbol = new XrptDesempeniosDia { DataSource = des };
                rptbol.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");

        }

        private void rptCompras_ItemClick(object sender, ItemClickEventArgs e)
        {
            var com = new EmpeñosDC(new clsConeccionDB().StringConn()).Compras.Where(b => b.FechaCompra == DateTime.Today && b.Estado == true);
            if (com.Any())
            {
                XrptComprasDia rptbol = new XrptComprasDia { DataSource = com };
                rptbol.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");

        }

        private void rptDepositos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dep = new EmpeñosDC(new clsConeccionDB().StringConn()).Transacciones.Where(b => b.TipoTransaccion == "Deposito" && b.FechaTransaccion == DateTime.Today && b.Estado == true);
            if (dep.Any())
            {
                XrptTransaccionesXDia rptbol = new XrptTransaccionesXDia
                {
                    DataSource = dep,
                    TipoTransaccion = { Value = "Depositos" }
                };
                rptbol.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
        }

        private void rptRetiros_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dep = new EmpeñosDC(new clsConeccionDB().StringConn()).Transacciones.Where(b => b.TipoTransaccion == "Retiro" && b.FechaTransaccion == DateTime.Today && b.Estado == true);
            if (dep.Any())
            {
                XrptTransaccionesXDia rptbol = new XrptTransaccionesXDia
                {
                    DataSource = dep,
                    TipoTransaccion = { Value = "Retiros" }
                };
                rptbol.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
        }

        private void rptCancelaciones_ItemClick(object sender, ItemClickEventArgs e)
        {
            var canc = new EmpeñosDC(new clsConeccionDB().StringConn()).Cancelaciones.Where(
                                    v => v.FechaCancelacion == DateTime.Today.Date);
            if (canc.Any())
            {
                XrptCancelaciones articulos = new XrptCancelaciones { DataSource = canc };
                articulos.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No hay suficientes datos para mostrar el reporte", "Registros 0");
        }
        private void rptEtiquetas_ItemClick(object sender, ItemClickEventArgs e)
        {
            var cod = new EmpeñosDC(new clsConeccionDB().StringConn()).Boletas.Where(b => b.FechaPrestamo == DateTime.Today.Date);
            if (cod.Any())
            {
                XrptCodigoBarras rptbol = new XrptCodigoBarras { DataSource = cod };
                rptbol.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
        }

        private void rptIngresos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var art = new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(
                                    v => v.FechaRegistro == DateTime.Today.Date && v.Estado != "Baja");
            if (art.Any())
            {
                XrptIngresoArticulos articulos = new XrptIngresoArticulos { DataSource = art };
                articulos.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No hay suficientes datos para mostrar el reporte", "Registros 0");
        }

        private void rptVentas_ItemClick(object sender, ItemClickEventArgs e)
        {
            var vent = new EmpeñosDC(new clsConeccionDB().StringConn()).Ventas.Where(
                                    v => v.FechaVenta == DateTime.Today.Date && v.Estado != "Cancelado");
            if (vent.Any())
            {
                XrptVentasDia articulos = new XrptVentasDia { DataSource = vent };
                articulos.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No hay suficientes datos para mostrar el reporte", "Registros 0");
        }

        private void rptAbonos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var abonos = new EmpeñosDC(new clsConeccionDB().StringConn()).PagosVentas.Where(
                                    v => v.FechaPago == DateTime.Today.Date && v.Estado);
            if (abonos.Any())
            {
                XrptAbonosDia abo = new XrptAbonosDia { DataSource = abonos };
                abo.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No hay suficientes datos para mostrar el reporte", "Registros 0");
        }

        private void rptFinanciamientos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var fin = new EmpeñosDC(new clsConeccionDB().StringConn()).Prestamos.Where(
                                    v => v.FechaPrestamo == DateTime.Today.Date && v.Estado == "Vigente");
            if (fin.Any())
            {
                XrptFinanciamientos abo = new XrptFinanciamientos { DataSource = fin };
                abo.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No hay suficientes datos para mostrar el reporte", "Registros 0");
        }

        private void rptPagos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var abonos = new EmpeñosDC(new clsConeccionDB().StringConn()).PagosFinanciamientos.Where(
                                    v => v.FechaPago == DateTime.Today.Date && v.Estado);
            if (abonos.Any())
            {
                XrptPagosFinanciamiento abo = new XrptPagosFinanciamiento { DataSource = abonos };
                abo.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No hay suficientes datos para mostrar el reporte", "Registros 0");
        }

        private void rptEmpeñosVigentes_ItemClick(object sender, ItemClickEventArgs e)
        {
            var bol = new EmpeñosDC(new clsConeccionDB().StringConn()).Boletas.Where(b => b.EstadoBoleta == "Vigente");
            if (bol.Any())
            {
                XrptEmpeñosVigentes rptbol = new XrptEmpeñosVigentes { DataSource = bol };
                rptbol.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
        }
        private void rptFinanciamientosActivos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var fin = new EmpeñosDC(new clsConeccionDB().StringConn()).Prestamos.Where(
                                   v => v.Estado == "Vigente");
            if (fin.Any())
            {
                XrptFinanciamientosActivos abo = new XrptFinanciamientosActivos { DataSource = fin };
                abo.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No hay suficientes datos para mostrar el reporte", "Registros 0");
        }

        private void rptVentasAtrasadas_ItemClick(object sender, ItemClickEventArgs e)
        {
            var vent = new EmpeñosDC(new clsConeccionDB().StringConn()).Ventas.Where(
                v =>
                    v.FechaVenta.AddMonths(
                        Convert.ToInt32(new clsModificarConfiguracion().configGetValue("VencimientoApartado"))).Date <
                    DateTime.Today.Date && v.Estado == "Apartado");
            if (vent.Any())
            {
                XrptApartadosAtrasados articulos = new XrptApartadosAtrasados { DataSource = vent };
                articulos.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No hay suficientes datos para mostrar el reporte", "Registros 0");
        }

        private void rptArticulosDisponibles_ItemClick(object sender, ItemClickEventArgs e)
        {
            var art = new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(
                                    v => v.Estado == "Disponible");
            if (art.Any())
            {
                XrptArticulosDisponibles articulos = new XrptArticulosDisponibles { DataSource = art };
                articulos.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No hay suficientes datos para mostrar el reporte", "Registros 0");
        }

        private void rptArticulosApartados_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cotizacion dsCotizacion=new Cotizacion();
            var art = new EmpeñosDC(new clsConeccionDB().StringConn()).DetalleVentas.Where(
                                    v => v.Venta.Estado == "Apartado")
                .Select(
                    vta =>
                        new
                        {
                            vta.CveArticulo,
                            vta.Articulo.Descripcion,
                            vta.Articulo.Kilates,
                            vta.Articulo.Peso,
                            vta.PrecioCompra,
                            Abonos = vta.Venta.PagosVentas.Sum(pg => (decimal?)pg.Abono)??0,
                            SaldoActual = vta.Venta.Saldo - (vta.Venta.PagosVentas.Where(pg=>pg.Estado).Sum(pg => (decimal?)pg.Abono) ?? 0),
                            registro=vta.Venta.Usuario.Nombre,
                        });//.Select(vta => vta.Saldo - (vta.PagosVentas.Where(pv => pv.Estado).Sum(pv => pv.Abono))).Sum();

            foreach (var dt in art)
            {
                dsCotizacion.Tables["ArticulosApartados"].Rows.Add(new object[]
                {dt.CveArticulo, dt.Descripcion, dt.Peso, dt.Kilates, dt.PrecioCompra, dt.SaldoActual, dt.registro});
            }
            if (art.Any())
            {
                XrptArticulosApartados articulos = new XrptArticulosApartados { DataSource = dsCotizacion.Tables["ArticulosApartados"], SaldoArticulosPartados = { Value = art.Sum(s => s.SaldoActual) } };
                articulos.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No hay suficientes datos para mostrar el reporte", "Registros 0");
        }
        #endregion
        private void vtnReportesFechas_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportesFechas rptFechas = new FrmReportesFechas();
            rptFechas.Show();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataSet inv = new DataSet("Inventario");
            var evig = new EmpeñosDC(new clsConeccionDB().StringConn()).Boletas
                       .Where(emp => emp.EstadoBoleta == "Vigente")
                       .Select(emp => new { emp.Folio, emp.Cliente, emp.PesoEmpeño, emp.Prestamo, emp.TipoEmpeño });
            DataTable dtevi = new LinqToDataTable().ObtenerDataTable2(evig);
            dtevi.TableName = "InventarioSoftEmpeños";
            DataTable datosSucursal = new DataTable("Sucursal");
            datosSucursal.Columns.Add("Sucursal", Type.GetType("System.String"));
            datosSucursal.Columns.Add("Direccion", Type.GetType("System.String"));
            //datosSucursal.Columns.Add("Boletas", Type.GetType("System.Int32"));
            DataRow filasucursal = datosSucursal.NewRow();
            filasucursal[0] = new clsModificarConfiguracion().configGetValue("Empresa");
            filasucursal[1] = new clsModificarConfiguracion().configGetValue("Direccion");
            datosSucursal.Rows.Add(filasucursal);
            dtevi.Columns.Add("Verificado", Type.GetType("System.Boolean"));
            foreach (DataRow fila in dtevi.Rows)
            {
                fila["Verificado"] = false;
            }
            inv.Tables.Add(datosSucursal);
            inv.Tables.Add(dtevi);

            string rutaescritorio = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            inv.WriteXml(rutaescritorio + @"\InventarioSoftEmpeños.xml", XmlWriteMode.WriteSchema);
            //inv.WriteXmlSchema(rutaescritorio + @"\InventarioSoftEmpeñosSchema.xml");
            MessageBox.Show("Se ha creado un Archivo el Escritorio 'InventarioSoftEmpeños.xml' \n Copielo donde se encuentra su aplicacion de inventario");
        }

        private void vtnGraficas_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Form1().ShowDialog();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void ribbon_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ClsVerificarCaja.CajaEstado())
            {
                MessageBox.Show("La Caja del Dia de hoy ya se ha cerrado\n SISTEMA BLOQUEADO", "Caja Cerrada",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void vtnGrupos_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarPantalla(new FrmListaGrupos());
        }

        private void vtnPrestamo_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarPantalla(new FrmCreditos());
        }

        private void vtnPagos_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarPantalla(new FrmPagosCreditos());
        }

        private void vtnGrupoAtrasados_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarPantalla(new FrmCreditosAtrasados());
        }

        private void rptDepositoBase_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dep = new EmpeñosDC(new clsConeccionDB().StringConn()).Transacciones.Where(b => b.TipoTransaccion == "Base" && b.FechaTransaccion == DateTime.Today && b.Estado );
            if (dep.Any())
            {
                XrptTransaccionesXDia rptbol = new XrptTransaccionesXDia
                {
                    DataSource = dep,
                    TipoTransaccion = { Value = "Base" }
                };
                rptbol.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
        }

        private void rptCreditos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dep = new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraCreditos.Where(b => b.FechaInicio == DateTime.Today && b.Estado=="Activo").Select(d=>d.Clave).ToList();
            int integrantes =
                new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraGruposDetalles.Count(
                    inte => dep.Contains(inte.CveGrupo));
            if (dep.Any())
            {
                IQueryable<FinancieraCredito> grupos = new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraCreditos.Where(g =>dep.Contains(g.Clave) );
                
                XrptCreditos rptbol = new XrptCreditos
                {
                    DataSource = grupos,
                    NumPersonas = {Value = integrantes}
                };
                rptbol.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
        }

        private void rptPagosCreditos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dep = new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraPagos.Where(b => b.FechaPago == DateTime.Today && b.Estado);
            if (dep.Any())
            {
                XrptPagosCreditos rptbol = new XrptPagosCreditos
                {
                    DataSource = dep,
                };
                rptbol.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
        }

        private void rptCreditosVigentes_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dep =
                new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraCreditos.Where(b => b.Estado == "Activo");//.Select(cre=>cre.CveGrupo ).ToList();
            int integrantes = new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraGruposDetalles.Count(
                    inte => dep.Select(c=>c.CveGrupo).ToList().Contains(inte.CveGrupo));
            if (dep.Any())
            {

                //IQueryable<FinancieraGrupo> grupos = new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraGrupos.Where(g =>dep.Contains(g.Clave) );
                XrptCreditosVigentes rptbol = new XrptCreditosVigentes
                {
                    DataSource = dep,
                    NumPersonas = { Value = integrantes }
                };
                rptbol.ShowPreviewDialog();
            }
            else
                XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
        }

        
    }
}