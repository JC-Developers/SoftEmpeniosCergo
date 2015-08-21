namespace SoftEmpenios.Dialogos
{
    partial class FrmDetallesCaja
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
            this.gridFinanciera = new DevExpress.XtraGrid.GridControl();
            this.grvFinanciera = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridCrono = new DevExpress.XtraGrid.GridControl();
            this.grid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.referencias = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).BeginInit();
            this.gpoContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFinanciera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFinanciera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.referencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // gpoContenedor
            // 
            this.gpoContenedor.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gpoContenedor.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gpoContenedor.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.gpoContenedor.Appearance.Options.UseBackColor = true;
            this.gpoContenedor.AppearanceCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gpoContenedor.AppearanceCaption.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gpoContenedor.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.gpoContenedor.AppearanceCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gpoContenedor.AppearanceCaption.Options.UseBackColor = true;
            this.gpoContenedor.AppearanceCaption.Options.UseFont = true;
            this.gpoContenedor.AppearanceCaption.Options.UseTextOptions = true;
            this.gpoContenedor.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gpoContenedor.Controls.Add(this.gridFinanciera);
            this.gpoContenedor.Controls.Add(this.labelControl1);
            this.gpoContenedor.Controls.Add(this.gridCrono);
            this.gpoContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpoContenedor.Location = new System.Drawing.Point(0, 0);
            this.gpoContenedor.LookAndFeel.SkinName = "Office 2010 Silver";
            this.gpoContenedor.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gpoContenedor.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gpoContenedor.Name = "gpoContenedor";
            this.gpoContenedor.Size = new System.Drawing.Size(576, 397);
            this.gpoContenedor.TabIndex = 1;
            this.gpoContenedor.Text = "Detalles";
            // 
            // gridFinanciera
            // 
            this.gridFinanciera.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridFinanciera.Location = new System.Drawing.Point(2, 212);
            this.gridFinanciera.MainView = this.grvFinanciera;
            this.gridFinanciera.Name = "gridFinanciera";
            this.gridFinanciera.Size = new System.Drawing.Size(572, 185);
            this.gridFinanciera.TabIndex = 2;
            this.gridFinanciera.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFinanciera,
            this.cardView1,
            this.gridView2});
            // 
            // grvFinanciera
            // 
            this.grvFinanciera.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvFinanciera.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvFinanciera.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciera.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.grvFinanciera.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.grvFinanciera.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciera.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciera.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciera.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.grvFinanciera.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.grvFinanciera.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvFinanciera.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.grvFinanciera.Appearance.Empty.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvFinanciera.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciera.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.EvenRow.Options.UseForeColor = true;
            this.grvFinanciera.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvFinanciera.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvFinanciera.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciera.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.grvFinanciera.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.grvFinanciera.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvFinanciera.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.grvFinanciera.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciera.Appearance.FilterPanel.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.FilterPanel.Options.UseForeColor = true;
            this.grvFinanciera.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(153)))), ((int)(((byte)(73)))));
            this.grvFinanciera.Appearance.FixedLine.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.grvFinanciera.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciera.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFinanciera.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(154)))), ((int)(((byte)(91)))));
            this.grvFinanciera.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFinanciera.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFinanciera.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvFinanciera.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvFinanciera.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciera.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grvFinanciera.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvFinanciera.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciera.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciera.Appearance.GroupButton.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.GroupButton.Options.UseBorderColor = true;
            this.grvFinanciera.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciera.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciera.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciera.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvFinanciera.Appearance.GroupFooter.Options.UseForeColor = true;
            this.grvFinanciera.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvFinanciera.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.grvFinanciera.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciera.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grvFinanciera.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciera.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciera.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciera.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grvFinanciera.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFinanciera.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciera.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grvFinanciera.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvFinanciera.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciera.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFinanciera.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFinanciera.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvFinanciera.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvFinanciera.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvFinanciera.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(183)))), ((int)(((byte)(125)))));
            this.grvFinanciera.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvFinanciera.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFinanciera.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvFinanciera.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
            this.grvFinanciera.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciera.Appearance.OddRow.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.OddRow.Options.UseForeColor = true;
            this.grvFinanciera.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(249)))));
            this.grvFinanciera.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.grvFinanciera.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(146)))), ((int)(((byte)(78)))));
            this.grvFinanciera.Appearance.Preview.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.Preview.Options.UseFont = true;
            this.grvFinanciera.Appearance.Preview.Options.UseForeColor = true;
            this.grvFinanciera.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvFinanciera.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grvFinanciera.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.grvFinanciera.Appearance.Row.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.Row.Options.UseBorderColor = true;
            this.grvFinanciera.Appearance.Row.Options.UseForeColor = true;
            this.grvFinanciera.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grvFinanciera.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.grvFinanciera.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(167)))), ((int)(((byte)(103)))));
            this.grvFinanciera.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.grvFinanciera.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grvFinanciera.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grvFinanciera.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFinanciera.GridControl = this.gridFinanciera;
            this.grvFinanciera.Name = "grvFinanciera";
            this.grvFinanciera.OptionsBehavior.Editable = false;
            this.grvFinanciera.OptionsMenu.EnableColumnMenu = false;
            this.grvFinanciera.OptionsView.ColumnAutoWidth = false;
            this.grvFinanciera.OptionsView.EnableAppearanceEvenRow = true;
            this.grvFinanciera.OptionsView.EnableAppearanceOddRow = true;
            this.grvFinanciera.OptionsView.RowAutoHeight = true;
            this.grvFinanciera.OptionsView.ShowGroupPanel = false;
            this.grvFinanciera.OptionsView.ShowViewCaption = true;
            // 
            // cardView1
            // 
            this.cardView1.Appearance.CardCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(213)))), ((int)(((byte)(157)))));
            this.cardView1.Appearance.CardCaption.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(213)))), ((int)(((byte)(157)))));
            this.cardView1.Appearance.CardCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.cardView1.Appearance.CardCaption.ForeColor = System.Drawing.Color.Black;
            this.cardView1.Appearance.CardCaption.Options.UseBackColor = true;
            this.cardView1.Appearance.CardCaption.Options.UseBorderColor = true;
            this.cardView1.Appearance.CardCaption.Options.UseFont = true;
            this.cardView1.Appearance.CardCaption.Options.UseForeColor = true;
            this.cardView1.Appearance.EmptySpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(233)))), ((int)(((byte)(177)))));
            this.cardView1.Appearance.EmptySpace.Options.UseBackColor = true;
            this.cardView1.Appearance.FieldCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(213)))), ((int)(((byte)(157)))));
            this.cardView1.Appearance.FieldCaption.BackColor2 = System.Drawing.Color.GhostWhite;
            this.cardView1.Appearance.FieldCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cardView1.Appearance.FieldCaption.ForeColor = System.Drawing.Color.Black;
            this.cardView1.Appearance.FieldCaption.Options.UseBackColor = true;
            this.cardView1.Appearance.FieldCaption.Options.UseFont = true;
            this.cardView1.Appearance.FieldCaption.Options.UseForeColor = true;
            this.cardView1.Appearance.FieldValue.BackColor = System.Drawing.Color.White;
            this.cardView1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cardView1.Appearance.FieldValue.ForeColor = System.Drawing.Color.Black;
            this.cardView1.Appearance.FieldValue.Options.UseBackColor = true;
            this.cardView1.Appearance.FieldValue.Options.UseFont = true;
            this.cardView1.Appearance.FieldValue.Options.UseForeColor = true;
            this.cardView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cardView1.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.cardView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cardView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.cardView1.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.cardView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.cardView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.cardView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.cardView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.cardView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cardView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
            this.cardView1.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.cardView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.cardView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.cardView1.Appearance.FocusedCardCaption.BackColor = System.Drawing.Color.Purple;
            this.cardView1.Appearance.FocusedCardCaption.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(50)))), ((int)(((byte)(178)))));
            this.cardView1.Appearance.FocusedCardCaption.BorderColor = System.Drawing.Color.Purple;
            this.cardView1.Appearance.FocusedCardCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cardView1.Appearance.FocusedCardCaption.ForeColor = System.Drawing.Color.White;
            this.cardView1.Appearance.FocusedCardCaption.Options.UseBackColor = true;
            this.cardView1.Appearance.FocusedCardCaption.Options.UseBorderColor = true;
            this.cardView1.Appearance.FocusedCardCaption.Options.UseFont = true;
            this.cardView1.Appearance.FocusedCardCaption.Options.UseForeColor = true;
            this.cardView1.Appearance.HideSelectionCardCaption.BackColor = System.Drawing.Color.Gray;
            this.cardView1.Appearance.HideSelectionCardCaption.BorderColor = System.Drawing.Color.Gray;
            this.cardView1.Appearance.HideSelectionCardCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cardView1.Appearance.HideSelectionCardCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cardView1.Appearance.HideSelectionCardCaption.Options.UseBackColor = true;
            this.cardView1.Appearance.HideSelectionCardCaption.Options.UseBorderColor = true;
            this.cardView1.Appearance.HideSelectionCardCaption.Options.UseFont = true;
            this.cardView1.Appearance.HideSelectionCardCaption.Options.UseForeColor = true;
            this.cardView1.Appearance.SelectedCardCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(10)))), ((int)(((byte)(138)))));
            this.cardView1.Appearance.SelectedCardCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cardView1.Appearance.SelectedCardCaption.ForeColor = System.Drawing.Color.White;
            this.cardView1.Appearance.SelectedCardCaption.Options.UseBackColor = true;
            this.cardView1.Appearance.SelectedCardCaption.Options.UseFont = true;
            this.cardView1.Appearance.SelectedCardCaption.Options.UseForeColor = true;
            this.cardView1.Appearance.SeparatorLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(213)))), ((int)(((byte)(157)))));
            this.cardView1.Appearance.SeparatorLine.Options.UseBackColor = true;
            this.cardView1.FocusedCardTopFieldIndex = 0;
            this.cardView1.GridControl = this.gridFinanciera;
            this.cardView1.Name = "cardView1";
            this.cardView1.OptionsBehavior.Editable = false;
            this.cardView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridFinanciera;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelControl1.Location = new System.Drawing.Point(559, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 19);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "X";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // gridCrono
            // 
            this.gridCrono.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridCrono.Location = new System.Drawing.Point(2, 26);
            this.gridCrono.MainView = this.grid;
            this.gridCrono.Name = "gridCrono";
            this.gridCrono.Size = new System.Drawing.Size(572, 186);
            this.gridCrono.TabIndex = 0;
            this.gridCrono.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grid,
            this.referencias,
            this.gridDetalle});
            // 
            // grid
            // 
            this.grid.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grid.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grid.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.grid.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.grid.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.grid.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.grid.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grid.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grid.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.grid.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.grid.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.grid.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.grid.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grid.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.grid.Appearance.Empty.Options.UseBackColor = true;
            this.grid.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grid.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.grid.Appearance.EvenRow.Options.UseBackColor = true;
            this.grid.Appearance.EvenRow.Options.UseForeColor = true;
            this.grid.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grid.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grid.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.grid.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.grid.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.grid.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.grid.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grid.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.grid.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.grid.Appearance.FilterPanel.Options.UseBackColor = true;
            this.grid.Appearance.FilterPanel.Options.UseForeColor = true;
            this.grid.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(153)))), ((int)(((byte)(73)))));
            this.grid.Appearance.FixedLine.Options.UseBackColor = true;
            this.grid.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.grid.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grid.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grid.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grid.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(154)))), ((int)(((byte)(91)))));
            this.grid.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grid.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grid.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grid.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grid.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grid.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.grid.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grid.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grid.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grid.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grid.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grid.Appearance.GroupButton.Options.UseBackColor = true;
            this.grid.Appearance.GroupButton.Options.UseBorderColor = true;
            this.grid.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grid.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grid.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.grid.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grid.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grid.Appearance.GroupFooter.Options.UseForeColor = true;
            this.grid.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grid.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.grid.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.grid.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grid.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grid.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grid.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grid.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grid.Appearance.GroupRow.Options.UseBackColor = true;
            this.grid.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grid.Appearance.GroupRow.Options.UseForeColor = true;
            this.grid.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grid.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(204)))), ((int)(((byte)(124)))));
            this.grid.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grid.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grid.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grid.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grid.Appearance.HeaderPanel.Options.UseFont = true;
            this.grid.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grid.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grid.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grid.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(183)))), ((int)(((byte)(125)))));
            this.grid.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grid.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grid.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grid.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grid.Appearance.HorzLine.Options.UseBackColor = true;
            this.grid.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(236)))), ((int)(((byte)(208)))));
            this.grid.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.grid.Appearance.OddRow.Options.UseBackColor = true;
            this.grid.Appearance.OddRow.Options.UseForeColor = true;
            this.grid.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(249)))));
            this.grid.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.grid.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(146)))), ((int)(((byte)(78)))));
            this.grid.Appearance.Preview.Options.UseBackColor = true;
            this.grid.Appearance.Preview.Options.UseFont = true;
            this.grid.Appearance.Preview.Options.UseForeColor = true;
            this.grid.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grid.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(248)))), ((int)(((byte)(236)))));
            this.grid.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.grid.Appearance.Row.Options.UseBackColor = true;
            this.grid.Appearance.Row.Options.UseBorderColor = true;
            this.grid.Appearance.Row.Options.UseForeColor = true;
            this.grid.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(244)))), ((int)(((byte)(232)))));
            this.grid.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.grid.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grid.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(167)))), ((int)(((byte)(103)))));
            this.grid.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grid.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.grid.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grid.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(177)))), ((int)(((byte)(94)))));
            this.grid.Appearance.VertLine.Options.UseBackColor = true;
            this.grid.GridControl = this.gridCrono;
            this.grid.Name = "grid";
            this.grid.OptionsBehavior.Editable = false;
            this.grid.OptionsMenu.EnableColumnMenu = false;
            this.grid.OptionsView.ColumnAutoWidth = false;
            this.grid.OptionsView.EnableAppearanceEvenRow = true;
            this.grid.OptionsView.EnableAppearanceOddRow = true;
            this.grid.OptionsView.RowAutoHeight = true;
            this.grid.OptionsView.ShowGroupPanel = false;
            this.grid.OptionsView.ShowViewCaption = true;
            // 
            // referencias
            // 
            this.referencias.Appearance.CardCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(213)))), ((int)(((byte)(157)))));
            this.referencias.Appearance.CardCaption.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(213)))), ((int)(((byte)(157)))));
            this.referencias.Appearance.CardCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.referencias.Appearance.CardCaption.ForeColor = System.Drawing.Color.Black;
            this.referencias.Appearance.CardCaption.Options.UseBackColor = true;
            this.referencias.Appearance.CardCaption.Options.UseBorderColor = true;
            this.referencias.Appearance.CardCaption.Options.UseFont = true;
            this.referencias.Appearance.CardCaption.Options.UseForeColor = true;
            this.referencias.Appearance.EmptySpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(233)))), ((int)(((byte)(177)))));
            this.referencias.Appearance.EmptySpace.Options.UseBackColor = true;
            this.referencias.Appearance.FieldCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(213)))), ((int)(((byte)(157)))));
            this.referencias.Appearance.FieldCaption.BackColor2 = System.Drawing.Color.GhostWhite;
            this.referencias.Appearance.FieldCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.referencias.Appearance.FieldCaption.ForeColor = System.Drawing.Color.Black;
            this.referencias.Appearance.FieldCaption.Options.UseBackColor = true;
            this.referencias.Appearance.FieldCaption.Options.UseFont = true;
            this.referencias.Appearance.FieldCaption.Options.UseForeColor = true;
            this.referencias.Appearance.FieldValue.BackColor = System.Drawing.Color.White;
            this.referencias.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 10F);
            this.referencias.Appearance.FieldValue.ForeColor = System.Drawing.Color.Black;
            this.referencias.Appearance.FieldValue.Options.UseBackColor = true;
            this.referencias.Appearance.FieldValue.Options.UseFont = true;
            this.referencias.Appearance.FieldValue.Options.UseForeColor = true;
            this.referencias.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.referencias.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(90)))), ((int)(((byte)(156)))));
            this.referencias.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.referencias.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.referencias.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.referencias.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.referencias.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.referencias.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.referencias.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(0)))), ((int)(((byte)(66)))));
            this.referencias.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.referencias.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
            this.referencias.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.referencias.Appearance.FilterPanel.Options.UseBackColor = true;
            this.referencias.Appearance.FilterPanel.Options.UseForeColor = true;
            this.referencias.Appearance.FocusedCardCaption.BackColor = System.Drawing.Color.Purple;
            this.referencias.Appearance.FocusedCardCaption.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(50)))), ((int)(((byte)(178)))));
            this.referencias.Appearance.FocusedCardCaption.BorderColor = System.Drawing.Color.Purple;
            this.referencias.Appearance.FocusedCardCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.referencias.Appearance.FocusedCardCaption.ForeColor = System.Drawing.Color.White;
            this.referencias.Appearance.FocusedCardCaption.Options.UseBackColor = true;
            this.referencias.Appearance.FocusedCardCaption.Options.UseBorderColor = true;
            this.referencias.Appearance.FocusedCardCaption.Options.UseFont = true;
            this.referencias.Appearance.FocusedCardCaption.Options.UseForeColor = true;
            this.referencias.Appearance.HideSelectionCardCaption.BackColor = System.Drawing.Color.Gray;
            this.referencias.Appearance.HideSelectionCardCaption.BorderColor = System.Drawing.Color.Gray;
            this.referencias.Appearance.HideSelectionCardCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.referencias.Appearance.HideSelectionCardCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.referencias.Appearance.HideSelectionCardCaption.Options.UseBackColor = true;
            this.referencias.Appearance.HideSelectionCardCaption.Options.UseBorderColor = true;
            this.referencias.Appearance.HideSelectionCardCaption.Options.UseFont = true;
            this.referencias.Appearance.HideSelectionCardCaption.Options.UseForeColor = true;
            this.referencias.Appearance.SelectedCardCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(10)))), ((int)(((byte)(138)))));
            this.referencias.Appearance.SelectedCardCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.referencias.Appearance.SelectedCardCaption.ForeColor = System.Drawing.Color.White;
            this.referencias.Appearance.SelectedCardCaption.Options.UseBackColor = true;
            this.referencias.Appearance.SelectedCardCaption.Options.UseFont = true;
            this.referencias.Appearance.SelectedCardCaption.Options.UseForeColor = true;
            this.referencias.Appearance.SeparatorLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(213)))), ((int)(((byte)(157)))));
            this.referencias.Appearance.SeparatorLine.Options.UseBackColor = true;
            this.referencias.FocusedCardTopFieldIndex = 0;
            this.referencias.GridControl = this.gridCrono;
            this.referencias.Name = "referencias";
            this.referencias.OptionsBehavior.Editable = false;
            this.referencias.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            // 
            // gridDetalle
            // 
            this.gridDetalle.GridControl = this.gridCrono;
            this.gridDetalle.Name = "gridDetalle";
            this.gridDetalle.OptionsView.ShowGroupPanel = false;
            // 
            // FrmDetallesCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 397);
            this.Controls.Add(this.gpoContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDetallesCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCronograma";
            this.Shown += new System.EventHandler(this.frmCronograma_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).EndInit();
            this.gpoContenedor.ResumeLayout(false);
            this.gpoContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFinanciera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFinanciera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.referencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpoContenedor;
        private DevExpress.XtraGrid.GridControl gridCrono;
        private DevExpress.XtraGrid.Views.Grid.GridView grid;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Views.Card.CardView referencias;
        private DevExpress.XtraGrid.Views.Grid.GridView gridDetalle;
        private DevExpress.XtraGrid.GridControl gridFinanciera;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFinanciera;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}