using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;
using SoftEmpenios.LogicaNegocios;

namespace SoftEmpenios.Dialogos
{
    public partial class FrmUsuarios : DevExpress.XtraEditors.XtraForm
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void botonNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Nuevo();
        }

        private void botonEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new ManejadorControles().DesectivarTextBox(gpoContenedor, true);
            txtNombre.Focus();
        }

        private void BotonGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }
        public void Nuevo()
        {
            new ManejadorControles().LimpiarControles(gpoContenedor);
            new ManejadorControles().DesectivarTextBox(gpoContenedor, true);
            txtNombre.Focus();
            //rbtUnidad.SelectedIndex = 0;
        }
        void Guardar()
        {
            try
            {
                if ((int)txtClave.EditValue == 0)
                {
                    Usuario usuario = new Usuario
                    {
                        Nombre = txtNombre.EditValue.ToString(),
                        Usuario1 = txtUsuario.EditValue.ToString(),
                        Contrasenia =  txtContraseña.EditValue.ToString(),
                        Permisos = cboPermiso.EditValue.ToString()

                    };
                    txtClave.EditValue = new LogicaUsuarios().AgregarRegistro(usuario);
                }
                else
                {
                    Usuario usuOri = new LogicaUsuarios().ObtenerUsuario((int)txtClave.EditValue);
                    Usuario usuario = new Usuario
                    {
                        CveUsuario = usuOri.CveUsuario,
                        Nombre = txtNombre.EditValue.ToString(),
                        Usuario1 = txtUsuario.EditValue.ToString(),
                        Contrasenia = txtContraseña.EditValue.ToString(),
                        Permisos = cboPermiso.EditValue.ToString()

                    };
                    new LogicaUsuarios().ActualizarRegistro(usuario, usuOri);
                }
                CargarGrid((int)txtClave.EditValue);
                new ManejadorControles().DesectivarTextBox(gpoContenedor, false);

            }
            catch (ValidationException vex)
            {
                MessageBox.Show(vex.Message, Application.ProductName + @"-Validando Datos");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Application.ProductName + @"-Validando Datos");
            }
        }
        private void CargarGrid(int cve)
        {
            gridUsuarios.DataSource = from a in new LogicaUsuarios().ObtenerTodos()
                                      select new
                                      {
                                          Clave=a.CveUsuario,
                                          a.Nombre,
                                          Usuario = a.Usuario1,
                                          Contraseña=a.Contrasenia,
                                          a.Permisos
                                      };
            grvUsuarios.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grvUsuarios.Columns[0].Width = 80;
            grvUsuarios.Columns[1].Width = 150;
            grvUsuarios.Columns[3].Visible = false;


            int rowHandle = grvUsuarios.LocateByValue("Clave", cve);
            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                grvUsuarios.FocusedRowHandle = rowHandle;
            new ManejadorControles().DesectivarTextBox(gpoContenedor, false);
        }

        private void FrmUsuarios_Shown(object sender, EventArgs e)
        {
            CargarGrid(0);
        }

        private void grvUsuarios_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            txtClave.EditValue = grvUsuarios.GetFocusedRowCellValue("Clave");
            txtNombre.EditValue = grvUsuarios.GetFocusedRowCellValue("Nombre");
            txtUsuario.EditValue = grvUsuarios.GetFocusedRowCellValue("Usuario");
            txtContraseña.EditValue = grvUsuarios.GetFocusedRowCellValue("Contraseña");
            cboPermiso.EditValue = grvUsuarios.GetFocusedRowCellValue("Permisos");
            new ManejadorControles().DesectivarTextBox(gpoContenedor, false);
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}