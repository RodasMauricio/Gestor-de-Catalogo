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
    public partial class FrmArticulosAfectados : Form
    {
        private List<Articulo> listaArticulosAfectados;
        public FrmArticulosAfectados()
        {
            InitializeComponent();
        }

        private void FrmArticulosAfectados_Load(object sender, EventArgs e)
        {
            CargarArticulosAfectados();
        }

        private void CargarArticulosAfectados()
        {
            NArticulo negocio = new NArticulo();
            listaArticulosAfectados = negocio.ListarArticulosAfectados();
            dgvArticulosAfectados.DataSource = listaArticulosAfectados;
        }
    }
}
