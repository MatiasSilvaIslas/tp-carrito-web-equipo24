using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            if (imagenes.Count > 0)
                imgArticulo.ImageUrl = imagenes[0].ImagenUrl;
            else
                imgArticulo.ImageUrl = "https://www.redeszone.net/app/uploads-redeszone.net/2021/09/Error-404-01-e1633683457508.jpg";
        }
    }
}