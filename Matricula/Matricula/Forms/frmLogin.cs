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
    public partial class frmLogin : Form
    {
        private SqlConnection cnx;
        private bool conectado;

        public SqlConnection Conexion
        {
            get
            {
                return cnx;
            }
        }
        public bool isConectado
        {
            get
            {
                return conectado;
            }
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            conectado = false;
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                String url = "Server=" + txtServidor.Text + "; DataBase=" +
                    txtBase.Text + "; UID = " + txtUsuario.Text + "; PWD = " +
                    txtPassword.Text;

                cnx = new SqlConnection(url);
                cnx.Open();
                conectado = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
