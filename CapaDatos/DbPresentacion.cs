using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class DbPresentacion :DbConnection
    {

        private int _idpresentacion;
        private string _nombre;
        private string _descripcion;
        private string _textobuscar;


        public int Idpresentacion { get => _idpresentacion; set => _idpresentacion = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Textobuscar { get => _textobuscar; set => _textobuscar = value; }



        public DbPresentacion()
        {


        }

        public DbPresentacion(int idpresentacion, string nombre, string descripcion, string textobuscar)
        {
            this.Idpresentacion = idpresentacion;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this._textobuscar = textobuscar;

        }

        public string Insertar(DbPresentacion Presentacion)
        {
            string rpta = "";
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try

                    {
                        command.Connection = connection;
                        command.CommandText = "spinsertar_presentacion";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdPresentacion = new SqlParameter();
                        ParIdPresentacion.ParameterName = "@idpresentacion";
                        ParIdPresentacion.SqlDbType = SqlDbType.Int;
                        ParIdPresentacion.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIdPresentacion);


                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 50;
                        ParNombre.Value = Presentacion.Nombre;
                        command.Parameters.Add(ParNombre);


                        SqlParameter ParDescripcion = new SqlParameter();
                        ParDescripcion.ParameterName = "@descripcion";
                        ParDescripcion.SqlDbType = SqlDbType.VarChar;
                        ParDescripcion.Size = 256;
                        ParDescripcion.Value = Presentacion.Descripcion;
                        command.Parameters.Add(ParDescripcion);

                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESO EL REGISTRO";




                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally { if (connection.State == ConnectionState.Open) connection.Close(); }


                }
            }
            return rpta;
        }


        //Editar

        public string Editar(DbPresentacion Presentacion)
        {
            string rpta = "";
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try

                    {
                        command.Connection = connection;
                        command.CommandText = "speditar_presentacion";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdpresentacion = new SqlParameter();
                        ParIdpresentacion.ParameterName = "@idpresentacion";
                        ParIdpresentacion.SqlDbType = SqlDbType.Int;
                        ParIdpresentacion.Value = Presentacion.Idpresentacion;
                        command.Parameters.Add(ParIdpresentacion);


                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 50;
                        ParNombre.Value = Presentacion.Nombre;
                        command.Parameters.Add(ParNombre);


                        SqlParameter ParDescripcion = new SqlParameter();
                        ParDescripcion.ParameterName = "@descripcion";
                        ParDescripcion.SqlDbType = SqlDbType.VarChar;
                        ParDescripcion.Size = 256;
                        ParDescripcion.Value = Presentacion.Descripcion;
                        command.Parameters.Add(ParDescripcion);

                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE ACTUALIZO EL REGISTRO";




                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally { if (connection.State == ConnectionState.Open) connection.Close(); }


                }
            }
            return rpta;
        }


        //METODO ELIMINAR
        public string Eliminar(DbPresentacion Presentacion)
        {
            string rpta = "";
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try

                    {
                        command.Connection = connection;
                        command.CommandText = "speliminar_presentacion";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdpresentacion = new SqlParameter();
                        ParIdpresentacion.ParameterName = "@idpresentacion";
                        ParIdpresentacion.SqlDbType = SqlDbType.Int;
                        ParIdpresentacion.Value = Presentacion.Idpresentacion;
                        command.Parameters.Add(ParIdpresentacion);


                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE ELIMINO EL REGISTRO";




                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally { if (connection.State == ConnectionState.Open) connection.Close(); }


                }
            }
            return rpta;
        }

        //Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("presentacion");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {

                        command.Connection = connection;
                        command.CommandText = "spmostrar_presentacion";
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter sqlDat = new SqlDataAdapter(command);
                        sqlDat.Fill(DtResultado);

                    }
                    catch (Exception)
                    {
                        DtResultado = null;
                    }

                }
            }
            return DtResultado;
        }

        //Metodo BuscarNombre
        public DataTable BuscarNombre(DbPresentacion Presentacion)
        {
            DataTable DtResultado = new DataTable("presentacion");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {

                        command.Connection = connection;
                        command.CommandText = "spbuscar_Presentacion";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.NVarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Presentacion.Textobuscar;
                        command.Parameters.Add(ParTextoBuscar);

                        SqlDataAdapter sqlDat = new SqlDataAdapter(command);
                        sqlDat.Fill(DtResultado);

                    }
                    catch (Exception)
                    {
                        DtResultado = null;
                    }

                }
            }
            return DtResultado;
        }

    }
}
