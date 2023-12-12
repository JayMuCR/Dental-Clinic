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
    public partial class WebForm3 : System.Web.UI.Page
    {

        ClaseHijos claseHijos = new ClaseHijos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosHijos();
            }
            SiteMapProvider provider1 = SiteMap.Providers["XmlSiteMapProvider"];
            SiteMapDataSource1.Provider = provider1;
            Menu1.DataBind();
        }

        private void CargarDatosHijos()
        {
            DataTable datosHijos = claseHijos.ObtenerDatosHijos();

            GvHijos.DataSource = datosHijos;
            GvHijos.DataBind();
        }





        public void ValidacionHijo()
        {
            try
            {


                string _IdPadre = identificacionPadre.Value;
                string _IdHijo = identificacionNino.Value;
                string _NombreCompleto = Nombre.Value;
                string _Sexo = Sexo.Value;
                string _FechaNac = FechaNacimiento.Value;


                if (string.IsNullOrWhiteSpace(_IdPadre) || string.IsNullOrWhiteSpace(_IdHijo) || string.IsNullOrWhiteSpace(_NombreCompleto) || string.IsNullOrWhiteSpace(_Sexo) || string.IsNullOrWhiteSpace(_FechaNac))
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

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //pasar los datos
                claseHijos.IdPadre = identificacionPadre.Value;
                claseHijos.IdHijo = identificacionNino.Value;
                claseHijos.Nombre = Nombre.Value;
                claseHijos.Sexo = Sexo.Value;
                claseHijos.FechaNac = FechaNacimiento.Value;

                ValidacionHijo();

                //escribir a bd
                claseHijos.AgregaHijos();



                CargarDatosHijos();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error de validación: " + ex.Message);
            }
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            claseHijos.IdPadre = identificacionPadre.Value;
            claseHijos.IdHijo = identificacionNino.Value;
            claseHijos.Nombre = Nombre.Value;
            claseHijos.Sexo = Sexo.Value;
            claseHijos.FechaNac = FechaNacimiento.Value;


            claseHijos.ModificaHijos();

            identificacionPadre.Value = string.Empty;
            identificacionNino.Value = string.Empty;
            Nombre.Value = string.Empty;
            Sexo.Value = string.Empty;
            FechaNacimiento.Value = string.Empty;


            CargarDatosHijos();
        }

        protected void GvHijos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice de la fila seleccionada
            int index = GvHijos.SelectedIndex;

            // Obtener los datos de la fila seleccionada
            string idpadre = GvHijos.Rows[index].Cells[1].Text;
            string idhijo = GvHijos.Rows[index].Cells[2].Text;
            string nombre = GvHijos.Rows[index].Cells[3].Text;
            string sexo = GvHijos.Rows[index].Cells[4].Text;
            string fechanac = GvHijos.Rows[index].Cells[5].Text;




            identificacionPadre.Value = idpadre;
            identificacionNino.Value = idhijo;
            Nombre.Value = nombre;
            Sexo.Value = sexo;
            FechaNacimiento.Value = fechanac;

            BtnAgregar.Visible = false;
            BtnModificar.Visible = true;
        }
    }
}