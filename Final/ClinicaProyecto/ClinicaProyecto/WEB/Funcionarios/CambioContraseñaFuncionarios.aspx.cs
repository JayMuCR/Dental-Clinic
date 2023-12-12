using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace WEB
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        ClaseFuncionarios claseFuncionarios = new ClaseFuncionarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            SiteMapProvider provider2 = SiteMap.Providers["XmlSiteMapProvider2"];
            SiteMapDataSource2.Provider = provider2;
            Menu2.DataBind();
        }





        // Método para llamar al procedimiento almacenado VerificarCredenciales
        private string VerificarCredenciales(string email, string nuevaContrasena)
        {
            string tipoUsuario = "No encontrado o usuario inactivo";

            try
            {
                using (SqlConnection connection = new SqlConnection("Server=JAY\\SQLEXPRESS;Database=ClinicaDental;Integrated Security=True;"))
                {
                    using (SqlCommand command = new SqlCommand("VerificarCredenciales", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", nuevaContrasena);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            tipoUsuario = reader["TipoUsuario"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error: " + ex.Message);
            }

            return tipoUsuario;
        }

        // Funcionario
        private void CambiarContraseñaFuncionario(string email, string nuevaContrasena)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=JAY\\SQLEXPRESS;Database=ClinicaDental;Integrated Security=True;"))
                {
                    string updateQuery = "UPDATE Funcionarios SET Password = @NuevaContrasena WHERE Email = @Email AND Estado = 'Activo'";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NuevaContrasena", nuevaContrasena);
                        command.Parameters.AddWithValue("@Email", email);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }


                MostrarAlerta("Contraseña cambiada exitosamente");
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error: " + ex.Message);
            }
        }

        // Padre
        private void CambiarContraseñaPadre(string email, string nuevaContrasena)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=JAY\\SQLEXPRESS;Database=ClinicaDental;Integrated Security=True;"))
                {
                    string updateQuery = "UPDATE Padres SET Password = @NuevaContrasena WHERE Email = @Email AND Estado = 'Activo'";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NuevaContrasena", nuevaContrasena);
                        command.Parameters.AddWithValue("@Email", email);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }


                MostrarAlerta("Contraseña cambiada exitosamente");
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error: " + ex.Message);
            }
        }

        //Alerta
        private void MostrarAlerta(string mensaje)
        {
            string script = $"<script>alert('{mensaje}');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alerta", script);
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string email = Email.Value.Trim();
                string nuevaContrasena = NuevaContrasena.Value.Trim();

                // Validar la contraseña
                if (!claseFuncionarios.ValidacionPassword(nuevaContrasena))
                {
                    MostrarAlerta("Contraseña inválida, debe tener entre 8 y 16 caracteres, al menos un digito, al menos una minuscula, al menos una mayuscula y al menos un caracter no alfanumerico");
                    return;
                }


                // Llamar al procedimiento almacenado para verificar las credenciales
                string tipoUsuario = VerificarCredenciales(email, nuevaContrasena);

                // Realizar acciones según el tipo de usuario
                if (tipoUsuario == "Funcionario")
                {
                    CambiarContraseñaFuncionario(email, nuevaContrasena);
                }
                else if (tipoUsuario == "Padre")
                {
                    CambiarContraseñaPadre(email, nuevaContrasena);
                }
                else
                {
                    MostrarAlerta("Error: No se ha encontrado un usuario con ese correo electronico. Verifiquelo e intentelo nuevamente.");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error: " + ex.Message);
            }
        }
    }
}