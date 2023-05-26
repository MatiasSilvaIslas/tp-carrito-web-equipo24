using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {


        public List<Marca> listar()
        {
            List<Marca> marcas = new List<Marca>();
            AccesoDatos acceso = new AccesoDatos();
            Marca vacia = new Marca();
            vacia.Id = 0;
            vacia.Descripcion = string.Empty;
            marcas.Add(vacia);

            try
            {
                acceso.setearConsulta("SELECT Id, Descripcion FROM MARCAS");
                acceso.ejecutarLectura();

                while (acceso.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)acceso.Lector["Id"];
                    aux.Descripcion = (string)acceso.Lector["Descripcion"];
                    marcas.Add(aux);
                }

                return marcas;
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

        public void agregar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta($"INSERT INTO MARCAS VALUES ('{marca.Descripcion}')");
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
        /*
         * listar
         * editar
         * crear
         * eliminar
         */
    }
}
