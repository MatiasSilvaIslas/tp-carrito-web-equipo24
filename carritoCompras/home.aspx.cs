using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace carritoCompras
{
    //public partial class home : System.Web.UI.Page
    //{
    //    public List<Articulo> articulos { get; set; }
    //    //private List<Articulo> articulosCarrito;
    //    protected void Page_Load(object sender, EventArgs e)
    //    {
    //        ArticuloNegocio articuloNegocio = new ArticuloNegocio();
    //        articulos = articuloNegocio.listar();
    //        Session["ArticulosCarrito"] = new List<Articulo>(); // Inicializar la lista en la sesión

    //        if (!IsPostBack)
    //        {
    //            repArticulos.DataSource = articulos;
    //            repArticulos.DataBind();
    //        }

    //    }

    //    protected void agregar_Click(object sender, EventArgs e)
    //    {
    //        string idArticulo = ((Button)sender).CommandArgument;
    //        ArticuloNegocio articuloNegocio = new ArticuloNegocio();
    //        Articulo articulo = new Articulo();
    //        articulo = articuloNegocio.listar(Int32.Parse(idArticulo));

    //        List<Articulo> articulosCarrito = (List<Articulo>)Session["ArticulosCarrito"];

    //        // Agregar el artículo a la lista del carrito
    //        articulosCarrito.Add(articulo);

    //        // Actualizar la lista en la sesión
    //        Session["ArticulosCarrito"] = articulosCarrito;
    //    }

    //    protected void btnPrueba_Click(object sender, EventArgs e)
    //    {
    //        List<Articulo> ac = (List<Articulo>)Session["ArticulosCarrito"];

    //        lblCantidad.Text = ac.Count.ToString();
    //    }
    //}
    public partial class home : System.Web.UI.Page
    {
        public List<Articulo> articulos { get; set; }
        public List<Articulo> articulosCarrito { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarArticulos();
            }
        }

        protected void CargarArticulos()
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            articulos = articuloNegocio.listar();
            Session["ArticulosCarrito"] = new List<Articulo>();

            repArticulos.DataSource = articulos;
            repArticulos.DataBind();
        }

        protected void agregar_Click(object sender, EventArgs e)
        {
            string idArticulo = ((Button)sender).CommandArgument;
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo articulo = articuloNegocio.listar(Int32.Parse(idArticulo));//Traigo el articulo desde la DDBB

            List<Articulo> articulosCarrito = (List<Articulo>)Session["ArticulosCarrito"];//obtengo la lista desde la sesion

            // Agregar el artículo a la lista del carrito
            articulosCarrito.Add(articulo); //Agrego un articulo a la lista

            // Actualizar la lista en la sesión
            Session["ArticulosCarrito"] = articulosCarrito; //actualizo la lista en la sesion

        }

    }
}