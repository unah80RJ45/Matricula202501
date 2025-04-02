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
    public partial class frmSeccionLista : Form
    {
        SqlDataAdapter adpSeccion;
        DataTable tabSeccion;
        SqlConnection conexion;

        public frmSeccionLista(SqlConnection cnx)
        {
            InitializeComponent();

            conexion = cnx;
            adpSeccion = new SqlDataAdapter("spSeccionSelect 0", cnx);
        }

        public frmSeccionLista()
        {
            InitializeComponent();
        }

        private void frmSeccionLista_Load(object sender, EventArgs e)
        {
            try
            {
                tabSeccion = new DataTable();
                dataGridView1.DataSource = tabSeccion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdAdicionar_Click(object sender, EventArgs e)
        {
            frmSeccion frm = new frmSeccion(conexion, -1);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
    }
}
