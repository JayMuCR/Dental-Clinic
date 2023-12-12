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
    public partial class Formulario_web4 : System.Web.UI.Page
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
            string nombre = GvServicios.Rows[index].Cells[1].Text;
            string codigo = GvServicios.Rows[index].Cells[3].Text;
            string costo = GvServicios.Rows[index].Cells[2].Text;





            Servicio.Value = nombre;
            Codigo.Value = codigo;
            Costo.Value = costo;


            BtnAgregar.Visible = false;
            BtnModificar.Visible = true;
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            claseServicios.NombreServicio = Servicio.Value;
            claseServicios.CodigoServicio= Convert.ToInt32(Codigo.Value);
            claseServicios.PrecioServicio= Convert.ToDecimal(Costo.Value);


            claseServicios.ModificaServicios();

            Servicio.Value = string.Empty;
            Codigo.Value = string.Empty;
            Costo.Value = string.Empty;


            CargarDatosServicios();
        }

        private void MostrarAlerta(string mensaje)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", $"alert('{mensaje}');", true);
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //pasar los datos
                claseServicios.NombreServicio = Servicio.Value;
                claseServicios.CodigoServicio = Convert.ToInt32(Codigo.Value);
                claseServicios.PrecioServicio = Convert.ToDecimal(Costo.Value);
           

                ValidacionServicio();

                //escribir a bd
                claseServicios.AgregaServicios();

                CargarDatosServicios();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error de validación: " + ex.Message);
            }
        }

        public void ValidacionServicio()
        {
            try
            {        // Additional validation for new fields
                string _NombreServicio = Servicio.Value;
                decimal _PrecioServicio = Convert.ToDecimal(Costo.Value);
                int _CodigoServicio= Convert.ToInt32(Codigo.Value);

                // Validate _NombreServicio
                if (string.IsNullOrWhiteSpace(_NombreServicio))
                {
                    MostrarAlerta("El nombre del servicio es obligatorio.");
                    return;
                }

                // Validate _PrecioServicio
                if (!decimal.TryParse(Costo.Value, out _PrecioServicio))
                {
                    MostrarAlerta("El precio del servicio debe ser un número válido.");
                    return;
                }


                // Validate _CodigoServicio
                if (!int.TryParse(Codigo.Value, out _CodigoServicio))
                {
                    MostrarAlerta("El código del servicio debe ser un número entero válido.");
                    return;
                }

            }
            catch (Exception ex)
            {
                MostrarAlerta("Error de validación: " + ex.Message);
            }
        }



    }
}