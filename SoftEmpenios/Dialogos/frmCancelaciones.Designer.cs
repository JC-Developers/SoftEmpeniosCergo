namespace SoftEmpenios.Dialogos
{
    partial class FrmCancelaciones
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
            this.mnuCancelar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gpoContenedor = new DevExpress.XtraEditors.GroupControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.gridDatos = new DevExpress.XtraGrid.GridControl();
            this.grvDatos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboTipoCancelacion = new DevExpress.XtraEditors.ComboBoxEdit();
            this.mnuCancelar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).BeginInit();
            this.gpoContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCancelacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuCancelar
            // 
            this.mnuCancelar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelarToolStripMenuItem});
            this.mnuCancelar.Name = "mnuCancelar";
            this.mnuCancelar.Size = new System.Drawing.Size(121, 26);
            // 
            // cancelarToolStripMenuItem
            // 
            this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
            this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.cancelarToolStripMenuItem.Text = "Cancelar";
            this.cancelarToolStripMenuItem.Click += new System.EventHandler(this.cancelarToolStripMenuItem_Click);
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
            this.gpoContenedor.Controls.Add(this.gridDatos);
            this.gpoContenedor.Controls.Add(this.cboTipoCancelacion);
            this.gpoContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpoContenedor.Location = new System.Drawing.Point(0, 0);
            this.gpoContenedor.LookAndFeel.SkinName = "Office 2010 Silver";
            this.gpoContenedor.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gpoContenedor.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gpoContenedor.Name = "gpoContenedor";
            this.gpoContenedor.Size = new System.Drawing.Size(666, 441);
            this.gpoContenedor.TabIndex = 3;
            this.gpoContenedor.Text = "Cancelaciones";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Location = new System.Drawing.Point(68, 35);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(167, 18);
            this.labelControl10.TabIndex = 140;
            this.labelControl10.Text = "Tipo de Cancelación:";
            // 
            // gridDatos
            // 
            this.gridDatos.ContextMenuStrip = this.mnuCancelar;
            this.gridDatos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridDatos.Location = new System.Drawing.Point(2, 77);
            this.gridDatos.MainView = this.grvDatos;
            this.gridDatos.Name = "gridDatos";
            this.gridDatos.Size = new System.Drawing.Size(662, 362);
            this.gridDatos.TabIndex = 0;
            this.gridDatos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDatos});
            // 
            // grvDatos
            // 
            this.grvDatos.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvDatos.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvDatos.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.grvDatos.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.grvDatos.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.grvDatos.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.grvDatos.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvDatos.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvDatos.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.grvDatos.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.grvDatos.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.grvDatos.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.grvDatos.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvDatos.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.grvDatos.Appearance.Empty.Options.UseBackColor = true;
            this.grvDatos.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvDatos.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.grvDatos.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvDatos.Appearance.EvenRow.Options.UseForeColor = true;
            this.grvDatos.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvDatos.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvDatos.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.grvDatos.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.grvDatos.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.grvDatos.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.grvDatos.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvDatos.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.grvDatos.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvDatos.Appearance.FilterPanel.Options.UseBackColor = true;
            this.grvDatos.Appearance.FilterPanel.Options.UseForeColor = true;
            this.grvDatos.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(153)))), ((int)(((byte)(73)))));
            this.grvDatos.Appearance.FixedLine.Options.UseBackColor = true;
            this.grvDatos.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.grvDatos.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvDatos.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDatos.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDatos.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(154)))), ((int)(((byte)(91)))));
            this.grvDatos.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDatos.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDatos.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDatos.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvDatos.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvDatos.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvDatos.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grvDatos.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grvDatos.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvDatos.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvDatos.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvDatos.Appearance.GroupButton.Options.UseBackColor = true;
            this.grvDatos.Appearance.GroupButton.Options.UseBorderColor = true;
            this.grvDatos.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvDatos.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvDatos.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.grvDatos.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvDatos.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvDatos.Appearance.GroupFooter.Options.UseForeColor = true;
            this.grvDatos.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvDatos.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.grvDatos.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.grvDatos.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDatos.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grvDatos.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvDatos.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvDatos.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grvDatos.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDatos.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grvDatos.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDatos.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvDatos.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvDatos.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvDatos.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvDatos.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDatos.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDatos.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDatos.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvDatos.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvDatos.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvDatos.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(183)))), ((int)(((byte)(125)))));
            this.grvDatos.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvDatos.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDatos.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDatos.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvDatos.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDatos.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
            this.grvDatos.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.grvDatos.Appearance.OddRow.Options.UseBackColor = true;
            this.grvDatos.Appearance.OddRow.Options.UseForeColor = true;
            this.grvDatos.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(249)))));
            this.grvDatos.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.grvDatos.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(146)))), ((int)(((byte)(78)))));
            this.grvDatos.Appearance.Preview.Options.UseBackColor = true;
            this.grvDatos.Appearance.Preview.Options.UseFont = true;
            this.grvDatos.Appearance.Preview.Options.UseForeColor = true;
            this.grvDatos.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvDatos.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvDatos.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.grvDatos.Appearance.Row.Options.UseBackColor = true;
            this.grvDatos.Appearance.Row.Options.UseBorderColor = true;
            this.grvDatos.Appearance.Row.Options.UseForeColor = true;
            this.grvDatos.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvDatos.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.grvDatos.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvDatos.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(167)))), ((int)(((byte)(103)))));
            this.grvDatos.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvDatos.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.grvDatos.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grvDatos.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvDatos.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDatos.GridControl = this.gridDatos;
            this.grvDatos.Name = "grvDatos";
            this.grvDatos.OptionsBehavior.Editable = false;
            this.grvDatos.OptionsCustomization.AllowColumnMoving = false;
            this.grvDatos.OptionsCustomization.AllowFilter = false;
            this.grvDatos.OptionsCustomization.AllowGroup = false;
            this.grvDatos.OptionsCustomization.AllowSort = false;
            this.grvDatos.OptionsFind.AlwaysVisible = true;
            this.grvDatos.OptionsFind.ShowClearButton = false;
            this.grvDatos.OptionsFind.ShowFindButton = false;
            this.grvDatos.OptionsView.ColumnAutoWidth = false;
            this.grvDatos.OptionsView.EnableAppearanceEvenRow = true;
            this.grvDatos.OptionsView.EnableAppearanceOddRow = true;
            this.grvDatos.OptionsView.ShowGroupPanel = false;
            // 
            // cboTipoCancelacion
            // 
            this.cboTipoCancelacion.EditValue = "";
            this.cboTipoCancelacion.Location = new System.Drawing.Point(241, 32);
            this.cboTipoCancelacion.Name = "cboTipoCancelacion";
            this.cboTipoCancelacion.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cboTipoCancelacion.Properties.Appearance.Options.UseFont = true;
            this.cboTipoCancelacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoCancelacion.Properties.Items.AddRange(new object[] {
            "Empeño",
            "Pago de Interes",
            "Desempeño",
            "Compra",
            "Depositos",
            "Retiros",
            "Venta",
            "Abono a Venta",
            "Financiamiento",
            "Abono a Financiamiento",
            "Creditos",
            "Pagos Creditos"});
            this.cboTipoCancelacion.Properties.NullText = "[Vacío]";
            this.cboTipoCancelacion.Properties.PopupSizeable = true;
            this.cboTipoCancelacion.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTipoCancelacion.Size = new System.Drawing.Size(208, 26);
            this.cboTipoCancelacion.TabIndex = 24;
            this.cboTipoCancelacion.SelectedIndexChanged += new System.EventHandler(this.cboTipoCancelacion_SelectedIndexChanged);
            // 
            // FrmCancelaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 441);
            this.Controls.Add(this.gpoContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCancelaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.mnuCancelar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).EndInit();
            this.gpoContenedor.ResumeLayout(false);
            this.gpoContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCancelacion.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuCancelar;
        private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem;
        private DevExpress.XtraEditors.GroupControl gpoContenedor;
        private DevExpress.XtraGrid.GridControl gridDatos;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDatos;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipoCancelacion;
        private DevExpress.XtraEditors.LabelControl labelControl10;
    }
}