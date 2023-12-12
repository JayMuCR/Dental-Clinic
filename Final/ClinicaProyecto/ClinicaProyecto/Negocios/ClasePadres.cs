using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class ClasePadres
    {

        //Variables
        string _NombrePadre;
        string _Cedula;
        string _Direccion;
        string _Telefono;
        string _Email;
        string _Password;
        string _Estado;

        Conection conexion = new Conection();


        //Propiedades
        public string NombrePadre { get => _NombrePadre; set => _NombrePadre = value; }
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }

        public DataTable TablaPadres { get => conexion.TablaPadres; }
        public string Password { get => _Password; set => _Password = value; }
        public string Estado { get => _Estado; set => _Estado = value; }

        //Metodos


        public void AgregaPadres()
        {
            
            conexion.EscribirPadre(_NombrePadre,_Cedula,_Direccion,_Telefono,_Email,_Password,_Estado);
        }


        public void LeerPadres()
        {
            conexion.LeerPadres();
        }


        public void ModificaPadres()
        {
            conexion.ModificarPadres(_NombrePadre,_Cedula,_Direccion,_Telefono,_Email);
        }

        public void CambiarContra()
        {
            conexion.CambiarPassword(_Cedula,_Password);
        }

        public DataTable ObtenerDatosPadres()//cargar en gv
        {

            DataTable datospadres = Conection.ObtenerDatosPadres();

            return datospadres;
        }

        public DataTable ObtenerDatosPadresSoloCedula(string cedula)//cargar en gv
        {

            DataTable datospadres = Conection.ObtenerDatosPadresSoloCedula(cedula);

            return datospadres;
        }

    }
}
