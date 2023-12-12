using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;


namespace Negocios
{
    public class ClaseServicios
    {
        //Variables
        string _NombreServicio;
        decimal _PrecioServicio;
        double _IVA;
        int _CodigoServicio;
        int _IdHijo;
        decimal _Costo;
        string _Fecha;
        string _Estado;

        

        Conection conexion = new Conection();

        //Propiedades
        public string NombreServicio { get => _NombreServicio; set => _NombreServicio = value; }
    
        public double IVA { get => _IVA; set => _IVA = value; }
        public DataTable TablaServicios { get => conexion.TablaServicios; }
        public int CodigoServicio { get => _CodigoServicio; set => _CodigoServicio = value; }
        public decimal PrecioServicio { get => _PrecioServicio; set => _PrecioServicio = value; }
        public int IdHijo { get => _IdHijo; set => _IdHijo = value; }
        public decimal Costo { get => _Costo; set => _Costo = value; }
        public string Fecha { get => _Fecha; set => _Fecha = value; }
        public string Estado { get => _Estado; set => _Estado = value; }

        //Metodos



        public void CalcularIVA()
        {
            //Calcular el IVA como un 2% del precio 
            _IVA = (double)PrecioServicio * 0.02;
        }

        public void AgregaServicios()
        {
            conexion.EscribirServicio(_NombreServicio,_PrecioServicio,_CodigoServicio);
        }


        public void LeerServicios()
        {
            conexion.LeerServicios();
        }

        public void ModificaServicios()
        {
            conexion.ModificarServicios(_NombreServicio,PrecioServicio,CodigoServicio);
        }

        public DataTable ObtenerDatosServicios()//cargar en gv
        {

            DataTable datosservicios = Conection.ObtenerDatosServicios();

            return datosservicios;
        }

        public DataTable ObtenerDatosServiciosSinCodigo()//cargar en gv
        {

            DataTable datosservicios = Conection.ObtenerDatosServiciosSinCodigo();

            return datosservicios;
        }


        public DataTable ObtenerDatosServiciosSoloCedula(string idhijo)//cargar en gv
        {

            DataTable datosserviciosbrindados = Conection.ObtenerDatosServiciosSoloCedula(idhijo);

            return datosserviciosbrindados;
        }


        public void EscribirServicioBrindado()
        {

            conexion.EscribirServicioBrindado(CodigoServicio,IdHijo,Costo,Fecha,Estado);
        }


        public void ModificarEstadoFactura(int codigo, int idhijo, decimal costo, string estado)
        {

            conexion.ModificarServiciosBrindados(codigo, idhijo,costo,estado);
        }

    }
}
