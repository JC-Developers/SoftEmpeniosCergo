using System;
using System.Windows.Forms;
using SoftEmpenios.Dialogos;
using System.Threading;
using SoftEmpenios.Clases;

namespace SoftEmpenios
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        public static void DoSplash()
        {
            new FrmInicio().ShowDialog();
        }


        [STAThread]
        private static void Main()
        {
            var thread = new Thread(DoSplash) {IsBackground = true};
            thread.Start();
            Thread.Sleep(5000);
            thread.Abort();
            Thread.Sleep(1000);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var configuracion = new clsModificarConfiguracion();
            if (!configuracion.ExisteArchivoApp())
            {
                MessageBox.Show("Error , no existe el archivo de configuracion.");
            }
            else
            {
                if (!configuracion.ValidaClaves())
                {
                    Application.Run(new FrmConfiguraciones());
                }
                Application.Run(new FrmSoftEmpenios());
                //Application.Run(new FrmPagosInteres());
            }
        }
    }
}
