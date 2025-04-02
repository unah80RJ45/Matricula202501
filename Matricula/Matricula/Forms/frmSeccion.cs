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
    public partial class frmSeccion : Form
    {
        SqlDataAdapter adpTablas;
        DataSet dsTablas;

        public frmSeccion(SqlConnection cnx, int seccion)
        {
            InitializeComponent();

            adpTablas = new SqlDataAdapter("spSeccionSelect 0; exec spClaseSelect 0; exec spMateriaSelect ''; exec spMaestroSelect; exec spCarreraSelect 0", cnx);
        }
        public frmSeccion()
        {
            InitializeComponent();
        }
        private void initCombo(ComboBox cmb, DataTable tabla, string nombre, string value)
        {
            cmb.DataSource = tabla;
            cmb.DisplayMember = nombre;
            cmb.ValueMember = value;
        }
        private void frmSeccion_Load(object sender, EventArgs e)
        {
            try
            {
                dsTablas = new DataSet();
                adpTablas.Fill(dsTablas);

                dsTablas.Tables[1].TableName = "Clase";

                dataGridView1.DataSource = dsTablas.Tables["Clase"];
                initCombo(cmbCarrera, dsTablas.Tables[4], "Nombre", "CarreraID");
                initCombo(cmbMaestro, dsTablas.Tables[3], "Nombre", "MaestroID");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
