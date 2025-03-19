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

namespace Matricula
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                String url = "Server=3.128.144.165;Database=Matricula202501;User Id=db2;Password=123;";
                SqlConnection cnx = new SqlConnection(url);
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "spInsertarProfesion";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                cmd.Parameters.AddWithValue("@pro", txtCodigo.Text);
                cmd.Parameters.AddWithValue("@nom", txtNombre.Text);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();
                txtCodigo.Clear();
                txtNombre.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String url = "Server=3.128.144.165;Database=Matricula202501;User Id=db2;Password=123;";
                SqlConnection cnx = new SqlConnection(url);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader data;

                cmd.CommandText = "spSelectProfesion";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
                cmd.Parameters.AddWithValue("@pro", txtCodigo.Text);

                cnx.Open();
                data = cmd.ExecuteReader();
                data.Read();
                txtNombre.Text = data["nombre"].ToString();
                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
