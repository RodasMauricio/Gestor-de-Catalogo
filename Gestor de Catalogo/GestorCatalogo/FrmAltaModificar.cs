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
    public partial class FrmAltaModificar : Form
    {
        Articulo articulo = null;
        public FrmAltaModificar()
        {
            InitializeComponent();
            Text = "AGREGAR";
        }
        public FrmAltaModificar(Articulo a)
        {
            InitializeComponent();
            Text = "MODIFICAR";
        }

        private void FrmAltaModificar_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            NMarca marca = new NMarca();
            NCategoria categoria = new NCategoria();
            try
            {
                cbMarca.DataSource = marca.ListarMarcas();
                cbMarca.ValueMember = "Id";
                cbMarca.DisplayMember = "Descripcion";
                cbCategoria.DataSource = categoria.ListarCategorias();
                cbCategoria.ValueMember = "Id";
                cbCategoria.DisplayMember = "Descripcion";
                cbMarca.SelectedIndex = -1;
                cbCategoria.SelectedIndex = -1;

                if (articulo != null)
                {

                }





            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
