namespace SoftEmpenios.Dialogos
{
    partial class FrmReportesFechas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpoContenedor = new DevExpress.XtraEditors.GroupControl();
            this.botonVerInforme = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpFechaFinal = new DevExpress.XtraEditors.DateEdit();
            this.cboTipoReporte = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dtpFechaInicial = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).BeginInit();
            this.gpoContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoReporte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gpoContenedor
            // 
            this.gpoContenedor.Appearance.BackColor = System.Drawing.Color.Orange;
            this.gpoContenedor.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gpoContenedor.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gpoContenedor.Appearance.Options.UseBackColor = true;
            this.gpoContenedor.AppearanceCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gpoContenedor.AppearanceCaption.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gpoContenedor.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.gpoContenedor.AppearanceCaption.ForeColor = System.Drawing.Color.White;
            this.gpoContenedor.AppearanceCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gpoContenedor.AppearanceCaption.Options.UseBackColor = true;
            this.gpoContenedor.AppearanceCaption.Options.UseFont = true;
            this.gpoContenedor.AppearanceCaption.Options.UseForeColor = true;
            this.gpoContenedor.AppearanceCaption.Options.UseTextOptions = true;
            this.gpoContenedor.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gpoContenedor.Controls.Add(this.botonVerInforme);
            this.gpoContenedor.Controls.Add(this.labelControl1);
            this.gpoContenedor.Controls.Add(this.dtpFechaFinal);
            this.gpoContenedor.Controls.Add(this.cboTipoReporte);
            this.gpoContenedor.Controls.Add(this.labelControl2);
            this.gpoContenedor.Controls.Add(this.labelControl4);
            this.gpoContenedor.Controls.Add(this.dtpFechaInicial);
            this.gpoContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpoContenedor.Location = new System.Drawing.Point(0, 0);
            this.gpoContenedor.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gpoContenedor.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gpoContenedor.Name = "gpoContenedor";
            this.gpoContenedor.Size = new System.Drawing.Size(417, 259);
            this.gpoContenedor.TabIndex = 2;
            this.gpoContenedor.Text = "Reportes por Fecha";
            // 
            // botonVerInforme
            // 
            this.botonVerInforme.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.botonVerInforme.Appearance.Options.UseFont = true;
            this.botonVerInforme.Image = global::SoftEmpenios.Properties.Resources.reporteLarge;
            this.botonVerInforme.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopLeft;
            this.botonVerInforme.Location = new System.Drawing.Point(333, 168);
            this.botonVerInforme.Name = "botonVerInforme";
            this.botonVerInforme.Size = new System.Drawing.Size(70, 86);
            this.botonVerInforme.TabIndex = 82;
            this.botonVerInforme.Text = "Ver";
            this.botonVerInforme.Click += new System.EventHandler(this.botonVerInforme_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl1.Location = new System.Drawing.Point(99, 140);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 18);
            this.labelControl1.TabIndex = 81;
            this.labelControl1.Text = "Fecha Final:";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.EditValue = new System.DateTime(2013, 10, 12, 20, 45, 55, 449);
            this.dtpFechaFinal.Location = new System.Drawing.Point(202, 136);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dtpFechaFinal.Properties.Appearance.Options.UseFont = true;
            this.dtpFechaFinal.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpFechaFinal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpFechaFinal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFechaFinal.Properties.DisplayFormat.FormatString = "dd/MMMM/yyyy";
            this.dtpFechaFinal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpFechaFinal.Properties.EditFormat.FormatString = "dd/MMMM/yyyy";
            this.dtpFechaFinal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpFechaFinal.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpFechaFinal.Size = new System.Drawing.Size(201, 26);
            this.dtpFechaFinal.TabIndex = 80;
            // 
            // cboTipoReporte
            // 
            this.cboTipoReporte.Location = new System.Drawing.Point(202, 50);
            this.cboTipoReporte.Name = "cboTipoReporte";
            this.cboTipoReporte.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cboTipoReporte.Properties.Appearance.Options.UseFont = true;
            this.cboTipoReporte.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoReporte.Properties.DropDownRows = 19;
            this.cboTipoReporte.Properties.Items.AddRange(new object[] {
            "Empeños",
            "Pagos de Interes",
            "Desempeños",
            "Compras",
            "Depositos",
            "Retiros",
            "Cortes de Caja",
            "Cancelaciones",
            "Etiquetas Boletas",
            "Ingreso Articulos",
            "Ventas",
            "Abono a Ventas",
            "Financiamiento",
            "Pago a Financiamiento",
            "Base Créditos",
            "Créditos Grupales",
            "Pagos Grupales",
            "Créditos Liquidados",
            "Financiamientos Liquidados"});
            this.cboTipoReporte.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTipoReporte.Size = new System.Drawing.Size(201, 26);
            this.cboTipoReporte.TabIndex = 79;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl2.Location = new System.Drawing.Point(25, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(171, 18);
            this.labelControl2.TabIndex = 78;
            this.labelControl2.Text = "Selecione el Reporte:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl4.Location = new System.Drawing.Point(94, 108);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(102, 18);
            this.labelControl4.TabIndex = 77;
            this.labelControl4.Text = "Fecha Inicio:";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.EditValue = new System.DateTime(2013, 10, 12, 20, 45, 55, 449);
            this.dtpFechaInicial.Location = new System.Drawing.Point(202, 104);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dtpFechaInicial.Properties.Appearance.Options.UseFont = true;
            this.dtpFechaInicial.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpFechaInicial.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpFechaInicial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFechaInicial.Properties.DisplayFormat.FormatString = "dd/MMMM/yyyy";
            this.dtpFechaInicial.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpFechaInicial.Properties.EditFormat.FormatString = "dd/MMMM/yyyy";
            this.dtpFechaInicial.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpFechaInicial.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpFechaInicial.Size = new System.Drawing.Size(201, 26);
            this.dtpFechaInicial.TabIndex = 76;
            // 
            // FrmReportesFechas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 259);
            this.Controls.Add(this.gpoContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmReportesFechas";
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).EndInit();
            this.gpoContenedor.ResumeLayout(false);
            this.gpoContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoReporte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpoContenedor;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipoReporte;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit dtpFechaInicial;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtpFechaFinal;
        private DevExpress.XtraEditors.SimpleButton botonVerInforme;
    }
}