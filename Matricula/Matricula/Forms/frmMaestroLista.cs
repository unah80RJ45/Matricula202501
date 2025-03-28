using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Matricula.Forms
{
    public partial class frmMaestroLista : Form
    {
        private SqlConnection conexion;
        private SqlDataAdapter adpMaestro;
        private DataTable tabMaestro;

        public frmMaestroLista(SqlConnection cnx)
        {
            InitializeComponent();

            conexion = cnx;

            adpMaestro = new SqlDataAdapter("select * from vMaestro", cnx);
        }
        public frmMaestroLista()
        {
            InitializeComponent();
        }

        private void frmMaestroLista_Load(object sender, EventArgs e)
        {
            try
            {
                tabMaestro = new DataTable();
                adpMaestro.Fill(tabMaestro);
                dataGridView1.DataSource = tabMaestro;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns["sexo"].Visible = false;
                dataGridView1.Columns["civil"].Visible = false;
                dataGridView1.Columns["profesionid"].Visible = false;

                cmbCampos.Items.Add("Nombre");
                cmbCampos.Items.Add("Sexo");
                cmbCampos.Items.Add("Civil");
                cmbCampos.Items.Add("Direccion");
                cmbCampos.Items.Add("nProfesion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
                tabMaestro.DefaultView.RowFilter = "";
            else
            {
                if(cmbCampos.SelectedIndex >= 0)
                {
                    String busca = cmbCampos.Text + " like '%" + txtBuscar.Text + "%'";
                    tabMaestro.DefaultView.RowFilter = busca;
                }
            }
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            int maestro = (int) tabMaestro.Rows[dataGridView1.CurrentRow.Index]["maestroid"];
            frmMaestroDetalle frm = new frmMaestroDetalle(conexion, maestro);
            frm.ShowDialog();
        }
    }
}
