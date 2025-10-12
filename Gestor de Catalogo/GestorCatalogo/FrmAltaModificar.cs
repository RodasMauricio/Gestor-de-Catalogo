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

        private void InsertarDatos()
        {
            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Marca = (Marca)cbMarca.SelectedItem;
                articulo.Categoria = (Categoria)cbCategoria.SelectedItem;
                articulo.Imagen = txtImagen.Text;
                if (txtPrecio.Text != "")
                    articulo.Precio = decimal.Parse(txtPrecio.Text);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
        




        private void txtImagen_Leave(object sender, EventArgs e)
        {
            Ayuda.CargarPB(txtImagen.Text, pbAltaMod);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "" && txtNombre.Text != "" && cbMarca.SelectedItem != null && cbCategoria.SelectedItem != null)
            {
                NArticulo negocio = new NArticulo();
                InsertarDatos();
                try
                {
                    DialogResult r = MessageBox.Show($"¿Desea {this.Text} este artículo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (articulo.Id != 0)
                        {
                            MessageBox.Show("¡Artículo Modificado!");
                        }
                        else
                        {
                            negocio.Agregar(articulo);
                            MessageBox.Show("¡Artículo Agregado!");
                        }
                        Close();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
            else
            {
                MessageBox.Show("Revise si completó los campos obligatorios (Código, Nombre, Marca y Categoría).", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
