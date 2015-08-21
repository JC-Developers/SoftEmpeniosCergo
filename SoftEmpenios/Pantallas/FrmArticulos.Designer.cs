namespace SoftEmpenios.Pantallas
{
    partial class FrmArticulos
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
            this.BotonEditar = new SoftEmpenios.Controles.BotonCambiante();
            this.botonDeleteSelected = new SoftEmpenios.Controles.BotonCambiante();
            this.botonUnselectAll = new SoftEmpenios.Controles.BotonCambiante();
            this.botonSelectAll = new SoftEmpenios.Controles.BotonCambiante();
            this.botonNuevo = new SoftEmpenios.Controles.BotonCambiante();
            this.GuardarArticulo = new SoftEmpenios.Controles.BotonCambiante();
            this.gpoContenedor = new DevExpress.XtraEditors.GroupControl();
            this.gridArticulos = new DevExpress.XtraGrid.GridControl();
            this.grvArticulos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrecioApartado = new SoftEmpenios.Controles.TextEditSelected();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipo = new DevExpress.XtraEditors.LookUpEdit();
            this.txtPrecio = new SoftEmpenios.Controles.TextEditSelected();
            this.txtPeso = new SoftEmpenios.Controles.TextEditSelected();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.dtpFechaRegistro = new DevExpress.XtraEditors.DateEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtClave = new DevExpress.XtraEditors.TextEdit();
            this.txtDescripcion = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).BeginInit();
            this.gpoContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioApartado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaRegistro.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaRegistro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BotonEditar
            // 
            this.BotonEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BotonEditar.BackColor = System.Drawing.Color.Transparent;
            this.BotonEditar.EtiquetaBoton = "Guardar Articulo";
            this.BotonEditar.FlatAppearance.BorderSize = 0;
            this.BotonEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BotonEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BotonEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonEditar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BotonEditar.Image = global::SoftEmpenios.Properties.Resources.Editar;
            this.BotonEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BotonEditar.imgDisable = global::SoftEmpenios.Properties.Resources.EditarD;
            this.BotonEditar.imgencima = global::SoftEmpenios.Properties.Resources.EditarO;
            this.BotonEditar.imgnormal = global::SoftEmpenios.Properties.Resources.Editar;
            this.BotonEditar.imgPrecionado = global::SoftEmpenios.Properties.Resources.EditarP;
            this.BotonEditar.Location = new System.Drawing.Point(558, 447);
            this.BotonEditar.Name = "BotonEditar";
            this.BotonEditar.Size = new System.Drawing.Size(55, 57);
            this.BotonEditar.TabIndex = 18;
            this.BotonEditar.Text = "Editar";
            this.BotonEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BotonEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BotonEditar.UseVisualStyleBackColor = false;
            this.BotonEditar.Visible = false;
            this.BotonEditar.Click += new System.EventHandler(this.BotonEditar_Click);
            // 
            // botonDeleteSelected
            // 
            this.botonDeleteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.botonDeleteSelected.AutoSize = true;
            this.botonDeleteSelected.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.botonDeleteSelected.BackColor = System.Drawing.Color.Transparent;
            this.botonDeleteSelected.EtiquetaBoton = "Dar de Baja Selecionados";
            this.botonDeleteSelected.FlatAppearance.BorderSize = 0;
            this.botonDeleteSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.botonDeleteSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.botonDeleteSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonDeleteSelected.Image = global::SoftEmpenios.Properties.Resources.DeleteN;
            this.botonDeleteSelected.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.botonDeleteSelected.imgDisable = global::SoftEmpenios.Properties.Resources.DeleteD;
            this.botonDeleteSelected.imgencima = global::SoftEmpenios.Properties.Resources.DeleteO;
            this.botonDeleteSelected.imgnormal = global::SoftEmpenios.Properties.Resources.DeleteN;
            this.botonDeleteSelected.imgPrecionado = global::SoftEmpenios.Properties.Resources.DeleteP;
            this.botonDeleteSelected.Location = new System.Drawing.Point(138, 450);
            this.botonDeleteSelected.Name = "botonDeleteSelected";
            this.botonDeleteSelected.Size = new System.Drawing.Size(54, 54);
            this.botonDeleteSelected.TabIndex = 16;
            this.botonDeleteSelected.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.botonDeleteSelected.UseVisualStyleBackColor = false;
            this.botonDeleteSelected.Visible = false;
            this.botonDeleteSelected.Click += new System.EventHandler(this.botonDeleteSelected_Click);
            // 
            // botonUnselectAll
            // 
            this.botonUnselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.botonUnselectAll.AutoSize = true;
            this.botonUnselectAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.botonUnselectAll.BackColor = System.Drawing.Color.Transparent;
            this.botonUnselectAll.EtiquetaBoton = "Deseleccionar";
            this.botonUnselectAll.FlatAppearance.BorderSize = 0;
            this.botonUnselectAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.botonUnselectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.botonUnselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonUnselectAll.Image = global::SoftEmpenios.Properties.Resources.unSelectN;
            this.botonUnselectAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.botonUnselectAll.imgDisable = global::SoftEmpenios.Properties.Resources.unSelectD;
            this.botonUnselectAll.imgencima = global::SoftEmpenios.Properties.Resources.unSelectO;
            this.botonUnselectAll.imgnormal = global::SoftEmpenios.Properties.Resources.unSelectN;
            this.botonUnselectAll.imgPrecionado = global::SoftEmpenios.Properties.Resources.unSelectP;
            this.botonUnselectAll.Location = new System.Drawing.Point(76, 450);
            this.botonUnselectAll.Name = "botonUnselectAll";
            this.botonUnselectAll.Size = new System.Drawing.Size(54, 54);
            this.botonUnselectAll.TabIndex = 15;
            this.botonUnselectAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.botonUnselectAll.UseVisualStyleBackColor = false;
            this.botonUnselectAll.Visible = false;
            this.botonUnselectAll.Click += new System.EventHandler(this.botonUnselectAll_Click);
            // 
            // botonSelectAll
            // 
            this.botonSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.botonSelectAll.AutoSize = true;
            this.botonSelectAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.botonSelectAll.BackColor = System.Drawing.Color.Transparent;
            this.botonSelectAll.EtiquetaBoton = "Selecionar Todo";
            this.botonSelectAll.FlatAppearance.BorderSize = 0;
            this.botonSelectAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.botonSelectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.botonSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonSelectAll.Image = global::SoftEmpenios.Properties.Resources.SelectallN;
            this.botonSelectAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.botonSelectAll.imgDisable = global::SoftEmpenios.Properties.Resources.SelectallD;
            this.botonSelectAll.imgencima = global::SoftEmpenios.Properties.Resources.SelectallO;
            this.botonSelectAll.imgnormal = global::SoftEmpenios.Properties.Resources.SelectallN;
            this.botonSelectAll.imgPrecionado = global::SoftEmpenios.Properties.Resources.SelectallP;
            this.botonSelectAll.Location = new System.Drawing.Point(14, 450);
            this.botonSelectAll.Name = "botonSelectAll";
            this.botonSelectAll.Size = new System.Drawing.Size(54, 54);
            this.botonSelectAll.TabIndex = 14;
            this.botonSelectAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.botonSelectAll.UseVisualStyleBackColor = false;
            this.botonSelectAll.Visible = false;
            this.botonSelectAll.Click += new System.EventHandler(this.botonSelectAll_Click);
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
            this.botonNuevo.Location = new System.Drawing.Point(609, 447);
            this.botonNuevo.Name = "botonNuevo";
            this.botonNuevo.Size = new System.Drawing.Size(55, 57);
            this.botonNuevo.TabIndex = 6;
            this.botonNuevo.Text = "Nuevo";
            this.botonNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.botonNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.botonNuevo.UseVisualStyleBackColor = false;
            this.botonNuevo.Click += new System.EventHandler(this.botonNuevo_Click);
            // 
            // GuardarArticulo
            // 
            this.GuardarArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GuardarArticulo.BackColor = System.Drawing.Color.Transparent;
            this.GuardarArticulo.EtiquetaBoton = "Guardar Articulo";
            this.GuardarArticulo.FlatAppearance.BorderSize = 0;
            this.GuardarArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.GuardarArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.GuardarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GuardarArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardarArticulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GuardarArticulo.Image = global::SoftEmpenios.Properties.Resources.SaveN1;
            this.GuardarArticulo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.GuardarArticulo.imgDisable = global::SoftEmpenios.Properties.Resources.SaveD1;
            this.GuardarArticulo.imgencima = global::SoftEmpenios.Properties.Resources.SaveO1;
            this.GuardarArticulo.imgnormal = global::SoftEmpenios.Properties.Resources.SaveN1;
            this.GuardarArticulo.imgPrecionado = global::SoftEmpenios.Properties.Resources.SaveP1;
            this.GuardarArticulo.Location = new System.Drawing.Point(670, 447);
            this.GuardarArticulo.Name = "GuardarArticulo";
            this.GuardarArticulo.Size = new System.Drawing.Size(61, 57);
            this.GuardarArticulo.TabIndex = 5;
            this.GuardarArticulo.Text = "Guardar";
            this.GuardarArticulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GuardarArticulo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.GuardarArticulo.UseVisualStyleBackColor = false;
            this.GuardarArticulo.Click += new System.EventHandler(this.GuardarArticulo_Click);
            // 
            // gpoContenedor
            // 
            this.gpoContenedor.Appearance.BackColor = System.Drawing.Color.Orange;
            this.gpoContenedor.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gpoContenedor.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
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
            this.gpoContenedor.Controls.Add(this.gridArticulos);
            this.gpoContenedor.Controls.Add(this.labelControl1);
            this.gpoContenedor.Controls.Add(this.txtPrecioApartado);
            this.gpoContenedor.Controls.Add(this.labelControl11);
            this.gpoContenedor.Controls.Add(this.labelControl5);
            this.gpoContenedor.Controls.Add(this.labelControl4);
            this.gpoContenedor.Controls.Add(this.labelControl3);
            this.gpoContenedor.Controls.Add(this.cboTipo);
            this.gpoContenedor.Controls.Add(this.txtPrecio);
            this.gpoContenedor.Controls.Add(this.txtPeso);
            this.gpoContenedor.Controls.Add(this.BotonEditar);
            this.gpoContenedor.Controls.Add(this.labelControl6);
            this.gpoContenedor.Controls.Add(this.botonDeleteSelected);
            this.gpoContenedor.Controls.Add(this.dtpFechaRegistro);
            this.gpoContenedor.Controls.Add(this.botonUnselectAll);
            this.gpoContenedor.Controls.Add(this.labelControl8);
            this.gpoContenedor.Controls.Add(this.botonSelectAll);
            this.gpoContenedor.Controls.Add(this.botonNuevo);
            this.gpoContenedor.Controls.Add(this.txtClave);
            this.gpoContenedor.Controls.Add(this.GuardarArticulo);
            this.gpoContenedor.Controls.Add(this.txtDescripcion);
            this.gpoContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpoContenedor.Location = new System.Drawing.Point(0, 0);
            this.gpoContenedor.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gpoContenedor.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gpoContenedor.Name = "gpoContenedor";
            this.gpoContenedor.Size = new System.Drawing.Size(743, 516);
            this.gpoContenedor.TabIndex = 2;
            this.gpoContenedor.Text = "Registro de Articulos";
            this.gpoContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.gpoContenedor_Paint);
            // 
            // gridArticulos
            // 
            this.gridArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridArticulos.Location = new System.Drawing.Point(12, 205);
            this.gridArticulos.MainView = this.grvArticulos;
            this.gridArticulos.Name = "gridArticulos";
            this.gridArticulos.Size = new System.Drawing.Size(719, 236);
            this.gridArticulos.TabIndex = 48;
            this.gridArticulos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvArticulos});
            // 
            // grvArticulos
            // 
            this.grvArticulos.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.grvArticulos.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvArticulos.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvArticulos.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvArticulos.GridControl = this.gridArticulos;
            this.grvArticulos.Name = "grvArticulos";
            this.grvArticulos.OptionsCustomization.AllowColumnMoving = false;
            this.grvArticulos.OptionsCustomization.AllowColumnResizing = false;
            this.grvArticulos.OptionsCustomization.AllowFilter = false;
            this.grvArticulos.OptionsCustomization.AllowGroup = false;
            this.grvArticulos.OptionsCustomization.AllowSort = false;
            this.grvArticulos.OptionsView.ShowGroupPanel = false;
            this.grvArticulos.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grvArticulos_RowClick);
            this.grvArticulos.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvArticulos_RowStyle);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl1.Location = new System.Drawing.Point(354, 176);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(136, 18);
            this.labelControl1.TabIndex = 47;
            this.labelControl1.Text = "Precio Apartado:";
            // 
            // txtPrecioApartado
            // 
            this.txtPrecioApartado.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrecioApartado.Location = new System.Drawing.Point(496, 172);
            this.txtPrecioApartado.Name = "txtPrecioApartado";
            this.txtPrecioApartado.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPrecioApartado.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPrecioApartado.Properties.Appearance.Options.UseFont = true;
            this.txtPrecioApartado.Properties.Appearance.Options.UseForeColor = true;
            this.txtPrecioApartado.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPrecioApartado.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtPrecioApartado.Properties.DisplayFormat.FormatString = "$ ##,##0.00";
            this.txtPrecioApartado.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrecioApartado.Properties.Mask.EditMask = "c2";
            this.txtPrecioApartado.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrecioApartado.Properties.ReadOnly = true;
            this.txtPrecioApartado.Size = new System.Drawing.Size(134, 26);
            this.txtPrecioApartado.TabIndex = 46;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl11.Location = new System.Drawing.Point(104, 174);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(57, 18);
            this.labelControl11.TabIndex = 45;
            this.labelControl11.Text = "Precio:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl5.Location = new System.Drawing.Point(116, 143);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(45, 18);
            this.labelControl5.TabIndex = 44;
            this.labelControl5.Text = "Peso:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl4.Location = new System.Drawing.Point(315, 144);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(101, 18);
            this.labelControl4.TabIndex = 43;
            this.labelControl4.Text = "Tipo Prenda:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl3.Location = new System.Drawing.Point(60, 96);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(101, 18);
            this.labelControl3.TabIndex = 42;
            this.labelControl3.Text = "Descripcion:";
            // 
            // cboTipo
            // 
            this.cboTipo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cboTipo.Location = new System.Drawing.Point(427, 140);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cboTipo.Properties.Appearance.Options.UseFont = true;
            this.cboTipo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipo.Size = new System.Drawing.Size(203, 26);
            this.cboTipo.TabIndex = 39;
            this.cboTipo.EditValueChanged += new System.EventHandler(this.cboTipo_EditValueChanged);
            // 
            // txtPrecio
            // 
            this.txtPrecio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrecio.Location = new System.Drawing.Point(167, 171);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPrecio.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPrecio.Properties.Appearance.Options.UseFont = true;
            this.txtPrecio.Properties.Appearance.Options.UseForeColor = true;
            this.txtPrecio.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPrecio.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtPrecio.Properties.DisplayFormat.FormatString = "$ ##,##0.00";
            this.txtPrecio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrecio.Properties.Mask.EditMask = "c2";
            this.txtPrecio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrecio.Properties.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(134, 26);
            this.txtPrecio.TabIndex = 41;
            // 
            // txtPeso
            // 
            this.txtPeso.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPeso.Location = new System.Drawing.Point(167, 139);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPeso.Properties.Appearance.Options.UseFont = true;
            this.txtPeso.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPeso.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtPeso.Properties.Mask.EditMask = "n1";
            this.txtPeso.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeso.Size = new System.Drawing.Size(134, 26);
            this.txtPeso.TabIndex = 40;
            this.txtPeso.EditValueChanged += new System.EventHandler(this.txtPeso_EditValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl6.Location = new System.Drawing.Point(338, 51);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(124, 18);
            this.labelControl6.TabIndex = 37;
            this.labelControl6.Text = "Fecha Empeño:";
            // 
            // dtpFechaRegistro
            // 
            this.dtpFechaRegistro.EditValue = new System.DateTime(2013, 10, 12, 20, 45, 55, 449);
            this.dtpFechaRegistro.Location = new System.Drawing.Point(468, 47);
            this.dtpFechaRegistro.Name = "dtpFechaRegistro";
            this.dtpFechaRegistro.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dtpFechaRegistro.Properties.Appearance.Options.UseFont = true;
            this.dtpFechaRegistro.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpFechaRegistro.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpFechaRegistro.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFechaRegistro.Properties.DisplayFormat.FormatString = "dd/MMM/yyyy";
            this.dtpFechaRegistro.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpFechaRegistro.Properties.ReadOnly = true;
            this.dtpFechaRegistro.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpFechaRegistro.Size = new System.Drawing.Size(162, 26);
            this.dtpFechaRegistro.TabIndex = 36;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl8.Location = new System.Drawing.Point(111, 49);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(50, 18);
            this.labelControl8.TabIndex = 35;
            this.labelControl8.Text = "Clave:";
            // 
            // txtClave
            // 
            this.txtClave.EditValue = 0;
            this.txtClave.Location = new System.Drawing.Point(167, 46);
            this.txtClave.Name = "txtClave";
            this.txtClave.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtClave.Properties.Appearance.Options.UseFont = true;
            this.txtClave.Properties.Appearance.Options.UseTextOptions = true;
            this.txtClave.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtClave.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClave.Properties.ReadOnly = true;
            this.txtClave.Size = new System.Drawing.Size(95, 26);
            this.txtClave.TabIndex = 34;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.EditValue = "";
            this.txtDescripcion.Location = new System.Drawing.Point(167, 79);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtDescripcion.Properties.Appearance.Options.UseFont = true;
            this.txtDescripcion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Size = new System.Drawing.Size(463, 54);
            this.txtDescripcion.TabIndex = 38;
            // 
            // FrmArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 516);
            this.Controls.Add(this.gpoContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmArticulos";
            this.Shown += new System.EventHandler(this.frmArticulos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).EndInit();
            this.gpoContenedor.ResumeLayout(false);
            this.gpoContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioApartado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaRegistro.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFechaRegistro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SoftEmpenios.Controles.BotonCambiante GuardarArticulo;
        private SoftEmpenios.Controles.BotonCambiante botonNuevo;
        private SoftEmpenios.Controles.BotonCambiante botonDeleteSelected;
        private SoftEmpenios.Controles.BotonCambiante botonUnselectAll;
        private SoftEmpenios.Controles.BotonCambiante botonSelectAll;
        private SoftEmpenios.Controles.BotonCambiante BotonEditar;
        private DevExpress.XtraEditors.GroupControl gpoContenedor;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtClave;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.DateEdit dtpFechaRegistro;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit cboTipo;
        private Controles.TextEditSelected txtPrecio;
        private Controles.TextEditSelected txtPeso;
        private DevExpress.XtraEditors.MemoEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Controles.TextEditSelected txtPrecioApartado;
        private DevExpress.XtraGrid.GridControl gridArticulos;
        private DevExpress.XtraGrid.Views.Grid.GridView grvArticulos;

    }
}