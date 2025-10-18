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
        public List<Categoria> ListarCategorias()
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
                List<Categoria> listaCategoria = new List<Categoria>();
                try
                {
                    datos.Consulta("Select C.Id, C.Descripcion From CATEGORIAS C");
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
    
        public void Agregar(string categoria)
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
                try
                {
                    datos.Consulta("Insert Into CATEGORIAS values (@categoria)");
                    datos.Parametros("@categoria", categoria);
                    datos.EjecutarComando();
                    MessageBox.Show($"¡Categoría \"{categoria}\" agregada!");
                }
                catch (Exception)
                {
                    MessageBox.Show("¡Error al agregar la categoría");
                }
            }
        }

        public void Eliminar(Categoria categoria)
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
                try
                {
                    datos.Consulta("Delete CATEGORIAS Where Id = @id");
                    datos.Parametros("@id", categoria.Id);
                    datos.EjecutarComando();
                    MessageBox.Show($"¡Categoría \"{categoria.Descripcion.ToUpper()}\" eliminada!");
                }
                catch (Exception)
                {
                    MessageBox.Show("¡Error al eliminar la categoría!");
                }
            }
        }

        public void Modificar(string categoriaModificada, int id, string categoriaAntigua)
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
                try
                {
                    datos.Consulta("Update CATEGORIAS set Descripcion = @categoriaModificada Where Id = @id");
                    datos.Parametros("@categoriaModificada", categoriaModificada);
                    datos.Parametros("@id", id);
                    datos.EjecutarComando();
                    MessageBox.Show($"¡Categoría \"{categoriaAntigua}\" se modificó a \"{categoriaModificada}\"!");
                }
                catch (Exception)
                {
                    MessageBox.Show("¡Error al modificar la categoría!");
                }
            }
        }
    }
}
