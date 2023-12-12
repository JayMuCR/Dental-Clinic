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
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        ClaseHijos claseHijos = new ClaseHijos();
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteMapProvider provider1 = SiteMap.Providers["XmlSiteMapProvider"];
            SiteMapDataSource1.Provider = provider1;
            Menu1.DataBind();
        }



        protected void btnRedireccionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Acercade.aspx");
            
        }
        protected void btnRedireccionarServicios_Click(object sender, EventArgs e)
        {
            Response.Redirect("Servicios.aspx");
        }
        protected void btnRedireccionarDatos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ActualizacionDatos.aspx");
        }


        protected void btnRedireccionarContraseña_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambioContraseña.aspx");
        }

        protected void btnRedireccionarHijo_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoHijo.aspx");
        }
    }
}