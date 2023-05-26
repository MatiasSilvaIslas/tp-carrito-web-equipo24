using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> listar()
        {
            List<Imagen> imagenes = new List<Imagen>();
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.setearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES");
                acceso.ejecutarLectura();

                while (acceso.Lector.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.Id = (int)acceso.Lector["Id"];
                    imagen.IdArticulo = (int)acceso.Lector["IdArticulo"];
                    // Nombre del articulo
                    imagen.ImagenUrl = (string)acceso.Lector["ImagenUrl"];
                    imagenes.Add(imagen);

                }
                return imagenes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }
        public List<Imagen> listar(int idArt)
        {
            List<Imagen> imagenes = new List<Imagen>();
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.setearConsulta($"SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = {idArt}");
                acceso.ejecutarLectura();

                while (acceso.Lector.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.Id = (int)acceso.Lector["Id"];
                    imagen.IdArticulo = (int)acceso.Lector["IdArticulo"];
                    // Nombre del articulo
                    imagen.ImagenUrl = (string)acceso.Lector["ImagenUrl"];
                    imagenes.Add(imagen);

                }
                return imagenes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }
        public void agregar(Imagen imagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES(" + imagen.IdArticulo + ",'" + imagen.ImagenUrl + "')");
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void eliminar(int idArticulo)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from Imagenes where IdArticulo = @IdArticulo");
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminarImagen(int idImagen)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta($"delete from Imagenes where Id = {idImagen}");
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
