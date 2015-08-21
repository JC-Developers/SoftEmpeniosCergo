using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SoftEmpenios.DBComun;
using SoftEmpenios.Clases;
//using System.Windows.Forms.DataVisualization.Charting;

namespace SoftEmpenios.Pantallas
{
    public partial class frmGraficas : Form
    {
        public frmGraficas()
        {
            InitializeComponent();
        }
        DbCasaEmpeniosDataContext mapeoCasaEmpeniosDC = new DbCasaEmpeniosDataContext(new clsConeccionDB().StringConn());
        private void SacarCajaActual()
        {
            var com = from c in mapeoCasaEmpeniosDC.ComprasDC
                      where c.FechaCompra == DateTime.Today.Date.AddDays(-1)
                      select new { c.TotalCompra };
            //var empe = from e in mapeoCasaEmpeniosDC.VistaGraficasDC
                       //where (e.FechaPrestamo >= DateTime.Today.AddMonths(-5) && e.FechaPrestamo < DateTime.Today.AddMonths(-4))

                       //group e by e.FechaPrestamo.ToString("MM-yy") into em
                       //select new {Fecha=em.Key,Prestamo=em.};
            //var graficas = from ef in mapeoCasaEmpeniosDC.VistaGraficasDC
            //               where (ef.FechaPrestamo > Convert.ToDateTime("9/12/2008") && ef.FechaPrestamo <= Convert.ToDateTime("13/1/2009"))
            //               //group  by  ef.FechaPrestamo.ToString("MM-YY") into em
            //               orderby ef.FechaPrestamo
            //               select ef;

            var inte = from i in mapeoCasaEmpeniosDC.PagosInteresDC
                       where i.FechaPago == DateTime.Today.Date.AddDays(-1)
                       select new { i.TotalPagar };
            var desem = from d in mapeoCasaEmpeniosDC.DesempeñosDC
                        where d.FechaDesempeño == DateTime.Today.Date.AddDays(-1)
                        select new { d.TotalPagar };
            //var ret = from r in mapeoCasaEmpeniosDC.TransaccionesDC
            //          where r.FechaTransaccion == DateTime.Today.Date && r.TipoTransaccion == "Retiro"
            //          select new { r.Cantidad };
            //var dep = from depo in mapeoCasaEmpeniosDC.TransaccionesDC
            //          where depo.FechaTransaccion == DateTime.Today.Date && depo.TipoTransaccion == "Deposito"                   //DateTime.Now
            //          select new { depo.Cantidad };
            //var cajahoy = from c in mapeoCasaEmpeniosDC.CajaDC
            //              where c.FechaCajaAbierto == DateTime.Today.Date && c.Estado == true
            //              select new { c.CajaInicial };
            //decimal CajaInicial = (cajahoy.Count() != 0) ? cajahoy.AsEnumerable().Sum(c => c.CajaInicial) : 0;
            decimal Compras = (com.Count() != 0) ? com.AsEnumerable().Sum(o => o.TotalCompra) : 0;//(com.AsEnumerable().Sum(o => o.TotalCompra)!=null)?com.AsEnumerable().Sum(o => o.TotalCompra):0;
            //object[] Empeniosf = empe.ToArray();//(empe.Count() != 0) ? empe.AsEnumerable().Sum(e => e.Prestamo) : 0;
            //object[] Empenios = empef.ToArray();
            //DataTable empenios = new LinqToDataTable().ObtenerDataTable2(graficas);
            decimal PagosIntereses = (inte.Count() != 0) ? inte.AsEnumerable().Sum(i => i.TotalPagar) : 0;
            decimal Desempenios = (desem.Count() != 0) ? desem.AsEnumerable().Sum(d => d.TotalPagar) : 0;
            //LlenarGrafica(empenios);
            //Empeniosbs.DataSource = graficas;
           // Grafica.DataManipulator.Group("Y1:FechaPrestamo,Y2:FechaPago,Y3:FechaDesempeño,Y4:FechaCompra",1, IntervalType.Months, "PrestamoDia", "GroupedStockPrice");

            //Grafica.EmpeniosbsSeries["Empenios"].Points.DataBindXY(empe,"Prestamo",empef,"FechaPrestamo");
            //decimal Retiros = (ret.Count() != 0) ? ret.AsEnumerable().Sum(r => r.Cantidad) : 0;
            //decimal Depositos = (dep.Count() != 0) ? dep.AsEnumerable().Sum(depo => depo.Cantidad) : 0;

            //decimal CajaActual = (CajaInicial + Depositos + PagosIntereses + Desempenios) - (Empenios + Retiros + Compras);
            //return CajaActual;
            //throw new NotImplementedException();
        }
        //private void LlenarGrafica(DataTable empenios)
        //{

        //    //Grafica.Series["Empenios"].Points.DataBind();
        //    for (int i = 0; i < empenios.Rows.Count; i++)
        //    {
        //        Grafica.Series[0].Points.AddXY(empenios.Rows[i][0], empenios.Rows[i][1]);
        //    }

            
        //    //Grafica.Series["Compras"].Points.Add(6520);
        //    //Grafica.Series["Compras"].Points.Add(3856);
        //    //Grafica.Series["Compras"].Points.Add(3895);
        //    //Grafica.Series["Compras"].Points.Add(5856);
        //}

        //private void frmGraficas_Load(object sender, EventArgs e)
        //{
        //    SacarCajaActual();
        //}
    }
}
