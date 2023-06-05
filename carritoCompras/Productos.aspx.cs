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
    public partial class Productos : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        public List<Articulo> articulos { get; set; }
        public List<Articulo> articulosCarrito { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = CheckBoxAvanzado.Checked;
            if (!IsPostBack)
            {
                if (Session["ArticulosCarrito"] == null)
                {
                    Session["ArticulosCarrito"] = new List<Articulo>();
                }
                CargarArticulos();
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }


        public void CargarArticulos()
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            Session.Add("ArticulosCarrito", articuloNegocio.listar());
            repArticulos.DataSource = Session["ArticulosCarrito"];
            repArticulos.DataBind();
        }

        protected void agregar_Click(object sender, EventArgs e)
        {
            string idArticulo = ((Button)sender).CommandArgument;
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo articulo = articuloNegocio.listar(Int32.Parse(idArticulo));//Traigo el articulo desde la DDBB

            List<Articulo> articulosCarrito = (List<Articulo>)Session["ArticulosCarrito"];//obtengo la lista desde la sesion
            articulosCarrito.Add(articulo); //Agrego un articulo a la lista
            Session["ArticulosCarrito"] = articulosCarrito; //actualizo la lista en la sesion
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            articulos = (List<Articulo>)Session["ArticulosCarrito"];
            List<Articulo> articulosFiltrados = articulos.FindAll(x => x.Nombre.ToLower().Contains(filtro.Text.ToLower()));
            repArticulos.DataSource = articulosFiltrados;
            repArticulos.DataBind();
        }

        protected void CheckBoxAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado=CheckBoxAvanzado.Checked;
            //CheckBoxAvanzado.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if(ddlCampo.SelectedItem.ToString()=="Número")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio= new ArticuloNegocio();
                repArticulos.DataSource=negocio.filtrar(ddlCampo.SelectedItem.ToString(),ddlCriterio.SelectedItem.ToString(),txtFiltroAvanzado.Text);
                repArticulos.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}