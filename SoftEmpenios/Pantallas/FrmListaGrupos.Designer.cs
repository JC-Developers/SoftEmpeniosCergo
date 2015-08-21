namespace SoftEmpenios.Pantallas
{
    partial class FrmListaGrupos
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.grvIntegrantes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridGrupos = new DevExpress.XtraGrid.GridControl();
            this.grvGrupos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gpoContenedor = new DevExpress.XtraEditors.GroupControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.cboCriterio = new DevExpress.XtraEditors.ComboBoxEdit();
            this.BotonEditar = new SoftEmpenios.Controles.BotonCambiante();
            this.BotonNuevo = new SoftEmpenios.Controles.BotonCambiante();
            ((System.ComponentModel.ISupportInitialize)(this.grvIntegrantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGrupos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).BeginInit();
            this.gpoContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCriterio.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grvIntegrantes
            // 
            this.grvIntegrantes.GridControl = this.gridGrupos;
            this.grvIntegrantes.Name = "grvIntegrantes";
            this.grvIntegrantes.OptionsView.ShowGroupPanel = false;
            this.grvIntegrantes.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            // 
            // gridGrupos
            // 
            this.gridGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode2.LevelTemplate = this.grvIntegrantes;
            gridLevelNode2.RelationName = "Integrantes";
            this.gridGrupos.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridGrupos.Location = new System.Drawing.Point(2, 63);
            this.gridGrupos.MainView = this.grvGrupos;
            this.gridGrupos.Name = "gridGrupos";
            this.gridGrupos.ShowOnlyPredefinedDetails = true;
            this.gridGrupos.Size = new System.Drawing.Size(1027, 335);
            this.gridGrupos.TabIndex = 0;
            this.gridGrupos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvGrupos,
            this.grvIntegrantes});
            this.gridGrupos.Load += new System.EventHandler(this.gridGrupos_Load);
            // 
            // grvGrupos
            // 
            this.grvGrupos.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvGrupos.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvGrupos.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.grvGrupos.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.grvGrupos.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.grvGrupos.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.grvGrupos.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvGrupos.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvGrupos.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.grvGrupos.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.grvGrupos.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.grvGrupos.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.grvGrupos.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvGrupos.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.grvGrupos.Appearance.Empty.Options.UseBackColor = true;
            this.grvGrupos.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvGrupos.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.grvGrupos.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvGrupos.Appearance.EvenRow.Options.UseForeColor = true;
            this.grvGrupos.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvGrupos.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvGrupos.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.grvGrupos.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.grvGrupos.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.grvGrupos.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.grvGrupos.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvGrupos.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.grvGrupos.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvGrupos.Appearance.FilterPanel.Options.UseBackColor = true;
            this.grvGrupos.Appearance.FilterPanel.Options.UseForeColor = true;
            this.grvGrupos.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(153)))), ((int)(((byte)(73)))));
            this.grvGrupos.Appearance.FixedLine.Options.UseBackColor = true;
            this.grvGrupos.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.grvGrupos.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvGrupos.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvGrupos.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvGrupos.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(154)))), ((int)(((byte)(91)))));
            this.grvGrupos.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvGrupos.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvGrupos.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvGrupos.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvGrupos.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvGrupos.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvGrupos.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grvGrupos.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grvGrupos.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvGrupos.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvGrupos.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvGrupos.Appearance.GroupButton.Options.UseBackColor = true;
            this.grvGrupos.Appearance.GroupButton.Options.UseBorderColor = true;
            this.grvGrupos.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvGrupos.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvGrupos.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.grvGrupos.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvGrupos.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvGrupos.Appearance.GroupFooter.Options.UseForeColor = true;
            this.grvGrupos.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvGrupos.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.grvGrupos.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.grvGrupos.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvGrupos.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grvGrupos.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvGrupos.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvGrupos.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grvGrupos.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvGrupos.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grvGrupos.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvGrupos.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvGrupos.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvGrupos.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvGrupos.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvGrupos.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvGrupos.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvGrupos.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(183)))), ((int)(((byte)(125)))));
            this.grvGrupos.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvGrupos.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvGrupos.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvGrupos.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvGrupos.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvGrupos.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
            this.grvGrupos.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.grvGrupos.Appearance.OddRow.Options.UseBackColor = true;
            this.grvGrupos.Appearance.OddRow.Options.UseForeColor = true;
            this.grvGrupos.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(249)))));
            this.grvGrupos.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.grvGrupos.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(146)))), ((int)(((byte)(78)))));
            this.grvGrupos.Appearance.Preview.Options.UseBackColor = true;
            this.grvGrupos.Appearance.Preview.Options.UseFont = true;
            this.grvGrupos.Appearance.Preview.Options.UseForeColor = true;
            this.grvGrupos.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvGrupos.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvGrupos.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.grvGrupos.Appearance.Row.Options.UseBackColor = true;
            this.grvGrupos.Appearance.Row.Options.UseBorderColor = true;
            this.grvGrupos.Appearance.Row.Options.UseForeColor = true;
            this.grvGrupos.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvGrupos.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.grvGrupos.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvGrupos.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(167)))), ((int)(((byte)(103)))));
            this.grvGrupos.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvGrupos.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.grvGrupos.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grvGrupos.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvGrupos.Appearance.VertLine.Options.UseBackColor = true;
            this.grvGrupos.GridControl = this.gridGrupos;
            this.grvGrupos.Name = "grvGrupos";
            this.grvGrupos.OptionsBehavior.Editable = false;
            this.grvGrupos.OptionsFind.AlwaysVisible = true;
            this.grvGrupos.OptionsFind.ShowClearButton = false;
            this.grvGrupos.OptionsFind.ShowCloseButton = false;
            this.grvGrupos.OptionsFind.ShowFindButton = false;
            this.grvGrupos.OptionsMenu.EnableColumnMenu = false;
            this.grvGrupos.OptionsPrint.PrintFooter = false;
            this.grvGrupos.OptionsView.EnableAppearanceEvenRow = true;
            this.grvGrupos.OptionsView.EnableAppearanceOddRow = true;
            this.grvGrupos.OptionsView.RowAutoHeight = true;
            this.grvGrupos.OptionsView.ShowFooter = true;
            this.grvGrupos.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grvGrupos_RowClick);
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
            this.gpoContenedor.AppearanceCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gpoContenedor.AppearanceCaption.Options.UseBackColor = true;
            this.gpoContenedor.AppearanceCaption.Options.UseFont = true;
            this.gpoContenedor.AppearanceCaption.Options.UseTextOptions = true;
            this.gpoContenedor.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gpoContenedor.Controls.Add(this.labelControl10);
            this.gpoContenedor.Controls.Add(this.cboCriterio);
            this.gpoContenedor.Controls.Add(this.BotonEditar);
            this.gpoContenedor.Controls.Add(this.BotonNuevo);
            this.gpoContenedor.Controls.Add(this.gridGrupos);
            this.gpoContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpoContenedor.Location = new System.Drawing.Point(0, 0);
            this.gpoContenedor.LookAndFeel.SkinName = "Office 2010 Silver";
            this.gpoContenedor.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gpoContenedor.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gpoContenedor.Name = "gpoContenedor";
            this.gpoContenedor.Size = new System.Drawing.Size(1032, 478);
            this.gpoContenedor.TabIndex = 3;
            this.gpoContenedor.Text = "Grupos Créditos";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Location = new System.Drawing.Point(30, 35);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(117, 18);
            this.labelControl10.TabIndex = 142;
            this.labelControl10.Text = "Busqueda por:";
            // 
            // cboCriterio
            // 
            this.cboCriterio.EditValue = "";
            this.cboCriterio.Location = new System.Drawing.Point(153, 31);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cboCriterio.Properties.Appearance.Options.UseFont = true;
            this.cboCriterio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCriterio.Properties.Items.AddRange(new object[] {
            "Clave",
            "Grupo"});
            this.cboCriterio.Properties.NullText = "[Vacío]";
            this.cboCriterio.Properties.PopupSizeable = true;
            this.cboCriterio.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboCriterio.Size = new System.Drawing.Size(208, 26);
            this.cboCriterio.TabIndex = 141;
            this.cboCriterio.SelectedIndexChanged += new System.EventHandler(this.cboCriterio_SelectedIndexChanged);
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
            this.BotonEditar.Location = new System.Drawing.Point(965, 404);
            this.BotonEditar.Name = "BotonEditar";
            this.BotonEditar.Size = new System.Drawing.Size(55, 69);
            this.BotonEditar.TabIndex = 19;
            this.BotonEditar.Text = "Editar Grupo";
            this.BotonEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BotonEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BotonEditar.UseVisualStyleBackColor = false;
            this.BotonEditar.Click += new System.EventHandler(this.BotonEditar_Click);
            // 
            // BotonNuevo
            // 
            this.BotonNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BotonNuevo.BackColor = System.Drawing.Color.Transparent;
            this.BotonNuevo.EtiquetaBoton = "Guardar Articulo";
            this.BotonNuevo.FlatAppearance.BorderSize = 0;
            this.BotonNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BotonNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BotonNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonNuevo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BotonNuevo.Image = global::SoftEmpenios.Properties.Resources.Nuevo1;
            this.BotonNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BotonNuevo.imgDisable = global::SoftEmpenios.Properties.Resources.Nuevo1D;
            this.BotonNuevo.imgencima = global::SoftEmpenios.Properties.Resources.Nuevo1O;
            this.BotonNuevo.imgnormal = global::SoftEmpenios.Properties.Resources.Nuevo1;
            this.BotonNuevo.imgPrecionado = global::SoftEmpenios.Properties.Resources.Nuevo1P;
            this.BotonNuevo.Location = new System.Drawing.Point(892, 404);
            this.BotonNuevo.Name = "BotonNuevo";
            this.BotonNuevo.Size = new System.Drawing.Size(55, 69);
            this.BotonNuevo.TabIndex = 16;
            this.BotonNuevo.Text = "Crear Grupo";
            this.BotonNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BotonNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BotonNuevo.UseVisualStyleBackColor = false;
            this.BotonNuevo.Click += new System.EventHandler(this.BotonNuevo_Click);
            // 
            // FrmListaGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 478);
            this.Controls.Add(this.gpoContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmListaGrupos";
            this.Text = "FrmListaGrupos";
            ((System.ComponentModel.ISupportInitialize)(this.grvIntegrantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGrupos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).EndInit();
            this.gpoContenedor.ResumeLayout(false);
            this.gpoContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCriterio.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpoContenedor;
        private DevExpress.XtraGrid.GridControl gridGrupos;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIntegrantes;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGrupos;
        private Controles.BotonCambiante BotonNuevo;
        private Controles.BotonCambiante BotonEditar;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.ComboBoxEdit cboCriterio;

    }
}