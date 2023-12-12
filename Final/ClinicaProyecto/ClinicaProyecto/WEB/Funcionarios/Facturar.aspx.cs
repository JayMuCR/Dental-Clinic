using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        ClaseServicios claseServicios = new ClaseServicios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosServicios();
            }
            SiteMapProvider provider2 = SiteMap.Providers["XmlSiteMapProvider2"];
            SiteMapDataSource2.Provider = provider2;
            Menu2.DataBind();
        }


        private void CargarDatosServicios()
        {
            DataTable datosServicios = claseServicios.ObtenerDatosServicios();

            GvServicios.DataSource = datosServicios;
            GvServicios.DataBind();
        }

        protected void GvServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice de la fila seleccionada
            int index = GvServicios.SelectedIndex;

            // Obtener los datos de la fila seleccionada
            
            string codigo = GvServicios.Rows[index].Cells[3].Text;
            string costo = GvServicios.Rows[index].Cells[2].Text;

            Costo.Value = costo;
            Codigo.Value = codigo;

        }
 
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {




            //Este datetime es para utilizar la fecha con la fecha de hoy
            DateTime fechaActual = DateTime.Now;
            try
            {
                // Aquí se le agrega el IVA
                decimal costoOriginal = Convert.ToDecimal(Costo.Value);

                // Calcula el nuevo costo con un 2% de impuestos
                decimal costoConImpuestos = costoOriginal * 1.02m; // Change 0.02m to 1.02m


                // Asigna el nuevo costo a la propiedad Costo de la claseServicios
                claseServicios.Costo = costoConImpuestos;

                // Pasar los datos
                claseServicios.CodigoServicio = Convert.ToInt32(Codigo.Value);
                claseServicios.IdHijo = Convert.ToInt32(Cedula.Value);
                claseServicios.Costo = costoConImpuestos;
                claseServicios.Fecha = fechaActual.ToString("yyyy-MM-dd");
                claseServicios.Estado= "Pendiente";

                //escribir a bd
                claseServicios.EscribirServicioBrindado();

                Codigo.Value = string.Empty;
                Costo.Value = string.Empty;
                MostrarAlerta("Se ha agregado el item a la factura.");

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