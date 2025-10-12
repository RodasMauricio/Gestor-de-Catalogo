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
    public partial class FrmDetalle : Form
    {
        private Articulo articulo;
        public FrmDetalle(Articulo a)
        {
            InitializeComponent();
            articulo = a;
        }

        private void FrmDetalle_Load(object sender, EventArgs e)
        {
            lblDCodigo.Text = articulo.Codigo;
            lblDNombre.Text = articulo.Nombre;
            lblDCategoria.Text = articulo.Categoria.Descripcion;
            lblDMarca.Text = articulo.Marca.Descripcion;
            lblDPrecio.Text = articulo.Precio.ToString();
            lblDDescripcion.Text = articulo.Descripcion;
            lblDImagen.Text = articulo.Imagen;
            Ayuda.CargarPB(lblDImagen.Text, pbDetalle);
        }

    }
}
