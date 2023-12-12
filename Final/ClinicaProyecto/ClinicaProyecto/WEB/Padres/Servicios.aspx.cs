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
    public partial class Formulario_web16 : System.Web.UI.Page
    {
        ClaseServicios claseServicios = new ClaseServicios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosServicios();
            }
            SiteMapProvider provider1 = SiteMap.Providers["XmlSiteMapProvider"];
            SiteMapDataSource1.Provider = provider1;
            Menu1.DataBind();
        }
        private void CargarDatosServicios()
        {
            DataTable datosServicios = claseServicios.ObtenerDatosServicios();

            GvServicios.DataSource = datosServicios;
            GvServicios.DataBind();
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtServiciosBrindados = claseServicios.ObtenerDatosServiciosSoloCedula(CedulaHijo.Value);
                GvFactura.DataSource = dtServiciosBrindados;
                GvFactura.DataBind();



            }
            catch (Exception ex)
            {
                MostrarAlerta("Error de validación: " + ex.Message);
            }
        }

        private void MostrarAlerta(string mensaje)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", $"alert('{mensaje}');", true);
        }


    }
}