namespace SoftEmpenios.Pantallas
{
    partial class FrmAbonosVenta
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCveAbono = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtAbono = new SoftEmpenios.Controles.TextEditSelected();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.dtpFechaAbono = new DevExpress.XtraEditors.DateEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarPrestamo = new SoftEmpenios.Controles.BotonCambiante();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtSaldo = new SoftEmpenios.Controles.TextEditSelected();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dtpFechaVenta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCliente = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtEnganche = new SoftEmpenios.Controles.TextEditSelected();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotalVenta = new SoftEmpenios.Controles.TextEditSelected();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtCveVenta = new DevExpress.XtraEditors.TextEdit();
            this.gridAbonos = new DevExpress.XtraGrid.GridControl();
            this.grvAbonos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridArticulos = new DevExpress.XtraGrid.GridControl();
            this.grvArticulos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.botonNuevo = new SoftEmpenios.Controles.BotonCambiante();
            this.botonGuardar = new SoftEmpenios.Controles.BotonCambiante();
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).BeginInit();
            this.gpoContenedor.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCveAbono.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbono.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaAbono.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaAbono.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaVenta.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnganche.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCveVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAbonos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAbonos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvArticulos)).BeginInit();
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
            this.gpoContenedor.Controls.Add(this.groupBox2);
            this.gpoContenedor.Controls.Add(this.groupBox1);
            this.gpoContenedor.Controls.Add(this.gridAbonos);
            this.gpoContenedor.Controls.Add(this.gridArticulos);
            this.gpoContenedor.Controls.Add(this.botonNuevo);
            this.gpoContenedor.Controls.Add(this.botonGuardar);
            this.gpoContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpoContenedor.Location = new System.Drawing.Point(0, 0);
            this.gpoContenedor.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gpoContenedor.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gpoContenedor.Name = "gpoContenedor";
            this.gpoContenedor.Size = new System.Drawing.Size(949, 432);
            this.gpoContenedor.TabIndex = 0;
            this.gpoContenedor.Text = "Abono a Ventas Apartado";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.labelControl2);
            this.groupBox2.Controls.Add(this.txtCveAbono);
            this.groupBox2.Controls.Add(this.labelControl5);
            this.groupBox2.Controls.Add(this.txtAbono);
            this.groupBox2.Controls.Add(this.labelControl6);
            this.groupBox2.Controls.Add(this.dtpFechaAbono);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(534, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 154);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Abono a Venta";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl2.Location = new System.Drawing.Point(212, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 18);
            this.labelControl2.TabIndex = 50;
            this.labelControl2.Text = "Clave:";
            // 
            // txtCveAbono
            // 
            this.txtCveAbono.EditValue = 0;
            this.txtCveAbono.Location = new System.Drawing.Point(268, 48);
            this.txtCveAbono.Name = "txtCveAbono";
            this.txtCveAbono.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtCveAbono.Properties.Appearance.Options.UseFont = true;
            this.txtCveAbono.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCveAbono.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCveAbono.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCveAbono.Properties.ReadOnly = true;
            this.txtCveAbono.Size = new System.Drawing.Size(130, 26);
            this.txtCveAbono.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F);
            this.labelControl5.Location = new System.Drawing.Point(159, 119);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(69, 23);
            this.labelControl5.TabIndex = 44;
            this.labelControl5.Text = "Abono:";
            // 
            // txtAbono
            // 
            this.txtAbono.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAbono.Location = new System.Drawing.Point(237, 116);
            this.txtAbono.Name = "txtAbono";
            this.txtAbono.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.txtAbono.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtAbono.Properties.Appearance.Options.UseFont = true;
            this.txtAbono.Properties.Appearance.Options.UseForeColor = true;
            this.txtAbono.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAbono.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtAbono.Properties.DisplayFormat.FormatString = "$ ##,##0.00";
            this.txtAbono.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAbono.Properties.Mask.EditMask = "c";
            this.txtAbono.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAbono.Size = new System.Drawing.Size(161, 32);
            this.txtAbono.TabIndex = 0;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl6.Location = new System.Drawing.Point(151, 20);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(111, 18);
            this.labelControl6.TabIndex = 37;
            this.labelControl6.Text = "Fecha Abono:";
            // 
            // dtpFechaAbono
            // 
            this.dtpFechaAbono.EditValue = new System.DateTime(2013, 10, 12, 20, 45, 55, 449);
            this.dtpFechaAbono.Location = new System.Drawing.Point(268, 16);
            this.dtpFechaAbono.Name = "dtpFechaAbono";
            this.dtpFechaAbono.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dtpFechaAbono.Properties.Appearance.Options.UseFont = true;
            this.dtpFechaAbono.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpFechaAbono.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpFechaAbono.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFechaAbono.Properties.DisplayFormat.FormatString = "dd/MMM/yyyy";
            this.dtpFechaAbono.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpFechaAbono.Properties.ReadOnly = true;
            this.dtpFechaAbono.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpFechaAbono.Size = new System.Drawing.Size(130, 26);
            this.dtpFechaAbono.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnBuscarPrestamo);
            this.groupBox1.Controls.Add(this.labelControl7);
            this.groupBox1.Controls.Add(this.txtSaldo);
            this.groupBox1.Controls.Add(this.labelControl4);
            this.groupBox1.Controls.Add(this.dtpFechaVenta);
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.txtEnganche);
            this.groupBox1.Controls.Add(this.labelControl11);
            this.groupBox1.Controls.Add(this.txtTotalVenta);
            this.groupBox1.Controls.Add(this.labelControl8);
            this.groupBox1.Controls.Add(this.txtCveVenta);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 158);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Venta";
            // 
            // btnBuscarPrestamo
            // 
            this.btnBuscarPrestamo.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarPrestamo.EtiquetaBoton = "Buscar Cliente";
            this.btnBuscarPrestamo.FlatAppearance.BorderSize = 0;
            this.btnBuscarPrestamo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBuscarPrestamo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBuscarPrestamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPrestamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPrestamo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscarPrestamo.Image = global::SoftEmpenios.Properties.Resources.Buscar;
            this.btnBuscarPrestamo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscarPrestamo.imgDisable = global::SoftEmpenios.Properties.Resources.BuscarD;
            this.btnBuscarPrestamo.imgencima = global::SoftEmpenios.Properties.Resources.BuscarO;
            this.btnBuscarPrestamo.imgnormal = global::SoftEmpenios.Properties.Resources.Buscar;
            this.btnBuscarPrestamo.imgPrecionado = global::SoftEmpenios.Properties.Resources.BuscarP;
            this.btnBuscarPrestamo.Location = new System.Drawing.Point(222, 22);
            this.btnBuscarPrestamo.Name = "btnBuscarPrestamo";
            this.btnBuscarPrestamo.Size = new System.Drawing.Size(32, 30);
            this.btnBuscarPrestamo.TabIndex = 77;
            this.btnBuscarPrestamo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarPrestamo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscarPrestamo.UseVisualStyleBackColor = false;
            this.btnBuscarPrestamo.Click += new System.EventHandler(this.btnBuscarPrestamo_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl7.Location = new System.Drawing.Point(51, 125);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(50, 18);
            this.labelControl7.TabIndex = 56;
            this.labelControl7.Text = "Saldo:";
            // 
            // txtSaldo
            // 
            this.txtSaldo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldo.Location = new System.Drawing.Point(107, 121);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSaldo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSaldo.Properties.Appearance.Options.UseFont = true;
            this.txtSaldo.Properties.Appearance.Options.UseForeColor = true;
            this.txtSaldo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSaldo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtSaldo.Properties.DisplayFormat.FormatString = "$ ##,##0.00";
            this.txtSaldo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSaldo.Properties.EditFormat.FormatString = "$ ##,##0.00";
            this.txtSaldo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSaldo.Properties.Mask.EditMask = "c2";
            this.txtSaldo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSaldo.Properties.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(111, 26);
            this.txtSaldo.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl4.Location = new System.Drawing.Point(264, 30);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(106, 18);
            this.labelControl4.TabIndex = 54;
            this.labelControl4.Text = "Fecha Venta:";
            // 
            // dtpFechaVenta
            // 
            this.dtpFechaVenta.EditValue = new System.DateTime(2013, 10, 12, 20, 45, 55, 449);
            this.dtpFechaVenta.Location = new System.Drawing.Point(381, 26);
            this.dtpFechaVenta.Name = "dtpFechaVenta";
            this.dtpFechaVenta.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dtpFechaVenta.Properties.Appearance.Options.UseFont = true;
            this.dtpFechaVenta.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpFechaVenta.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpFechaVenta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFechaVenta.Properties.DisplayFormat.FormatString = "dd/MMM/yyyy";
            this.dtpFechaVenta.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpFechaVenta.Properties.ReadOnly = true;
            this.dtpFechaVenta.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpFechaVenta.Size = new System.Drawing.Size(123, 26);
            this.dtpFechaVenta.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl3.Location = new System.Drawing.Point(40, 61);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(61, 18);
            this.labelControl3.TabIndex = 52;
            this.labelControl3.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.EditValue = "";
            this.txtCliente.Location = new System.Drawing.Point(107, 57);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtCliente.Properties.Appearance.Options.UseFont = true;
            this.txtCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCliente.Properties.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(397, 26);
            this.txtCliente.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl1.Location = new System.Drawing.Point(289, 93);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(86, 18);
            this.labelControl1.TabIndex = 47;
            this.labelControl1.Text = "Enganche:";
            // 
            // txtEnganche
            // 
            this.txtEnganche.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtEnganche.Location = new System.Drawing.Point(381, 90);
            this.txtEnganche.Name = "txtEnganche";
            this.txtEnganche.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtEnganche.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEnganche.Properties.Appearance.Options.UseFont = true;
            this.txtEnganche.Properties.Appearance.Options.UseForeColor = true;
            this.txtEnganche.Properties.Appearance.Options.UseTextOptions = true;
            this.txtEnganche.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtEnganche.Properties.DisplayFormat.FormatString = "$ ##,##0.00";
            this.txtEnganche.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEnganche.Properties.EditFormat.FormatString = "$ ##,##0.00";
            this.txtEnganche.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEnganche.Properties.Mask.EditMask = "c2";
            this.txtEnganche.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtEnganche.Properties.ReadOnly = true;
            this.txtEnganche.Size = new System.Drawing.Size(123, 26);
            this.txtEnganche.TabIndex = 4;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl11.Location = new System.Drawing.Point(5, 93);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(96, 18);
            this.labelControl11.TabIndex = 45;
            this.labelControl11.Text = "Total Venta:";
            // 
            // txtTotalVenta
            // 
            this.txtTotalVenta.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalVenta.Location = new System.Drawing.Point(107, 89);
            this.txtTotalVenta.Name = "txtTotalVenta";
            this.txtTotalVenta.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTotalVenta.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTotalVenta.Properties.Appearance.Options.UseFont = true;
            this.txtTotalVenta.Properties.Appearance.Options.UseForeColor = true;
            this.txtTotalVenta.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalVenta.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalVenta.Properties.DisplayFormat.FormatString = "$ ##,##0.00";
            this.txtTotalVenta.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalVenta.Properties.EditFormat.FormatString = "$ ##,##0.00";
            this.txtTotalVenta.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalVenta.Properties.Mask.EditMask = "c2";
            this.txtTotalVenta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalVenta.Properties.ReadOnly = true;
            this.txtTotalVenta.Size = new System.Drawing.Size(111, 26);
            this.txtTotalVenta.TabIndex = 3;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl8.Location = new System.Drawing.Point(51, 29);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(50, 18);
            this.labelControl8.TabIndex = 35;
            this.labelControl8.Text = "Clave:";
            // 
            // txtCveVenta
            // 
            this.txtCveVenta.EditValue = 0;
            this.txtCveVenta.Location = new System.Drawing.Point(107, 26);
            this.txtCveVenta.Name = "txtCveVenta";
            this.txtCveVenta.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtCveVenta.Properties.Appearance.Options.UseFont = true;
            this.txtCveVenta.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCveVenta.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCveVenta.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCveVenta.Properties.Mask.EditMask = "n0";
            this.txtCveVenta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCveVenta.Properties.ReadOnly = true;
            this.txtCveVenta.Size = new System.Drawing.Size(111, 26);
            this.txtCveVenta.TabIndex = 0;
            // 
            // gridAbonos
            // 
            this.gridAbonos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAbonos.Location = new System.Drawing.Point(12, 210);
            this.gridAbonos.MainView = this.grvAbonos;
            this.gridAbonos.Name = "gridAbonos";
            this.gridAbonos.Size = new System.Drawing.Size(516, 154);
            this.gridAbonos.TabIndex = 2;
            this.gridAbonos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAbonos});
            // 
            // grvAbonos
            // 
            this.grvAbonos.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvAbonos.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvAbonos.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.grvAbonos.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.grvAbonos.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.grvAbonos.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.grvAbonos.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvAbonos.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvAbonos.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.grvAbonos.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.grvAbonos.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.grvAbonos.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.grvAbonos.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvAbonos.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.grvAbonos.Appearance.Empty.Options.UseBackColor = true;
            this.grvAbonos.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvAbonos.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.grvAbonos.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvAbonos.Appearance.EvenRow.Options.UseForeColor = true;
            this.grvAbonos.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvAbonos.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvAbonos.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.grvAbonos.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.grvAbonos.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.grvAbonos.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.grvAbonos.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvAbonos.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.grvAbonos.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvAbonos.Appearance.FilterPanel.Options.UseBackColor = true;
            this.grvAbonos.Appearance.FilterPanel.Options.UseForeColor = true;
            this.grvAbonos.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(153)))), ((int)(((byte)(73)))));
            this.grvAbonos.Appearance.FixedLine.Options.UseBackColor = true;
            this.grvAbonos.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.grvAbonos.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvAbonos.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAbonos.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAbonos.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(154)))), ((int)(((byte)(91)))));
            this.grvAbonos.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAbonos.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAbonos.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAbonos.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvAbonos.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvAbonos.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvAbonos.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grvAbonos.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grvAbonos.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvAbonos.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvAbonos.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvAbonos.Appearance.GroupButton.Options.UseBackColor = true;
            this.grvAbonos.Appearance.GroupButton.Options.UseBorderColor = true;
            this.grvAbonos.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvAbonos.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvAbonos.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.grvAbonos.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvAbonos.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvAbonos.Appearance.GroupFooter.Options.UseForeColor = true;
            this.grvAbonos.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvAbonos.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.grvAbonos.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.grvAbonos.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAbonos.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grvAbonos.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvAbonos.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvAbonos.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grvAbonos.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAbonos.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grvAbonos.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAbonos.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvAbonos.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvAbonos.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.grvAbonos.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvAbonos.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAbonos.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAbonos.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAbonos.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvAbonos.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvAbonos.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvAbonos.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(183)))), ((int)(((byte)(125)))));
            this.grvAbonos.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvAbonos.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAbonos.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAbonos.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvAbonos.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAbonos.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
            this.grvAbonos.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.grvAbonos.Appearance.OddRow.Options.UseBackColor = true;
            this.grvAbonos.Appearance.OddRow.Options.UseForeColor = true;
            this.grvAbonos.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(249)))));
            this.grvAbonos.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.grvAbonos.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(146)))), ((int)(((byte)(78)))));
            this.grvAbonos.Appearance.Preview.Options.UseBackColor = true;
            this.grvAbonos.Appearance.Preview.Options.UseFont = true;
            this.grvAbonos.Appearance.Preview.Options.UseForeColor = true;
            this.grvAbonos.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvAbonos.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvAbonos.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.grvAbonos.Appearance.Row.Options.UseBackColor = true;
            this.grvAbonos.Appearance.Row.Options.UseBorderColor = true;
            this.grvAbonos.Appearance.Row.Options.UseForeColor = true;
            this.grvAbonos.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvAbonos.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.grvAbonos.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvAbonos.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(167)))), ((int)(((byte)(103)))));
            this.grvAbonos.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvAbonos.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.grvAbonos.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grvAbonos.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvAbonos.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAbonos.GridControl = this.gridAbonos;
            this.grvAbonos.Name = "grvAbonos";
            this.grvAbonos.OptionsBehavior.Editable = false;
            this.grvAbonos.OptionsCustomization.AllowColumnMoving = false;
            this.grvAbonos.OptionsCustomization.AllowColumnResizing = false;
            this.grvAbonos.OptionsCustomization.AllowFilter = false;
            this.grvAbonos.OptionsCustomization.AllowGroup = false;
            this.grvAbonos.OptionsCustomization.AllowSort = false;
            this.grvAbonos.OptionsView.EnableAppearanceEvenRow = true;
            this.grvAbonos.OptionsView.EnableAppearanceOddRow = true;
            this.grvAbonos.OptionsView.ShowGroupPanel = false;
            this.grvAbonos.OptionsView.ShowViewCaption = true;
            this.grvAbonos.ViewCaption = "Abonos Realizados";
            // 
            // gridArticulos
            // 
            this.gridArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridArticulos.Location = new System.Drawing.Point(534, 42);
            this.gridArticulos.MainView = this.grvArticulos;
            this.gridArticulos.Name = "gridArticulos";
            this.gridArticulos.Size = new System.Drawing.Size(403, 158);
            this.gridArticulos.TabIndex = 1;
            this.gridArticulos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvArticulos});
            // 
            // grvArticulos
            // 
            this.grvArticulos.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvArticulos.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvArticulos.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.grvArticulos.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.grvArticulos.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.grvArticulos.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.grvArticulos.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvArticulos.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvArticulos.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.grvArticulos.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.grvArticulos.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.grvArticulos.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.grvArticulos.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvArticulos.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.grvArticulos.Appearance.Empty.Options.UseBackColor = true;
            this.grvArticulos.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvArticulos.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.grvArticulos.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvArticulos.Appearance.EvenRow.Options.UseForeColor = true;
            this.grvArticulos.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvArticulos.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvArticulos.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.grvArticulos.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.grvArticulos.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.grvArticulos.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.grvArticulos.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvArticulos.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.grvArticulos.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvArticulos.Appearance.FilterPanel.Options.UseBackColor = true;
            this.grvArticulos.Appearance.FilterPanel.Options.UseForeColor = true;
            this.grvArticulos.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(153)))), ((int)(((byte)(73)))));
            this.grvArticulos.Appearance.FixedLine.Options.UseBackColor = true;
            this.grvArticulos.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.grvArticulos.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvArticulos.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvArticulos.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvArticulos.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(154)))), ((int)(((byte)(91)))));
            this.grvArticulos.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvArticulos.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvArticulos.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvArticulos.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvArticulos.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvArticulos.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvArticulos.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grvArticulos.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grvArticulos.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvArticulos.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvArticulos.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvArticulos.Appearance.GroupButton.Options.UseBackColor = true;
            this.grvArticulos.Appearance.GroupButton.Options.UseBorderColor = true;
            this.grvArticulos.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvArticulos.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvArticulos.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.grvArticulos.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvArticulos.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvArticulos.Appearance.GroupFooter.Options.UseForeColor = true;
            this.grvArticulos.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvArticulos.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.grvArticulos.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.grvArticulos.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvArticulos.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grvArticulos.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvArticulos.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvArticulos.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grvArticulos.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvArticulos.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grvArticulos.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvArticulos.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvArticulos.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvArticulos.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.grvArticulos.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvArticulos.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvArticulos.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvArticulos.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvArticulos.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvArticulos.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvArticulos.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvArticulos.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(183)))), ((int)(((byte)(125)))));
            this.grvArticulos.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvArticulos.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvArticulos.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvArticulos.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvArticulos.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvArticulos.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
            this.grvArticulos.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.grvArticulos.Appearance.OddRow.Options.UseBackColor = true;
            this.grvArticulos.Appearance.OddRow.Options.UseForeColor = true;
            this.grvArticulos.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(249)))));
            this.grvArticulos.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.grvArticulos.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(146)))), ((int)(((byte)(78)))));
            this.grvArticulos.Appearance.Preview.Options.UseBackColor = true;
            this.grvArticulos.Appearance.Preview.Options.UseFont = true;
            this.grvArticulos.Appearance.Preview.Options.UseForeColor = true;
            this.grvArticulos.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvArticulos.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvArticulos.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.grvArticulos.Appearance.Row.Options.UseBackColor = true;
            this.grvArticulos.Appearance.Row.Options.UseBorderColor = true;
            this.grvArticulos.Appearance.Row.Options.UseForeColor = true;
            this.grvArticulos.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvArticulos.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.grvArticulos.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvArticulos.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(167)))), ((int)(((byte)(103)))));
            this.grvArticulos.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvArticulos.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.grvArticulos.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grvArticulos.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvArticulos.Appearance.VertLine.Options.UseBackColor = true;
            this.grvArticulos.GridControl = this.gridArticulos;
            this.grvArticulos.Name = "grvArticulos";
            this.grvArticulos.OptionsBehavior.Editable = false;
            this.grvArticulos.OptionsCustomization.AllowColumnMoving = false;
            this.grvArticulos.OptionsCustomization.AllowColumnResizing = false;
            this.grvArticulos.OptionsCustomization.AllowFilter = false;
            this.grvArticulos.OptionsCustomization.AllowGroup = false;
            this.grvArticulos.OptionsCustomization.AllowSort = false;
            this.grvArticulos.OptionsView.EnableAppearanceEvenRow = true;
            this.grvArticulos.OptionsView.EnableAppearanceOddRow = true;
            this.grvArticulos.OptionsView.ShowGroupPanel = false;
            this.grvArticulos.OptionsView.ShowViewCaption = true;
            this.grvArticulos.ViewCaption = "Articulos Apartados";
            // 
            // botonNuevo
            // 
            this.botonNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botonNuevo.BackColor = System.Drawing.Color.Transparent;
            this.botonNuevo.EtiquetaBoton = "Guardar Articulo";
            this.botonNuevo.FlatAppearance.BorderSize = 0;
            this.botonNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.botonNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.botonNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonNuevo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.botonNuevo.Image = global::SoftEmpenios.Properties.Resources.Nuevo1;
            this.botonNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.botonNuevo.imgDisable = global::SoftEmpenios.Properties.Resources.Nuevo1D;
            this.botonNuevo.imgencima = global::SoftEmpenios.Properties.Resources.Nuevo1O;
            this.botonNuevo.imgnormal = global::SoftEmpenios.Properties.Resources.Nuevo1;
            this.botonNuevo.imgPrecionado = global::SoftEmpenios.Properties.Resources.Nuevo1P;
            this.botonNuevo.Location = new System.Drawing.Point(816, 370);
            this.botonNuevo.Name = "botonNuevo";
            this.botonNuevo.Size = new System.Drawing.Size(55, 57);
            this.botonNuevo.TabIndex = 5;
            this.botonNuevo.Text = "Nuevo";
            this.botonNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.botonNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.botonNuevo.UseVisualStyleBackColor = false;
            this.botonNuevo.Click += new System.EventHandler(this.botonNuevo_Click);
            // 
            // botonGuardar
            // 
            this.botonGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botonGuardar.BackColor = System.Drawing.Color.Transparent;
            this.botonGuardar.EtiquetaBoton = "Guardar Articulo";
            this.botonGuardar.FlatAppearance.BorderSize = 0;
            this.botonGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.botonGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.botonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonGuardar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.botonGuardar.Image = global::SoftEmpenios.Properties.Resources.SaveN1;
            this.botonGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.botonGuardar.imgDisable = global::SoftEmpenios.Properties.Resources.SaveD1;
            this.botonGuardar.imgencima = global::SoftEmpenios.Properties.Resources.SaveO1;
            this.botonGuardar.imgnormal = global::SoftEmpenios.Properties.Resources.SaveN1;
            this.botonGuardar.imgPrecionado = global::SoftEmpenios.Properties.Resources.SaveP1;
            this.botonGuardar.Location = new System.Drawing.Point(877, 370);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(61, 57);
            this.botonGuardar.TabIndex = 4;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.botonGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.botonGuardar.UseVisualStyleBackColor = false;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // FrmAbonosVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 432);
            this.Controls.Add(this.gpoContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAbonosVenta";
            this.Shown += new System.EventHandler(this.frmAbonosVenta_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).EndInit();
            this.gpoContenedor.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCveAbono.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbono.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaAbono.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaAbono.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaVenta.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnganche.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCveVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAbonos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAbonos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvArticulos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpoContenedor;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtCveAbono;
        private DevExpress.XtraGrid.GridControl gridArticulos;
        private DevExpress.XtraGrid.Views.Grid.GridView grvArticulos;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Controles.TextEditSelected txtEnganche;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private Controles.TextEditSelected txtTotalVenta;
        private Controles.TextEditSelected txtAbono;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.DateEdit dtpFechaAbono;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private Controles.BotonCambiante botonNuevo;
        private DevExpress.XtraEditors.TextEdit txtCveVenta;
        private Controles.BotonCambiante botonGuardar;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtCliente;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private Controles.TextEditSelected txtSaldo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit dtpFechaVenta;
        private DevExpress.XtraGrid.GridControl gridAbonos;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAbonos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controles.BotonCambiante btnBuscarPrestamo;

    }
}