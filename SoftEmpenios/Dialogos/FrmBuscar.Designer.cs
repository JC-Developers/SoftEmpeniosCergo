namespace SoftEmpenios.Dialogos
{
    partial class FrmBuscar
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.grvDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridBusqueda = new DevExpress.XtraGrid.GridControl();
            this.grvResultado = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gpoContenedor = new DevExpress.XtraEditors.GroupControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.cboCriterio = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBusqueda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvResultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).BeginInit();
            this.gpoContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCriterio.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grvDetalle
            // 
            this.grvDetalle.GridControl = this.gridBusqueda;
            this.grvDetalle.Name = "grvDetalle";
            // 
            // gridBusqueda
            // 
            this.gridBusqueda.Dock = System.Windows.Forms.DockStyle.Bottom;
            gridLevelNode1.LevelTemplate = this.grvDetalle;
            gridLevelNode1.RelationName = "Detalle";
            this.gridBusqueda.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridBusqueda.Location = new System.Drawing.Point(2, 64);
            this.gridBusqueda.MainView = this.grvResultado;
            this.gridBusqueda.Name = "gridBusqueda";
            this.gridBusqueda.Size = new System.Drawing.Size(680, 362);
            this.gridBusqueda.TabIndex = 0;
            this.gridBusqueda.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvResultado,
            this.grvDetalle});
            this.gridBusqueda.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridBusqueda_MouseDoubleClick);
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
            this.grvResultado.OptionsFind.AlwaysVisible = true;
            this.grvResultado.OptionsFind.ShowClearButton = false;
            this.grvResultado.OptionsFind.ShowFindButton = false;
            this.grvResultado.OptionsView.ColumnAutoWidth = false;
            this.grvResultado.OptionsView.EnableAppearanceEvenRow = true;
            this.grvResultado.OptionsView.EnableAppearanceOddRow = true;
            this.grvResultado.OptionsView.ShowGroupPanel = false;
            // 
            // gpoContenedor
            // 
            this.gpoContenedor.Appearance.BackColor = System.Drawing.Color.Orange;
            this.gpoContenedor.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gpoContenedor.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gpoContenedor.Appearance.Options.UseBackColor = true;
            this.gpoContenedor.AppearanceCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gpoContenedor.AppearanceCaption.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gpoContenedor.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpoContenedor.AppearanceCaption.ForeColor = System.Drawing.Color.White;
            this.gpoContenedor.AppearanceCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gpoContenedor.AppearanceCaption.Options.UseBackColor = true;
            this.gpoContenedor.AppearanceCaption.Options.UseFont = true;
            this.gpoContenedor.AppearanceCaption.Options.UseForeColor = true;
            this.gpoContenedor.AppearanceCaption.Options.UseTextOptions = true;
            this.gpoContenedor.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gpoContenedor.Controls.Add(this.labelControl10);
            this.gpoContenedor.Controls.Add(this.gridBusqueda);
            this.gpoContenedor.Controls.Add(this.cboCriterio);
            this.gpoContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpoContenedor.Location = new System.Drawing.Point(0, 0);
            this.gpoContenedor.LookAndFeel.SkinName = "Office 2010 Silver";
            this.gpoContenedor.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gpoContenedor.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gpoContenedor.Name = "gpoContenedor";
            this.gpoContenedor.Size = new System.Drawing.Size(684, 428);
            this.gpoContenedor.TabIndex = 2;
            this.gpoContenedor.Text = "Busquedas";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Location = new System.Drawing.Point(118, 36);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(117, 18);
            this.labelControl10.TabIndex = 140;
            this.labelControl10.Text = "Busqueda por:";
            // 
            // cboCriterio
            // 
            this.cboCriterio.EditValue = "";
            this.cboCriterio.Location = new System.Drawing.Point(241, 32);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cboCriterio.Properties.Appearance.Options.UseFont = true;
            this.cboCriterio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCriterio.Properties.NullText = "[Vacío]";
            this.cboCriterio.Properties.PopupSizeable = true;
            this.cboCriterio.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboCriterio.Size = new System.Drawing.Size(208, 26);
            this.cboCriterio.TabIndex = 24;
            this.cboCriterio.SelectedIndexChanged += new System.EventHandler(this.cboCriterio_SelectedIndexChanged);
            // 
            // FrmBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 428);
            this.Controls.Add(this.gpoContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmBuscar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.grvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBusqueda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvResultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).EndInit();
            this.gpoContenedor.ResumeLayout(false);
            this.gpoContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCriterio.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpoContenedor;
        private DevExpress.XtraGrid.GridControl gridBusqueda;
        private DevExpress.XtraGrid.Views.Grid.GridView grvResultado;
        private DevExpress.XtraEditors.ComboBoxEdit cboCriterio;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDetalle;
    }
}