namespace SoftEmpenios.Pantallas
{
    partial class FrmFinanciamientosAtrasados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFinanciamientosAtrasados));
            this.grvPagos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCrono = new DevExpress.XtraGrid.GridControl();
            this.grvFinanciamientos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gpoContenedor = new DevExpress.XtraEditors.GroupControl();
            this.botonImprimir = new SoftEmpenios.Controles.BotonCambiante();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grvPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFinanciamientos)).BeginInit();
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
            this.gridCrono.MainView = this.grvFinanciamientos;
            this.gridCrono.Name = "gridCrono";
            this.gridCrono.ShowOnlyPredefinedDetails = true;
            this.gridCrono.Size = new System.Drawing.Size(1004, 384);
            this.gridCrono.TabIndex = 0;
            this.gridCrono.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFinanciamientos,
            this.grvPagos});
            this.gridCrono.DoubleClick += new System.EventHandler(this.gridCrono_DoubleClick);
            // 
            // grvFinanciamientos
            // 
            this.grvFinanciamientos.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvFinanciamientos.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvFinanciamientos.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciamientos.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.grvFinanciamientos.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.grvFinanciamientos.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciamientos.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciamientos.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciamientos.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.grvFinanciamientos.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.grvFinanciamientos.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvFinanciamientos.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.grvFinanciamientos.Appearance.Empty.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvFinanciamientos.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciamientos.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.EvenRow.Options.UseForeColor = true;
            this.grvFinanciamientos.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvFinanciamientos.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvFinanciamientos.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciamientos.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.grvFinanciamientos.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.grvFinanciamientos.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvFinanciamientos.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.grvFinanciamientos.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciamientos.Appearance.FilterPanel.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.FilterPanel.Options.UseForeColor = true;
            this.grvFinanciamientos.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(153)))), ((int)(((byte)(73)))));
            this.grvFinanciamientos.Appearance.FixedLine.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.grvFinanciamientos.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciamientos.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFinanciamientos.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(154)))), ((int)(((byte)(91)))));
            this.grvFinanciamientos.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFinanciamientos.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFinanciamientos.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvFinanciamientos.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvFinanciamientos.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciamientos.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grvFinanciamientos.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvFinanciamientos.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciamientos.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciamientos.Appearance.GroupButton.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.GroupButton.Options.UseBorderColor = true;
            this.grvFinanciamientos.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciamientos.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciamientos.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciamientos.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvFinanciamientos.Appearance.GroupFooter.Options.UseForeColor = true;
            this.grvFinanciamientos.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvFinanciamientos.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.grvFinanciamientos.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciamientos.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grvFinanciamientos.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciamientos.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciamientos.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciamientos.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grvFinanciamientos.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFinanciamientos.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciamientos.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciamientos.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvFinanciamientos.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciamientos.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFinanciamientos.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFinanciamientos.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvFinanciamientos.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvFinanciamientos.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvFinanciamientos.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(183)))), ((int)(((byte)(125)))));
            this.grvFinanciamientos.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvFinanciamientos.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFinanciamientos.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvFinanciamientos.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
            this.grvFinanciamientos.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciamientos.Appearance.OddRow.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.OddRow.Options.UseForeColor = true;
            this.grvFinanciamientos.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(249)))));
            this.grvFinanciamientos.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.grvFinanciamientos.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(146)))), ((int)(((byte)(78)))));
            this.grvFinanciamientos.Appearance.Preview.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.Preview.Options.UseFont = true;
            this.grvFinanciamientos.Appearance.Preview.Options.UseForeColor = true;
            this.grvFinanciamientos.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvFinanciamientos.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvFinanciamientos.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciamientos.Appearance.Row.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.Row.Options.UseBorderColor = true;
            this.grvFinanciamientos.Appearance.Row.Options.UseForeColor = true;
            this.grvFinanciamientos.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvFinanciamientos.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.grvFinanciamientos.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(167)))), ((int)(((byte)(103)))));
            this.grvFinanciamientos.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.grvFinanciamientos.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grvFinanciamientos.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvFinanciamientos.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFinanciamientos.GridControl = this.gridCrono;
            this.grvFinanciamientos.Name = "grvFinanciamientos";
            this.grvFinanciamientos.OptionsBehavior.Editable = false;
            this.grvFinanciamientos.OptionsMenu.EnableColumnMenu = false;
            this.grvFinanciamientos.OptionsPrint.PrintFooter = false;
            this.grvFinanciamientos.OptionsView.EnableAppearanceEvenRow = true;
            this.grvFinanciamientos.OptionsView.EnableAppearanceOddRow = true;
            this.grvFinanciamientos.OptionsView.RowAutoHeight = true;
            this.grvFinanciamientos.OptionsView.ShowGroupPanel = false;
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
            this.gpoContenedor.Text = "Financiamientos Atrasados";
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
            // FrmFinanciamientosAtrasados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 490);
            this.Controls.Add(this.gpoContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmFinanciamientosAtrasados";
            this.Text = "frmFinanciamientosAtrasados";
            this.Shown += new System.EventHandler(this.frmFinanciamientosAtrasados_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grvPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFinanciamientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).EndInit();
            this.gpoContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printableComponentLink1.ImageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpoContenedor;
        private DevExpress.XtraGrid.GridControl gridCrono;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFinanciamientos;
        private Controles.BotonCambiante botonImprimir;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPagos;

    }
}