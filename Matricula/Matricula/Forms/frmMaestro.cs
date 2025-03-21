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
    public partial class frmMaestro : Form
    {
        SqlConnection cnx;
        SqlDataAdapter adpMaestro;
        DataTable tabMaestro;

        public frmMaestro()
        {
            InitializeComponent();

            Conexion();
        }

        private void Conexion()
        {
            String url = "Server=3.128.144.165;Database=Matricula202501;User Id=db2;Password=123;";
            cnx = new SqlConnection(url);
            adpMaestro = new SqlDataAdapter();

            adpMaestro.SelectCommand = new SqlCommand("spMaestroSelect", cnx);
            adpMaestro.SelectCommand.CommandType = CommandType.StoredProcedure;

            adpMaestro.InsertCommand = new SqlCommand("spMaestroInsert", cnx);
            adpMaestro.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpMaestro.InsertCommand.Parameters.Add("@mae", SqlDbType.Int, 4, "MaestroID");
            adpMaestro.InsertCommand.Parameters.Add("@nom", SqlDbType.VarChar, 50, "Nombre");
            adpMaestro.InsertCommand.Parameters.Add("@sex", SqlDbType.VarChar, 1, "Sexo");
            adpMaestro.InsertCommand.Parameters.Add("@civ", SqlDbType.VarChar, 1, "civil");
            adpMaestro.InsertCommand.Parameters.Add("@tel", SqlDbType.VarChar, 20, "telefono");
            adpMaestro.InsertCommand.Parameters.Add("@dir", SqlDbType.VarChar, 100, "Direccion");
            adpMaestro.InsertCommand.Parameters.Add("@pro", SqlDbType.Int, 4, "ProfesionID");

            adpMaestro.UpdateCommand = new SqlCommand("spMaestroUpdate", cnx);
            adpMaestro.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpMaestro.UpdateCommand.Parameters.Add("@mae", SqlDbType.Int, 4, "MaestroID");
            adpMaestro.UpdateCommand.Parameters.Add("@nom", SqlDbType.VarChar, 50, "Nombre");
            adpMaestro.UpdateCommand.Parameters.Add("@sex", SqlDbType.VarChar, 1, "Sexo");
            adpMaestro.UpdateCommand.Parameters.Add("@civ", SqlDbType.VarChar, 1, "civil");
            adpMaestro.UpdateCommand.Parameters.Add("@tel", SqlDbType.VarChar, 20, "telefono");
            adpMaestro.UpdateCommand.Parameters.Add("@dir", SqlDbType.VarChar, 100, "Direccion");
            adpMaestro.UpdateCommand.Parameters.Add("@pro", SqlDbType.Int, 4, "ProfesionID");

            adpMaestro.DeleteCommand = new SqlCommand();
            adpMaestro.DeleteCommand.CommandText = "spMaestroDelete";
            adpMaestro.DeleteCommand.CommandType = CommandType.StoredProcedure;
            adpMaestro.DeleteCommand.Connection = cnx;
            adpMaestro.DeleteCommand.Parameters.Add("@mae", SqlDbType.Int, 4, "MaestroID");
        }

        private void frmMaestro_Load(object sender, EventArgs e)
        {
            tabMaestro = new DataTable();
            adpMaestro.Fill(tabMaestro);
            dataGridView1.DataSource = tabMaestro;
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                adpMaestro.Update(tabMaestro);
                MessageBox.Show("Datos salvados satifactoriamente", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
