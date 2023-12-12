using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conection
    {

        //Variables
        string string_connection;
        SqlConnection connection;
        DataSet ds_resultados = new DataSet();

        //Propiedades
        public DataTable TablaServicios { get => ds_resultados.Tables[0]; }
        public DataTable TablaPadres { get => ds_resultados.Tables[0]; }
        public DataTable TablaHijos { get => ds_resultados.Tables[0]; }
        public DataTable TablaFuncionarios { get => ds_resultados.Tables[0]; }


        //Metodos


        //BD
        //Abrir conexion
        private void Abrir()
        {
            string_connection = "Server=JAY\\SQLEXPRESS;Database=ClinicaDental;Integrated Security=True;";
       

            connection = new SqlConnection(string_connection);
            connection.Open();

        } //Abrir


        //Cerrar conexion
        private void Cerrar()
        {
            connection.Close();
        }




        //Escritura en BD
        public void EscribirServicio(string nombre, decimal precio, int codigo)
        {
            SqlCommand instructionSQL;
            Abrir();

            instructionSQL = new SqlCommand("Insert into Servicios(NombreServicio, Precio, CodigoServicio) values (@Nombre, @Precio, @Codigo)", connection);

            //parametros

            instructionSQL.Parameters.AddWithValue("@Nombre", nombre);
            instructionSQL.Parameters.AddWithValue("@Precio", precio);
            instructionSQL.Parameters.AddWithValue("@Codigo", codigo);


            instructionSQL.ExecuteNonQuery();

            Cerrar();
        }


        public void EscribirServicioBrindado(int codigo, int idhijo, decimal costo, string fecha, string estado)
        {
            SqlCommand instructionSQL;
            Abrir();

            instructionSQL = new SqlCommand("Insert into ServiciosBrindados(CodigoServicio, IdHijo, Costo, Fecha, Estado) values (@Codigo, @IdHijo, @Costo, @Fecha, @Estado)", connection);

            //parametros

            instructionSQL.Parameters.AddWithValue("@Codigo", codigo);
            instructionSQL.Parameters.AddWithValue("@IdHijo", idhijo);
            instructionSQL.Parameters.AddWithValue("@Costo", costo);
            instructionSQL.Parameters.AddWithValue("@Fecha", fecha);
            instructionSQL.Parameters.AddWithValue("@Estado", estado);


            instructionSQL.ExecuteNonQuery();

            Cerrar();
        }


        public void EscribirPadre(string nombre, string cedula, string direccion, string telefono, string email, string password, string estado)
        {
            SqlCommand instructionSQL;
             Abrir();

            instructionSQL = new SqlCommand("Insert into Padres(NombreCompletoPadre, Cedula, Direccion, Telefono, Email, Password, Estado) values (@NombrePadre, @Cedula, @Direccion, @Telefono, @Email, @Password, @Estado)", connection);

            //parametros

            instructionSQL.Parameters.AddWithValue("@NombrePadre", nombre);
            instructionSQL.Parameters.AddWithValue("@Cedula", cedula);
            instructionSQL.Parameters.AddWithValue("@Direccion", direccion);
            instructionSQL.Parameters.AddWithValue("@Telefono", telefono);
            instructionSQL.Parameters.AddWithValue("@Email", email);
            instructionSQL.Parameters.AddWithValue("@Password", password);
            instructionSQL.Parameters.AddWithValue("@Estado", estado);

                
            instructionSQL.ExecuteNonQuery();

            Cerrar();
        }




        public void EscribirHijo(string idpadre, string idhijo, string nombrecompleto, string sexo, string fechanac)
        {
            SqlCommand instructionSQL;
            Abrir();

            instructionSQL = new SqlCommand("Insert into Hijos(IdPadre, IdHijo, NombreCompleto, Sexo, FechaNacimiento) values (@IdPadre, @IdHijo, @NombreCompleto,@Sexo,@FechaNac)", connection);

            //parametros

            instructionSQL.Parameters.AddWithValue("@IdPadre", idpadre);
            instructionSQL.Parameters.AddWithValue("@IdHijo", idhijo);
            instructionSQL.Parameters.AddWithValue("@NombreCompleto", nombrecompleto);
            instructionSQL.Parameters.AddWithValue("@Sexo", sexo);
            instructionSQL.Parameters.AddWithValue("@FechaNac", fechanac);


            instructionSQL.ExecuteNonQuery();

            Cerrar();
        }

        public void EscribirFuncionario(string nombrefuncionario, string idfuncionario,string email, string password, string estado)
        {
            SqlCommand instructionSQL;
            Abrir();

            instructionSQL = new SqlCommand("Insert into Funcionarios(NombreCompletoFuncionario, IdentificacionFuncionario, Email, Password, Estado) values (@NombreFuncionario,@IdFuncionario,@Email, @Password, @Estado)", connection);

            //parametros

            instructionSQL.Parameters.AddWithValue("@NombreFuncionario", nombrefuncionario);
            instructionSQL.Parameters.AddWithValue("@IdFuncionario", idfuncionario);
            instructionSQL.Parameters.AddWithValue("@Email", email);
            instructionSQL.Parameters.AddWithValue("@Password", password);
            instructionSQL.Parameters.AddWithValue("@Estado", estado);


            instructionSQL.ExecuteNonQuery();

            Cerrar();
        }


        //Lectura
        public void LeerServicios()
        {

            SqlDataAdapter sqlDA;
            SqlCommand instruccionSQL;
            Abrir();

            instruccionSQL = new SqlCommand("select NombreServicio, Precio, CodigoServicio from Servicios", connection);


            try
            {
                sqlDA = new SqlDataAdapter(instruccionSQL);
                sqlDA.Fill(ds_resultados);
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            Cerrar();
        }

        public void LeerPadres()
        {

            SqlDataAdapter sqlDA;
            SqlCommand instruccionSQL;
            Abrir();

            instruccionSQL = new SqlCommand("select NombreCompletoPadre, Cedula, Direccion, Telefono, Email, Password from Padres", connection);


            try
            {
                sqlDA = new SqlDataAdapter(instruccionSQL);
                sqlDA.Fill(ds_resultados);
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            Cerrar();
        }

        public void LeerHijos()
        {

            SqlDataAdapter sqlDA;
            SqlCommand instruccionSQL;
            Abrir();

            instruccionSQL = new SqlCommand("select IdPadre, IdHijo, NombreCompleto, Sexo, FechaNacimiento from Hijos", connection);


            try
            {
                sqlDA = new SqlDataAdapter(instruccionSQL);
                sqlDA.Fill(ds_resultados);
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            Cerrar();
        }

        public void LeerFuncionarios()
        {

            SqlDataAdapter sqlDA;
            SqlCommand instruccionSQL;
            Abrir();

            instruccionSQL = new SqlCommand("select NombreCompletoFuncionario, IdentificacionFuncionario, Email, Password, Estado from Funcionarios", connection);


            try
            {
                sqlDA = new SqlDataAdapter(instruccionSQL);
                sqlDA.Fill(ds_resultados);
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            Cerrar();
        }

        



        //Modificacion

        public void ModificarServicios(string nombre, decimal precio, int codigo)
        {
            SqlCommand instructionSQL;
            Abrir();
            
            instructionSQL = new SqlCommand("Update Servicios set NombreServicio= @nombre, Precio= @precio where CodigoServicio=@codigo", connection);

            //parametros

            instructionSQL.Parameters.AddWithValue("@Nombre", nombre);
            instructionSQL.Parameters.AddWithValue("@Precio", precio);
            instructionSQL.Parameters.AddWithValue("@Codigo", codigo);


            instructionSQL.ExecuteNonQuery();

            Cerrar();

        }

        public void ModificarPadres(string nombre, string cedula, string direccion, string telefono, string email)
        {


            SqlCommand instructionSQL;
            Abrir();
            instructionSQL = new SqlCommand("Update Padres set NombreCompletoPadre=@nombre, Direccion=@direccion, Telefono=@telefono, Email=@email where Cedula=@cedula", connection);

            // Parámetros
            instructionSQL.Parameters.AddWithValue("@nombre", nombre);
            instructionSQL.Parameters.AddWithValue("@cedula", cedula);
            instructionSQL.Parameters.AddWithValue("@direccion", direccion);
            instructionSQL.Parameters.AddWithValue("@telefono", telefono);
            instructionSQL.Parameters.AddWithValue("@email", email);
         

            instructionSQL.ExecuteNonQuery();


            Cerrar();
        }

        public void ModificarHijos(string idpadre, string idhijo, string nombrecompleto, string sexo, string fechanac)
        {



            SqlCommand instructionSQL;
            Abrir();
            instructionSQL = new SqlCommand("Update Hijos set IdPadre=@idpadre, NombreCompleto= @nombrecompleto, Sexo= @sexo, FechaNacimiento=@fechanac where IdHijo=@idhijo", connection);

            //parametros

            instructionSQL.Parameters.AddWithValue("@IdPadre", idpadre);
            instructionSQL.Parameters.AddWithValue("@IdHijo", idhijo);
            instructionSQL.Parameters.AddWithValue("@NombreCompleto", nombrecompleto);
            instructionSQL.Parameters.AddWithValue("@Sexo", sexo);
            instructionSQL.Parameters.AddWithValue("@FechaNac", fechanac);


            instructionSQL.ExecuteNonQuery();

            Cerrar();
        }

        public void ModificarFuncionarios(string nombrefuncionario, string idfuncionario, string email, string estado)
        {


            SqlCommand instructionSQL;
            Abrir();
            instructionSQL = new SqlCommand("Update Funcionarios set NombreCompletoFuncionario=@nombrefuncionario, Email= @email, Estado= @estado where IdentificacionFuncionario=@idfuncionario", connection);

            //parametros

            instructionSQL.Parameters.AddWithValue("@NombreFuncionario", nombrefuncionario);
            instructionSQL.Parameters.AddWithValue("@IdFuncionario", idfuncionario);
            instructionSQL.Parameters.AddWithValue("@Email", email);
            instructionSQL.Parameters.AddWithValue("@Estado", estado);


            instructionSQL.ExecuteNonQuery();

            Cerrar();

        }


        public void ModificarServiciosBrindados(int codigo, int idhijo, decimal costo, string estado)
        {

            SqlCommand instructionSQL;
            Abrir();

            instructionSQL = new SqlCommand("UPDATE ServiciosBrindados SET Estado=@Estado WHERE IdHijo=@IdHijo AND Costo=@Costo AND CodigoServicio=@Codigo", connection);

            // parametros
            instructionSQL.Parameters.AddWithValue("@Codigo", codigo);
            instructionSQL.Parameters.AddWithValue("@IdHijo", idhijo);
            instructionSQL.Parameters.AddWithValue("@Costo", costo);
            instructionSQL.Parameters.AddWithValue("@Estado", estado);

            instructionSQL.ExecuteNonQuery();

            Cerrar();
        }



        //Cambiar contra al padre
        public void CambiarPassword(string cedula, string password) {

            SqlCommand instructionSQL;
            Abrir();
            instructionSQL = new SqlCommand("Update Padres set Password= @password where Cedula=@cedula", connection);

            //parametros

            instructionSQL.Parameters.AddWithValue("@Password", password);
            instructionSQL.Parameters.AddWithValue("@cedula", cedula);



            instructionSQL.ExecuteNonQuery();

            Cerrar();

        }



        //Metodo para verificar si es usuario o padre
        public static string ObtenerTipoUsuario(string email, string password)
        {
            string tipoUsuario = null; //se crea esta variable para saber que tipo de usuario es
            string cedula = null; // variable para la cedula

            using (SqlConnection connection = new SqlConnection("Server=JAY\\SQLEXPRESS;Database=ClinicaDental;Integrated Security=True;"))
            {
                using (SqlCommand command = new SqlCommand("VerificarCredenciales", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    // con el correo y contrasena 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tipoUsuario = reader["TipoUsuario"].ToString();
                            cedula = reader["Cedula"].ToString();
                        }
                    }
                }
            }

            return tipoUsuario + ";" + cedula;// retorna el valor para la verificacion
        }


        //Cargar datos en gv
        public static DataTable ObtenerDatosPadres()
        {
            using (SqlConnection connection = new SqlConnection("Server=JAY\\SQLEXPRESS;Database=ClinicaDental;Integrated Security=True;"))
            {
                connection.Open();
                //El primero ejemplo Cedula es el nombre de la columna en la base de datos, el segundo ejemplo Cédula es el nombre como lo queremos ver en la tabla
                using (SqlCommand command = new SqlCommand("select NombreCompletoPadre AS NombreCompleto, Cedula, Direccion, Telefono, Email from Padres", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }



        public static DataTable ObtenerDatosServiciosSoloCedula(string idhijo)
        {
            using (SqlConnection connection = new SqlConnection("Server=JAY\\SQLEXPRESS;Database=ClinicaDental;Integrated Security=True;"))
            {
                connection.Open();
                // El primero ejemplo Cedula es el nombre de la columna en la base de datos, el segundo ejemplo Cédula es el nombre como lo queremos ver en la tabla
                using (SqlCommand command = new SqlCommand("SELECT CodigoServicio, IdHijo AS Cedula_Hijo, Costo, Fecha, Estado FROM ServiciosBrindados WHERE IdHijo = @idhijo AND Estado = 'Pendiente'", connection))
                {
                    // Add the parameter to the SqlCommand
                    command.Parameters.AddWithValue("@idhijo", idhijo);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }



        public static DataTable ObtenerDatosPadresSoloCedula(string cedula)
        {
            using (SqlConnection connection = new SqlConnection("Server=JAY\\SQLEXPRESS;Database=ClinicaDental;Integrated Security=True;"))
            {
                connection.Open();
                //El primero ejemplo Cedula es el nombre de la columna en la base de datos, el segundo ejemplo Cédula es el nombre como lo queremos ver en la tabla
                using (SqlCommand command = new SqlCommand("select NombreCompletoPadre AS NombreCompleto, Cedula, Direccion, Telefono, Email from Padres WHERE Cedula = @Cedula", connection))
                {
                    command.Parameters.AddWithValue("@Cedula",cedula);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }


        public static DataTable ObtenerDatosHijos()
        {
            using (SqlConnection connection = new SqlConnection("Server=JAY\\SQLEXPRESS;Database=ClinicaDental;Integrated Security=True;"))
            {
                connection.Open();
                //El primero ejemplo Cedula es el nombre de la columna en la base de datos, el segundo ejemplo Cédula es el nombre como lo queremos ver en la tabla
                using (SqlCommand command = new SqlCommand("select IdPadre, IdHijo, NombreCompleto, Sexo, FechaNacimiento as FechaNacimiento from Hijos", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public static DataTable ObtenerDatosFuncionarios()
        {
            using (SqlConnection connection = new SqlConnection("Server=JAY\\SQLEXPRESS;Database=ClinicaDental;Integrated Security=True;"))
            {
                connection.Open();
                //El primero ejemplo Cedula es el nombre de la columna en la base de datos, el segundo ejemplo Cédula es el nombre como lo queremos ver en la tabla
                using (SqlCommand command = new SqlCommand("select NombreCompletoFuncionario AS Nombre, IdentificacionFuncionario AS Identificacion, Email, Estado from Funcionarios", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public static DataTable ObtenerDatosServicios()
        {
            using (SqlConnection connection = new SqlConnection("Server=JAY\\SQLEXPRESS;Database=ClinicaDental;Integrated Security=True;"))
            {
                connection.Open();
                //El primero ejemplo Cedula es el nombre de la columna en la base de datos, el segundo ejemplo Cédula es el nombre como lo queremos ver en la tabla
                using (SqlCommand command = new SqlCommand("select NombreServicio, Precio, CodigoServicio from Servicios", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public static DataTable ObtenerDatosServiciosSinCodigo()
        {
            using (SqlConnection connection = new SqlConnection("Server=JAY\\SQLEXPRESS;Database=ClinicaDental;Integrated Security=True;"))
            {
                connection.Open();
                //El primero ejemplo Cedula es el nombre de la columna en la base de datos, el segundo ejemplo Cédula es el nombre como lo queremos ver en la tabla
                using (SqlCommand command = new SqlCommand("select NombreServicio, Precio from Servicios", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

    }
}
