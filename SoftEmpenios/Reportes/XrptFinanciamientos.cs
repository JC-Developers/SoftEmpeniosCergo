using System;
using System.Linq;
using SoftEmpenios.DBComun;
using SoftEmpenios.Clases;
using SoftEmpenios.Pantallas;
using System.Windows.Forms;

namespace SoftEmpenios.Reportes
{
    public partial class XrptFinanciamientos : DevExpress.XtraReports.UI.XtraReport, iPantalla
    {
        public XrptFinanciamientos()
        {
            InitializeComponent();
        }
        #region de comando de Herencia
        public bool ConfirmarCierre()
        {
            switch (MessageBox.Show("\x00bfHa realizado cambios sin Guardar?. \x00bfDesea guardarlas?", "Muebleria", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                case DialogResult.Yes:
                    this.Guardar();
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
            
        }
        public void Paginar(int primerRegistro)
        {
            throw new NotImplementedException();
        }
        public string nombrePantalla
        {
            get
            {
                return "Reporte Financiamiento";
            }
        }

        #endregion
        private void rptFinanciamientos_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            IQueryable<Prestamo> prestamos = from p in new EmpeñosDC(new clsConeccionDB().StringConn()).Prestamos
                                             where p.FechaPrestamo.Date==DateTime.Today.Date && p.Estado!="Cancelado"
                                             select p;
            DatosInforme.DataSource = prestamos;

        }
        

    }
}
