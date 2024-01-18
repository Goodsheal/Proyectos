using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace CapaDatos
{
    public class DbArticulo : DbConnection
    {
        private int _Idarticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Imagen;
        private int _Idcategoria;
        private int _Idpresentacion;
        private string _TextoBuscar;

        public int Idarticulo
        {
            get { return _Idarticulo; }
            set { _Idarticulo = value; }
        }

        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }


        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public byte[] Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }
        public int Idcategoria
        {
            get { return _Idcategoria; }
            set { _Idcategoria = value; }
        }

        public int Idpresentacion
        {
            get { return _Idpresentacion; }
            set { _Idpresentacion = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        public DbArticulo()
        {

        }

        public DbArticulo(int idarticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion, string textobuscar)
        {
            this.Idarticulo = idarticulo;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.Idcategoria = idcategoria;
            this.Idpresentacion = idpresentacion;
            this.TextoBuscar = textobuscar;

        }

        public string Insertar(DbArticulo Articulo)
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
                        command.CommandText = "spinsertar_articulo";
                        command.CommandType = CommandType.StoredProcedure;
                       
                        SqlParameter ParIdarticulo = new SqlParameter();
                        ParIdarticulo.ParameterName = "@idarticulo";
                        ParIdarticulo.SqlDbType = SqlDbType.Int;
                        ParIdarticulo.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIdarticulo);

                        SqlParameter ParCodigo = new SqlParameter();
                        ParCodigo.ParameterName = "@codigo";
                        ParCodigo.SqlDbType = SqlDbType.VarChar;
                        ParCodigo.Size = 50;
                        ParCodigo.Value = Articulo.Codigo;
                        command.Parameters.Add(ParCodigo);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 50;
                        ParNombre.Value = Articulo.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParDescripcion = new SqlParameter();
                        ParDescripcion.ParameterName = "@descripcion";
                        ParDescripcion.SqlDbType = SqlDbType.VarChar;
                        ParDescripcion.Size = 1024;
                        ParDescripcion.Value = Articulo.Descripcion;
                        command.Parameters.Add(ParDescripcion);

                        SqlParameter ParImagen = new SqlParameter();
                        ParImagen.ParameterName = "@imagen";
                        ParImagen.SqlDbType = SqlDbType.Image;
                        ParImagen.Value = Articulo.Imagen;
                        command.Parameters.Add(ParImagen);

                        SqlParameter ParIdcategoria = new SqlParameter();
                        ParIdcategoria.ParameterName = "@idcategoria";
                        ParIdcategoria.SqlDbType = SqlDbType.VarChar;
                        ParIdcategoria.Value = Articulo.Idcategoria;
                        command.Parameters.Add(ParIdcategoria);

                        SqlParameter ParIdpresentacion = new SqlParameter();
                        ParIdpresentacion.ParameterName = "@idpresentacion";
                        ParIdpresentacion.SqlDbType = SqlDbType.VarChar;
                        ParIdpresentacion.Value = Articulo.Idpresentacion;
                        command.Parameters.Add(ParIdpresentacion);

                        //Ejecutamos nuestro comando

                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESO EL REGISTRO";


                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open) connection.Close();
                    }
                }

            }

            return rpta;

        }


        public string Editar(DbArticulo Articulo)
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
                        command.CommandText = "speditar_articulo";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdarticulo = new SqlParameter();
                        ParIdarticulo.ParameterName = "@idarticulo";
                        ParIdarticulo.SqlDbType = SqlDbType.Int;
                        ParIdarticulo.Value = Articulo.Idarticulo;
                        command.Parameters.Add(ParIdarticulo);

                        SqlParameter ParCodigo = new SqlParameter();
                        ParCodigo.ParameterName = "@codigo";
                        ParCodigo.SqlDbType = SqlDbType.VarChar;
                        ParCodigo.Size = 50;
                        ParCodigo.Value = Articulo.Codigo;
                        command.Parameters.Add(ParCodigo);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 50;
                        ParNombre.Value = Articulo.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParDescripcion = new SqlParameter();
                        ParDescripcion.ParameterName = "@descripcion";
                        ParDescripcion.SqlDbType = SqlDbType.VarChar;
                        ParDescripcion.Size = 1024;
                        ParDescripcion.Value = Articulo.Descripcion;
                        command.Parameters.Add(ParDescripcion);

                        SqlParameter ParImagen = new SqlParameter();
                        ParImagen.ParameterName = "@imagen";
                        ParImagen.SqlDbType = SqlDbType.Image;
                        ParImagen.Value = Articulo.Imagen;
                        command.Parameters.Add(ParImagen);

                        SqlParameter ParIdcategoria = new SqlParameter();
                        ParIdcategoria.ParameterName = "@idcategoria";
                        ParIdcategoria.SqlDbType = SqlDbType.VarChar;
                        ParIdcategoria.Value = Articulo.Idcategoria;
                        command.Parameters.Add(ParIdcategoria);

                        SqlParameter ParIdpresentacion = new SqlParameter();
                        ParIdpresentacion.ParameterName = "@idpresentacion";
                        ParIdpresentacion.SqlDbType = SqlDbType.VarChar;
                        ParIdpresentacion.Value = Articulo.Idpresentacion;
                        command.Parameters.Add(ParIdpresentacion);


                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE MODIFICAO EL REGISTRO";


                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open) connection.Close();
                    }
                }

            }

            return rpta;

        }


        public string Eliminar(DbArticulo Articulo)
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
                        command.CommandText = "speliminar_articulo";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdarticulo = new SqlParameter();
                        ParIdarticulo.ParameterName = "@idarticulo";
                        ParIdarticulo.SqlDbType = SqlDbType.Int;
                        ParIdarticulo.Value = Articulo.Idarticulo;
                        command.Parameters.Add(ParIdarticulo);



                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open) connection.Close();
                    }
                }

            }

            return rpta;

        }


        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("articulo");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {

                        command.Connection = connection;
                        command.CommandText = "spmostrar_articulo";
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


        public DataTable BuscarNombre(DbArticulo Articulo)
        {
            DataTable DtResultado = new DataTable("articulo");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {

                        command.Connection = connection;
                        command.CommandText = "spbuscar_articulo_nombre";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.NVarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Articulo.TextoBuscar;
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


        public DataTable Stock_Articulos()
        {
            DataTable DtResultado = new DataTable("articulo");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {

                        command.Connection = connection;
                        command.CommandText = "spstock_articulos";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter SqlDat = new SqlDataAdapter(command);
                        SqlDat.Fill(DtResultado);

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