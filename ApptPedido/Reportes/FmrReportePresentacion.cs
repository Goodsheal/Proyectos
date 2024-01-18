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
    public partial class FmrReportePresentacion : Form
    {
        public FmrReportePresentacion()
        {
            InitializeComponent();
        }

        private void FmrReportePresentacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_presentacion' Puede moverla o quitarla según sea necesario.
            this.spmostrar_presentacionTableAdapter.Fill(this.dsPrincipal.spmostrar_presentacion);

            this.reportViewer1.RefreshReport();
        }
    }
}
