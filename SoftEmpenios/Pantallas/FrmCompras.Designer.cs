namespace SoftEmpenios.Pantallas
{
    partial class FrmCompras
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
            this.botonGuardarCompra = new SoftEmpenios.Controles.BotonCambiante();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotalCompra = new SoftEmpenios.Controles.TextEditSelected();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipoPrenda = new DevExpress.XtraEditors.LookUpEdit();
            this.btnAgregarPrenda = new DevExpress.XtraEditors.SimpleButton();
            this.txtAvaluo = new SoftEmpenios.Controles.TextEditSelected();
            this.txtCveCompra = new DevExpress.XtraEditors.TextEdit();
            this.txtPesoEmpenio = new SoftEmpenios.Controles.TextEditSelected();
            this.gridBusqueda = new DevExpress.XtraGrid.GridControl();
            this.grvResultado = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).BeginInit();
            this.gpoContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCompra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoPrenda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAvaluo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCveCompra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPesoEmpenio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBusqueda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvResultado)).BeginInit();
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
            this.gpoContenedor.Controls.Add(this.botonGuardarCompra);
            this.gpoContenedor.Controls.Add(this.labelControl9);
            this.gpoContenedor.Controls.Add(this.txtTotalCompra);
            this.gpoContenedor.Controls.Add(this.labelControl11);
            this.gpoContenedor.Controls.Add(this.labelControl5);
            this.gpoContenedor.Controls.Add(this.labelControl4);
            this.gpoContenedor.Controls.Add(this.labelControl1);
            this.gpoContenedor.Controls.Add(this.cboTipoPrenda);
            this.gpoContenedor.Controls.Add(this.btnAgregarPrenda);
            this.gpoContenedor.Controls.Add(this.txtAvaluo);
            this.gpoContenedor.Controls.Add(this.txtCveCompra);
            this.gpoContenedor.Controls.Add(this.txtPesoEmpenio);
            this.gpoContenedor.Controls.Add(this.gridBusqueda);
            this.gpoContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpoContenedor.Location = new System.Drawing.Point(0, 0);
            this.gpoContenedor.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gpoContenedor.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gpoContenedor.Name = "gpoContenedor";
            this.gpoContenedor.Size = new System.Drawing.Size(887, 546);
            this.gpoContenedor.TabIndex = 4;
            this.gpoContenedor.Text = "Compras";
            // 
            // botonGuardarCompra
            // 
            this.botonGuardarCompra.BackColor = System.Drawing.Color.Transparent;
            this.botonGuardarCompra.EtiquetaBoton = "Comprar e Imprimir Ticket";
            this.botonGuardarCompra.FlatAppearance.BorderSize = 0;
            this.botonGuardarCompra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.botonGuardarCompra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.botonGuardarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonGuardarCompra.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonGuardarCompra.Image = global::SoftEmpenios.Properties.Resources.Printer;
            this.botonGuardarCompra.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.botonGuardarCompra.imgDisable = global::SoftEmpenios.Properties.Resources.Printerdiseable;
            this.botonGuardarCompra.imgencima = global::SoftEmpenios.Properties.Resources.Printerover;
            this.botonGuardarCompra.imgnormal = global::SoftEmpenios.Properties.Resources.Printer;
            this.botonGuardarCompra.imgPrecionado = global::SoftEmpenios.Properties.Resources.PrinterPush;
            this.botonGuardarCompra.Location = new System.Drawing.Point(791, 138);
            this.botonGuardarCompra.Name = "botonGuardarCompra";
            this.botonGuardarCompra.Size = new System.Drawing.Size(84, 89);
            this.botonGuardarCompra.TabIndex = 119;
            this.botonGuardarCompra.Text = "Imprimir Compra";
            this.botonGuardarCompra.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.botonGuardarCompra.UseVisualStyleBackColor = false;
            this.botonGuardarCompra.Click += new System.EventHandler(this.botonGuardarCompra_Click);
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F);
            this.labelControl9.Location = new System.Drawing.Point(568, 104);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(139, 23);
            this.labelControl9.TabIndex = 47;
            this.labelControl9.Text = "Total Compra:";
            // 
            // txtTotalCompra
            // 
            this.txtTotalCompra.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalCompra.Location = new System.Drawing.Point(713, 100);
            this.txtTotalCompra.Name = "txtTotalCompra";
            this.txtTotalCompra.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.txtTotalCompra.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtTotalCompra.Properties.Appearance.Options.UseFont = true;
            this.txtTotalCompra.Properties.Appearance.Options.UseForeColor = true;
            this.txtTotalCompra.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalCompra.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalCompra.Properties.DisplayFormat.FormatString = "$ ##,##0.00";
            this.txtTotalCompra.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalCompra.Properties.Mask.EditMask = "c2";
            this.txtTotalCompra.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalCompra.Properties.ReadOnly = true;
            this.txtTotalCompra.Size = new System.Drawing.Size(162, 32);
            this.txtTotalCompra.TabIndex = 46;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl11.Location = new System.Drawing.Point(307, 141);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(60, 18);
            this.labelControl11.TabIndex = 45;
            this.labelControl11.Text = "Avaluo:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl5.Location = new System.Drawing.Point(100, 140);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(45, 18);
            this.labelControl5.TabIndex = 44;
            this.labelControl5.Text = "Peso:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl4.Location = new System.Drawing.Point(39, 108);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(106, 18);
            this.labelControl4.TabIndex = 43;
            this.labelControl4.Text = "Tipo Compra:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl1.Location = new System.Drawing.Point(95, 75);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 18);
            this.labelControl1.TabIndex = 42;
            this.labelControl1.Text = "Clave:";
            // 
            // cboTipoPrenda
            // 
            this.cboTipoPrenda.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cboTipoPrenda.Location = new System.Drawing.Point(151, 104);
            this.cboTipoPrenda.Name = "cboTipoPrenda";
            this.cboTipoPrenda.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cboTipoPrenda.Properties.Appearance.Options.UseFont = true;
            this.cboTipoPrenda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoPrenda.Size = new System.Drawing.Size(345, 26);
            this.cboTipoPrenda.TabIndex = 38;
            this.cboTipoPrenda.EditValueChanged += new System.EventHandler(this.cboTipoPrenda_EditValueChanged);
            // 
            // btnAgregarPrenda
            // 
            this.btnAgregarPrenda.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAgregarPrenda.Appearance.Options.UseFont = true;
            this.btnAgregarPrenda.Image = global::SoftEmpenios.Properties.Resources.AgregarPrenda;
            this.btnAgregarPrenda.Location = new System.Drawing.Point(404, 169);
            this.btnAgregarPrenda.Name = "btnAgregarPrenda";
            this.btnAgregarPrenda.Size = new System.Drawing.Size(92, 40);
            this.btnAgregarPrenda.TabIndex = 41;
            this.btnAgregarPrenda.Text = "Agregar";
            this.btnAgregarPrenda.Click += new System.EventHandler(this.btnAgregarPrenda_Click);
            // 
            // txtAvaluo
            // 
            this.txtAvaluo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAvaluo.Location = new System.Drawing.Point(376, 137);
            this.txtAvaluo.Name = "txtAvaluo";
            this.txtAvaluo.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtAvaluo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAvaluo.Properties.Appearance.Options.UseFont = true;
            this.txtAvaluo.Properties.Appearance.Options.UseForeColor = true;
            this.txtAvaluo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAvaluo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtAvaluo.Properties.DisplayFormat.FormatString = "$ ##,##0.00";
            this.txtAvaluo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAvaluo.Properties.Mask.EditMask = "c2";
            this.txtAvaluo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAvaluo.Properties.ReadOnly = true;
            this.txtAvaluo.Size = new System.Drawing.Size(120, 26);
            this.txtAvaluo.TabIndex = 40;
            // 
            // txtCveCompra
            // 
            this.txtCveCompra.EditValue = 0;
            this.txtCveCompra.Location = new System.Drawing.Point(151, 72);
            this.txtCveCompra.Name = "txtCveCompra";
            this.txtCveCompra.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtCveCompra.Properties.Appearance.Options.UseFont = true;
            this.txtCveCompra.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCveCompra.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCveCompra.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtCveCompra.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCveCompra.Properties.ReadOnly = true;
            this.txtCveCompra.Size = new System.Drawing.Size(105, 26);
            this.txtCveCompra.TabIndex = 37;
            // 
            // txtPesoEmpenio
            // 
            this.txtPesoEmpenio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPesoEmpenio.Location = new System.Drawing.Point(151, 136);
            this.txtPesoEmpenio.Name = "txtPesoEmpenio";
            this.txtPesoEmpenio.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPesoEmpenio.Properties.Appearance.Options.UseFont = true;
            this.txtPesoEmpenio.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPesoEmpenio.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtPesoEmpenio.Properties.Mask.EditMask = "n1";
            this.txtPesoEmpenio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPesoEmpenio.Size = new System.Drawing.Size(134, 26);
            this.txtPesoEmpenio.TabIndex = 39;
            this.txtPesoEmpenio.EditValueChanged += new System.EventHandler(this.txtPesoEmpenio_EditValueChanged);
            // 
            // gridBusqueda
            // 
            this.gridBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridBusqueda.Location = new System.Drawing.Point(2, 233);
            this.gridBusqueda.MainView = this.grvResultado;
            this.gridBusqueda.Name = "gridBusqueda";
            this.gridBusqueda.Size = new System.Drawing.Size(883, 311);
            this.gridBusqueda.TabIndex = 1;
            this.gridBusqueda.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvResultado});
            // 
            // grvResultado
            // 
            this.grvResultado.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvResultado.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvResultado.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.grvResultado.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.grvResultado.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.grvResultado.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.grvResultado.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvResultado.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvResultado.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.grvResultado.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.grvResultado.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.grvResultado.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.grvResultado.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvResultado.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.grvResultado.Appearance.Empty.Options.UseBackColor = true;
            this.grvResultado.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvResultado.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.grvResultado.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvResultado.Appearance.EvenRow.Options.UseForeColor = true;
            this.grvResultado.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvResultado.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvResultado.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.grvResultado.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.grvResultado.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.grvResultado.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.grvResultado.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvResultado.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.grvResultado.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvResultado.Appearance.FilterPanel.Options.UseBackColor = true;
            this.grvResultado.Appearance.FilterPanel.Options.UseForeColor = true;
            this.grvResultado.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(153)))), ((int)(((byte)(73)))));
            this.grvResultado.Appearance.FixedLine.Options.UseBackColor = true;
            this.grvResultado.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.grvResultado.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvResultado.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvResultado.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvResultado.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(154)))), ((int)(((byte)(91)))));
            this.grvResultado.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvResultado.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvResultado.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvResultado.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvResultado.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvResultado.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvResultado.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grvResultado.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grvResultado.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvResultado.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvResultado.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvResultado.Appearance.GroupButton.Options.UseBackColor = true;
            this.grvResultado.Appearance.GroupButton.Options.UseBorderColor = true;
            this.grvResultado.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvResultado.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvResultado.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.grvResultado.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvResultado.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvResultado.Appearance.GroupFooter.Options.UseForeColor = true;
            this.grvResultado.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvResultado.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.grvResultado.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.grvResultado.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvResultado.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grvResultado.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvResultado.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvResultado.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grvResultado.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvResultado.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grvResultado.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvResultado.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvResultado.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvResultado.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvResultado.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvResultado.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvResultado.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvResultado.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvResultado.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvResultado.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvResultado.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvResultado.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(183)))), ((int)(((byte)(125)))));
            this.grvResultado.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvResultado.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvResultado.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvResultado.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvResultado.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvResultado.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
            this.grvResultado.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.grvResultado.Appearance.OddRow.Options.UseBackColor = true;
            this.grvResultado.Appearance.OddRow.Options.UseForeColor = true;
            this.grvResultado.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(249)))));
            this.grvResultado.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.grvResultado.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(146)))), ((int)(((byte)(78)))));
            this.grvResultado.Appearance.Preview.Options.UseBackColor = true;
            this.grvResultado.Appearance.Preview.Options.UseFont = true;
            this.grvResultado.Appearance.Preview.Options.UseForeColor = true;
            this.grvResultado.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvResultado.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvResultado.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.grvResultado.Appearance.Row.Options.UseBackColor = true;
            this.grvResultado.Appearance.Row.Options.UseBorderColor = true;
            this.grvResultado.Appearance.Row.Options.UseForeColor = true;
            this.grvResultado.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvResultado.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.grvResultado.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvResultado.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(167)))), ((int)(((byte)(103)))));
            this.grvResultado.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvResultado.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.grvResultado.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grvResultado.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvResultado.Appearance.VertLine.Options.UseBackColor = true;
            this.grvResultado.GridControl = this.gridBusqueda;
            this.grvResultado.Name = "grvResultado";
            this.grvResultado.OptionsBehavior.Editable = false;
            this.grvResultado.OptionsCustomization.AllowColumnMoving = false;
            this.grvResultado.OptionsCustomization.AllowColumnResizing = false;
            this.grvResultado.OptionsCustomization.AllowFilter = false;
            this.grvResultado.OptionsCustomization.AllowGroup = false;
            this.grvResultado.OptionsCustomization.AllowSort = false;
            this.grvResultado.OptionsView.EnableAppearanceEvenRow = true;
            this.grvResultado.OptionsView.EnableAppearanceOddRow = true;
            this.grvResultado.OptionsView.ShowGroupPanel = false;
            this.grvResultado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvResultado_KeyDown);
            // 
            // FrmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 546);
            this.Controls.Add(this.gpoContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCompras";
            this.Text = "FrmCompras";
            this.Shown += new System.EventHandler(this.FrmCompras_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).EndInit();
            this.gpoContenedor.ResumeLayout(false);
            this.gpoContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCompra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoPrenda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAvaluo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCveCompra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPesoEmpenio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBusqueda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvResultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpoContenedor;
        private DevExpress.XtraGrid.GridControl gridBusqueda;
        private DevExpress.XtraGrid.Views.Grid.GridView grvResultado;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cboTipoPrenda;
        private DevExpress.XtraEditors.SimpleButton btnAgregarPrenda;
        private Controles.TextEditSelected txtAvaluo;
        private DevExpress.XtraEditors.TextEdit txtCveCompra;
        private Controles.TextEditSelected txtPesoEmpenio;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private Controles.TextEditSelected txtTotalCompra;
        private Controles.BotonCambiante botonGuardarCompra;

    }
}