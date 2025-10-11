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
            NMarca negocioMarca = new NMarca();
            NCategoria negocioCategoria = new NCategoria();
            listaMarca = negocioMarca.ListarMarcas();
            listaCategoria = negocioCategoria.ListarCategorias();
            dgvMarca.DataSource = listaMarca;
            dgvCategoria.DataSource = listaCategoria;

        }
    }
}
