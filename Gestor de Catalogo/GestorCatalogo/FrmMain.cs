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
            CargarImagen(listaArticulos[0].Imagen);
        }
        private void OcultarColumnas()
        {
            dgvMain.Columns["Id"].Visible = false;
            dgvMain.Columns["Imagen"].Visible = false;
        }
        public void CargarImagen(string img)
        {
            try
            {
                pbMain.Load(img);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void dgvMain_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvMain.CurrentRow.DataBoundItem;
            CargarImagen(seleccionado.Imagen);
        }


        //Evento Botones--
        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = new Articulo();
            seleccionado = (Articulo)dgvMain.CurrentRow.DataBoundItem;
            FrmDetalle ventanaDetalle = new FrmDetalle(seleccionado);
            ventanaDetalle.ShowDialog();
        }


        //--Evento Botones

    }
}
