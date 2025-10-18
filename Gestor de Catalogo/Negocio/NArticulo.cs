using Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace Negocio
{
    public class NArticulo
    {
        private string consulta = "Select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Id IdMarca, M.Descripcion Marca, C.Id IdCategoria, C.Descripcion Categoria, A.ImagenUrl Imagen, A.Precio From ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdMarca = M.Id And A.IdCategoria = C.Id";


        public List<Articulo> ListarArticulos()
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
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
                        if (!(datos.Lector["IdMarca"] is null && datos.Lector["Marca"] is null))
                        {
                            a.Marca.Id = (int)datos.Lector["IdMarca"];
                            a.Marca.Descripcion = (string)datos.Lector["Marca"];
                        }
                        a.Categoria = new Categoria();
                        if (!(datos.Lector["IdCategoria"] is null && datos.Lector["Categoria"] is null))
                        {
                            a.Categoria.Id = (int)datos.Lector["IdCategoria"];
                            a.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                        }

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
            }
        }
        
        public List<Articulo> FiltroAvanzado(string filtrarPor, string criterio, string filtro)
        {
            string consultaFiltro = this.consulta;
            using (AccesoDatos datos = new AccesoDatos())
            {
                try
                {
                    List<Articulo> listadoFiltrado = new List<Articulo>();
                    consultaFiltro += " And ";
                    switch (filtrarPor)
                    {
                        case "Nombre":
                            if (criterio == "Comienza con...")
                            {
                                consultaFiltro += "Nombre Like @filtro"; ;
                                datos.Parametros("@filtro", filtro + "%");
                            }
                            else
                            {
                                if (criterio == "Termina con...")
                                {
                                    consultaFiltro += "Nombre Like @filtro ";
                                    datos.Parametros("@filtro", "%" + filtro );
                                }
                                else
                                {
                                    consultaFiltro += "Nombre Like @filtro ";
                                    datos.Parametros("@filtro", "%" + filtro + "%");
                                }
                            }
                            break;
                        case "Descripción":
                            consultaFiltro += "A.Descripcion Like @filtro ";
                            datos.Parametros("@filtro", "%" + filtro + "%");
                            break;
                        case "Precio":
                            if (criterio == "Mínimo")
                                consultaFiltro += "A.Precio >= @filtro Order By Precio ASC";
                            else
                                consultaFiltro += "A.Precio <= @filtro Order By Precio DESC";
                            datos.Parametros("@filtro", filtro);
                            break;
                    }
                    datos.Consulta(consultaFiltro);
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

                        listadoFiltrado.Add(a);
                    }
                    return listadoFiltrado;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        public List<Articulo> ListarArticulosAfectados()
        {
          string consulta = "SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.IdMarca, m.Descripcion Marca, a.IdCategoria, c.Descripcion Categoria, a.ImagenUrl, a.Precio FROM Articulos a LEFT JOIN Marcas m ON a.IdMarca = m.Id LEFT JOIN Categorias c ON a.IdCategoria = c.Id WHERE m.Id IS NULL OR c.Id IS NULL";
            using (AccesoDatos datos = new AccesoDatos())
            {
                List<Articulo> listaArticulosAfectados = new List<Articulo>();
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
                        if (!(datos.Lector["Marca"] is DBNull))
                        {
                            a.Marca.Descripcion = (string)datos.Lector["Marca"];
                        }
                        else
                        {
                            a.Marca.Descripcion = "-";
                        }
                        a.Categoria = new Categoria();
                        a.Categoria.Id = (int)datos.Lector["IdCategoria"];
                        if (!(datos.Lector["Categoria"] is DBNull))
                        {
                            a.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                        }
                        else
                        {
                            a.Categoria.Descripcion = "-";
                        }

                        if (!(datos.Lector["ImagenUrl"] is DBNull))
                            a.Imagen = (string)datos.Lector["ImagenUrl"];

                        a.Precio = (decimal)datos.Lector["Precio"];

                        listaArticulosAfectados.Add(a);
                    }
                    return listaArticulosAfectados;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        public void Agregar(Articulo a)
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
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
                    MessageBox.Show("¡Artículo Agregado!");
                }
                catch (Exception)
                {
                    MessageBox.Show("¡Error al Agregar el Artículo!");
                }
            }
        }
        public void Eliminar(int id)
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
                try
                {
                    datos.Consulta("Delete From ARTICULOS Where Id = @id");
                    datos.Parametros("@id", id);
                    datos.EjecutarComando();
                    MessageBox.Show("¡Artículo Eliminado!");
                }
                catch (Exception)
                {
                    MessageBox.Show("¡Error al Eliminar el Artículo!");
                }
            }
        }
        public void Modificar(Articulo a)
        { 
            using (AccesoDatos datos = new AccesoDatos())
            {
                try
                {
                    datos.Consulta("Update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @imagen, Precio = @precio Where Id = @id");
                    datos.Parametros("@codigo", a.Codigo.ToUpper());
                    datos.Parametros("@nombre", a.Nombre);
                    datos.Parametros("@descripcion", a.Descripcion);
                    datos.Parametros("@idMarca", a.Marca.Id);
                    datos.Parametros("@idCategoria", a.Categoria.Id);
                    datos.Parametros("@imagen", a.Imagen);
                    datos.Parametros("@precio", a.Precio);
                    datos.Parametros("@id", a.Id);
                    datos.EjecutarComando();
                    MessageBox.Show("¡Artículo Modificado!");
                }
                catch (Exception)
                {
                    MessageBox.Show("¡Error al Modificar el Artículo!");
                }
            }
        }
    }
}
