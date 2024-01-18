using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ApptPedido.Consultas
{
    public partial class FmrConsultaStock_Articulo : Form
    {
        public FmrConsultaStock_Articulo()
        {
            InitializeComponent();
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
           
        }

        
        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulo.Stock_Articulos();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FmrConsultaStock_Articulo_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
