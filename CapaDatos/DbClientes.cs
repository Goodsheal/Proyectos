using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace CapaDatos
{
    public class DbClientes :DbConnection
    {
        private int _Idcliente;

        private string _Nombre;

        private string _Apellidos;

        private string _Sexo;

        private DateTime _Fecha_Nacimiento;

        private string _Tipo_Documento;

        private string _Num_Documento;


        private string _Direccion;

        private string _Telefono;

        private string _Email;

        private string _TextoBuscar;

        public int Idcliente
        {
            get { return _Idcliente; }
            set { _Idcliente = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }

        public string Sexo
        {
            get { return _Sexo; }
            set { _Sexo = value; }
        }

        public DateTime Fecha_Nacimiento
        {
            get { return _Fecha_Nacimiento; }
            set { _Fecha_Nacimiento = value; }
        }

        public string Tipo_Documento
        {
            get { return _Tipo_Documento; }
            set { _Tipo_Documento = value; }
        }
        public string Num_Documento
        {
            get { return _Num_Documento; }
            set { _Num_Documento = value; }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }


        public DbClientes()
        {

        }
        public DbClientes(int idcliente, string nombre, string apellidos, string sexo,
           DateTime fecha_nacimiento, string tipo_documento, string num_documento, string direccion,
           string telefono, string email, string textobuscar)
        {
            this.Idcliente = idcliente;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.Fecha_Nacimiento = fecha_nacimiento;
            this.Tipo_Documento = tipo_documento;
            this.Num_Documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.TextoBuscar = textobuscar;

        }

        public string Insertar(DbClientes Cliente)
        {
            string rpta = "";

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {

                    try
                    {
                        //Código

                        command.Connection = connection;
                        command.CommandText = "spinsertar_cliente";
                        command.CommandType = CommandType.StoredProcedure;


                        SqlParameter ParIdcliente = new SqlParameter();
                        ParIdcliente.ParameterName = "@idcliente";
                        ParIdcliente.SqlDbType = SqlDbType.Int;
                        ParIdcliente.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIdcliente);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 50;
                        ParNombre.Value = Cliente.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParApellidos = new SqlParameter();
                        ParApellidos.ParameterName = "@apellidos";
                        ParApellidos.SqlDbType = SqlDbType.VarChar;
                        ParApellidos.Size = 50;
                        ParApellidos.Value = Cliente.Apellidos;
                        command.Parameters.Add(ParApellidos);

                        SqlParameter ParSexo = new SqlParameter();
                        ParSexo.ParameterName = "@sexo";
                        ParSexo.SqlDbType = SqlDbType.VarChar;
                        ParSexo.Size = 50;
                        ParSexo.Value = Cliente.Sexo;
                        command.Parameters.Add(ParSexo);

                        SqlParameter ParFecha_Nacimiento = new SqlParameter();
                        ParFecha_Nacimiento.ParameterName = "@fecha_nacimiento";
                        ParFecha_Nacimiento.SqlDbType = SqlDbType.VarChar;
                        ParFecha_Nacimiento.Size = 50;
                        ParFecha_Nacimiento.Value = Cliente.Fecha_Nacimiento;
                        command.Parameters.Add(ParFecha_Nacimiento);

                        SqlParameter ParTipoDocumento = new SqlParameter();
                        ParTipoDocumento.ParameterName = "@tipo_documento";
                        ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                        ParTipoDocumento.Size = 20;
                        ParTipoDocumento.Value = Cliente.Tipo_Documento;
                        command.Parameters.Add(ParTipoDocumento);

                        SqlParameter ParNum_Documento = new SqlParameter();
                        ParNum_Documento.ParameterName = "@num_documento";
                        ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                        ParNum_Documento.Size = 11;
                        ParNum_Documento.Value = Cliente.Num_Documento;
                        command.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter();
                        ParDireccion.ParameterName = "@direccion";
                        ParDireccion.SqlDbType = SqlDbType.VarChar;
                        ParDireccion.Size = 100;
                        ParDireccion.Value = Cliente.Direccion;
                        command.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter();
                        ParTelefono.ParameterName = "@telefono";
                        ParTelefono.SqlDbType = SqlDbType.VarChar;
                        ParTelefono.Size = 11;
                        ParTelefono.Value = Cliente.Telefono;
                        command.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter();
                        ParEmail.ParameterName = "@email";
                        ParEmail.SqlDbType = SqlDbType.VarChar;
                        ParEmail.Size = 50;
                        ParEmail.Value = Cliente.Email;
                        command.Parameters.Add(ParEmail);

                        //Ejecutamos nuestro comando

                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESO EL REGISTRO";


                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally { if (connection.State == ConnectionState.Open) connection.Close();
                    
                    }
                
                    

                }
            }
            return rpta;

        }





        //Método Editar
        public string Editar(DbClientes Cliente)
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
                        command.CommandText = "speditar_cliente";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdcliente = new SqlParameter();
                        ParIdcliente.ParameterName = "@idcliente";
                        ParIdcliente.SqlDbType = SqlDbType.Int;
                        ParIdcliente.Value = Cliente.Idcliente;
                        command.Parameters.Add(ParIdcliente);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 50;
                        ParNombre.Value = Cliente.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParApellidos = new SqlParameter();
                        ParApellidos.ParameterName = "@apellidos";
                        ParApellidos.SqlDbType = SqlDbType.VarChar;
                        ParApellidos.Size = 50;
                        ParApellidos.Value = Cliente.Apellidos;
                        command.Parameters.Add(ParApellidos);

                        SqlParameter ParSexo = new SqlParameter();
                        ParSexo.ParameterName = "@sexo";
                        ParSexo.SqlDbType = SqlDbType.VarChar;
                        ParSexo.Size = 50;
                        ParSexo.Value = Cliente.Sexo;
                        command.Parameters.Add(ParSexo);

                        SqlParameter ParFecha_Nacimiento = new SqlParameter();
                        ParFecha_Nacimiento.ParameterName = "@fecha_nacimiento";
                        ParFecha_Nacimiento.SqlDbType = SqlDbType.VarChar;
                        ParFecha_Nacimiento.Size = 50;
                        ParFecha_Nacimiento.Value = Cliente.Fecha_Nacimiento;
                        command.Parameters.Add(ParFecha_Nacimiento);

                        SqlParameter ParTipoDocumento = new SqlParameter();
                        ParTipoDocumento.ParameterName = "@tipo_documento";
                        ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                        ParTipoDocumento.Size = 20;
                        ParTipoDocumento.Value = Cliente.Tipo_Documento;
                        command.Parameters.Add(ParTipoDocumento);

                        SqlParameter ParNum_Documento = new SqlParameter();
                        ParNum_Documento.ParameterName = "@num_documento";
                        ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                        ParNum_Documento.Size = 11;
                        ParNum_Documento.Value = Cliente.Num_Documento;
                        command.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter();
                        ParDireccion.ParameterName = "@direccion";
                        ParDireccion.SqlDbType = SqlDbType.VarChar;
                        ParDireccion.Size = 100;
                        ParDireccion.Value = Cliente.Direccion;
                        command.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter();
                        ParTelefono.ParameterName = "@telefono";
                        ParTelefono.SqlDbType = SqlDbType.VarChar;
                        ParTelefono.Size = 11;
                        ParTelefono.Value = Cliente.Telefono;
                        command.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter();
                        ParEmail.ParameterName = "@email";
                        ParEmail.SqlDbType = SqlDbType.VarChar;
                        ParEmail.Size = 50;
                        ParEmail.Value = Cliente.Email;
                        command.Parameters.Add(ParEmail);

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
                    return rpta;
                }
            }
        }



        //Método Eliminar
        public string Eliminar(DbClientes Cliente)
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
                        command.CommandText = "speliminar_cliente";
                        command.CommandType = CommandType.StoredProcedure;


                        SqlParameter ParIdcliente = new SqlParameter();
                        ParIdcliente.ParameterName = "@idcliente";
                        ParIdcliente.SqlDbType = SqlDbType.Int;
                        ParIdcliente.Value = Cliente.Idcliente;
                        command.Parameters.Add(ParIdcliente);

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
            DataTable DtResultado = new DataTable("cliente");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {

                        command.Connection = connection;
                        command.CommandText = "spmostrar_cliente";
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

        public DataTable BuscarApellidos(DbClientes Cliente)
        {
            DataTable DtResultado = new DataTable("cliente");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {

                        command.Connection = connection;
                        command.CommandText = "spbuscar_cliente_apellidos";
                        command.CommandType = CommandType.StoredProcedure;


                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Cliente.TextoBuscar;
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


        

        public DataTable BuscarNum_Documento(DbClientes Cliente)
        {

            DataTable DtResultado = new DataTable("cliente");
            using (var connection = GetConnection()) 
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {

                        command.Connection = connection;
                        command.CommandText = "spbuscar_cliente_num_documento";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Cliente.TextoBuscar;
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
