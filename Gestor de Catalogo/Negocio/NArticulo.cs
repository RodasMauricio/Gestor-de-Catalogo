using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class NArticulo
    {
        private string consulta = "Select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Id IdMarca, M.Descripcion Marca, C.Id IdCategoria, C.Descripcion Categoria, A.ImagenUrl Imagen, A.Precio From ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdMarca = M.Id And A.IdCategoria = C.Id";
        public List<Articulo> ListarArticulos()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> listaArticulo = new List<Articulo>();
            try
            {
                datos.Consulta(consulta);
                datos.EjecutarConsulta();

                while (datos.Lector.Read())
                {
                    Articulo a = new Articulo();

                    a.Id = (int)datos.Lector["Id"];
                    a.Codigo = (string)datos.Lector["Codigo"];
                    a.Nombre = (string)datos.Lector["Nombre"];
                    a.Descripcion = (string)datos.Lector["Descripcion"];
                    a.Marca = new Marca();
                    a.Marca.Id = (int)datos.Lector["IdMarca"];
                    a.Marca.Descripcion = (string)datos.Lector["Marca"];
                    a.Categoria = new Categoria();
                    a.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    a.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    if (!(datos.Lector["Imagen"] is DBNull))
                        a.Imagen = (string)datos.Lector["Imagen"];

                    a.Precio = (decimal)datos.Lector["Precio"];

                    listaArticulo.Add(a);
                }
                return listaArticulo;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }


        public void Agregar(Articulo a)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.Consulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)values(@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagen, @precio)");
                datos.Parametros("@codigo", a.Codigo.ToUpper());
                datos.Parametros("@nombre", a.Nombre);
                datos.Parametros("@descripcion", a.Descripcion);
                datos.Parametros("@idMarca", a.Marca.Id);
                datos.Parametros("@idCategoria", a.Categoria.Id);
                datos.Parametros("@imagen", a.Imagen);
                datos.Parametros("@precio", a.Precio);
                datos.EjecutarComando();
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }





    }
}
