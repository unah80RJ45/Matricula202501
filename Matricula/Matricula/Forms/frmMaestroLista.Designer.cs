namespace Matricula.Forms
{
    partial class frmMaestroLista
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbCampos = new System.Windows.Forms.ComboBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.cmdAdicionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 38);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(511, 230);
            this.dataGridView1.TabIndex = 0;
            // 
            // cmbCampos
            // 
            this.cmbCampos.FormattingEnabled = true;
            this.cmbCampos.Location = new System.Drawing.Point(14, 8);
            this.cmbCampos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbCampos.Name = "cmbCampos";
            this.cmbCampos.Size = new System.Drawing.Size(155, 21);
            this.cmbCampos.TabIndex = 1;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(181, 9);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(147, 20);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // cmdModificar
            // 
            this.cmdModificar.Location = new System.Drawing.Point(14, 279);
            this.cmdModificar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(131, 30);
            this.cmdModificar.TabIndex = 3;
            this.cmdModificar.Text = "Modificar";
            this.cmdModificar.UseVisualStyleBackColor = true;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // cmdAdicionar
            // 
            this.cmdAdicionar.Location = new System.Drawing.Point(149, 279);
            this.cmdAdicionar.Margin = new System.Windows.Forms.Padding(2);
            this.cmdAdicionar.Name = "cmdAdicionar";
            this.cmdAdicionar.Size = new System.Drawing.Size(131, 30);
            this.cmdAdicionar.TabIndex = 4;
            this.cmdAdicionar.Text = "Adicionar";
            this.cmdAdicionar.UseVisualStyleBackColor = true;
            this.cmdAdicionar.Click += new System.EventHandler(this.cmdAdicionar_Click);
            // 
            // frmMaestroLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 317);
            this.Controls.Add(this.cmdAdicionar);
            this.Controls.Add(this.cmdModificar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.cmbCampos);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMaestroLista";
            this.Text = "frmMaestroLista";
            this.Load += new System.EventHandler(this.frmMaestroLista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbCampos;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button cmdModificar;
        private System.Windows.Forms.Button cmdAdicionar;
    }
}