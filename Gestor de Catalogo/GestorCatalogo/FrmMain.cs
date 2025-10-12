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
    public partial class FrmMain : Form
    {
        private Articulo articulo;
        private List<Articulo> listaArticulos;
        private List<Categoria> listaCategoria;
        private List<Marca> listaMarca;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            CargarMain();
        }
        private void CargarMain()
        {
            NArticulo negocio = new NArticulo();
            listaArticulos = negocio.ListarArticulos();
            dgvMain.DataSource = listaArticulos;
            OcultarColumnas();
            Ayuda.CargarPB(listaArticulos[0].Imagen, pbMain);
            if (cbFiltrarPor.Items.Count == 0)
                CargarFiltrarPor();
        }
        private void OcultarColumnas()
        {
            dgvMain.Columns["Id"].Visible = false;
            dgvMain.Columns["Imagen"].Visible = false;
        }
        private void CargarFiltrarPor()
        {
            cbFiltrarPor.Items.Add("Nombre");
            cbFiltrarPor.Items.Add("Categoría");
            cbFiltrarPor.Items.Add("Marca");
            cbFiltrarPor.Items.Add("Descripción");
            cbFiltrarPor.Items.Add("Precio");
        }
        private Articulo SeleccionArticulo()
        {
            if (dgvMain.CurrentRow != null)
                articulo = (Articulo)dgvMain.CurrentRow.DataBoundItem;
            else
                articulo = (Articulo)dgvMain.Rows[0].DataBoundItem;

            return articulo;
        }
        
        
        //Evento Botones--
        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = new Articulo();
            seleccionado = (Articulo)dgvMain.CurrentRow.DataBoundItem;
            FrmDetalle ventanaDetalle = new FrmDetalle(seleccionado);
            ventanaDetalle.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaModificar ventana = new FrmAltaModificar();
            ventana.ShowDialog();
            CargarMain();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SeleccionArticulo();
            DialogResult r = MessageBox.Show($"¿Eliminar artículo ({articulo.Nombre})?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                NArticulo negocio = new NArticulo();
                negocio.Eliminar(articulo.Id);
                CargarMain();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            SeleccionArticulo();
            FrmAltaModificar ventana = new FrmAltaModificar(articulo);
            ventana.ShowDialog();
            CargarMain();
        }

        //--Evento Botones



        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> filtroRapido;
            string filtro = txtBusqueda.Text.ToUpper();

            filtroRapido = listaArticulos.FindAll(x => x.Codigo.ToUpper().Contains(filtro) || x.Nombre.ToUpper().Contains(filtro) || x.Marca.Descripcion.ToUpper().Contains(filtro) || x.Categoria.Descripcion.ToUpper().Contains(filtro));

            dgvMain.DataSource = null;
            dgvMain.DataSource = filtroRapido;
            OcultarColumnas();
        }
        private void dgvMain_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.CurrentRow != null)
                {
                    Articulo seleccionado = (Articulo)dgvMain.CurrentRow.DataBoundItem;
                    Ayuda.CargarPB(seleccionado.Imagen, pbMain);
                }
                else
                {
                    Ayuda.CargarPB("", pbMain);
                    btnDetalle.Enabled = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void cbFiltrarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbFiltrarPor.SelectedItem.ToString();
            if (cbFiltrarPor.SelectedIndex > -1)
                cbCriterio.Enabled = true;
            if (cbCriterio.Items.Count > 0)
                cbCriterio.Items.Clear();

            txtFiltro.Enabled = false;
            btnFiltrar.Enabled = false;

            switch (opcion)
            {
                case "Nombre":
                    cbCriterio.Items.Add("Comienza con...");
                    cbCriterio.Items.Add("Termina con...");
                    cbCriterio.Items.Add("Contiene...");
                    break;
                case "Categoría":
                    NCategoria categoria = new NCategoria();
                    listaCategoria = categoria.ListarCategorias();
                    foreach (Categoria c in listaCategoria)
                    {
                        cbCriterio.Items.Add(c);
                    }
                    break;
                case "Marca":
                    NMarca marca = new NMarca();
                    listaMarca = marca.ListarMarcas();
                    foreach (Marca m in listaMarca)
                    {
                        cbCriterio.Items.Add(m);
                    }
                    break;
                case "Descripción":
                    cbCriterio.Enabled = false;
                    txtFiltro.Enabled = true;
                    break;
                case "Precio":
                    cbCriterio.Items.Add("Mínimo");
                    cbCriterio.Items.Add("Máximo");
                    break;
            }
            if (txtFiltro.Text != "")
                txtFiltro.Clear();

        }

        private void cbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = cbFiltrarPor.SelectedItem.ToString();
            if (seleccion != null && seleccion != "Marca" && seleccion != "Categoría")
            {
                txtFiltro.Enabled = true;
            }
            else
            {
                txtFiltro.Enabled = false;
                btnFiltrar.Enabled = true;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if (txtFiltro.Text != "")
                btnFiltrar.Enabled = true;
            else
                btnFiltrar.Enabled = false;
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiltrarPor.SelectedItem.ToString() == "Precio")
            {
                txtFiltro.ShortcutsEnabled = false;
                if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cbFiltrarPor.Items.Clear();
            cbCriterio.Items.Clear();
            txtFiltro.Clear();
            txtFiltro.Enabled = false;
            cbCriterio.Enabled = false;
            txtBusqueda.Clear();
            CargarMain();
        }
    }
}
