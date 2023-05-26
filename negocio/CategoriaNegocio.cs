using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> categorias = new List<Categoria>();
            AccesoDatos acceso = new AccesoDatos();
            Categoria vacia = new Categoria();
            vacia.Id = 0;
            vacia.Descripcion = string.Empty;
            categorias.Add(vacia);

            try
            {
                acceso.setearConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
                acceso.ejecutarLectura();

                while (acceso.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)acceso.Lector["Id"];
                    aux.Descripcion = (string)acceso.Lector["Descripcion"];
                    categorias.Add(aux);
                }

                return categorias;
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
        public void agregar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta($"INSERT INTO CATEGORIAS VALUES ('{categoria.Descripcion}')");
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
    }
}
