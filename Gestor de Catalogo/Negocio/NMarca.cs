using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class NMarca
    {
        private string consulta = "Select M.Id, M.Descripcion From MARCAS M";
        public List<Marca> ListarMarcas()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Marca> listaMarca = new List<Marca>();
            try
            {
                datos.Consulta(consulta);
                datos.EjecutarConsulta();
                while (datos.Lector.Read())
                {
                    Marca m = new Marca();
                    m.Id = (int)datos.Lector["Id"];
                    m.Descripcion = (string)datos.Lector["Descripcion"];
                    listaMarca.Add(m);
                }
                return listaMarca;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
