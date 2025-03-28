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
    public partial class frmMaestroDetalle : Form
    {
        SqlDataAdapter adpMaestro;
        DataTable tabMaestro;

        public frmMaestroDetalle(SqlConnection cnx, int maestro)
        {
            InitializeComponent();

            adpMaestro = new SqlDataAdapter("select * from vMaestro where MaestroID = " + maestro, cnx);

        }         
        public frmMaestroDetalle()
        {
            InitializeComponent();
        }

        private void frmMaestroDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                tabMaestro = new DataTable();
                adpMaestro.Fill(tabMaestro);

                txtCodigo.Text = tabMaestro.Rows[0]["maestroid"].ToString();
                txtNombre.Text = tabMaestro.Rows[0]["nombre"].ToString();
                txtDireccion.Text = tabMaestro.Rows[0]["direccion"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
