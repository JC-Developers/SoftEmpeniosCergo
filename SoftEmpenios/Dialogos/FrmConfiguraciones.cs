using System;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.Dialogos
{
    public partial class FrmConfiguraciones : XtraForm
    {
        int _idConfiguracion;
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        private  string Nomdbanterior = "";

        public FrmConfiguraciones()
        {
            InitializeComponent();
        }

        private void FrmConfiguraciones_Shown(object sender, EventArgs e)
        {
            LLenarConfigDb();
        }
        private void LLenarPrecios()
        {
            _entidades.Connection.ConnectionString = new clsConeccionDB().StringConn();
            var precios = _entidades.Precios.Select(p => new { p.Clave, p.Tipo, p.Empeño, p.Compra, p.VentaContado, p.VentaApartado, });
            DataTable dtprecios = new LinqToDataTable().ObtenerDataTable2(precios);
            gridPrecios.DataSource = dtprecios;
            grvPrecios.Columns[0].Visible = false;
            grvPrecios.Columns[1].OptionsColumn.AllowEdit = false;
            grvPrecios.Columns[2].DisplayFormat.FormatType=FormatType.Numeric;
            grvPrecios.Columns[2].DisplayFormat.FormatString = "$ #,##0.00";
            grvPrecios.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
            grvPrecios.Columns[3].DisplayFormat.FormatString = "$ #,##0.00";
            grvPrecios.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
            grvPrecios.Columns[4].DisplayFormat.FormatString = "$ #,##0.00";
            grvPrecios.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
            grvPrecios.Columns[5].DisplayFormat.FormatString = "$ #,##0.00";
            
            gridPrecios.Enabled = false;
            txtDolar.EditValue = _entidades.Configuraciones.First().PrecioCompraDolar;
            txtVencimientoApartado.EditValue = _entidades.Configuraciones.First().VencimientoApartado;

        }
        private void LLenarDiasDesempeño()
        {
            _entidades.Connection.ConnectionString = new clsConeccionDB().StringConn();
            IQueryable<Horario> horas = _entidades.Horarios;
            DataTable h = new LinqToDataTable().ObtenerDataTable2(horas);
            gridHorarios.DataSource = h;
            grvHorarios.Columns[0].Visible = false;
            grvHorarios.Columns[1].OptionsColumn.AllowEdit = false;
            grvHorarios.Columns[2].ColumnEdit = horaInicial;
            grvHorarios.Columns[3].ColumnEdit = horaFinal;
            gridHorarios.Enabled = false;

        }
        private void LLenarConfigDb()
        {

            cboServidores.EditValue = new clsModificarConfiguracion().configGetValue("ServidorDB");
            txtUsuario.EditValue = new clsModificarConfiguracion().configGetValue("UsuarioDB");
            txtContrasenia.EditValue = new clsModificarConfiguracion().configGetValue("ContraseniaDB");
            cboBasesDatos.EditValue = new clsModificarConfiguracion().configGetValue("BasedeDatos");
            if (cboServidores.Text == "" && txtUsuario.Text == "" && txtContrasenia.Text == "" && cboBasesDatos.Text == "")
            {
                LlenarServidores();

            }
            else
            {
                new ManejadorControles().DesectivarTextBox(tapBaseDatos, false);

            }
        }
        private void LlenarServidores()
        {
            cboServidores.Properties.Items.Clear();
            DataTable dataSources = SqlDataSourceEnumerator.Instance.GetDataSources();
            if (dataSources.Rows.Count == 0)
            {

                DialogResult = XtraMessageBox.Show("No se encontraron servidores desea actualizar", "No se encuentra servidor", MessageBoxButtons.RetryCancel);
                if (DialogResult == DialogResult.Retry)
                {
                    LlenarServidores();
                }
            }
            foreach (DataRow row in dataSources.Rows)
            {
                cboServidores.Properties.Items.Add(row["InstanceName"].ToString() != string.Empty
                                                            ? String.Format("{0}\\{1}", row["ServerName"],
                                                                            row["InstanceName"])
                                                            : row["ServerName"]);
            }
        }
        private void LlenarDatosEmpresa()
        {
            _entidades.Connection.ConnectionString = new clsConeccionDB().StringConn();
            Configuracione empre = _entidades.Configuraciones.FirstOrDefault();

            if (empre == null) return;
            _idConfiguracion = empre.Clave;
            txtEmpresa.EditValue = empre.NombreEmpresa;
            txtRazonSocial.EditValue = empre.RazonSocial;
            txtRFC.EditValue = empre.RFC;
            txtCURP.EditValue = empre.CURP;
            txtDireccion.EditValue = empre.Direccion;
            txtCP.EditValue = empre.CodigoPostal;
            txtMunicipio.EditValue = empre.Municipio;

            txtInteres.EditValue = empre.PorcentajeInteres;
            txtRecargo.EditValue = empre.PorcentajeRecargo;
            txtVencimiento.EditValue = empre.DiasVencimiento;
            txtProrroga.EditValue = empre.Proroga;
            txtVencimientoApartado.EditValue = empre.VencimientoApartado;

            txtDolar.EditValue = empre.PrecioCompraDolar;
        }
        #region configuracion hipotecario
        private void LlenarConfigFinanciamiento()
        {
            try
            {
                
                IQueryable<Financiamiento> configfina = _entidades.Financiamientos;
                if (configfina.Any())
                {
                    foreach (Financiamiento f in configfina)
                    {
                        switch (f.Tipo)
                        {
                            case "Hipotecario":
                                txtClaveH.EditValue = f.Clave;
                                txtInteresH.EditValue = f.Interes;
                                txtProrrogaH.EditValue = f.Prorroga;
                                txtRecargoH.EditValue = f.Recargo;
                                txtVencimientoH.EditValue = f.Vencimiento;
                                break;
                            case "AutoFinanciamiento":
                                txtClaveA.EditValue = f.Clave;
                                txtInteresA.EditValue = f.Interes;
                                txtProrrogaA.EditValue = f.Prorroga;
                                txtRecargoA.EditValue = f.Recargo;
                                txtEngancheA.EditValue = f.Enganche;
                                txtVencimientoA.EditValue = f.Vencimiento;
                                break;
                            case "Personal":
                                txtClaveP.EditValue = f.Clave;
                                txtInteresP.EditValue = f.Interes;
                                txtProrrogaP.EditValue = f.Prorroga;
                                txtRecargoP.EditValue = f.Recargo;
                                txtVencimientoP.EditValue = f.Vencimiento;
                                break;
                            case "Personal Fijo":
                                txtClavePF.EditValue = f.Clave;
                                txtInteresPF.EditValue = f.Interes;
                                txtProrrogaPF.EditValue = f.Prorroga;
                                txtRecargoPF.EditValue = f.Recargo;
                                txtVencimientoPF.EditValue = f.Vencimiento;
                                break;
                            case "Grupal":
                                 txtClaveG.EditValue = f.Clave;
                                txtInteresG.EditValue = f.Interes;
                                txtProrrogaG.EditValue = f.Prorroga;
                                txtRecargoG.EditValue = f.Recargo;
                                txtBaseG.EditValue = f.Enganche;
                                txtVencimientoG.EditValue = f.Vencimiento;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }
        private void GuardarFinanciamiento()
        {
            try
            {
                if ((int)txtClaveH.EditValue == 0)
                {
                    Financiamiento finaH = new Financiamiento
                    {
                        Tipo = "Hipotecario",
                        Interes = Convert.ToDecimal(txtInteresH.EditValue),
                        Prorroga = Convert.ToInt32(txtProrrogaH.EditValue),
                        Recargo = Convert.ToDecimal(txtRecargoH.EditValue),
                        Vencimiento = Convert.ToInt32(txtVencimientoH.EditValue)
                    };
                    _entidades.Financiamientos.InsertOnSubmit(finaH);
                    txtClaveH.EditValue = finaH.Clave;
                }
                else
                {
                    Financiamiento finaH = _entidades.Financiamientos.FirstOrDefault(f => f.Clave == Convert.ToInt32(txtClaveH.EditValue));
                    if (finaH != null)
                    {
                        finaH.Interes = Convert.ToDecimal(txtInteresH.EditValue);
                        finaH.Prorroga = Convert.ToInt32(txtProrrogaH.EditValue);
                        finaH.Recargo = Convert.ToDecimal(txtRecargoH.EditValue);
                        finaH.Vencimiento = Convert.ToInt32(txtVencimientoH.EditValue);
                    }
                }
                if ((int)txtClaveA.EditValue == 0)
                {
                    Financiamiento finaA = new Financiamiento
                    {
                        Tipo = "AutoFinanciamiento",
                        Interes = Convert.ToDecimal(txtInteresA.EditValue),
                        Prorroga = Convert.ToInt32(txtProrrogaA.EditValue),
                        Recargo = Convert.ToDecimal(txtRecargoA.EditValue),
                        Enganche = Convert.ToDecimal(txtEngancheA.EditValue),
                        Vencimiento = Convert.ToInt32(txtVencimientoA.EditValue)
                    };
                    _entidades.Financiamientos.InsertOnSubmit(finaA);
                    txtClaveA.EditValue = finaA.Clave;
                }
                else
                {
                    Financiamiento finaA = _entidades.Financiamientos.FirstOrDefault(f => f.Clave == Convert.ToInt32(txtClaveA.EditValue));
                    if (finaA != null)
                    {
                        finaA.Interes = Convert.ToDecimal(txtInteresA.EditValue);
                        finaA.Prorroga = Convert.ToInt32(txtProrrogaA.EditValue);
                        finaA.Recargo = Convert.ToDecimal(txtRecargoA.EditValue);
                        finaA.Enganche = Convert.ToDecimal(txtEngancheA.EditValue);
                        finaA.Vencimiento = Convert.ToInt32(txtVencimientoA.EditValue);
                    }
                }
                if ((int)txtClaveP.EditValue == 0)
                {
                    Financiamiento finaP = new Financiamiento
                    {
                        Tipo = "Personal",
                        Interes = Convert.ToDecimal(txtInteresP.EditValue),
                        Prorroga = Convert.ToInt32(txtProrrogaP.EditValue),
                        Recargo = Convert.ToDecimal(txtRecargoP.EditValue),
                        Vencimiento = Convert.ToInt32(txtVencimientoP.EditValue)
                    };
                    _entidades.Financiamientos.InsertOnSubmit(finaP);
                    txtClaveP.EditValue = finaP.Clave;
                }
                else
                {
                    Financiamiento finaP = _entidades.Financiamientos.FirstOrDefault(f => f.Clave == Convert.ToInt32(txtClaveP.EditValue));

                    if (finaP != null)
                    {
                        finaP.Interes = Convert.ToDecimal(txtInteresP.EditValue);
                        finaP.Prorroga = Convert.ToInt32(txtProrrogaP.EditValue);
                        finaP.Recargo = Convert.ToDecimal(txtRecargoP.EditValue);
                        finaP.Vencimiento = Convert.ToInt32(txtVencimientoP.EditValue);
                    }
                }
                if ((int)txtClavePF.EditValue == 0)
                {
                    Financiamiento finaP = new Financiamiento
                    {
                        Tipo = "Personal Fijo",
                        Interes = Convert.ToDecimal(txtInteresPF.EditValue),
                        Prorroga = Convert.ToInt32(txtProrrogaPF.EditValue),
                        Recargo = Convert.ToDecimal(txtRecargoPF.EditValue),
                        Vencimiento = Convert.ToInt32(txtVencimientoPF.EditValue)
                    };
                    _entidades.Financiamientos.InsertOnSubmit(finaP);
                    txtClavePF.EditValue = finaP.Clave;
                }
                else
                {
                    Financiamiento finaP = _entidades.Financiamientos.FirstOrDefault(f => f.Clave == Convert.ToInt32(txtClavePF.EditValue));

                    if (finaP != null)
                    {
                        finaP.Interes = Convert.ToDecimal(txtInteresPF.EditValue);
                        finaP.Prorroga = Convert.ToInt32(txtProrrogaPF.EditValue);
                        finaP.Recargo = Convert.ToDecimal(txtRecargoPF.EditValue);
                        finaP.Vencimiento = Convert.ToInt32(txtVencimientoPF.EditValue);
                    }
                }
                if ((int)txtClaveG.EditValue == 0)
                {
                    Financiamiento finaG = new Financiamiento
                    {
                        Tipo = "Grupal",
                        Interes = Convert.ToDecimal(txtInteresG.EditValue),
                        Prorroga = Convert.ToInt32(txtProrrogaG.EditValue),
                        Recargo = Convert.ToDecimal(txtRecargoG.EditValue),
                        Vencimiento = Convert.ToInt32(txtVencimientoG.EditValue),
                        Enganche = Convert.ToDecimal(txtBaseG.EditValue)
                    };
                    _entidades.Financiamientos.InsertOnSubmit(finaG);
                    txtClaveG.EditValue = finaG.Clave;
                }
                else
                {
                    Financiamiento finaG = _entidades.Financiamientos.FirstOrDefault(f => f.Clave == Convert.ToInt32(txtClaveG.EditValue));

                    if (finaG != null)
                    {
                        finaG.Interes = Convert.ToDecimal(txtInteresG.EditValue);
                        finaG.Prorroga = Convert.ToInt32(txtProrrogaG.EditValue);
                        finaG.Recargo = Convert.ToDecimal(txtRecargoG.EditValue);
                        finaG.Vencimiento = Convert.ToInt32(txtVencimientoG.EditValue);
                        finaG.Enganche = Convert.ToDecimal(txtBaseG.EditValue);
                    }
                }
                _entidades.SubmitChanges();
                XtraMessageBox.Show("Ya se ha guardado la Configuracion de financiamiento", "Datos Guardados");

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }


        #endregion
        private void cboServidores_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (cboServidores.Properties.Items.Count != 0) return;
            using (Cursor = Cursors.WaitCursor)
            {
                LlenarServidores();
            }
            Cursor = Cursors.Default;
        }

        private void cboBasesDatos_QueryPopUp(object sender, CancelEventArgs e)
        {
            try
            {
                using (Cursor = Cursors.WaitCursor)
                {
                    if (txtUsuario.Text == "" || txtContrasenia.Text == "" || cboServidores.Text == string.Empty)
                        return;
                    cboBasesDatos.Properties.Items.Clear();
                    ServerConnection serverConnection = new ServerConnection(cboServidores.Text, txtUsuario.Text,
                        txtContrasenia.Text);
                    Server server = new Server(serverConnection);
                    foreach (Database database in server.Databases.Cast<Database>().Where(database => !database.IsSystemObject))
                    {
                        cboBasesDatos.Properties.Items.Add(database.Name);
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("No se puede conectar con el servidor \n" + exception.Message, "Conexión Incorrecta");
                Cursor = Cursors.Default;
            }
        }

        private void btnGuardarTap_Click(object sender, EventArgs e)
        {
            switch (tapConfiguraciones.SelectedTabPageIndex)
            {
                case 0:
                    {
                        GuardarConfigDb();
                    }
                    break;
                case 1:
                    {
                        GuardarConfigEmpresa();
                    }
                    break;
                case 2:
                    {
                        GuardarPrecios();
                        //GuardarConfigEmpresa();
                    }
                    break;
                case 3:
                    {
                        GuardarFinanciamiento();
                    }
                    break;
                case 4:
                    {
                        GuardarHorario();
                    }
                    break;
            }
        }
        private void GuardarConfigEmpresa()
        {
            _entidades.Connection.ConnectionString = new clsConeccionDB().StringConn();
            Configuracione config = new Configuracione();
            if (_idConfiguracion == 0)
            {

                config.NombreEmpresa = txtEmpresa.Text;
                config.RazonSocial = txtRazonSocial.Text;
                config.RFC = txtRFC.Text;
                config.CURP = txtCURP.Text;
                config.Direccion = txtDireccion.Text;
                config.CodigoPostal = txtCP.Text;
                config.Municipio = txtMunicipio.Text;
                config.PorcentajeInteres = Convert.ToDecimal(txtInteres.EditValue);
                config.Proroga = Convert.ToInt32(txtProrroga.EditValue);
                config.DiasVencimiento = Convert.ToInt32(txtVencimiento.EditValue);
                config.VencimientoApartado = Convert.ToInt32(txtVencimientoApartado.Value);
                config.PorcentajeRecargo = Convert.ToDecimal(txtRecargo.EditValue);

                config.PrecioCompraDolar = Convert.ToDecimal(txtDolar.EditValue);
                config.FechaUltimaModificacion = DateTime.Today;
                _entidades.Configuraciones.InsertOnSubmit(config);

            }
            else
            {
                Configuracione config1 = _entidades.Configuraciones.FirstOrDefault(pi => pi.Clave == _idConfiguracion);
                

                if (config1 != null)
                {
                    config1.NombreEmpresa = txtEmpresa.Text;
                    config1.RazonSocial = txtRazonSocial.Text;
                    config1.RFC = txtRFC.Text;
                    config1.CURP = txtCURP.Text;
                    config1.Direccion = txtDireccion.Text;
                    config1.CodigoPostal = txtCP.Text;
                    config1.Municipio = txtMunicipio.Text;
                    config1.PorcentajeInteres = Convert.ToDecimal(txtInteres.EditValue);
                    config1.Proroga = Convert.ToInt32(txtProrroga.EditValue);
                    config1.DiasVencimiento = Convert.ToInt32(txtVencimiento.EditValue);
                    config1.VencimientoApartado = Convert.ToInt32(txtVencimientoApartado.Value);
                    config1.PorcentajeRecargo = Convert.ToDecimal(txtRecargo.EditValue);

                    config1.PrecioCompraDolar = Convert.ToDecimal(txtDolar.EditValue);
                    config1.FechaUltimaModificacion = DateTime.Today;
                    _idConfiguracion = config1.Clave;
                }
            }
            _entidades.SubmitChanges();
            _idConfiguracion = (config.Clave == 0) ? _idConfiguracion : config.Clave;
            new clsModificarConfiguracion().configSetValue("Empresa", txtEmpresa.Text);
            new clsModificarConfiguracion().configSetValue("RazonSocial", txtRazonSocial.Text);
            new clsModificarConfiguracion().configSetValue("RFC", txtRFC.Text);
            new clsModificarConfiguracion().configSetValue("CURP", txtCURP.Text);
            new clsModificarConfiguracion().configSetValue("Direccion", String.Format("{0} {1} {2}", txtDireccion.Text, txtCP.Text, txtMunicipio.Text));
            new clsModificarConfiguracion().configSetValue("Interes", txtInteres.EditValue.ToString());
            new clsModificarConfiguracion().configSetValue("Prorroga", txtProrroga.Value.ToString());
            new clsModificarConfiguracion().configSetValue("PorcentajeRecargo", txtRecargo.EditValue.ToString());
            new clsModificarConfiguracion().configSetValue("DiasVencimiento", txtVencimiento.EditValue.ToString());
            new clsModificarConfiguracion().configSetValue("VencimientoApartado", txtVencimientoApartado.Value.ToString());
            new clsModificarConfiguracion().configSetValue("ImpresoraTickets", txtImpresoraTickets.Text);
            new clsModificarConfiguracion().configSetValue("ImpresoraBoletas", txtImpresoraBoletas.Text);
            XtraMessageBox.Show("Ya se ha guardado la Configuracion", "Datos Guardados");
        }
        private void GuardarConfigDb()
        {
            try
            {
                clsModificarConfiguracion configuracion = new clsModificarConfiguracion();
                if (!chkCrearDB.Checked)
                {
                    if (!Probar()) return;
                    configuracion.ModificarValoresConfig(cboServidores.Text, cboBasesDatos.Text, txtUsuario.Text, txtContrasenia.Text);
                       
                    new ManejadorControles().DesectivarTextBox(tapBaseDatos, false);
                    XtraMessageBox.Show("Configuracion Guardada", "Configuracion");
                }
                else
                {
                    if ((cboServidores.SelectedIndex > -1) && (cboServidores.Text != "") && cboBasesDatos.Text != "")
                    {
                        clsCreacionBD nbd = new clsCreacionBD();
                        if (nbd.CrearBD(cboServidores.Text, txtUsuario.Text, txtContrasenia.Text, cboBasesDatos.Text))
                        {
                            XtraMessageBox.Show("Creacion de las tablas exitosa!");
                            cboBasesDatos.Enabled = txtUsuario.Enabled = txtContrasenia.Enabled = cboServidores.Enabled = false;
                            configuracion.ModificarValoresConfig(cboServidores.Text, cboBasesDatos.Text, txtUsuario.Text, txtContrasenia.Text);
                            new ManejadorControles().DesectivarTextBox(tapBaseDatos, false);
                        }
                        else
                        {
                            XtraMessageBox.Show("Creacion de base de datos fallada tablas fallada.");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Error : favor de proporcionar todos los campos necesarios.");
                    }

                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message, "Error al crear base de datos");
            }

        }
        private bool Probar()
        {
            if (((cboServidores.Text == "") || (cboBasesDatos.Text == "")) || (txtUsuario.Text == ""))
            {
                XtraMessageBox.Show("Error. Favor de llenar todos los campos.");
                return false;
            }
            string cadenaconect = String.Format("Data source ={0};Initial Catalog ={1};user id={2};password={3};", cboServidores.Text, cboBasesDatos.Text, txtUsuario.Text, txtContrasenia.Text);
            clsConeccionDB ndb = new clsConeccionDB();
            if (ndb.ProbarConexion(cadenaconect))
            {
                return true;
            }
            XtraMessageBox.Show("Conexion incorrecta. Favor de proporcionar informaciones validas.");
            return false;
        }
        private void GuardarPrecios()
        {
            try
            {
                for (int i = 0; i < grvPrecios.RowCount; i++)
                {
                    Precio premod =
                        _entidades.Precios.FirstOrDefault(p => p.Clave == Convert.ToInt32(grvPrecios.GetRowCellValue(i, "Clave").ToString()));
                    if (premod == null) continue;
                    premod.Empeño = Convert.ToDecimal(grvPrecios.GetRowCellValue(i, "Empeño").ToString());
                    premod.Compra = Convert.ToDecimal(grvPrecios.GetRowCellValue(i, "Compra").ToString());
                    premod.VentaContado = Convert.ToDecimal(grvPrecios.GetRowCellValue(i, "VentaContado").ToString());
                    premod.VentaApartado = Convert.ToDecimal(grvPrecios.GetRowCellValue(i, "VentaApartado").ToString());
                    _entidades.SubmitChanges();
                }
                XtraMessageBox.Show("Se ha Guardado los Precios", "Guardar");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error en Guardar");
            }
        }
        private void GuardarHorario()
        {
            for (int i = 0; i < grvHorarios.RowCount; i++)
            {
                Horario hr = _entidades.Horarios.SingleOrDefault(h => h.Numero == Convert.ToInt32(grvHorarios.GetRowCellValue(i, "Numero").ToString()));
                if (hr != null)
                {
                    hr.Dia = grvHorarios.GetRowCellValue(i, "Dia").ToString();
                    hr.HoraInicial = Convert.ToDateTime(grvHorarios.GetRowCellValue(i, "HoraInicial").ToString());
                    hr.HoraFinal = Convert.ToDateTime(grvHorarios.GetRowCellValue(i, "HoraFinal").ToString());
                }
                _entidades.SubmitChanges();
            }
            XtraMessageBox.Show("Ya se ha guardado el horario", "Datos Guardados");
            if (cboBasesDatos.Text == Nomdbanterior || Nomdbanterior == "")
            {

                if (!_entidades.Usuarios.Any())
                {
                    FrmUsuarios frmUsuarios = new FrmUsuarios();
                    frmUsuarios.ShowDialog(this);
                    Close();
                }
            }
            else
            {
                if (_entidades.Usuarios.Any())
                {FrmIniciarSesion login = new FrmIniciarSesion();
                    login.ShowDialog(this);
                    //new FrmPrincipal().Ponernombrevendedor();
                }
                else
                {

                    FrmUsuarios frmUsuarios = new FrmUsuarios();
                    frmUsuarios.ShowDialog(this);
                    Close();

                }
            }
        }

        private void tapConfiguraciones_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (e.Page.TabIndex)
            {
                case 0:
                    {
                        new ManejadorControles().DesectivarTextBox(tapBaseDatos, false);

                    }
                    break;
                case 1:
                    {
                        new ManejadorControles().DesectivarTextBox(tapEmpresa, false);
                        LlenarDatosEmpresa();
                    }
                    break;
                case 2:
                    {
                        new ManejadorControles().DesectivarTextBox(tapPrecios, false);
                        LLenarPrecios();
                    }
                    break;
                case 3:
                    {
                        new ManejadorControles().DesectivarTextBox(tapFinanciamiento, false);
                        LlenarConfigFinanciamiento();
                    }
                    break;
                case 4:
                    {
                        new ManejadorControles().DesectivarTextBox(tapHorarios, false);
                        LLenarDiasDesempeño();
                    }
                    break;
            }
        }

        private void btnEditarTap_Click(object sender, EventArgs e)
        {
            switch (tapConfiguraciones.SelectedTabPageIndex)
            {
                case 0:
                {
                    new ManejadorControles().DesectivarTextBox(tapBaseDatos, true);
                    cboServidores.Focus();
                }
                    break;
                case 1:
                {
                    new ManejadorControles().DesectivarTextBox(tapEmpresa, true);
                    txtEmpresa.Focus();
                }
                    break;
                case 2:
                {
                    new ManejadorControles().DesectivarTextBox(tapPrecios, true);
                    gridPrecios.Enabled = true;
                }
                    break;
                case 3:
                {
                    new ManejadorControles().DesectivarTextBox(tapFinanciamiento, true);
                    txtClaveA.Enabled = false;
                    txtClaveH.Enabled = false;
                    txtClaveP.Enabled = false;
                    txtInteresH.Focus();
                }
                    break;
                case 4:
                    new ManejadorControles().DesectivarTextBox(tapHorarios, true);
                    gridHorarios.Enabled = true;
                    break;
            }
        }

        private void txtImpresoraBoletas_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            PrintDialog printer = new PrintDialog { PrinterSettings = new System.Drawing.Printing.PrinterSettings() };
            if (printer.ShowDialog() == DialogResult.OK)
                txtImpresoraBoletas.Text = printer.PrinterSettings.PrinterName;
        }

        private void txtImpresoraTickets_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            PrintDialog printer = new PrintDialog { PrinterSettings = new System.Drawing.Printing.PrinterSettings() };
            if (printer.ShowDialog() == DialogResult.OK)
                txtImpresoraTickets.Text = printer.PrinterSettings.PrinterName;
        }
    }
}