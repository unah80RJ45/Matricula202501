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

            adpMaestro.InsertCommand = new SqlCommand("spMaestroInsert", cnx);
            adpMaestro.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpMaestro.InsertCommand.Parameters.Add("@mae", SqlDbType.Int, 4, "MaestroID");
            adpMaestro.InsertCommand.Parameters.Add("@nom", SqlDbType.VarChar, 50, "Nombre");
            adpMaestro.InsertCommand.Parameters.Add("@sex", SqlDbType.VarChar, 1, "Sexo");
            adpMaestro.InsertCommand.Parameters.Add("@civ", SqlDbType.VarChar, 1, "civil");
            adpMaestro.InsertCommand.Parameters.Add("@tel", SqlDbType.VarChar, 20, "telefono");
            adpMaestro.InsertCommand.Parameters.Add("@dir", SqlDbType.VarChar, 100, "Direccion");
            adpMaestro.InsertCommand.Parameters.Add("@pro", SqlDbType.Int, 4, "ProfesionID");
            adpMaestro.InsertCommand.Parameters["@mae"].Direction = ParameterDirection.InputOutput;

            adpMaestro.UpdateCommand = new SqlCommand("spMaestroUpdate", cnx);
            adpMaestro.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpMaestro.UpdateCommand.Parameters.Add("@mae", SqlDbType.Int, 4, "MaestroID");
            adpMaestro.UpdateCommand.Parameters.Add("@nom", SqlDbType.VarChar, 50, "Nombre");
            adpMaestro.UpdateCommand.Parameters.Add("@sex", SqlDbType.VarChar, 1, "Sexo");
            adpMaestro.UpdateCommand.Parameters.Add("@civ", SqlDbType.VarChar, 1, "civil");
            adpMaestro.UpdateCommand.Parameters.Add("@tel", SqlDbType.VarChar, 20, "telefono");
            adpMaestro.UpdateCommand.Parameters.Add("@dir", SqlDbType.VarChar, 100, "Direccion");
            adpMaestro.UpdateCommand.Parameters.Add("@pro", SqlDbType.Int, 4, "ProfesionID");

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

                if(tabMaestro.Rows.Count == 0)
                {
                    tabMaestro.Rows.Add();
                }
                else
                {
                    txtCodigo.Text = tabMaestro.Rows[0]["maestroid"].ToString();
                    txtNombre.Text = tabMaestro.Rows[0]["nombre"].ToString();
                    txtDireccion.Text = tabMaestro.Rows[0]["direccion"].ToString();
                    txtSexo.Text = tabMaestro.Rows[0]["sexo"].ToString();
                    txtCivil.Text = tabMaestro.Rows[0]["civil"].ToString();
                    txtTelefono.Text = tabMaestro.Rows[0]["telefono"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                bool errores = false;
         
                if(txtNombre.Text.Length == 0)
                {
                    errorProvider1.SetError(txtNombre, "Falta ingresar el nombre");
                    errores = true;
                }

                try
                {
                    int codigo = Int16.Parse(txtCodigo.Text);
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(txtCodigo, "El codigo debe ser numerico");
                    errores = true;
                }

                if (errores)
                    return;

                tabMaestro.Rows[0]["nombre"] = txtNombre.Text;
                tabMaestro.Rows[0]["direccion"] = txtDireccion.Text;
                tabMaestro.Rows[0]["sexo"] = txtSexo.Text;
                tabMaestro.Rows[0]["civil"] = txtCivil.Text;
                tabMaestro.Rows[0]["telefono"] = txtTelefono.Text;

                adpMaestro.Update(tabMaestro);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
