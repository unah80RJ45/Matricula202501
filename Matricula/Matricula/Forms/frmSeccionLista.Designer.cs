namespace Matricula.Forms
{
    partial class frmSeccionLista
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
            this.cmdAdicionar = new System.Windows.Forms.Button();
            this.cmdModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 375);
            this.dataGridView1.TabIndex = 0;
            // 
            // cmdAdicionar
            // 
            this.cmdAdicionar.Location = new System.Drawing.Point(12, 397);
            this.cmdAdicionar.Name = "cmdAdicionar";
            this.cmdAdicionar.Size = new System.Drawing.Size(173, 57);
            this.cmdAdicionar.TabIndex = 1;
            this.cmdAdicionar.Text = "Adicionar";
            this.cmdAdicionar.UseVisualStyleBackColor = true;
            this.cmdAdicionar.Click += new System.EventHandler(this.cmdAdicionar_Click);
            // 
            // cmdModificar
            // 
            this.cmdModificar.Location = new System.Drawing.Point(186, 397);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(173, 57);
            this.cmdModificar.TabIndex = 2;
            this.cmdModificar.Text = "Modificar";
            this.cmdModificar.UseVisualStyleBackColor = true;
            // 
            // frmSeccionLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 466);
            this.Controls.Add(this.cmdModificar);
            this.Controls.Add(this.cmdAdicionar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmSeccionLista";
            this.Text = "frmSeccionLista";
            this.Load += new System.EventHandler(this.frmSeccionLista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cmdAdicionar;
        private System.Windows.Forms.Button cmdModificar;
    }
}