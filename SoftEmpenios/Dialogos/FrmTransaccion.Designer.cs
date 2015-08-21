namespace SoftEmpenios.Dialogos
{
    partial class FrmTransaccion
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
            this.txtConcepto = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.botonGuardar = new SoftEmpenios.Controles.BotonCambiante();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtCantidad = new SoftEmpenios.Controles.TextEditSelected();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCLave = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).BeginInit();
            this.gpoContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcepto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCLave.Properties)).BeginInit();
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
            this.gpoContenedor.Controls.Add(this.txtConcepto);
            this.gpoContenedor.Controls.Add(this.labelControl2);
            this.gpoContenedor.Controls.Add(this.cboTipo);
            this.gpoContenedor.Controls.Add(this.botonGuardar);
            this.gpoContenedor.Controls.Add(this.labelControl9);
            this.gpoContenedor.Controls.Add(this.txtCantidad);
            this.gpoContenedor.Controls.Add(this.labelControl1);
            this.gpoContenedor.Controls.Add(this.txtCLave);
            this.gpoContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpoContenedor.Location = new System.Drawing.Point(0, 0);
            this.gpoContenedor.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gpoContenedor.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gpoContenedor.Name = "gpoContenedor";
            this.gpoContenedor.Size = new System.Drawing.Size(575, 246);
            this.gpoContenedor.TabIndex = 0;
            this.gpoContenedor.Text = "Depositos y Retiros";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(113, 142);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConcepto.Size = new System.Drawing.Size(367, 96);
            this.txtConcepto.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl2.Location = new System.Drawing.Point(68, 113);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 18);
            this.labelControl2.TabIndex = 126;
            this.labelControl2.Text = "Tipo:";
            // 
            // cboTipo
            // 
            this.cboTipo.Location = new System.Drawing.Point(113, 110);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.cboTipo.Properties.Appearance.Options.UseFont = true;
            this.cboTipo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipo.Properties.Items.AddRange(new object[] {
            "Deposito",
            "Retiro"});
            this.cboTipo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTipo.Size = new System.Drawing.Size(162, 26);
            this.cboTipo.TabIndex = 1;
            // 
            // botonGuardar
            // 
            this.botonGuardar.BackColor = System.Drawing.Color.Transparent;
            this.botonGuardar.EtiquetaBoton = "Comprar e Imprimir Ticket";
            this.botonGuardar.FlatAppearance.BorderSize = 0;
            this.botonGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.botonGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.botonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonGuardar.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonGuardar.Image = global::SoftEmpenios.Properties.Resources.Printer;
            this.botonGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.botonGuardar.imgDisable = global::SoftEmpenios.Properties.Resources.Printerdiseable;
            this.botonGuardar.imgencima = global::SoftEmpenios.Properties.Resources.Printerover;
            this.botonGuardar.imgnormal = global::SoftEmpenios.Properties.Resources.Printer;
            this.botonGuardar.imgPrecionado = global::SoftEmpenios.Properties.Resources.PrinterPush;
            this.botonGuardar.Location = new System.Drawing.Point(486, 163);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(84, 70);
            this.botonGuardar.TabIndex = 3;
            this.botonGuardar.Text = "Imprimir";
            this.botonGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.botonGuardar.UseVisualStyleBackColor = false;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F);
            this.labelControl9.Location = new System.Drawing.Point(12, 76);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(95, 23);
            this.labelControl9.TabIndex = 123;
            this.labelControl9.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCantidad.Location = new System.Drawing.Point(113, 72);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.txtCantidad.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCantidad.Properties.Appearance.Options.UseFont = true;
            this.txtCantidad.Properties.Appearance.Options.UseForeColor = true;
            this.txtCantidad.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCantidad.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtCantidad.Properties.DisplayFormat.FormatString = "$ ##,##0.00";
            this.txtCantidad.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCantidad.Properties.Mask.EditMask = "c2";
            this.txtCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCantidad.Size = new System.Drawing.Size(162, 32);
            this.txtCantidad.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.labelControl1.Location = new System.Drawing.Point(57, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 18);
            this.labelControl1.TabIndex = 121;
            this.labelControl1.Text = "Clave:";
            // 
            // txtCLave
            // 
            this.txtCLave.EditValue = 0;
            this.txtCLave.Location = new System.Drawing.Point(113, 40);
            this.txtCLave.Name = "txtCLave";
            this.txtCLave.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtCLave.Properties.Appearance.Options.UseFont = true;
            this.txtCLave.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCLave.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCLave.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtCLave.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCLave.Properties.ReadOnly = true;
            this.txtCLave.Size = new System.Drawing.Size(105, 26);
            this.txtCLave.TabIndex = 4;
            // 
            // FrmTransaccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 246);
            this.Controls.Add(this.gpoContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmTransaccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.gpoContenedor)).EndInit();
            this.gpoContenedor.ResumeLayout(false);
            this.gpoContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcepto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCLave.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpoContenedor;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipo;
        private Controles.BotonCambiante botonGuardar;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private Controles.TextEditSelected txtCantidad;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtCLave;
        private DevExpress.XtraEditors.MemoEdit txtConcepto;
    }
}