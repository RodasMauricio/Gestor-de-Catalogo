using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class NCategoria
    {
        private string consulta = "Select C.Id, C.Descripcion From CATEGORIAS C";
        public List<Categoria> ListarCategorias()
        {
            AccesoDatos datos = new AccesoDatos();
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
}
