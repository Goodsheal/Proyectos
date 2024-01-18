using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ApptPedido
{
    public partial class FmrLogin : Form
    {
        public FmrLogin()
        {
            InitializeComponent();
            LblHora.Text = DateTime.Now.ToString();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            LblHora.Text = DateTime.Now.ToString();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            DataTable Datos = CapaNegocio.NTrabajador.Login(this.TxtUsuario.Text, this.TxtPassword.Text);
            //Evaluar si existe el Usuario
            if (Datos.Rows.Count == 0)
            {
                MessageBox.Show("NO Tiene Acceso al Sistema", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FmrPrincipal Fmr = new FmrPrincipal();
                Fmr.Idtrabajador = Datos.Rows[0][0].ToString();
                Fmr.Apellidos = Datos.Rows[0][1].ToString();
                Fmr.Nombre = Datos.Rows[0][2].ToString();
                Fmr.Acceso = Datos.Rows[0][3].ToString();

                Fmr.Show();
                this.Hide();

            }
        }

        private void FmrLogin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
