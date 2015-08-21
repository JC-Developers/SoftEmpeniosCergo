namespace SoftEmpenios.Pantallas
{
    partial class FrmCreditosAtrasados
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreditosAtrasados));
            this.grvPagos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCrono = new DevExpress.XtraGrid.GridControl();
            this.grvCreditos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gpoContenedor = new DevExpress.XtraEditors.GroupControl();
            this.botonImprimir = new SoftEmpenios.Controles.BotonCambiante();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grvPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCreditos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).BeginInit();
            this.gpoContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printableComponentLink1.ImageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // grvPagos
            // 
            this.grvPagos.GridControl = this.gridCrono;
            this.grvPagos.Name = "grvPagos";
            this.grvPagos.OptionsView.ShowGroupPanel = false;
            this.grvPagos.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            // 
            // gridCrono
            // 
            this.gridCrono.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.LevelTemplate = this.grvPagos;
            gridLevelNode1.RelationName = "Pagos";
            this.gridCrono.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridCrono.Location = new System.Drawing.Point(2, 26);
            this.gridCrono.MainView = this.grvCreditos;
            this.gridCrono.Name = "gridCrono";
            this.gridCrono.ShowOnlyPredefinedDetails = true;
            this.gridCrono.Size = new System.Drawing.Size(1004, 384);
            this.gridCrono.TabIndex = 0;
            this.gridCrono.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCreditos,
            this.grvPagos});
            this.gridCrono.DoubleClick += new System.EventHandler(this.gridCrono_DoubleClick);
            // 
            // grvCreditos
            // 
            this.grvCreditos.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvCreditos.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvCreditos.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.grvCreditos.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.grvCreditos.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.grvCreditos.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.grvCreditos.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvCreditos.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvCreditos.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.grvCreditos.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.grvCreditos.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.grvCreditos.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.grvCreditos.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvCreditos.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.grvCreditos.Appearance.Empty.Options.UseBackColor = true;
            this.grvCreditos.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvCreditos.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.grvCreditos.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvCreditos.Appearance.EvenRow.Options.UseForeColor = true;
            this.grvCreditos.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvCreditos.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvCreditos.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.grvCreditos.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.grvCreditos.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.grvCreditos.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.grvCreditos.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvCreditos.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.grvCreditos.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvCreditos.Appearance.FilterPanel.Options.UseBackColor = true;
            this.grvCreditos.Appearance.FilterPanel.Options.UseForeColor = true;
            this.grvCreditos.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(153)))), ((int)(((byte)(73)))));
            this.grvCreditos.Appearance.FixedLine.Options.UseBackColor = true;
            this.grvCreditos.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.grvCreditos.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvCreditos.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvCreditos.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvCreditos.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(154)))), ((int)(((byte)(91)))));
            this.grvCreditos.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvCreditos.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvCreditos.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvCreditos.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvCreditos.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvCreditos.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvCreditos.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grvCreditos.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grvCreditos.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvCreditos.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvCreditos.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvCreditos.Appearance.GroupButton.Options.UseBackColor = true;
            this.grvCreditos.Appearance.GroupButton.Options.UseBorderColor = true;
            this.grvCreditos.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvCreditos.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvCreditos.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.grvCreditos.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvCreditos.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvCreditos.Appearance.GroupFooter.Options.UseForeColor = true;
            this.grvCreditos.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvCreditos.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.grvCreditos.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.grvCreditos.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvCreditos.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grvCreditos.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvCreditos.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvCreditos.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grvCreditos.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvCreditos.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grvCreditos.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvCreditos.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvCreditos.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvCreditos.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvCreditos.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvCreditos.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvCreditos.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvCreditos.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCreditos.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvCreditos.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvCreditos.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCreditos.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(183)))), ((int)(((byte)(125)))));
            this.grvCreditos.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvCreditos.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvCreditos.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvCreditos.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvCreditos.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvCreditos.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
            this.grvCreditos.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.grvCreditos.Appearance.OddRow.Options.UseBackColor = true;
            this.grvCreditos.Appearance.OddRow.Options.UseForeColor = true;
            this.grvCreditos.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(249)))));
            this.grvCreditos.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.grvCreditos.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(146)))), ((int)(((byte)(78)))));
            this.grvCreditos.Appearance.Preview.Options.UseBackColor = true;
            this.grvCreditos.Appearance.Preview.Options.UseFont = true;
            this.grvCreditos.Appearance.Preview.Options.UseForeColor = true;
            this.grvCreditos.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvCreditos.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvCreditos.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.grvCreditos.Appearance.Row.Options.UseBackColor = true;
            this.grvCreditos.Appearance.Row.Options.UseBorderColor = true;
            this.grvCreditos.Appearance.Row.Options.UseForeColor = true;
            this.grvCreditos.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvCreditos.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.grvCreditos.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvCreditos.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(167)))), ((int)(((byte)(103)))));
            this.grvCreditos.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvCreditos.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.grvCreditos.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grvCreditos.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvCreditos.Appearance.VertLine.Options.UseBackColor = true;
            this.grvCreditos.GridControl = this.gridCrono;
            this.grvCreditos.Name = "grvCreditos";
            this.grvCreditos.OptionsBehavior.Editable = false;
            this.grvCreditos.OptionsMenu.EnableColumnMenu = false;
            this.grvCreditos.OptionsPrint.PrintFooter = false;
            this.grvCreditos.OptionsView.EnableAppearanceEvenRow = true;
            this.grvCreditos.OptionsView.EnableAppearanceOddRow = true;
            this.grvCreditos.OptionsView.RowAutoHeight = true;
            this.grvCreditos.OptionsView.ShowGroupPanel = false;
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
            this.gpoContenedor.Controls.Add(this.botonImprimir);
            this.gpoContenedor.Controls.Add(this.gridCrono);
            this.gpoContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpoContenedor.Location = new System.Drawing.Point(0, 0);
            this.gpoContenedor.LookAndFeel.SkinName = "Office 2010 Silver";
            this.gpoContenedor.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gpoContenedor.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gpoContenedor.Name = "gpoContenedor";
            this.gpoContenedor.Size = new System.Drawing.Size(1009, 490);
            this.gpoContenedor.TabIndex = 2;
            this.gpoContenedor.Text = "Creditos Atrasados";
            // 
            // botonImprimir
            // 
            this.botonImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botonImprimir.BackColor = System.Drawing.Color.Transparent;
            this.botonImprimir.EtiquetaBoton = "Depositar Dinero";
            this.botonImprimir.FlatAppearance.BorderSize = 0;
            this.botonImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.botonImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.botonImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonImprimir.Image = global::SoftEmpenios.Properties.Resources.Printer;
            this.botonImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.botonImprimir.imgDisable = global::SoftEmpenios.Properties.Resources.Printerdiseable;
            this.botonImprimir.imgencima = global::SoftEmpenios.Properties.Resources.Printerover;
            this.botonImprimir.imgnormal = global::SoftEmpenios.Properties.Resources.Printer;
            this.botonImprimir.imgPrecionado = global::SoftEmpenios.Properties.Resources.PrinterPush;
            this.botonImprimir.Location = new System.Drawing.Point(907, 419);
            this.botonImprimir.Name = "botonImprimir";
            this.botonImprimir.Size = new System.Drawing.Size(97, 66);
            this.botonImprimir.TabIndex = 120;
            this.botonImprimir.Text = "Imprimir";
            this.botonImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.botonImprimir.UseVisualStyleBackColor = true;
            this.botonImprimir.Click += new System.EventHandler(this.botonImprimir_Click);
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Component = this.gridCrono;
            // 
            // 
            // 
            this.printableComponentLink1.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageCollection.ImageStream")));
            this.printableComponentLink1.Landscape = true;
            this.printableComponentLink1.Margins = new System.Drawing.Printing.Margins(50, 50, 100, 100);
            this.printableComponentLink1.PrintingSystem = this.printingSystem1;
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            // 
            // FrmCreditosAtrasados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 490);
            this.Controls.Add(this.gpoContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCreditosAtrasados";
            this.Text = "Creditos Atrasados";
            this.Shown += new System.EventHandler(this.frmFinanciamientosAtrasados_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grvPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCreditos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).EndInit();
            this.gpoContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printableComponentLink1.ImageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpoContenedor;
        private DevExpress.XtraGrid.GridControl gridCrono;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCreditos;
        private Controles.BotonCambiante botonImprimir;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPagos;

    }
}