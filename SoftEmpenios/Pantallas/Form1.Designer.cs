namespace SoftEmpenios.Pantallas
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.RectangleGradientFillOptions rectangleGradientFillOptions3 = new DevExpress.XtraCharts.RectangleGradientFillOptions();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel3 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView3 = new DevExpress.XtraCharts.LineSeriesView();
            this.gpoContenedor = new DevExpress.XtraEditors.GroupControl();
            this.botonVerGrafica = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipoDato = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpFechaFinal = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dtpFechaInicial = new DevExpress.XtraEditors.DateEdit();
            this.cboTipoMuestra = new DevExpress.XtraEditors.ComboBoxEdit();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.cajaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).BeginInit();
            this.gpoContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDato.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoMuestra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cajaBindingSource)).BeginInit();
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
            this.gpoContenedor.Controls.Add(this.botonVerGrafica);
            this.gpoContenedor.Controls.Add(this.labelControl3);
            this.gpoContenedor.Controls.Add(this.labelControl2);
            this.gpoContenedor.Controls.Add(this.cboTipoDato);
            this.gpoContenedor.Controls.Add(this.labelControl1);
            this.gpoContenedor.Controls.Add(this.dtpFechaFinal);
            this.gpoContenedor.Controls.Add(this.labelControl4);
            this.gpoContenedor.Controls.Add(this.dtpFechaInicial);
            this.gpoContenedor.Controls.Add(this.cboTipoMuestra);
            this.gpoContenedor.Controls.Add(this.chartControl1);
            this.gpoContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpoContenedor.Location = new System.Drawing.Point(0, 0);
            this.gpoContenedor.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gpoContenedor.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gpoContenedor.Name = "gpoContenedor";
            this.gpoContenedor.Size = new System.Drawing.Size(1014, 489);
            this.gpoContenedor.TabIndex = 1;
            this.gpoContenedor.Text = "Graficas de Empeños";
            // 
            // botonVerGrafica
            // 
            this.botonVerGrafica.Location = new System.Drawing.Point(678, 69);
            this.botonVerGrafica.Name = "botonVerGrafica";
            this.botonVerGrafica.Size = new System.Drawing.Size(106, 23);
            this.botonVerGrafica.TabIndex = 89;
            this.botonVerGrafica.Text = "Mostrar Grafica";
            this.botonVerGrafica.Click += new System.EventHandler(this.botonVerGrafica_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl3.Location = new System.Drawing.Point(383, 85);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(150, 18);
            this.labelControl3.TabIndex = 88;
            this.labelControl3.Text = "Rango de Muestra:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl2.Location = new System.Drawing.Point(428, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(105, 18);
            this.labelControl2.TabIndex = 87;
            this.labelControl2.Text = "Tipo de Dato:";
            // 
            // cboTipoDato
            // 
            this.cboTipoDato.Location = new System.Drawing.Point(539, 49);
            this.cboTipoDato.Name = "cboTipoDato";
            this.cboTipoDato.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cboTipoDato.Properties.Appearance.Options.UseFont = true;
            this.cboTipoDato.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoDato.Properties.Items.AddRange(new object[] {
            "Empeños",
            "Intereses",
            "Desempeños",
            "Compras",
            "Ventas",
            "Abono a Ventas",
            "Financiamientos",
            "Pagos a Financiamiento"});
            this.cboTipoDato.Size = new System.Drawing.Size(133, 26);
            this.cboTipoDato.TabIndex = 86;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl1.Location = new System.Drawing.Point(62, 85);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 18);
            this.labelControl1.TabIndex = 85;
            this.labelControl1.Text = "Fecha Final:";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.EditValue = new System.DateTime(2013, 10, 12, 20, 45, 55, 449);
            this.dtpFechaFinal.Location = new System.Drawing.Point(165, 81);
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
            this.dtpFechaFinal.TabIndex = 84;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl4.Location = new System.Drawing.Point(57, 53);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(102, 18);
            this.labelControl4.TabIndex = 83;
            this.labelControl4.Text = "Fecha Inicio:";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.EditValue = new System.DateTime(2013, 10, 12, 20, 45, 55, 449);
            this.dtpFechaInicial.Location = new System.Drawing.Point(165, 49);
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
            this.dtpFechaInicial.TabIndex = 82;
            // 
            // cboTipoMuestra
            // 
            this.cboTipoMuestra.Location = new System.Drawing.Point(539, 82);
            this.cboTipoMuestra.Name = "cboTipoMuestra";
            this.cboTipoMuestra.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cboTipoMuestra.Properties.Appearance.Options.UseFont = true;
            this.cboTipoMuestra.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoMuestra.Properties.Items.AddRange(new object[] {
            "Dias",
            "Meses",
            "Años"});
            this.cboTipoMuestra.Size = new System.Drawing.Size(133, 26);
            this.cboTipoMuestra.TabIndex = 1;
            // 
            // chartControl1
            // 
            this.chartControl1.AppearanceNameSerializable = "The Trees";
            this.chartControl1.BackColor = System.Drawing.Color.Orange;
            this.chartControl1.DataSource = this.cajaBindingSource;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chartControl1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Gradient;
            rectangleGradientFillOptions3.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.chartControl1.FillStyle.Options = rectangleGradientFillOptions3;
            this.chartControl1.Location = new System.Drawing.Point(2, 134);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.PaletteBaseColorNumber = 1;
            this.chartControl1.PaletteName = "Opulent";
            this.chartControl1.PaletteRepository.Add("Paleta 1", new DevExpress.XtraCharts.Palette("Paleta 1", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Silver, System.Drawing.Color.Silver)}));
            this.chartControl1.PaletteRepository.Add("Paleta 2", new DevExpress.XtraCharts.Palette("Paleta 2", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Silver, System.Drawing.Color.Silver)}));
            this.chartControl1.SeriesDataMember = "TotalEmpenios";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl1.SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            pointSeriesLabel3.LineVisible = true;
            this.chartControl1.SeriesTemplate.Label = pointSeriesLabel3;
            this.chartControl1.SeriesTemplate.View = lineSeriesView3;
            this.chartControl1.SeriesTemplate.Visible = false;
            this.chartControl1.Size = new System.Drawing.Size(1010, 353);
            this.chartControl1.TabIndex = 0;
            // 
            // cajaBindingSource
            // 
            this.cajaBindingSource.DataSource = typeof(SoftEmpenios.DBComun.Caja);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 489);
            this.Controls.Add(this.gpoContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).EndInit();
            this.gpoContenedor.ResumeLayout(false);
            this.gpoContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDato.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaInicial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoMuestra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cajaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpoContenedor;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.BindingSource cajaBindingSource;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipoMuestra;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtpFechaFinal;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit dtpFechaInicial;
        private DevExpress.XtraEditors.SimpleButton botonVerGrafica;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipoDato;
    }
}