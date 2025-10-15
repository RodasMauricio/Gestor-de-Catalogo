using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Negocio
{
    public class NCategoria
    {
        private string consulta = "Select C.Id, C.Descripcion From CATEGORIAS C";
        public List<Categoria> ListarCategorias()
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
                List<Categoria> listaCategoria = new List<Categoria>();
                try
                {
                    datos.Consulta(consulta);
                    datos.EjecutarConsulta();
                    while (datos.Lector.Read())
                    {
                        Categoria c = new Categoria();
                        c.Id = (int)datos.Lector["Id"];
                        c.Descripcion = (string)datos.Lector["Descripcion"];
                        listaCategoria.Add(c);
                    }
                    return listaCategoria;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    
        public void Agregar()
        {

        }

        public void Eliminar(Categoria categoria)
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
                try
                {
                    datos.Consulta($"Delete CATEGORIAS Where Id = {categoria.Id}");
                    datos.EjecutarComando();
                    MessageBox.Show($"¡Categoría \"{categoria.Descripcion.ToUpper()}\" eliminada!");
                }
                catch (Exception)
                {
                    MessageBox.Show("¡Error al eliminar la categoría!");
                }
            }
        }
    }
}
