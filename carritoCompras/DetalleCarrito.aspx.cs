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
    public partial class DetalleCarrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ArticulosCarrito"] != null)
            {
                decimal total = 0;
                List<Articulo> articulosCarrito = (List<Articulo>)Session["ArticulosCarrito"];
                //gvCarrito.DataSource = articulosCarrito;
                //gvCarrito.DataBind();
                repArticulos.DataSource = articulosCarrito;
                repArticulos.DataBind();
                foreach (Articulo articulo in articulosCarrito)
                {
                    total += articulo.Precio;
                }
                lblTotal.Text += total.ToString();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}