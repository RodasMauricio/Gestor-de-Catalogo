using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace GestorCatalogo
{
    public partial class FrmMarcaCategoria : Form
    {
        private Marca marca = null;
        private Categoria categoria = null;
        private List<Marca> listaMarca;
        private List<Categoria> listaCategoria;
        public FrmMarcaCategoria()
        {
            InitializeComponent();
        }

        private void FrmMarcaCategoria_Load(object sender, EventArgs e)
        {
            CargarMarca();
            CargarCategoria();
        }

        private void CargarMarca()
        {
            NMarca negocioMarca = new NMarca();
            listaMarca = negocioMarca.ListarMarcas();
            dgvMarca.DataSource = listaMarca;
            dgvMarca.Columns["Id"].Visible = false;
            dgvMarca.Columns[1].Width = 145;
        }
        private void CargarCategoria()
        {
            NCategoria negocioCategoria = new NCategoria();
            listaCategoria = negocioCategoria.ListarCategorias();
            dgvCategoria.DataSource = listaCategoria;
            dgvCategoria.Columns["Id"].Visible = false;
            dgvCategoria.Columns[1].Width = 145;
        }

        private void btnActualizarMarca_Click(object sender, EventArgs e)
        {
            CargarMarca();
        }

        private void btnActualizarCategoria_Click(object sender, EventArgs e)
        {
            CargarCategoria();
        }

        private void txtFiltroMarca_TextChanged(object sender, EventArgs e)
        {
            if (txtFiltroMarca.Text != "")
            {
                lblXMarca.Enabled = true;
                lblXMarca.Visible = true;
            }
            else
            {
                lblXMarca.Enabled = false;
                lblXMarca.Visible = false;
            }
        }

        private void txtFiltroCategoria_TextChanged(object sender, EventArgs e)
        {
            if (txtFiltroCategoria.Text != "")
            {
                lblXCategoria.Enabled = true;
                lblXCategoria.Visible = true;
            }
            else
            {
                lblXCategoria.Enabled = false;
                lblXCategoria.Visible = false;
            }
        }

        private void lblXMarca_Click(object sender, EventArgs e)
        {
            txtFiltroMarca.Clear();
        }

        private void lblXCategoria_Click(object sender, EventArgs e)
        {
            txtFiltroCategoria.Clear();
        }

        private void dgvMarca_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMarca.SelectedRows.Count > 0)
            {
                dgvCategoria.ClearSelection();
                marca = (Marca)dgvMarca.CurrentRow.DataBoundItem;
            }
            else
            {
                marca = null;
            }
        }

        private void dgvCategoria_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategoria.SelectedRows.Count > 0)
            {
                dgvMarca.ClearSelection();
                categoria = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;
            }
            else
            {
                categoria = null;
            }
        }




        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (marca == null)
            {
                MessageBox.Show($"¿Desea eliminar {categoria.Descripcion}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show($"¿Desea eliminar {marca.Descripcion}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }
    }
}
