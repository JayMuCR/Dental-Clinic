using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        ClasePadres clasePadres = new ClasePadres();
        ClaseFuncionarios claseFuncionarios = new ClaseFuncionarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosPadresCedula();
            }
            SiteMapProvider provider1 = SiteMap.Providers["XmlSiteMapProvider"];
            SiteMapDataSource1.Provider = provider1;
            Menu1.DataBind();
        }

        private void CargarDatosPadresCedula()
        {
            DataTable datosPadres = clasePadres.ObtenerDatosPadresSoloCedula(HttpContext.Current.Request.Cookies["Cedula"].Value);

            datospadres.DataSource = datosPadres;
            datospadres.DataBind();
        }

        protected void datospadres_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice de la fila seleccionada
            int index = datospadres.SelectedIndex;

            // Obtener los datos de la fila seleccionada
            string nombre = datospadres.Rows[index].Cells[1].Text;
            string cedula = datospadres.Rows[index].Cells[2].Text;
            string direccion = datospadres.Rows[index].Cells[3].Text;
            string telefono = datospadres.Rows[index].Cells[4].Text;
            string correo = datospadres.Rows[index].Cells[5].Text;


            nombreCompleto.Value = nombre;
            identificacion.Value = cedula;
            Direccion.Value = direccion;
            Telefono.Value = telefono;
            correoElectronico.Value = correo;

        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            // Obtén el correo electrónico ingresado por el usuario
            string email = correoElectronico.Value.Trim();

            // Validar el correo electrónico
            if (!claseFuncionarios.ValidacionEmail(email))
            {
                MostrarAlerta("Correo electrónico no válido.");
                return;
            }

            // Continuar con la modificación si la validación del correo es exitosa
            clasePadres.NombrePadre = nombreCompleto.Value;
            clasePadres.Cedula = identificacion.Value;
            clasePadres.Direccion = Direccion.Value;
            clasePadres.Telefono = Telefono.Value;
            clasePadres.Email = correoElectronico.Value;

            clasePadres.ModificaPadres();

            // Limpiar los campos después de la modificación
            nombreCompleto.Value = string.Empty;
            identificacion.Value = string.Empty;
            Direccion.Value = string.Empty;
            Telefono.Value = string.Empty;
            correoElectronico.Value = string.Empty;

            // Recargar los datos después de la modificación
            CargarDatosPadresCedula();
        }


        private void MostrarAlerta(string mensaje)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{mensaje}');", true);
        }

    }
}