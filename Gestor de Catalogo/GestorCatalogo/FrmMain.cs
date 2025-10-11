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
            NArticulo negocio = new NArticulo();
            listaArticulos = negocio.ListarArticulos();
            dgvMain.DataSource = listaArticulos;
        }
    }
}
