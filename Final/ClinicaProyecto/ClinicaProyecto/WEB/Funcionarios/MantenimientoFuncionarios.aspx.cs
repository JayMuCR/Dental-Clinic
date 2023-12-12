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
    public partial class Formulario_web3 : System.Web.UI.Page
    {
        ClaseFuncionarios claseFuncionarios = new ClaseFuncionarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosFuncionarios();
            }
            SiteMapProvider provider2 = SiteMap.Providers["XmlSiteMapProvider2"];
            SiteMapDataSource2.Provider = provider2;
            Menu2.DataBind();
        }


        private void CargarDatosFuncionarios()
        {
            DataTable datosFuncionarios = claseFuncionarios.ObtenerDatosFuncionarios();

            GridViewFuncionarios.DataSource = datosFuncionarios;
            GridViewFuncionarios.DataBind();
        }

        protected void GridViewFuncionarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice de la fila seleccionada
            int index = GridViewFuncionarios.SelectedIndex;

            // Obtener los datos de la fila seleccionada
            string nombre = GridViewFuncionarios.Rows[index].Cells[1].Text; ;
            string identificacion = GridViewFuncionarios.Rows[index].Cells[2].Text;
            string correo = GridViewFuncionarios.Rows[index].Cells[3].Text;
            string estado= GridViewFuncionarios.Rows[index].Cells[4].Text;


            NombreFuncionario.Value = nombre;
            IdentificacionFuncionario.Value = identificacion;
            Email.Value = correo;
            Estado.Value = estado;


            BtnAgregar.Visible = false;
            BtnModificar.Visible = true;
            Password.Disabled = true;
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            claseFuncionarios.NombreFuncionario = NombreFuncionario.Value;
            claseFuncionarios.IdFuncionario = IdentificacionFuncionario.Value;
            claseFuncionarios.Email = Email.Value;
            claseFuncionarios.Estado = Estado.Value;


            claseFuncionarios.ModificaFuncionarios();

            NombreFuncionario.Value = string.Empty;
            IdentificacionFuncionario.Value = string.Empty;
            Email.Value = string.Empty;
  

            CargarDatosFuncionarios();
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //pasar los datos
                claseFuncionarios.NombreFuncionario = NombreFuncionario.Value;
                claseFuncionarios.IdFuncionario = IdentificacionFuncionario.Value;
                claseFuncionarios.Password = Password.Value;
                claseFuncionarios.Email = Email.Value;
                claseFuncionarios.Estado = Estado.Value;

                // Validar la contraseña
                if (!claseFuncionarios.ValidacionPassword(claseFuncionarios.Password))
                {
                    MostrarAlerta("Contraseña inválida, debe tener entre 8 y 16 caracteres, al menos un digito, al menos una minuscula, al menos una mayuscula y al menos un caracter no alfanumerico");
                    return;
                }

                // Validar el correo electrónico
                if (!claseFuncionarios.ValidacionEmail(claseFuncionarios.Email))
                {
                    MostrarAlerta("Correo electrónico no válido.");
                    return;
                }

                ValidacionFuncionario();

                //escribir a bd
                claseFuncionarios.AgregaFuncionarios();

                CargarDatosFuncionarios();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error de validación: " + ex.Message);
            }
        }



        public void ValidacionFuncionario()
        {
            try
            {
                string _Email = Email.Value;
                string _Estado = Estado.Value;
                string _NombreFuncionario = NombreFuncionario.Value;
                string _IdFuncionario = IdentificacionFuncionario.Value;

                // Verificar si los campos están vacíos
                if (string.IsNullOrWhiteSpace(_Email) || string.IsNullOrWhiteSpace(_Estado) || string.IsNullOrWhiteSpace(_NombreFuncionario) || string.IsNullOrWhiteSpace(_IdFuncionario))
                {
                    MostrarAlerta("Todos los campos son obligatorios.");
                    return;
                }

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