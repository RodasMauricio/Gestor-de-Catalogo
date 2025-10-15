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
        Marca da = new Marca();
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
    }
}
