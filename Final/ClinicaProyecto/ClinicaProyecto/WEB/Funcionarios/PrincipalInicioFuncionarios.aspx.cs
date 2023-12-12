using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ClaseHijos claseHijos = new ClaseHijos();
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteMapProvider provider2 = SiteMap.Providers["XmlSiteMapProvider2"];
            SiteMapDataSource2.Provider = provider2;
            Menu2.DataBind();
        }

        protected void btnRedireccionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AcercadeFuncionarios.aspx");
        }

        protected void btnRedireccionarServicios_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoServicios.aspx");
        }

        protected void btnRedireccionarContraseña_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambioContraseñaFuncionarios.aspx");
        }

        protected void btnRedireccionarFacturacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Facturar.aspx");
        }

        protected void btnRedireccionarFuncionarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoFuncionarios.aspx");
        }

        protected void btnRedireccionarHijos_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoNiño.aspx");
        }

        protected void btnRedireccionarPadres_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoPadres.aspx");
        }

        protected void btnRedireccionarPagar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pagar.aspx");
        }
    }
}