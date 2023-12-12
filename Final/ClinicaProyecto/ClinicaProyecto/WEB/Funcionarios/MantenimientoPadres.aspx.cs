using Negocios;
using System;
using System.Data;
using System.Web;
using System.Web.UI;

namespace WEB.Funcionarios
{
    public partial class MantenimientoPadres : System.Web.UI.Page
    {
        ClaseFuncionarios claseFuncionarios = new ClaseFuncionarios();
        ClasePadres clasePadres = new ClasePadres();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosPadres();
            }
            SiteMapProvider provider2 = SiteMap.Providers["XmlSiteMapProvider2"];
            SiteMapDataSource2.Provider = provider2;
            Menu2.DataBind();
        }

        private void CargarDatosPadres()
        {
            DataTable datosPadres = claseFuncionarios.ObtenerDatosPadres();

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




            NombreCompleto.Value = nombre;
            Identificacion.Value = cedula;
            Dirección.Value = direccion;
            Telefono.Value = telefono;
            CorreoElectronico.Value = correo;

            BtnAgregar.Visible = false;
            BtnModificar.Visible = true;
            Password.Disabled = true;
        }


        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            clasePadres.NombrePadre = NombreCompleto.Value;
            clasePadres.Cedula = Identificacion.Value;
            clasePadres.Direccion = Dirección.Value;
            clasePadres.Telefono = Telefono.Value;
            clasePadres.Email = CorreoElectronico.Value;

            clasePadres.ModificaPadres();





            NombreCompleto.Value = string.Empty;
            Identificacion.Value = string.Empty;
            Dirección.Value = string.Empty;
            Telefono.Value = string.Empty;
            CorreoElectronico.Value = string.Empty;


            CargarDatosPadres();
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //pasar los datos
                clasePadres.NombrePadre = NombreCompleto.Value;
                clasePadres.Cedula = Identificacion.Value;
                clasePadres.Direccion = Dirección.Value;
                clasePadres.Telefono = Telefono.Value;
                clasePadres.Email = CorreoElectronico.Value;
                clasePadres.Password = Password.Value;
                clasePadres.Estado = PadreActivo.Value;

                // Validar la contraseña
                if (!claseFuncionarios.ValidacionPassword(clasePadres.Password))
                {
                    MostrarAlerta("Contraseña inválida, debe tener entre 8 y 16 caracteres, al menos un digito, al menos una minuscula, al menos una mayuscula y al menos un caracter no alfanumerico");
                    return;
                }
                //validacion de email
                if (!claseFuncionarios.ValidacionEmail(clasePadres.Email))
                {
                    MostrarAlerta("Correo electrónico invalido.");
                    return;
                }


                ValidacionPadre();

                //escribir a bd
                clasePadres.AgregaPadres();


                NombreCompleto.Value = string.Empty;
                Identificacion.Value = string.Empty;
                Dirección.Value = string.Empty;
                Telefono.Value = string.Empty;
                CorreoElectronico.Value = string.Empty;
                Password.Value= string.Empty;


                CargarDatosPadres();


            }
            catch (Exception ex)
            {
                MostrarAlerta("Error de validación: " + ex.Message);
            }
        }
        public void ValidacionPadre()
        {
            try
            {
                string _NombrePadre = NombreCompleto.Value;
                string _Cedula = Identificacion.Value;
                string _Direccion = Dirección.Value;
                string _Telefono = Telefono.Value;
                string _Email = CorreoElectronico.Value;
                string _EstadoPadre = PadreActivo.Value;

                // Verificar si los campos están vacíos
                if (string.IsNullOrWhiteSpace(_NombrePadre) || string.IsNullOrWhiteSpace(_Cedula) || string.IsNullOrWhiteSpace(_Direccion) || string.IsNullOrWhiteSpace(_Telefono) || string.IsNullOrWhiteSpace(_Email) || string.IsNullOrWhiteSpace(_EstadoPadre))
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