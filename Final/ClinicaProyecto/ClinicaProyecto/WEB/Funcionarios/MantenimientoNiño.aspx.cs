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
    public partial class Formulario_web12 : System.Web.UI.Page
    {

        ClaseHijos ClaseHijos = new ClaseHijos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosHijos();
            }
            SiteMapProvider provider2 = SiteMap.Providers["XmlSiteMapProvider2"];
            SiteMapDataSource2.Provider = provider2;
            Menu2.DataBind();
        }



        private void CargarDatosHijos()
        {
            DataTable datosHijos = ClaseHijos.ObtenerDatosHijos();

            GvHijos.DataSource = datosHijos;
            GvHijos.DataBind();
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

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            ClaseHijos.IdPadre = identificacionPadre.Value;
            ClaseHijos.IdHijo = identificacionNino.Value;
            ClaseHijos.Nombre = Nombre.Value;
            ClaseHijos.Sexo = Sexo.Value;
            ClaseHijos.FechaNac = FechaNacimiento.Value;


            ClaseHijos.ModificaHijos();

            identificacionPadre.Value = string.Empty;
            identificacionNino.Value = string.Empty;
            Nombre.Value = string.Empty;
            Sexo.Value = string.Empty;
            FechaNacimiento.Value = string.Empty;


            CargarDatosHijos();
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //pasar los datos
                ClaseHijos.IdPadre = identificacionPadre.Value;
                ClaseHijos.IdHijo = identificacionNino.Value;
                ClaseHijos.Nombre = Nombre.Value;
                ClaseHijos.Sexo = Sexo.Value;
                ClaseHijos.FechaNac = FechaNacimiento.Value;

                ValidacionHijo();

                //escribir a bd
                ClaseHijos.AgregaHijos();



                CargarDatosHijos();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error de validación: " + ex.Message);
            }
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



    }
}