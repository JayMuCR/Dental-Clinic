using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class ClaseHijos
    {

        //Variables
        string _IdPadre;
        string _IdHijo;
        string _NombreCompleto;
        string _Sexo;
        string _FechaNac;

        Conection conexion = new Conection();

        //Propiedades
        public string IdPadre { get => _IdPadre; set => _IdPadre = value; }
        public string IdHijo { get => _IdHijo; set => _IdHijo = value; }
        public string Nombre { get => _NombreCompleto; set => _NombreCompleto = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public string FechaNac { get => _FechaNac; set => _FechaNac = value; }
        public DataTable TablaHijos { get => conexion.TablaHijos; }

        //Metodos

        public void AgregaHijos()
        {
            conexion.EscribirHijo(_IdPadre, _IdHijo, _NombreCompleto, _Sexo, _FechaNac);
        }

        // Método para calcular la edad utilizando la información de la clase
        public int CalcularEdad()
        {
           
            if (DateTime.TryParse(_FechaNac, out DateTime fechaNacimiento))
            {
                DateTime fechaActual = DateTime.Today;
                int edad = fechaActual.Year - fechaNacimiento.Year;

                // Ajustar la edad si aún no ha pasado el cumpleaños de este año
                if (fechaNacimiento.Date > fechaActual.AddYears(-edad))
                {
                    edad--;
                }

                return edad;
            }
            else
            {
     
                throw new ArgumentException("La fecha de nacimiento no es válida.");
            }
        }


        public void LeerHijos()
        {
            conexion.LeerHijos();
        }

        public void ModificaHijos()
        {
            conexion.ModificarHijos(_IdPadre,_IdHijo, _NombreCompleto, _Sexo,_FechaNac);
        }


        public DataTable ObtenerDatosHijos()//cargar en gv
        {

            DataTable datoshijos = Conection.ObtenerDatosHijos();

            return datoshijos;
        }

    }
}
