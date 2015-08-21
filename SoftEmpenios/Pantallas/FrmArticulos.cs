
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using SoftEmpenios.DBComun;
using SoftEmpenios.Clases;
using System.ComponentModel.DataAnnotations;
using SoftEmpenios.LogicaNegocios;

namespace SoftEmpenios.Pantallas
{
    public partial class FrmArticulos : Form, iPantalla
    {

        private readonly EmpeñosDC _mapeoVentas = new EmpeñosDC(new clsConeccionDB().StringConn());
        private DataTable _dtArticulos = new DataTable();
        private readonly DataTable _dtprecios = new DataTable("Precios");

        public FrmArticulos()
        {
            InitializeComponent();DataColumn num = new DataColumn
            {
                ColumnName = "Clave",
                DataType = Type.GetType("System.Int32"),
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ReadOnly = true,
                Unique = true
            };
            _dtprecios.Columns.Add(num);
            _dtprecios.Columns.Add("Tipo", Type.GetType("System.String"));
            _dtprecios.Columns.Add("Contado", Type.GetType("System.Decimal"));
            _dtprecios.Columns.Add("Apartado", Type.GetType("System.Decimal"));
            var precios =
                new EmpeñosDC(new clsConeccionDB().StringConn()).Precios.Select(p => new { p.Tipo, Contado = p.VentaContado, Apartado = p.VentaApartado });

            foreach (var pre in precios)
            {
                _dtprecios.Rows.Add(new object[] {null, pre.Tipo, pre.Contado, pre.Apartado});
            }
            _dtprecios.Rows.Add(new object[] {null, "Varios", 0M, 0M});
            cboTipo.Properties.DataSource = _dtprecios;
            cboTipo.Properties.DisplayMember = "Tipo";
            cboTipo.Properties.ValueMember = "Clave";

        }

        public bool ConfirmarCierre()
        {
// ReSharper disable LocalizableElement
            switch (
                MessageBox.Show("\x00bfHa realizado cambios sin Guardar?. \x00bfDesea guardarlas?", "Muebleria",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
// ReSharper restore LocalizableElement
            {
                case DialogResult.Yes:
                    Guardar();
                    return true;

                case DialogResult.No:
                    return true;
            }
            return false;
        }

        public void Refrescar()
        {
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
            
            new ManejadorControles().LimpiarControles(gpoContenedor);
            new ManejadorControles().DesectivarTextBox(gpoContenedor, true);
            cboTipo.EditValue = cboTipo.Properties.GetDataSourceValue(cboTipo.Properties.ValueMember, 0);
            txtDescripcion.Focus();
        }

        public void Paginar(int primerRegistro)
        {
            //throw new NotImplementedException();
        }

        public string nombrePantalla
        {
            get
            {
                return "Articulos";
            }
        }

        private void GuardarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ClsVerificarCaja.CajaEstado())
                {
                    XtraMessageBox.Show("La Caja del Dia de hoy ya se ha cerrado\n SISTEMA BLOQUEADO", "Caja Cerrada",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                if ((int) txtClave.EditValue == 0)
                {
                    var art = new Articulo
                    {
                        Descripcion = txtDescripcion.Text,
                        Peso = Convert.ToDecimal(txtPeso.EditValue),
                        Kilates = cboTipo.Text,
                        Precio = Convert.ToDecimal(txtPrecio.EditValue),
                        PrecioCredito = Convert.ToDecimal(txtPrecioApartado.EditValue),
                        FechaRegistro = DateTime.Today.Date,
                        Estado = "Disponible",
                        CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp"))
                    };

                    txtClave.EditValue = new LogicaArticulos().InsertarArticulo(art);
                }
                else
                {
                    var original = new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Single(a => a.Clave==Convert.ToInt32(txtClave.EditValue));
                    Articulo art=new Articulo
                    {
                        Clave = original.Clave,
                        Descripcion = txtDescripcion.Text,
                        Peso = Convert.ToDecimal(txtPeso.EditValue),
                        Kilates = cboTipo.Text,
                        Precio = Convert.ToDecimal(txtPrecio.EditValue),
                        PrecioCredito = Convert.ToDecimal(txtPrecioApartado.EditValue),
                        FechaRegistro = Convert.ToDateTime(dtpFechaRegistro.EditValue).Date,
                        Estado =original.Estado,
                        CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp")),
                    };
                    new LogicaArticulos().ActualizarArticulo(art,original);
                    
                } XtraMessageBox.Show("Articulo Guardado");
                new ManejadorControles().DesectivarTextBox(gpoContenedor, false);
                LlenargridArticulos();
            }
            catch (ValidationException vex)
            {
                XtraMessageBox.Show(vex.Message, "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void LlenargridArticulos()
        {
            var articulos = from arts in _mapeoVentas.Articulos
                where arts.Estado != "Baja"
                orderby arts.Clave descending
                select
                    new
                    {
                        arts.Clave,
                        arts.Descripcion,
                        arts.Peso,
                        Tipo = arts.Kilates,
                        PrecioContado = arts.Precio,
                        PrecioApartado = arts.PrecioCredito,
                        arts.FechaRegistro,
                        arts.Estado
                    };
            _dtArticulos.Clear();
            if (!articulos.Any()) return;
            _dtArticulos = new LinqToDataTable().ObtenerDataTable2(articulos);
// ReSharper disable AssignNullToNotNullAttribute
            _dtArticulos.Columns.Add("S", Type.GetType("System.Boolean"));
// ReSharper restore AssignNullToNotNullAttribute
            foreach (DataRow fila in _dtArticulos.Rows)
            {
                fila["S"] = false;
            }
            _dtArticulos.Columns["S"].SetOrdinal(0);

            gridArticulos.DataSource = _dtArticulos;
            Formatogrid();
        }

        private void Formatogrid()
        {
            grvArticulos.Columns[1].OptionsColumn.AllowEdit = false;
            grvArticulos.Columns[1].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grvArticulos.Columns[2].OptionsColumn.AllowEdit = false;
            grvArticulos.Columns[2].Width = 250;
            grvArticulos.Columns[0].Width = 20;
            grvArticulos.Columns[1].Width = 80;
            grvArticulos.Columns[3].Width = 80;
            grvArticulos.Columns[3].OptionsColumn.AllowEdit = false;
            grvArticulos.Columns[4].OptionsColumn.AllowEdit = false;
            grvArticulos.Columns[5].OptionsColumn.AllowEdit = false;
            grvArticulos.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
            grvArticulos.Columns[5].DisplayFormat.FormatString = "c2";
            grvArticulos.Columns[6].OptionsColumn.AllowEdit = false;
            grvArticulos.Columns[6].DisplayFormat.FormatType = FormatType.Numeric;
            grvArticulos.Columns[6].DisplayFormat.FormatString = "c2";
            grvArticulos.Columns[7].OptionsColumn.AllowEdit = false;
            grvArticulos.Columns[7].DisplayFormat.FormatType = FormatType.DateTime;
            grvArticulos.Columns[7].DisplayFormat.FormatString = "dd-MMM-yyyy";
            grvArticulos.Columns[7].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grvArticulos.Columns[8].OptionsColumn.AllowEdit = false;
        }

        private void frmArticulos_Shown(object sender, EventArgs e)
        {
            Nuevo();
            if (new clsModificarConfiguracion().configGetValue("PermisosApp") == "Administrador")
            {
                botonDeleteSelected.Visible = true;
                botonSelectAll.Visible = true;
                botonUnselectAll.Visible = true;
                BotonEditar.Visible = true;
            }
            cboTipo.Properties.PopulateColumns();
            cboTipo.Properties.Columns[0].Visible = false;
            LlenargridArticulos();

        }

        private void botonNuevo_Click(object sender, EventArgs e)
        {
          Nuevo();
        }

        private void botonSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow t in _dtArticulos.Rows)
            {
                t["S"] = true;
            }
        }

        private void botonUnselectAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow t in _dtArticulos.Rows)
            {
                t["S"] = false;
            }
        }

        private void botonDeleteSelected_Click(object sender, EventArgs e)
        {
            foreach (DataRow t in from DataRow t in _dtArticulos.Rows where (bool)t["S"] select t)
            {
                if (t[8].ToString() == "Disponible")
                {
                    var bolven = (_mapeoVentas.Articulos.Where(
                        bol => bol.Clave == Convert.ToInt32(t[1].ToString()))).Single();
                    bolven.Estado = "Baja";
                }

                if (t[8].ToString() == "Apartado")
                {
                    Articulo art =
                        _mapeoVentas.Articulos.Single(
                            a => a.Clave == Convert.ToInt32(t[1]));
                    if (art != null) art.Estado = "Baja";
                    var venta = (_mapeoVentas.DetalleVentas.Where(
                        vta => vta.CveArticulo == Convert.ToInt32(t[1]))
                        .Select(vta => vta.Venta)).Single();
                    venta.Estado = "Moroso";
                }
                _mapeoVentas.SubmitChanges();
            }
            LlenargridArticulos();
        }

        private void BotonEditar_Click(object sender, EventArgs e)
        {new ManejadorControles().DesectivarTextBox(gpoContenedor, true);
            if (cboTipo.EditValue==null)return;
            if ((int) cboTipo.EditValue > 12)
            {
                txtPeso.Properties.ReadOnly = true;
                txtPrecioApartado.Properties.ReadOnly = false;
                txtPrecio.Properties.ReadOnly = false;
            }
            else
            txtPeso.Properties.ReadOnly = false;
        }
        
        private void cboTipo_EditValueChanged(object sender, EventArgs e)
        {
            
            CalcularPrecios();
        }

        private void CalcularPrecios()
        {
            if (cboTipo.EditValue==null)return;
            decimal apartado = 0;
            decimal precio = 0;
            if ((int)cboTipo.EditValue > 12){
                txtPeso.EditValue = 1M;
                txtPeso.Properties.ReadOnly = true;
                txtPrecio.EditValue = 0;
                txtPrecioApartado.EditValue = 0;
                txtPrecio.Properties.ReadOnly = false;
                txtPrecioApartado.Properties.ReadOnly = false;
                return;
            }
            txtPeso.Properties.ReadOnly = false;
            txtPrecio.Properties.ReadOnly = true;
            txtPrecioApartado.Properties.ReadOnly = true;
            object row = cboTipo.Properties.GetDataSourceRowByKeyValue(cboTipo.EditValue);
            if (row != null)
            {
                precio = Convert.ToDecimal(((DataRowView) row)["Contado"].ToString());
                apartado = Convert.ToDecimal(((DataRowView) row)["Apartado"].ToString());
            }
            txtPrecio.EditValue = decimal.Round( precio * Convert.ToDecimal(txtPeso.EditValue));
            txtPrecioApartado.EditValue =decimal.Round( apartado * Convert.ToDecimal(txtPeso.EditValue));
        }

        private void grvArticulos_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle < 0) return;
            if (view == null) return;
            string estado = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Estado"]);
            switch(estado)
            {
                case "Disponible":
                    e.Appearance.BackColor = Color.DarkSeaGreen;
                    break;
                case "Vendido":
                    e.Appearance.BackColor = Color.LightCoral;
                    break;
                case "Apartado":
                    e.Appearance.BackColor = Color.Yellow;
                    break;
                    
            }
        }

        private void grvArticulos_RowClick(object sender, RowClickEventArgs e)
        {
            new ManejadorControles().DesectivarTextBox(gpoContenedor, false);
            txtClave.EditValue = _dtArticulos.Rows[e.RowHandle][1];
            txtDescripcion.EditValue = _dtArticulos.Rows[e.RowHandle][2];
            txtPeso.EditValue = _dtArticulos.Rows[e.RowHandle][3];
            cboTipo.EditValue = cboTipo.Properties.GetKeyValueByDisplayText(_dtArticulos.Rows[e.RowHandle][4].ToString());
            txtPrecio.EditValue = _dtArticulos.Rows[e.RowHandle][5];
            txtPrecioApartado.EditValue = _dtArticulos.Rows[e.RowHandle][6];
            dtpFechaRegistro.EditValue = _dtArticulos.Rows[e.RowHandle][7];
        }

        private void txtPeso_EditValueChanged(object sender, EventArgs e)
        {
            CalcularPrecios();
        }

        private void gpoContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
