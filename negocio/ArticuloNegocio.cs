using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            ImagenNegocio imagen = new ImagenNegocio();

            try
            {
                datos.setearConsulta("SELECT DISTINCT A.Id, A.Nombre, A.Codigo, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio, A.IdMarca, A.IdCategoria FROM ARTICULOS A LEFT JOIN MARCAS M ON M.ID = A.IdMarca LEFT JOIN CATEGORIAS C ON C.ID = A.IdCategoria");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Marca = new Marca();
                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        articulo.Marca.Id = (int)datos.Lector["IdMarca"];
                        articulo.Marca.Descripcion = (string)datos.Lector["Marca"];
                    }
                    else articulo.Marca.Descripcion = " ";
                    articulo.Categoria = new Categoria();
                    if (!(datos.Lector["Categoria"] is DBNull))
                    {
                        articulo.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                        articulo.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    }
                    else articulo.Categoria.Descripcion = " ";
                    decimal DosDecimal;
                    DosDecimal = (decimal)datos.Lector["Precio"];

                    articulo.Precio = Math.Truncate(DosDecimal * 100) / 100;
                    articulo.Imagenes = imagen.listar(articulo.Id);
                    articulos.Add(articulo);
                }
                return articulos;
                //decimal DosDecimal;
                //DosDecimal = (decimal)datos.Lector["precio"];
                //aux.Precio = Decimal.Parse(DosDecimal.ToString("0.00"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (articulo.Marca == null)
                {
                    datos.setearConsulta("INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, Precio, IdCategoria) VALUES('" + articulo.Codigo + "','" + articulo.Nombre + "','" + articulo.Descripcion + "'," + articulo.Precio + "," + articulo.Categoria.Id + ")");
                }
                else if (articulo.Categoria == null)
                {
                    datos.setearConsulta("INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, Precio, IdMarca) VALUES('" + articulo.Codigo + "','" + articulo.Nombre + "','" + articulo.Descripcion + "'," + articulo.Precio + "," + articulo.Marca.Id + ")");
                }
                else if (articulo.Categoria == null && articulo.Marca == null)
                {
                    datos.setearConsulta("INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, Precio) VALUES('" + articulo.Codigo + "','" + articulo.Nombre + "','" + articulo.Descripcion + "'," + articulo.Precio + "," + ")");
                }
                else
                    datos.setearConsulta("INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria) VALUES('" + articulo.Codigo + "','" + articulo.Nombre + "','" + articulo.Descripcion + "'," + articulo.Precio + "," + articulo.Marca.Id + "," + articulo.Categoria.Id + ")");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta($"UPDATE ARTICULOS SET CODIGO = '{articulo.Codigo}', NOMBRE = '{articulo.Nombre}', DESCRIPCION = '{articulo.Descripcion}', IdMarca = {articulo.Marca.Id}, IdCategoria ={articulo.Categoria.Id} WHERE Id = {articulo.Id}");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public int consultarUltimoId()
        {
            AccesoDatos datos = new AccesoDatos();
            int id = 0;
            try
            {
                datos.setearConsulta("select max(Id) as Id from Articulos");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    id = (int)datos.Lector["id"];
                }
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from Articulos where Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            ImagenNegocio imagen = new ImagenNegocio();
            try
            {
                string consulta = "SELECT DISTINCT A.Id, A.Nombre, A.Codigo, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio FROM ARTICULOS A LEFT JOIN MARCAS M ON M.ID = A.IdMarca LEFT JOIN CATEGORIAS C ON C.ID = A.IdCategoria WHERE ";
                switch (campo)
                {
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "A.Precio > " + filtro;
                                break;
                            case "Menor a":
                                consulta += "A.Precio < " + filtro;
                                break;
                            default:
                                consulta += "A.Precio = " + filtro;
                                break;
                        }
                        break;
                    case "Código":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Codigo like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "A.Codigo like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "A.Codigo like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Nombre like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "A.Nombre like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "A.Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Descripción":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "A.Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "A.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Marca":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "M.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "M.Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "M.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    default:
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "C.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "C.Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "C.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Marca = new Marca();
                    articulo.Marca.Descripcion = (string)datos.Lector["Marca"];
                    articulo.Categoria = new Categoria();
                    if (!(datos.Lector["Categoria"] is DBNull))
                        articulo.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    else articulo.Categoria.Descripcion = " ";
                    decimal DosDecimal;
                    DosDecimal = (decimal)datos.Lector["Precio"];

                    articulo.Precio = Math.Truncate(DosDecimal * 100) / 100;
                    articulo.Imagenes = imagen.listar(articulo.Id);
                    lista.Add(articulo);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
