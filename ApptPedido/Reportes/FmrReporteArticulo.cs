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
    public partial class FmrReporteArticulo : Form
    {
        public FmrReporteArticulo()
        {
            InitializeComponent();
        }

        private void FmrReporteArticulo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_articulo' Puede moverla o quitarla según sea necesario.
            this.spmostrar_articuloTableAdapter.Fill(this.dsPrincipal.spmostrar_articulo);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
