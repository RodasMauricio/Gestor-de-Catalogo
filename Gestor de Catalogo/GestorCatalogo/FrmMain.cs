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
        private List<Articulo> listaArticulos;
        private Articulo articulo;
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
        }
        private void OcultarColumnas()
        {
            dgvMain.Columns["Id"].Visible = false;
            dgvMain.Columns["Imagen"].Visible = false;
        }
        
        private Articulo SeleccionArticulo()
        {
            if (dgvMain.CurrentRow != null)
                articulo = (Articulo)dgvMain.CurrentRow.DataBoundItem;
            else
                articulo = (Articulo)dgvMain.Rows[0].DataBoundItem;

            return articulo;
        }
        
        
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

    }
}
