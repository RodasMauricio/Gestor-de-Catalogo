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

namespace GestorCatalogo
{
    public partial class FrmMarcaCategoria : Form
    {
        private Marca marca = null;
        private Categoria categoria = null;
        private List<Marca> listaMarca;
        private List<Categoria> listaCategoria;
        private string marcaAntigua = null;
        private string categoriaAntigua = null;
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
        }
        private void CargarCategoria()
        {
            NCategoria negocioCategoria = new NCategoria();
            listaCategoria = negocioCategoria.ListarCategorias();
            dgvCategoria.DataSource = listaCategoria;
            dgvCategoria.Columns["Id"].Visible = false;
        }
        


        private bool ValidacionAgregar(string x)
        {
            DialogResult r = MessageBox.Show($"¿Desea agregar \"{x}\"?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                return true;
            else
                return false;
        }
        private bool ValidacionModificar(string a, string b)
        {
            DialogResult r = MessageBox.Show($"¿Desea modificar \"{a}\" por \"{b}\"?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                return true;
            else
                return false;
        }
        
        private void LimpiarBloquearTxtModificar()
        {
            txtModificarMarca.Clear();
            txtModificarMarca.Enabled = false;

            txtModificarCategoria.Clear();
            txtModificarCategoria.Enabled = false;
        }

        private void txtFiltroMarca_TextChanged(object sender, EventArgs e)
        {
            List<Marca> filtroMarca;
            string filtro = txtFiltroMarca.Text.ToUpper();

            filtroMarca = listaMarca.FindAll(x => x.Descripcion.ToUpper().Contains(filtro));
            dgvMarca.DataSource = null;
            dgvMarca.DataSource = filtroMarca;
            dgvMarca.Columns["Id"].Visible = false;

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
            List<Categoria> filtroCategoria;
            string filtro = txtFiltroCategoria.Text.ToUpper();

            filtroCategoria = listaCategoria.FindAll(x => x.Descripcion.ToUpper().Contains(filtro));
            dgvCategoria.DataSource = null;
            dgvCategoria.DataSource = filtroCategoria;
            dgvCategoria.Columns["Id"].Visible = false;

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
        


        //Botones--
        private void btnActualizarMarca_Click(object sender, EventArgs e)
        {
            CargarMarca();
            txtFiltroMarca.Clear();
            txtAgregarMarca.Clear();
            txtModificarMarca.Clear();
            txtModificarMarca.Enabled = false;
        }

        private void btnActualizarCategoria_Click(object sender, EventArgs e)
        {
            CargarCategoria();
            txtFiltroCategoria.Clear();
            txtAgregarCategoria.Clear();
            txtModificarCategoria.Clear();
            txtModificarMarca.Enabled = false;
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
                    try
                    {
                        NCategoria negocio = new NCategoria();
                        string categoriaF = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(categoria.ToLower());
                        negocio.Agregar(categoriaF);
                        CargarCategoria();
                        txtAgregarCategoria.Clear();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (categoria != null)
            {
                categoriaAntigua = categoria.Descripcion;
                txtModificarCategoria.Enabled = true;
                txtModificarCategoria.Text = categoria.Descripcion;
                txtModificarMarca.Clear();
                txtModificarMarca.Enabled = false;
            }
            else if (marca != null)
            {
                marcaAntigua = marca.Descripcion;
                txtModificarMarca.Enabled = true;
                txtModificarMarca.Text = marca.Descripcion;
                txtModificarCategoria.Clear();
                txtModificarCategoria.Enabled = false;
            }
        }
       
        private void btnModificarMarca_Click(object sender, EventArgs e)
        {
            if (txtModificarMarca.Text != "")
            {
                marcaAntigua = marca.Descripcion;
                string marcaModificada = txtModificarMarca.Text;
                if (ValidacionModificar(marcaAntigua, marcaModificada))
                {
                    try
                    {
                        int id = marca.Id;
                        NMarca negocio = new NMarca();
                        negocio.Modificar(marcaModificada, id, marcaAntigua);
                        CargarMarca();
                        dgvMarca.ClearSelection();
                        txtModificarMarca.Clear();
                        txtModificarMarca.Enabled = false;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        
        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            if (txtModificarCategoria.Text != "")
            {
                categoriaAntigua = categoria.Descripcion;
                string categoriaModificada = txtModificarCategoria.Text;
                if (ValidacionModificar(categoriaAntigua, categoriaModificada))
                {
                    try
                    {
                        int id = categoria.Id;
                        NCategoria negocio = new NCategoria();
                        negocio.Modificar(categoriaModificada, id, categoriaAntigua);
                        CargarCategoria();
                        dgvMarca.ClearSelection();
                        txtModificarCategoria.Clear();
                        txtModificarCategoria.Enabled = false;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        
        private void btnArticulosAfectados_Click(object sender, EventArgs e)
        {
           
            try
            {
                FrmArticulosAfectados ventana = new FrmArticulosAfectados();
                ventana.ShowDialog();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //--Botones

        
        
        private void txtModificarMarca_TextChanged(object sender, EventArgs e)
        {
            if (txtModificarMarca.Text != marcaAntigua && txtModificarMarca.Text != "")
                btnModificarMarca.Enabled = true;
            else
                btnModificarMarca.Enabled = false;
        }

        private void txtModificarCategoria_TextChanged(object sender, EventArgs e)
        {
            if (txtModificarCategoria.Text != categoriaAntigua && txtModificarCategoria.Text != "")
                btnModificarCategoria.Enabled = true;
            else
                btnModificarCategoria.Enabled = false;
        }


        private void dgvMarca_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMarca.SelectedRows.Count > 0)
            {
                dgvCategoria.ClearSelection();
                LimpiarBloquearTxtModificar();
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
                LimpiarBloquearTxtModificar();
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
