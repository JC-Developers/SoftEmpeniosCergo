using System;
using System.Data;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;
using SoftEmpenios.Dialogos;

namespace SoftEmpenios.Pantallas
{
    public partial class FrmListaGrupos : DevExpress.XtraEditors.XtraForm, iPantalla
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        public FrmListaGrupos()
        {
            InitializeComponent();
        }

        public void Buscar()
        {
            //throw new NotImplementedException();
        }

        public void Eliminar()
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            //throw new NotImplementedException();
        }

        public void Nuevo()
        {
            //throw new NotImplementedException();
        }

        public string nombrePantalla {
            get { return "Lista de Grupos"; }
        }

        private void CargarGrupos()
        {

            DataSet gruposDS=new DataSet("Grupos");
            var grupos = _entidades.FinancieraGrupos.Select(g => new {g.Clave,Grupo= g.Nombre, g.Estado, g.FechaModificacion});
            var integrantes = _entidades.FinancieraGruposDetalles.Select(g => new {g.CveGrupo, g.CveCliente,g.FinancieraCliente.Nombre,g.Solicitado,g.Aprobado,g.Base,g.Tipo});
            if (!grupos.Any())return;
            DataTable gruposDT = new LinqToDataTable().ObtenerDataTable2(grupos);
            DataTable integratesDT = new LinqToDataTable().ObtenerDataTable2(integrantes);
            gruposDS.Tables.AddRange(new []{gruposDT,integratesDT});

            //DataColumn keyColumn = gruposDS.Tables[0].Columns["Clave"];
            //DataColumn foreignKeyColumn = gruposDS.Tables[1].Columns["CveGrupo"];
            //gruposDS.Relations.Add("Pagos", keyColumn, foreignKeyColumn);
            gruposDS.Relations.Add("Integrantes", gruposDT.Columns[0], integratesDT.Columns[0]);

            gridGrupos.DataSource = gruposDS.Tables[0];
            gridGrupos.ForceInitialize();
            grvIntegrantes.PopulateColumns(gruposDS.Tables[1]);
            new MyFindPanelFilterHelper(grvGrupos);
            
        }

        private void gridGrupos_Load(object sender, EventArgs e)
        {
            CargarGrupos();
            grvGrupos_RowClick(grvGrupos, null);
        }

        private void BotonNuevo_Click(object sender, EventArgs e)
        {
            new XfrmGrupo().ShowDialog(this);
            CargarGrupos();
        }
        private void BotonEditar_Click(object sender, EventArgs e)
        {
            if (grvGrupos.FocusedRowHandle<0)return;
            XfrmGrupo frmgrupo=new XfrmGrupo
            {
                CveGrupo = Convert.ToInt32(grvGrupos.GetFocusedRowCellValue("Clave"))
            };
            frmgrupo.ShowDialog(this);
            CargarGrupos();
        }

        private void grvGrupos_RowClick(object sender, RowClickEventArgs e)
        {
            if (grvGrupos.FocusedRowHandle<0)
                return;
            string estado = grvGrupos.GetRowCellValue(grvGrupos.FocusedRowHandle, "Estado").ToString();
            BotonEditar.Enabled = (estado == "PROCESO" || estado == "INACTIVO");

        }

        private void cboCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            grvGrupos.OptionsFind.FindFilterColumns = cboCriterio.Text;
            grvGrupos.ApplyFindFilter("");
        }

    }
}