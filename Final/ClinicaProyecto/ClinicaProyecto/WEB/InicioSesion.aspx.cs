using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Negocios;

namespace WEB
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            ClaseFuncionarios claseFuncionarios = new ClaseFuncionarios();
            string []datos = claseFuncionarios.ObtenerTipoUsuario(Login.UserName, Login.Password).Split(';');

           
            if (datos[0] == "Funcionario" || datos[0] == "Padre")
            {
                e.Authenticated = true;
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, Login.UserName, DateTime.Now, DateTime.Now.AddMinutes(10), true, "1");
                string eticket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie authcookie = new HttpCookie(FormsAuthentication.FormsCookieName, eticket);
                authcookie.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(authcookie);

                HttpCookie cookiecedula = new HttpCookie("Cedula", datos[1]);
                HttpContext.Current.Response.Cookies.Add(cookiecedula);

                if (datos[0] == "Funcionario")
                {
                    Response.Redirect("Funcionarios/PrincipalInicioFuncionarios.aspx");
                }
                else if (datos[0] == "Padre")
                {
                    Response.Redirect("Padres/PrincipalInicio.aspx");
                }
            }
            else
            {
                e.Authenticated = false;
            }
        }
    }
}