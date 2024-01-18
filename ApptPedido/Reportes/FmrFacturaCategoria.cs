using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApptPedido.Reportes
{
    public partial class FmrFacturaCategoria : Form
    {
        public FmrFacturaCategoria()
        {
            InitializeComponent();
        }

        private void FmrFacturaCategoria_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_categoria' Puede moverla o quitarla según sea necesario.
            this.spmostrar_categoriaTableAdapter.Fill(this.dsPrincipal.spmostrar_categoria);
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_categoria' Puede moverla o quitarla según sea necesario.
            this.spmostrar_categoriaTableAdapter.Fill(this.dsPrincipal.spmostrar_categoria);
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_articulo' Puede moverla o quitarla según sea necesario.

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
