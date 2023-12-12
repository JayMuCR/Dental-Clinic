using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class Formulario_web18 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Leer el valor desde el archivo web.config
            string acercaDe1 = ConfigurationManager.AppSettings["AcercaDe1"];
            string acercaDe2 = ConfigurationManager.AppSettings["AcercaDe2"];
            string acercaDe3 = ConfigurationManager.AppSettings["AcercaDe3"];

            // Mostrar el valor en un control Label
            lblAcercaDe1.Text = acercaDe1;
            lblAcercaDe2.Text = acercaDe2;
            lblAcercaDe3.Text = acercaDe3;

            SiteMapProvider provider2 = SiteMap.Providers["XmlSiteMapProvider2"];
            SiteMapDataSource2.Provider = provider2;
            Menu2.DataBind();
        }
    }
}