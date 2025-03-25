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
        SqlDataAdapter adpMaestro; SqlDataAdapter adpProfesion;
        DataTable tabMaestro; DataTable tabProfesion; DataTable tabSexo; 

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

            adpMaestro.DeleteCommand = new SqlCommand();
            adpMaestro.DeleteCommand.CommandText = "spMaestroDelete";
            adpMaestro.DeleteCommand.CommandType = CommandType.StoredProcedure;
            adpMaestro.DeleteCommand.Connection = cnx;
            adpMaestro.DeleteCommand.Parameters.Add("@mae", SqlDbType.Int, 4, "MaestroID");
        }

        private void frmMaestro_Load(object sender, EventArgs e)
        {
            // cargar el datagridview
            tabMaestro = new DataTable();
            adpMaestro.Fill(tabMaestro);
            dataGridView1.DataSource = tabMaestro;

            // cargar combox dentro del datagridview
            adpProfesion = new SqlDataAdapter("spSelectProfesion 0", cnx);
            tabProfesion = new DataTable();
            adpProfesion.Fill(tabProfesion);
            DataGridViewComboBoxColumn cmbProfesion = new DataGridViewComboBoxColumn();
            cmbProfesion.DataSource = tabProfesion;
            cmbProfesion.DisplayMember = "Nombre";
            cmbProfesion.ValueMember = "ProfesionID";
            cmbProfesion.DataPropertyName = "ProfesionID";
            cmbProfesion.HeaderText = "Profesion";
            cmbProfesion.DisplayStyleForCurrentCellOnly = true;
            dataGridView1.Columns.Add(cmbProfesion);
            
            // Cargar Estado Civil
            DataTable tabCivil = new DataTable();
            tabCivil.Columns.Add("Codigo"); tabCivil.Columns.Add("Nombre");
            DataRow nRow = tabCivil.NewRow();
            nRow[0] = "C"; nRow[1] = "Casado";
            //DataRow sRow = tabCivil.NewRow();
            //nRow[0] = "S"; nRow[1] = "Soltero";

            tabCivil.Rows.Add(nRow);
            //tabCivil.Rows.Add(sRow);

            DataGridViewComboBoxColumn cmdCivil = new DataGridViewComboBoxColumn();
            cmdCivil.DataSource = tabCivil;
            cmdCivil.DisplayMember = "Nombre";
            cmdCivil.ValueMember = "Codigo";
            cmdCivil.DataPropertyName = "Civil";
            cmdCivil.HeaderText = "EstadoCivil";
            cmdCivil.DisplayStyleForCurrentCellOnly = true;
            dataGridView1.Columns.Add(cmdCivil);

            dataGridView1.Columns["ProfesionID"].Visible = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
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
