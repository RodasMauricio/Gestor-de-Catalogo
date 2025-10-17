using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorCatalogo
{
    public partial class FrmArticulosAfectados : Form
    {
        private Articulo articulo = null;
        private List<Articulo> listaArticulosAfectados;
        public FrmArticulosAfectados()
        {
            InitializeComponent();
        }
        private void FrmArticulosAfectados_Load(object sender, EventArgs e)
        {
            CargarArticulosAfectados();
        }

        private void CargarArticulosAfectados()
        {
            NArticulo negocio = new NArticulo();
            listaArticulosAfectados = negocio.ListarArticulosAfectados();
            dgvArticulosAfectados.DataSource = listaArticulosAfectados;
            OcultarColumnas();
        }
        private void OcultarColumnas()
        {
            dgvArticulosAfectados.Columns["Id"].Visible = false;
            dgvArticulosAfectados.Columns["Imagen"].Visible = false;
        }

        private Articulo SeleccionArticulo()
        {
            if (dgvArticulosAfectados.CurrentRow != null)
                articulo = (Articulo)dgvArticulosAfectados.CurrentRow.DataBoundItem;
            else
                articulo = (Articulo)dgvArticulosAfectados.Rows[0].DataBoundItem;

            return articulo;
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvArticulosAfectados.Rows.Count > 0)
            {
                try
                {
                    SeleccionArticulo();
                    FrmAltaModificar ventana = new FrmAltaModificar(articulo);
                    ventana.ShowDialog();
                    CargarArticulosAfectados();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void dgvArticulosAfectados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvArticulosAfectados.Columns["Precio"].Visible == true)
            {
                if (e.Value != null && e.Value is decimal)
                {
                    e.Value = string.Format("{0:C0}", e.Value);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvArticulosAfectados.Rows.Count > 0)
            {
                try
                {
                    SeleccionArticulo();
                    DialogResult r = MessageBox.Show($"¿Eliminar artículo ({articulo.Nombre})?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        NArticulo negocio = new NArticulo();
                        negocio.Eliminar(articulo.Id);
                        CargarArticulosAfectados();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
