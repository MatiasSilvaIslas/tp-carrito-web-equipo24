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
        public List<Articulo> Articulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ArticulosCarrito"] != null)
                {
                  Articulos = (List<Articulo>)Session["ArticulosCarrito"];
                    repArticulos.DataSource = Articulos;
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
            Articulos = (List<Articulo>)Session["ArticulosCarrito"];
            if (Articulos != null)
            {
                Articulo articuloEliminar = Articulos.Find(a => a.Id == articulo.Id);
                if (articuloEliminar != null)
                {
                    Articulos.Remove(articuloEliminar);
                    Session["ArticulosCarrito"] = Articulos;
                    repArticulos.DataSource = Articulos;
                    repArticulos.DataBind();
                    cargarPrecio();
                }
            }
        }

        public void cargarPrecio()
        {
            decimal total = 0;
            Articulos = (List<Articulo>)Session["ArticulosCarrito"];
            if (Articulos != null)
            {
                
                foreach (Articulo articulo in Articulos)
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