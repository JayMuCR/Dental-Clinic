using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Negocios
{
    public class ClaseFuncionarios
    {
        //Variables
        string _Email;
        string _Password;
        string _Estado;
        string _NombreFuncionario;
        string _IdFuncionario;
        Conection conexion = new Conection();

        //Propiedades
        public string Email { get => _Email; set => _Email = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public DataTable TablaFuncionarios { get => conexion.TablaFuncionarios; }
        public string NombreFuncionario { get => _NombreFuncionario; set => _NombreFuncionario = value; }
        public string IdFuncionario { get => _IdFuncionario; set => _IdFuncionario = value; }

        //Metodos

        public void AgregaFuncionarios()//Escritura
        {
            conexion.EscribirFuncionario(_NombreFuncionario,_IdFuncionario,_Email, _Password, _Estado);
        }


        public void LeerFuncionarios()//Lectura
        {
            conexion.LeerFuncionarios();
        }

        public void ModificaFuncionarios()//Modificacion
        {
            conexion.ModificarFuncionarios(_NombreFuncionario,_IdFuncionario,_Email,_Estado);
        }

        public string ObtenerTipoUsuario(string email, string password)//Para saber el tipo de usuario
        {
            // Llama al procedimiento almacenado
            string tipoUsuario = Conection.ObtenerTipoUsuario(email, password);

            return tipoUsuario;
        }

        public DataTable ObtenerDatosPadres()//cargar en gv
        {
           
            DataTable datospadres = Conection.ObtenerDatosPadres();

            return datospadres;
        }

        public bool ValidacionPassword(string password)//validar patron de contra
        {
            // Expresión regular para validar la cadena
            string patron = @"^(?=.*\d)(?=.*[\u0021-\u002b\u003c-\u0040])(?=.*[A-Z])(?=.*[a-z])\S{8,16}$";

            // Comprobar si la cédula cumple con el patrón
            bool correcto = Regex.IsMatch(password, patron);

            return correcto;
        }

        public DataTable ObtenerDatosFuncionarios()//cargar en gv
        {

            DataTable datosfuncionarios = Conection.ObtenerDatosFuncionarios();

            return datosfuncionarios;
        }

        public bool ValidacionEmail(string email)//validar patron de contra
        {
            // Expresión regular para validar la cadena
            string patron = @"^(([^<>()\[\]\\.,;:\s@”]+(\.[^<>()\[\]\\.,;:\s@”]+)*)|(“.+”))@((\[[0–9]{1,3}\.[0–9]{1,3}\.[0–9]{1,3}\.[0–9]{1,3}])|
                            (([a-zA-Z\-0–9]+\.)+[a-zA-Z]{2,}))$";

            // Comprobar si la cédula cumple con el patrón
            bool correcto = Regex.IsMatch(email, patron);

            return true;
        }



    }
}
