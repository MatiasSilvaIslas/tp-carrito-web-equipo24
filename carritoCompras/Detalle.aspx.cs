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
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            
            articulo = articuloNegocio.listar(id);
            lblNombre.Text = articulo.Nombre;
            lblPrecio.Text += articulo.Precio;
            lblMarca.Text = articulo.Marca.Descripcion;
            lblCategoria.Text = articulo.Categoria.Descripcion;
            lblDescripcion.Text = articulo.Descripcion;
        }
    }
}