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
            if (listaArticulos.Count > 0)
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
            cbFiltrarPor.Items.Add("Descripción");
            cbFiltrarPor.Items.Add("Marca");
            cbFiltrarPor.Items.Add("Categoría");
            cbFiltrarPor.Items.Add("Precio");
        }
        private void SeleccionArticulo()
        {
            if (dgvMain.CurrentRow != null)
                articulo = (Articulo)dgvMain.CurrentRow.DataBoundItem;
            else
                articulo = (Articulo)dgvMain.Rows[0].DataBoundItem;
        }
        private List<Articulo> FiltroMarcaCategoria(string filtrarPor, string criterio)
        {
            try
            {
                List<Articulo> listadoFiltrado = new List<Articulo>();
                switch (filtrarPor)
                {
                    case "Marca":
                        foreach (Articulo m in listaArticulos)
                        {
                            if (m.Marca.Descripcion == criterio)
                                listadoFiltrado.Add(m);
                        }
                        break;
                    case "Categoría":
                        foreach (Articulo c in listaArticulos)
                        {
                            if (c.Categoria.Descripcion == criterio)
                                listadoFiltrado.Add(c);
                        }
                        break;
                }
                return listadoFiltrado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Evento Botones--

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAltaModificar ventana = new FrmAltaModificar();
                ventana.ShowDialog();
                CargarMain();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count > 0)
            {
                try
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
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count > 0)
            {
                try
                {
                    SeleccionArticulo();
                    FrmAltaModificar ventana = new FrmAltaModificar(articulo);
                    ventana.ShowDialog();
                    CargarMain();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        
        private void btnMarcaCategoria_Click(object sender, EventArgs e)
        {
            FrmMarcaCategoria ventana = new FrmMarcaCategoria();
            ventana.ShowDialog();
            CargarMain();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count > 0)
            {
                try
                {
                    SeleccionArticulo();
                    FrmDetalle ventanaDetalle = new FrmDetalle(articulo);
                    ventanaDetalle.ShowDialog();
                }
                catch (Exception)
                {
                    throw;
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
            btnLimpiar.Enabled = false;
            btnFiltrar.Enabled = false;
        }
        
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                string filtrarPor = cbFiltrarPor.SelectedItem.ToString();
                string criterio = null;
                string filtro = null; ;
                if (filtrarPor != "Descripción")
                    criterio = cbCriterio.SelectedItem.ToString();
                if (filtrarPor == "Marca" || filtrarPor == "Categoría")
                {
                    dgvMain.DataSource = null;
                    dgvMain.DataSource = FiltroMarcaCategoria(filtrarPor, criterio);
                }
                else
                {
                    NArticulo negocio = new NArticulo();
                    filtro = txtFiltro.Text;
                    dgvMain.DataSource = null;
                    dgvMain.DataSource = negocio.FiltroAvanzado(filtrarPor, criterio, filtro);
                }
                OcultarColumnas();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cbFiltrarPor.SelectedIndex = -1;
            cbCriterio.Items.Clear();
            cbCriterio.Enabled = false;
            txtFiltro.Clear();
            txtFiltro.Enabled = false;
            btnFiltrar.Enabled = false;
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

            if (txtBusqueda.Text != "")
            {
                lblXBusqueda.Visible = true;
                lblXBusqueda.Enabled = true;
            }
            else
            {
                lblXBusqueda.Visible = false;
                lblXBusqueda.Enabled = false;
            }

        }
        private void dgvMain_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.CurrentRow != null)
                {
                    SeleccionArticulo();
                    Ayuda.CargarPB(articulo.Imagen, pbMain);
                    lblMarca.Text = articulo.Marca.Descripcion;
                    lblArticulo.Text = articulo.Nombre;
                    lblPrecio.Text = articulo.Precio.ToString("C0");
                    btnDetalle.Enabled = true;
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
                else
                {
                    lblMarca.Text = "-";
                    lblArticulo.Text = "-";
                    lblPrecio.Text = "-";
                    Ayuda.CargarPB("", pbMain);
                    btnDetalle.Enabled = false;
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void cbFiltrarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiltrarPor.SelectedIndex > -1)
            {
                btnLimpiar.Enabled = true;
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
            else
            {
                btnLimpiar.Enabled = false;
            }
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

        private void lblXBusqueda_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
        }

        private void dgvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMain.Columns["Precio"].Visible == true)
            {
                if (e.Value != null && e.Value is decimal)
                {
                    // Formatear el valor de la celda como moneda
                    e.Value = string.Format("{0:C0}", e.Value);
                }
            }
        }

    }
}
