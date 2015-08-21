namespace SoftEmpenios.Pantallas
{
    partial class FrmVentas
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
            this.mnuEliminar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.gpoContenedor = new DevExpress.XtraEditors.GroupControl();
            this.cboTipoVenta = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnAgregarArticulo = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtSaldo = new SoftEmpenios.Controles.TextEditSelected();
            this.botonNuevo = new SoftEmpenios.Controles.BotonCambiante();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dtpFechaVenta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCliente = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridArticulosVenta = new DevExpress.XtraGrid.GridControl();
            this.grvArticulos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtEnganche = new SoftEmpenios.Controles.TextEditSelected();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.botonGuardar = new SoftEmpenios.Controles.BotonCambiante();
            this.txtTotalVenta = new SoftEmpenios.Controles.TextEditSelected();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtCveVenta = new DevExpress.XtraEditors.TextEdit();
            this.mnuEliminar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).BeginInit();
            this.gpoContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaVenta.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridArticulosVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnganche.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCveVenta.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuEliminar
            // 
            this.mnuEliminar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuEliminar});
            this.mnuEliminar.Name = "mnuCancelar";
            this.mnuEliminar.Size = new System.Drawing.Size(118, 26);
            // 
            // cmnuEliminar
            // 
            this.cmnuEliminar.Name = "cmnuEliminar";
            this.cmnuEliminar.Size = new System.Drawing.Size(117, 22);
            this.cmnuEliminar.Text = "Eliminar";
            this.cmnuEliminar.Click += new System.EventHandler(this.cmnuEliminar_Click);
            // 
            // gpoContenedor
            // 
            this.gpoContenedor.Appearance.BackColor = System.Drawing.Color.Orange;
            this.gpoContenedor.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gpoContenedor.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.gpoContenedor.Appearance.Options.UseBackColor = true;
            this.gpoContenedor.AppearanceCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gpoContenedor.AppearanceCaption.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gpoContenedor.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.gpoContenedor.AppearanceCaption.ForeColor = System.Drawing.Color.White;
            this.gpoContenedor.AppearanceCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gpoContenedor.AppearanceCaption.Options.UseBackColor = true;
            this.gpoContenedor.AppearanceCaption.Options.UseFont = true;
            this.gpoContenedor.AppearanceCaption.Options.UseForeColor = true;
            this.gpoContenedor.AppearanceCaption.Options.UseTextOptions = true;
            this.gpoContenedor.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gpoContenedor.Controls.Add(this.cboTipoVenta);
            this.gpoContenedor.Controls.Add(this.labelControl2);
            this.gpoContenedor.Controls.Add(this.btnAgregarArticulo);
            this.gpoContenedor.Controls.Add(this.labelControl7);
            this.gpoContenedor.Controls.Add(this.txtSaldo);
            this.gpoContenedor.Controls.Add(this.botonNuevo);
            this.gpoContenedor.Controls.Add(this.labelControl4);
            this.gpoContenedor.Controls.Add(this.dtpFechaVenta);
            this.gpoContenedor.Controls.Add(this.labelControl3);
            this.gpoContenedor.Controls.Add(this.txtCliente);
            this.gpoContenedor.Controls.Add(this.labelControl1);
            this.gpoContenedor.Controls.Add(this.gridArticulosVenta);
            this.gpoContenedor.Controls.Add(this.txtEnganche);
            this.gpoContenedor.Controls.Add(this.labelControl11);
            this.gpoContenedor.Controls.Add(this.botonGuardar);
            this.gpoContenedor.Controls.Add(this.txtTotalVenta);
            this.gpoContenedor.Controls.Add(this.labelControl8);
            this.gpoContenedor.Controls.Add(this.txtCveVenta);
            this.gpoContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpoContenedor.Location = new System.Drawing.Point(0, 0);
            this.gpoContenedor.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gpoContenedor.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gpoContenedor.Name = "gpoContenedor";
            this.gpoContenedor.Size = new System.Drawing.Size(893, 540);
            this.gpoContenedor.TabIndex = 2;
            this.gpoContenedor.Text = "Ventas";
            // 
            // cboTipoVenta
            // 
            this.cboTipoVenta.Location = new System.Drawing.Point(108, 111);
            this.cboTipoVenta.Name = "cboTipoVenta";
            this.cboTipoVenta.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cboTipoVenta.Properties.Appearance.Options.UseFont = true;
            this.cboTipoVenta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoVenta.Properties.Items.AddRange(new object[] {
            "Contado",
            "Apartado"});
            this.cboTipoVenta.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTipoVenta.Size = new System.Drawing.Size(187, 26);
            this.cboTipoVenta.TabIndex = 75;
            this.cboTipoVenta.SelectedIndexChanged += new System.EventHandler(this.cboTipoVenta_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl2.Location = new System.Drawing.Point(12, 115);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(90, 18);
            this.labelControl2.TabIndex = 74;
            this.labelControl2.Text = "Tipo Venta:";
            // 
            // btnAgregarArticulo
            // 
            this.btnAgregarArticulo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAgregarArticulo.Appearance.Options.UseFont = true;
            this.btnAgregarArticulo.Appearance.Options.UseTextOptions = true;
            this.btnAgregarArticulo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnAgregarArticulo.Image = global::SoftEmpenios.Properties.Resources.AgregarPrenda;
            this.btnAgregarArticulo.Location = new System.Drawing.Point(437, 111);
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.Size = new System.Drawing.Size(101, 40);
            this.btnAgregarArticulo.TabIndex = 72;
            this.btnAgregarArticulo.Text = "Agregar Articulo";
            this.btnAgregarArticulo.Click += new System.EventHandler(this.botonAgregarArticulo_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl7.Location = new System.Drawing.Point(697, 446);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(50, 18);
            this.labelControl7.TabIndex = 71;
            this.labelControl7.Text = "Saldo:";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaldo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldo.Location = new System.Drawing.Point(753, 442);
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
            this.txtSaldo.Size = new System.Drawing.Size(123, 26);
            this.txtSaldo.TabIndex = 64;
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
            this.botonNuevo.Location = new System.Drawing.Point(754, 474);
            this.botonNuevo.Name = "botonNuevo";
            this.botonNuevo.Size = new System.Drawing.Size(55, 57);
            this.botonNuevo.TabIndex = 65;
            this.botonNuevo.Text = "Nuevo";
            this.botonNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.botonNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.botonNuevo.UseVisualStyleBackColor = false;
            this.botonNuevo.Click += new System.EventHandler(this.botonNuevo_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl4.Location = new System.Drawing.Point(298, 51);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(106, 18);
            this.labelControl4.TabIndex = 70;
            this.labelControl4.Text = "Fecha Venta:";
            // 
            // dtpFechaVenta
            // 
            this.dtpFechaVenta.EditValue = new System.DateTime(2013, 10, 12, 20, 45, 55, 449);
            this.dtpFechaVenta.Location = new System.Drawing.Point(415, 47);
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
            this.dtpFechaVenta.TabIndex = 58;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl3.Location = new System.Drawing.Point(41, 83);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(61, 18);
            this.labelControl3.TabIndex = 69;
            this.labelControl3.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.EditValue = "";
            this.txtCliente.Location = new System.Drawing.Point(108, 79);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtCliente.Properties.Appearance.Options.UseFont = true;
            this.txtCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCliente.Size = new System.Drawing.Size(430, 26);
            this.txtCliente.TabIndex = 60;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl1.Location = new System.Drawing.Point(661, 413);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(86, 18);
            this.labelControl1.TabIndex = 68;
            this.labelControl1.Text = "Enganche:";
            // 
            // gridArticulosVenta
            // 
            this.gridArticulosVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridArticulosVenta.ContextMenuStrip = this.mnuEliminar;
            this.gridArticulosVenta.Location = new System.Drawing.Point(17, 157);
            this.gridArticulosVenta.MainView = this.grvArticulos;
            this.gridArticulosVenta.Name = "gridArticulosVenta";
            this.gridArticulosVenta.Size = new System.Drawing.Size(859, 209);
            this.gridArticulosVenta.TabIndex = 59;
            this.gridArticulosVenta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.grvArticulos.GridControl = this.gridArticulosVenta;
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
            this.grvArticulos.ViewCaption = "Articulos a Vender";
            this.grvArticulos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvArticulos_KeyDown);
            // 
            // txtEnganche
            // 
            this.txtEnganche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnganche.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtEnganche.Location = new System.Drawing.Point(753, 410);
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
            this.txtEnganche.TabIndex = 62;
            this.txtEnganche.EditValueChanged += new System.EventHandler(this.txtEnganche_EditValueChanged);
            // 
            // labelControl11
            // 
            this.labelControl11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl11.Location = new System.Drawing.Point(651, 376);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(96, 18);
            this.labelControl11.TabIndex = 67;
            this.labelControl11.Text = "Total Venta:";
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
            this.botonGuardar.Location = new System.Drawing.Point(815, 474);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(61, 57);
            this.botonGuardar.TabIndex = 63;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.botonGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.botonGuardar.UseVisualStyleBackColor = false;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // txtTotalVenta
            // 
            this.txtTotalVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalVenta.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalVenta.Location = new System.Drawing.Point(753, 372);
            this.txtTotalVenta.Name = "txtTotalVenta";
            this.txtTotalVenta.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtTotalVenta.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.txtTotalVenta.Size = new System.Drawing.Size(123, 32);
            this.txtTotalVenta.TabIndex = 61;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl8.Location = new System.Drawing.Point(52, 50);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(50, 18);
            this.labelControl8.TabIndex = 66;
            this.labelControl8.Text = "Clave:";
            // 
            // txtCveVenta
            // 
            this.txtCveVenta.EditValue = 0;
            this.txtCveVenta.Location = new System.Drawing.Point(108, 47);
            this.txtCveVenta.Name = "txtCveVenta";
            this.txtCveVenta.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtCveVenta.Properties.Appearance.Options.UseFont = true;
            this.txtCveVenta.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCveVenta.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCveVenta.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCveVenta.Properties.Mask.EditMask = "n0";
            this.txtCveVenta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCveVenta.Properties.ReadOnly = true;
            this.txtCveVenta.Size = new System.Drawing.Size(123, 26);
            this.txtCveVenta.TabIndex = 57;
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 540);
            this.Controls.Add(this.gpoContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVentas";
            this.Load += new System.EventHandler(this.frmVentas_Load);
            this.mnuEliminar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).EndInit();
            this.gpoContenedor.ResumeLayout(false);
            this.gpoContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaVenta.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridArticulosVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnganche.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCveVenta.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuEliminar;
        private System.Windows.Forms.ToolStripMenuItem cmnuEliminar;
        private DevExpress.XtraEditors.GroupControl gpoContenedor;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private Controles.TextEditSelected txtSaldo;
        private Controles.BotonCambiante botonNuevo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit dtpFechaVenta;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtCliente;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridArticulosVenta;
        private DevExpress.XtraGrid.Views.Grid.GridView grvArticulos;
        private Controles.TextEditSelected txtEnganche;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private Controles.BotonCambiante botonGuardar;
        private Controles.TextEditSelected txtTotalVenta;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtCveVenta;
        private DevExpress.XtraEditors.SimpleButton btnAgregarArticulo;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipoVenta;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}