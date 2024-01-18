using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApptPedido;
using ApptPedido.Reportes;
using CapaNegocio;
namespace ApptPedidos
{
    public partial class FmrCategoria : Form
    {

        private bool Isnuevo = false;
        private bool IsEditar = false;

        public FmrCategoria()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtIdcategoria, "Codigo se genero automaticamente");
            this.ttMensaje.SetToolTip(this.txtNombre, "El nombre el nombre de la categoria");
            this.ttMensaje.SetToolTip(this.txtDescripcion, "Ingrese un texto detallado de la categoria");

        }

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "App Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "App Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Limpiar()
        {
            this.txtIdcategoria.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;

        }

        private void Habilitar(bool valor)
        {
            this.txtIdcategoria.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;

        }

        private void Botones()
        {
            if (this.Isnuevo || this.IsEditar)

            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;

            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;



            }


        }
        private void OcultarColumnas()
        {
            if (dataListado.RowCount > 0)
            {
                this.dataListado.Columns[0].Visible = false;
                this.dataListado.Columns[1].Visible = false;
            }


        }
        private void Mostrar()
        {
            dataListado.DataSource = NCategoria.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total De Registro : " + dataListado.Rows.Count;
            tabControl1.SelectedIndex = 0;


        }
        private void BuscaNombre()
        {
            dataListado.DataSource = NCategoria.BuscarNombre(this.txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total de Registros :" + dataListado.Rows.Count;
        }

        private void FmrCategoria_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left= 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscaNombre();
        }


        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscaNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = string.Empty;
                if (txtNombre.Text == string.Empty) 
                {
                    MensajeError("Faltan Ingresar algunos datos, seran remarcados");
                    erroricono.SetError(txtNombre, "Ingreso el nombre de la categoria");
                
                }
                else 
                {
                    if (Isnuevo) 
                    {
                        rpta = NCategoria.Insertar(txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim());
                    
                    }
                    else 
                    {
                        rpta = NCategoria.Editar(Convert.ToInt32(txtIdcategoria.Text),txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim());
                    }
                    if (rpta.Equals("OK")) 
                    {
                        if (Isnuevo) 
                        {
                            this.MensajeOk("Se inserto de forma correcta el registro");
                        }
                        else 
                        {
                        this.MensajeOk("Se actualizo de forma correcta el registro");
                        }

                    
                    }
                    else 
                    {
                        this.MensajeError(rpta);
                    }
                    Isnuevo = false;
                    IsEditar = false;
                    Botones();
                    Limpiar();
                    Mostrar();
                
                }
            
            
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            txtIdcategoria.Text = Convert.ToString(dataListado.CurrentRow.Cells["idcategoria"].Value);
            txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            txtDescripcion.Text = Convert.ToString(dataListado.CurrentRow.Cells["descripcion"].Value);
            tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!txtIdcategoria.Text.Equals("")) 
            {
            IsEditar=true;
                Botones();
                Habilitar(true);
            }
            else 
            {
                MensajeError("Se debe seleccionar primero el registro a modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Isnuevo=false;
            IsEditar = false;
            Botones();
            Limpiar();
            Habilitar(false);
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked) 
            {
                dataListado.Columns[0].Visible = true;

            }
            else 
            {
                dataListado.Columns[0].Visible=false;
            }



        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index) 
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);


            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try 
            {
                DialogResult Opcion;
                Opcion=MessageBox.Show("Realmente desea eliminar los registros"," Pedidos App",
                    MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK) 
                {
                    string Codigo, Rpta = "";
                    foreach(DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value)) 
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NCategoria.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("Ok")) 
                            {

                                MensajeOk("Se elimino correctamente el registro");
                            }
                            else 
                            {
                                MensajeError(Rpta);
                            }

                        
                        }

                        
                    }
                    Mostrar();

                }


            }
            catch(Exception ex) 
            {
            MessageBox.Show(ex.Message+ex.StackTrace);
            }


        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FmrFacturaCategoria fmr = new FmrFacturaCategoria();
            fmr.ShowDialog();
        }
    }
}
