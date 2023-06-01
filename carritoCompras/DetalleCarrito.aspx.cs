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
            if (!IsPostBack)
            {
                if (Session["ArticulosCarrito"] != null)
                {
                    List<Articulo> articulosCarrito = (List<Articulo>)Session["ArticulosCarrito"];
                    repArticulos.DataSource = articulosCarrito;
                    repArticulos.DataBind();
                    cargarPrecio();
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string idArticulo = ((Button)sender).CommandArgument;
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo articulo = articuloNegocio.listar(Int32.Parse(idArticulo));
            List<Articulo> articulosCarrito = (List<Articulo>)Session["ArticulosCarrito"];
            if (articulosCarrito != null)
            {
                Articulo articuloEliminar = articulosCarrito.Find(a => a.Id == articulo.Id);
                if (articuloEliminar != null)
                {
                    articulosCarrito.Remove(articuloEliminar);
                    Session["ArticulosCarrito"] = articulosCarrito;
                    repArticulos.DataSource = articulosCarrito;
                    repArticulos.DataBind();
                    cargarPrecio();
                }
            }
        }

        public void cargarPrecio()
        {
            decimal total = 0;
            List<Articulo> articulosCarrito = (List<Articulo>)Session["ArticulosCarrito"];
            if (articulosCarrito != null)
            {
                
                foreach (Articulo articulo in articulosCarrito)
                {
                    total += articulo.Precio;
                }
                lblTotal.Text = "Total $" + total.ToString();
            }
            else
            {
                lblTotal.Text = "Total $" + total.ToString();
            }
        }

    }
}