using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ApptPedidos;

namespace ApptPedido
{
    public partial class FmrPrincipal : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
       

        public string Idtrabajador = "";
        public string Apellidos = "";
        public string Nombre = "";
        public string Acceso = "";


        public FmrPrincipal()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 68);
            panelMenu.Controls.Add(leftBorderBtn);

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;





        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(249, 118, 176);
            public static Color color7 = Color.FromArgb(95, 77, 221);
            public static Color color8 = Color.FromArgb(172, 126, 241);





        }



        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)

            {
                DisableButton();

                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleCenter;


                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                IconoFormularioActual.IconChar = currentBtn.IconChar;
                IconoFormularioActual.IconColor = color;

            }









        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(0, 0, 64);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;


            }









        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(FmrArticulo.GetInstancia());


        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FmrCategoria());

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FmrClientes());


        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(FmrIngreso.GetInstancia());
            FmrIngreso frm = FmrIngreso.GetInstancia();
            frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);


        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new FmrPresentacion());

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            IconoFormularioActual.IconChar = currentBtn.IconChar;
            IconoFormularioActual.IconColor = Color.MediumPurple;
            TituloDeFormulario.Text = "Inicio";

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Reset();
        }



        private void OpenChildForm(Form childForm) 
        {

           
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock= DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            TituloDeFormulario.Text = childForm.Text;




        }

        private void GestionUsuario()
        {
            //COntrolar los accesos
            if (Acceso == "Administrador")
            {
                this.iconButton1.Enabled = true;
                this.iconButton2.Enabled = true;
                this.iconButton3.Enabled = true;
                this.iconButton4.Enabled = true;
                this.iconButton5.Enabled = true;
                this.iconButton6.Enabled = true;
                this.iconButton7.Enabled = true;
                

            }
            else if (Acceso == "Vendedor")
            {
                this.iconButton2.Enabled = false;
                this.iconButton3.Enabled = false;
                this.iconButton4.Enabled = false;
                this.iconButton5.Enabled = false;
                this.iconButton6.Enabled = false;
                this.iconButton7.Enabled = false;
                this.iconButton8.Enabled = false;





            }
            else if (Acceso == "Almacenero")
            {
                this.iconButton3.Enabled = true;
               

            }
            else
            {
                this.iconButton1.Enabled = false;
                this.iconButton2.Enabled = false;
                this.iconButton3.Enabled = false;
                this.iconButton4.Enabled = false;
                

            }
        }

        private void FmrPrincipal_Load(object sender, EventArgs e)
        {
            GestionUsuario();

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FmrProveedor());
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);
            OpenChildForm(new FmrTrabajador());
        }

        private void TituloDeFormulario_Click(object sender, EventArgs e)
        {

        }

        private void IconoFormularioActual_Click(object sender, EventArgs e)
        {

        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(FmrVenta.GetInstancia());
            FmrVenta frm = FmrVenta.GetInstancia();
            frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
