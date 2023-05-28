﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace carritoCompras
{
    public partial class home : System.Web.UI.Page
    {
        public List<Articulo> articulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            articulos = articuloNegocio.listar();
            if (!IsPostBack)
            {
                repArticulos.DataSource = articulos;
                repArticulos.DataBind();
            }
        }
        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }

    }
}