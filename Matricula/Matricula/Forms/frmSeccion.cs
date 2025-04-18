﻿using System;
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
        SqlDataAdapter adpSeccion;
        SqlDataAdapter adpClase;
        SqlConnection conexion;
        SqlParameter prmSeccion;

        public frmSeccion(SqlConnection cnx, int seccion)
        {
            String spSeccion = "spSeccionSelect " + seccion;
            String spClase = "exec spClaseSelect " + seccion;
            conexion = cnx;

            InitializeComponent();

            adpTablas = new SqlDataAdapter(spSeccion + ";" + spClase + "; exec spMateriaSelect ''; exec spMaestroSelect; exec spCarreraSelect 0", cnx);

            adpSeccion = new SqlDataAdapter();
            adpSeccion.InsertCommand = new SqlCommand("spSeccionInsert", cnx);
            adpSeccion.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpSeccion.InsertCommand.Parameters.Add("@seccion", SqlDbType.Int, 4, "SeccionID");
            adpSeccion.InsertCommand.Parameters.Add("@materia", SqlDbType.VarChar, 20, "MateriaID");
            adpSeccion.InsertCommand.Parameters.Add("@maestro", SqlDbType.Int, 4, "MaestroID");
            adpSeccion.InsertCommand.Parameters.Add("@carrera", SqlDbType.Int, 4, "CarreraID");
            adpSeccion.InsertCommand.Parameters.Add("@aula", SqlDbType.Int, 4, "aula");
            adpSeccion.InsertCommand.Parameters.Add("@horario", SqlDbType.VarChar , 20, "Aula");

            prmSeccion = new SqlParameter("@seccion", 0);

            adpClase = new SqlDataAdapter();
            adpClase.InsertCommand = new SqlCommand("spClaseInsert", cnx);
            adpClase.InsertCommand.CommandType = CommandType.StoredProcedure;
//            adpClase.InsertCommand.Parameters.Add("@seccion", SqlDbType.Int, 4, "SeccionID");
            adpClase.InsertCommand.Parameters.Add(prmSeccion);
            adpClase.InsertCommand.Parameters.Add("@alumno", SqlDbType.Int, 4, "AlumnoID");
            adpClase.InsertCommand.Parameters.Add("@nota", SqlDbType.Int, 4, "Nota");

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
            cmb.SelectedIndex = -1;
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void frmSeccion_Load(object sender, EventArgs e)
        {
            try
            {              
                dsTablas = new DataSet();
                adpTablas.Fill(dsTablas);

                dsTablas.Tables[0].TableName = "Seccion";
                dsTablas.Tables[1].TableName = "Clase";
                dsTablas.Tables[2].TableName = "Materia";
                dsTablas.Tables[3].TableName = "Maestro";
                dsTablas.Tables[4].TableName = "Carrera";

                dataGridView1.DataSource = dsTablas.Tables["Clase"];
                dataGridView1.Columns["seccionid"].Visible = false;
                dataGridView1.Columns["nombre"].ReadOnly = true;
                dataGridView1.Columns["nombre"].Width = 250;

                initCombo(cmbCarrera, dsTablas.Tables[4], "Nombre", "CarreraID");
                initCombo(cmbMaestro, dsTablas.Tables[3], "Nombre", "MaestroID");
                initCombo(cmbMateria, dsTablas.Tables["Materia"], "Nombre", "MateriaID");

                if (dsTablas.Tables["Seccion"].Rows.Count == 0)
                    dsTablas.Tables["Seccion"].Rows.Add();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool setError(Control obj, String Mensaje)
        {
            bool ret = false;

            errorProvider1.SetError(obj, Mensaje);

            return ret;
        }
        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                bool noError = true;

                errorProvider1.Clear();
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

                if (txtCodigo.Text.Length == 0) noError = setError(txtCodigo, "Falta el codigo");
                if (cmbCarrera.SelectedIndex < 0) noError = setError(cmbCarrera, "Debe seleccionar la carrera");
                if (cmbMaestro.SelectedIndex < 0) noError = setError(cmbMaestro, "Debe seleccionar el maestro");
                if (cmbMateria.SelectedIndex < 0) noError = setError(cmbMateria, "Debe seleccionar la materia");
                if (txtHorario.Text.Length == 0) noError = setError(txtHorario, "Falta el horario");
                if (txtAula.Text.Length == 0) noError = setError(txtHorario, "Falta el aula");
                if (dsTablas.Tables["Clase"].DefaultView.Count == 0) noError = setError(dataGridView1, "No ha especificado alumnos");

                if (!noError)
                    return;

                dsTablas.Tables["Seccion"].Rows[0]["SeccionID"] = txtCodigo.Text;
                dsTablas.Tables["Seccion"].Rows[0]["MateriaID"] = cmbMateria.SelectedValue;
                dsTablas.Tables["Seccion"].Rows[0]["MaestroID"] = cmbMaestro.SelectedValue;
                dsTablas.Tables["Seccion"].Rows[0]["CarreraID"] = cmbCarrera.SelectedValue;
                dsTablas.Tables["Seccion"].Rows[0]["Horario"] = txtHorario.Text;
                dsTablas.Tables["Seccion"].Rows[0]["Aula"] = txtAula.Text;

                prmSeccion.Value = txtCodigo.Text;
                adpSeccion.Update(dsTablas.Tables["Seccion"]);
                adpClase.Update(dsTablas.Tables["Clase"]);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            String col = dataGridView1.Columns[e.ColumnIndex].Name.ToLower();

            if(col == "alumnoid")
            {
                DataTable tabAlumno = new DataTable();
                SqlDataAdapter adpAlumno = new SqlDataAdapter("spAlumnoSelect " + e.FormattedValue, conexion);
                adpAlumno.Fill(tabAlumno);

                if(tabAlumno.Rows.Count == 0)
                {
                    MessageBox.Show("El alumno no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                else
                {
                    dsTablas.Tables["Clase"].DefaultView[e.RowIndex]["nombre"] = tabAlumno.Rows[0]["nombre"];
                    dataGridView1.Refresh();
                }
            }
        }
    }
}
