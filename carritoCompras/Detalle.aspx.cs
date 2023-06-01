using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace carritoCompras
{
    public partial class Detalle : System.Web.UI.Page
    {
        public Articulo articulo { get; set; }
        public List<Imagen> imagenes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            imagenes = imagenNegocio.listar(id);

            articulo = articuloNegocio.listar(id);
            lblNombre.Text = articulo.Nombre;
            lblPrecio.Text += articulo.Precio;
            lblMarca.Text = articulo.Marca.Descripcion;
            lblCategoria.Text = articulo.Categoria.Descripcion;
            lblDescripcion.Text = articulo.Descripcion;
            cargarCarrousel();
        }
        public void cargarCarrousel()
        {
            if (imagenes.Count == 0)
            {
                Imagen aux = new Imagen();
                aux.ImagenUrl = "https://img.freepik.com/premium-vector/no-photo-available-vector-icon-default-image-symbol-picture-coming-soon-web-site-mobile-app_87543-10615.jpg?size=626&ext=jpg&ga=GA1.1.70386129.1685633354&semt=location_fest_v1";
                imagenes.Add(aux);
            }
            repImg.DataSource = imagenes;
            repImg.DataBind();
        }
    }
}