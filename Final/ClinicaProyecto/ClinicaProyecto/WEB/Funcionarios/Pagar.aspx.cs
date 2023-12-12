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
    public partial class Formulario_web14 : System.Web.UI.Page
    {
        ClaseServicios claseServicios= new ClaseServicios();
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteMapProvider provider2 = SiteMap.Providers["XmlSiteMapProvider2"];
            SiteMapDataSource2.Provider = provider2;
            Menu2.DataBind();
        }


        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtServiciosBrindados= claseServicios.ObtenerDatosServiciosSoloCedula(CedulaHijo.Value);
                GridViewFacturas.DataSource = dtServiciosBrindados;
                GridViewFacturas.DataBind();



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


        protected void GridViewFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice de la fila seleccionada
            int index = GridViewFacturas.SelectedIndex;

            // Obtener los datos de la fila seleccionada

            string codigo = GridViewFacturas.Rows[index].Cells[1].Text;
            string costo = GridViewFacturas.Rows[index].Cells[3].Text;

            Costo.InnerText = costo;
            Codigo.InnerText = codigo;
        }

        protected void BtnPagar_Click(object sender, EventArgs e)
        {

            try
            {
                int codigo = Convert.ToInt32(Codigo.InnerText);
                int idHijo = Convert.ToInt32(CedulaHijo.Value);
                decimal costo = Convert.ToDecimal(Costo.InnerText);
                string estado = "Cancelado";

                claseServicios.ModificarEstadoFactura(codigo, idHijo, costo, estado);

                BtnBuscar_Click(sender, e);

                // Limpiar los elementos después de la operación exitosa
                Codigo.InnerText = string.Empty;
                Costo.InnerText = string.Empty;

                MostrarAlerta("Se ha realizado el pago exitosamente");
            }
            catch (FormatException)
            {
                MostrarAlerta("Error: La información no es válida para realizar el pago.");
            }
            catch (OverflowException)
            {
                MostrarAlerta("Error: Valor numérico fuera del rango permitido.");
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error inesperado: " + ex.Message);
            }


        }
    }
}