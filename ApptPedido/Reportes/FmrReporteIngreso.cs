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
    public partial class FmrReporteIngreso : Form
    {
        public FmrReporteIngreso()
        {
            InitializeComponent();
        }

        private void FmrReporteIngreso_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_ingreso' Puede moverla o quitarla según sea necesario.
            this.spmostrar_ingresoTableAdapter.Fill(this.dsPrincipal.spmostrar_ingreso);

            this.reportViewer1.RefreshReport();
        }
    }
}
