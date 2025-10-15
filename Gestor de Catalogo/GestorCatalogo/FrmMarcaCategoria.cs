using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Dominio;
using Negocio;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

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
        
        private bool ValidacionAgregar(string x)
        {
            DialogResult r = MessageBox.Show($"¿Desea agregar \"{x}\"?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                return true;
            else
                return false;
        }
        
        //Botones--
        private void btnActualizarMarca_Click(object sender, EventArgs e)
        {
            CargarMarca();
            txtFiltroMarca.Clear();
            txtAgregarMarca.Clear();
        }
        
        private void btnActualizarCategoria_Click(object sender, EventArgs e)
        {
            CargarCategoria();
            txtFiltroCategoria.Clear();
            txtAgregarCategoria.Clear();
        }
        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult r;
            if (marca != null)
            {
                try
                {
                    r = MessageBox.Show($"¿Eliminar marca ({marca.Descripcion.ToUpper()})?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        NMarca negocio = new NMarca();
                        negocio.Eliminar(marca);
                        CargarMarca();
                        marca = null;
                        btnEliminar.Enabled = false;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (categoria != null)
            {
                r = MessageBox.Show($"¿Eliminar categoría ({categoria.Descripcion.ToUpper()})?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    try
                    {
                        NCategoria negocio = new NCategoria();
                        negocio.Eliminar(categoria);
                        CargarCategoria();
                        categoria = null;
                        btnEliminar.Enabled = false;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else
            {
                btnEliminar.Enabled = false;
            }
            dgvMarca.ClearSelection();
            dgvCategoria.ClearSelection();

            if (dgvMarca.Rows.Count == 0)
                dgvCategoria.Focus();
            else if (dgvCategoria.Rows.Count == 0)
                dgvMarca.Focus();
                
        }
       
        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            if (txtAgregarMarca.Text != "")
            {
                string marca = txtAgregarMarca.Text; 
                if (ValidacionAgregar(marca))
                { 
                    try
                    {
                        NMarca negocio = new NMarca();
                        string marcaF = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(marca.ToLower());
                        negocio.Agregar(marcaF);
                        CargarMarca();
                        txtAgregarMarca.Clear();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            if (txtAgregarCategoria.Text != "")
            {
                string categoria = txtAgregarCategoria.Text;
                if(ValidacionAgregar(categoria))
                {
                    NCategoria negocio = new NCategoria();
                    string categoriaF = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(categoria.ToLower());
                    negocio.Agregar(categoriaF);
                    CargarCategoria();
                    txtAgregarCategoria.Clear();
                }
            }
        }
        //--Botones


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
        private void lblXMarca_Click(object sender, EventArgs e)
        {
            txtFiltroMarca.Clear();
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
                btnEliminar.Enabled = true;
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
                btnEliminar.Enabled = true;
            }
            else
            {
                categoria = null;
            }
        }

    }
}
