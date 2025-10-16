using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Negocio
{
    public class NMarca
    {
        private string consulta = "Select M.Id, M.Descripcion From MARCAS M";
        public List<Marca> ListarMarcas()
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
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
    
    
        public void Agregar(string marca)
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
                try
                {
                    datos.Consulta("Insert Into MARCAS values (@marca)");
                    datos.Parametros("@marca", marca);
                    datos.EjecutarComando();
                    MessageBox.Show($"¡Marca \"{marca}\" agregada!");
                }
                catch (Exception)
                {
                    MessageBox.Show("¡Error al agregar la marca");
                }
            }
        }
        
        public void Eliminar(Marca marca)
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
                try
                {
                    datos.Consulta($"Delete MARCAS Where Id = {marca.Id}");
                    datos.EjecutarComando();
                    MessageBox.Show($"¡Marca \"{marca.Descripcion.ToUpper()}\" eliminada!");
                }
                catch (Exception)
                {
                    MessageBox.Show("¡Error al eliminar la marca");
                }
            }
        }

        public void Modificar(string marcaModificada, int id, string marcaAntigua)
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
                try
                {
                    datos.Consulta("Update MARCAS set Descripcion = @marcaModificada Where Id = @id");
                    datos.Parametros("@marcaModificada", marcaModificada);
                    datos.Parametros("@id", id);
                    datos.EjecutarComando();
                    MessageBox.Show($"¡Marca \"{marcaAntigua}\" se modificó a \"{marcaModificada}\"!");
                }
                catch (Exception)
                {
                    MessageBox.Show("¡Error al modificar la marca!");;
                }
            }
        }

    }
}
