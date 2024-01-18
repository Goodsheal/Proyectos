using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography;

namespace CapaDatos
{
    public class DbTrabajador : DbConnection
    {
        private int _Idtrabajador;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _Fecha_Nacimiento;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Password;
        private string _TextoBuscar;

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        public string Acceso
        {
            get { return _Acceso; }
            set { _Acceso = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        public string Num_Documento
        {
            get { return _Num_Documento; }
            set { _Num_Documento = value; }
        }


        public DateTime Fecha_Nacimiento
        {
            get { return _Fecha_Nacimiento; }
            set { _Fecha_Nacimiento = value; }
        }


        public string Sexo
        {
            get { return _Sexo; }
            set { _Sexo = value; }
        }

        public string Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public int Idtrabajador
        {
            get { return _Idtrabajador; }
            set { _Idtrabajador = value; }
        }

        public DbTrabajador()
        {

        }

        public DbTrabajador(int idtrabajador, string nombre, string apellidos, string sexo,
            DateTime fecha_nacimiento, string num_documento, string direccion, string telefono,
            string email, string acceso, string usuario, string password, string textobuscar)
        {
            this.Idtrabajador = idtrabajador;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.Fecha_Nacimiento = fecha_nacimiento;
            this.Num_Documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Password = password;
            this.TextoBuscar = textobuscar;

        }

        public string Insertar(DbTrabajador Trabajador)
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
                        command.CommandText = "spinsertar_trabajador";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdtrabajador = new SqlParameter();
                        ParIdtrabajador.ParameterName = "@idtrabajador";
                        ParIdtrabajador.SqlDbType = SqlDbType.Int;
                        ParIdtrabajador.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIdtrabajador);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 20;
                        ParNombre.Value = Trabajador.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParApellidos = new SqlParameter();
                        ParApellidos.ParameterName = "@apellidos";
                        ParApellidos.SqlDbType = SqlDbType.VarChar;
                        ParApellidos.Size = 40;
                        ParApellidos.Value = Trabajador.Apellidos;
                        command.Parameters.Add(ParApellidos);

                        SqlParameter ParSexo = new SqlParameter();
                        ParSexo.ParameterName = "@sexo";
                        ParSexo.SqlDbType = SqlDbType.VarChar;
                        ParSexo.Size = 1;
                        ParSexo.Value = Trabajador.Sexo;
                        command.Parameters.Add(ParSexo);

                        SqlParameter ParFecha_Nacimiento = new SqlParameter();
                        ParFecha_Nacimiento.ParameterName = "@fecha_nacimiento";
                        ParFecha_Nacimiento.SqlDbType = SqlDbType.VarChar;
                        ParFecha_Nacimiento.Size = 50;
                        ParFecha_Nacimiento.Value = Trabajador.Fecha_Nacimiento;
                        command.Parameters.Add(ParFecha_Nacimiento);

                        SqlParameter ParNum_Documento = new SqlParameter();
                        ParNum_Documento.ParameterName = "@num_documento";
                        ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                        ParNum_Documento.Size = 11;
                        ParNum_Documento.Value = Trabajador.Num_Documento;
                        command.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter();
                        ParDireccion.ParameterName = "@direccion";
                        ParDireccion.SqlDbType = SqlDbType.VarChar;
                        ParDireccion.Size = 100;
                        ParDireccion.Value = Trabajador.Direccion;
                        command.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter();
                        ParTelefono.ParameterName = "@telefono";
                        ParTelefono.SqlDbType = SqlDbType.VarChar;
                        ParTelefono.Size = 11;
                        ParTelefono.Value = Trabajador.Telefono;
                        command.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter();
                        ParEmail.ParameterName = "@email";
                        ParEmail.SqlDbType = SqlDbType.VarChar;
                        ParEmail.Size = 50;
                        ParEmail.Value = Trabajador.Email;
                        command.Parameters.Add(ParEmail);

                        SqlParameter ParAcceso = new SqlParameter();
                        ParAcceso.ParameterName = "@acceso";
                        ParAcceso.SqlDbType = SqlDbType.VarChar;
                        ParAcceso.Size = 50;
                        ParAcceso.Value = Trabajador.Acceso;
                        command.Parameters.Add(ParAcceso);

                        SqlParameter ParUsuario = new SqlParameter();
                        ParUsuario.ParameterName = "@usuario";
                        ParUsuario.SqlDbType = SqlDbType.VarChar;
                        ParUsuario.Size = 50;
                        ParUsuario.Value = Trabajador.Usuario;
                        command.Parameters.Add(ParUsuario);

                        SqlParameter ParPassword = new SqlParameter();
                        ParPassword.ParameterName = "@password";
                        ParPassword.SqlDbType = SqlDbType.VarChar;
                        ParPassword.Size = 50;
                        ParPassword.Value = Trabajador.Password;
                        command.Parameters.Add(ParPassword);

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

        public string Editar(DbTrabajador Trabajador)
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
                        command.CommandText = "speditar_trabajador";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdtrabajador = new SqlParameter();
                        ParIdtrabajador.ParameterName = "@idtrabajador";
                        ParIdtrabajador.SqlDbType = SqlDbType.Int;
                        ParIdtrabajador.Value = Trabajador.Idtrabajador;
                        command.Parameters.Add(ParIdtrabajador);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 20;
                        ParNombre.Value = Trabajador.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParApellidos = new SqlParameter();
                        ParApellidos.ParameterName = "@apellidos";
                        ParApellidos.SqlDbType = SqlDbType.VarChar;
                        ParApellidos.Size = 40;
                        ParApellidos.Value = Trabajador.Apellidos;
                        command.Parameters.Add(ParApellidos);

                        SqlParameter ParSexo = new SqlParameter();
                        ParSexo.ParameterName = "@sexo";
                        ParSexo.SqlDbType = SqlDbType.VarChar;
                        ParSexo.Size = 1;
                        ParSexo.Value = Trabajador.Sexo;
                        command.Parameters.Add(ParSexo);

                        SqlParameter ParFecha_Nacimiento = new SqlParameter();
                        ParFecha_Nacimiento.ParameterName = "@fecha_nacimiento";
                        ParFecha_Nacimiento.SqlDbType = SqlDbType.VarChar;
                        ParFecha_Nacimiento.Size = 50;
                        ParFecha_Nacimiento.Value = Trabajador.Fecha_Nacimiento;
                        command.Parameters.Add(ParFecha_Nacimiento);

                        SqlParameter ParNum_Documento = new SqlParameter();
                        ParNum_Documento.ParameterName = "@num_documento";
                        ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                        ParNum_Documento.Size = 11;
                        ParNum_Documento.Value = Trabajador.Num_Documento;
                        command.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter();
                        ParDireccion.ParameterName = "@direccion";
                        ParDireccion.SqlDbType = SqlDbType.VarChar;
                        ParDireccion.Size = 100;
                        ParDireccion.Value = Trabajador.Direccion;
                        command.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter();
                        ParTelefono.ParameterName = "@telefono";
                        ParTelefono.SqlDbType = SqlDbType.VarChar;
                        ParTelefono.Size = 11;
                        ParTelefono.Value = Trabajador.Telefono;
                        command.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter();
                        ParEmail.ParameterName = "@email";
                        ParEmail.SqlDbType = SqlDbType.VarChar;
                        ParEmail.Size = 50;
                        ParEmail.Value = Trabajador.Email;
                        command.Parameters.Add(ParEmail);

                        SqlParameter ParAcceso = new SqlParameter();
                        ParAcceso.ParameterName = "@acceso";
                        ParAcceso.SqlDbType = SqlDbType.VarChar;
                        ParAcceso.Size = 50;
                        ParAcceso.Value = Trabajador.Acceso;
                        command.Parameters.Add(ParAcceso);

                        SqlParameter ParUsuario = new SqlParameter();
                        ParUsuario.ParameterName = "@usuario";
                        ParUsuario.SqlDbType = SqlDbType.VarChar;
                        ParUsuario.Size = 50;
                        ParUsuario.Value = Trabajador.Usuario;
                        command.Parameters.Add(ParUsuario);

                        SqlParameter ParPassword = new SqlParameter();
                        ParPassword.ParameterName = "@password";
                        ParPassword.SqlDbType = SqlDbType.VarChar;
                        ParPassword.Size = 50;
                        ParPassword.Value = Trabajador.Password;
                        command.Parameters.Add(ParPassword);

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


        public string Eliminar(DbTrabajador Trabajador)
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
                        command.CommandText = "speliminar_trabajador";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdtrabajador = new SqlParameter();
                        ParIdtrabajador.ParameterName = "@idtrabajador";
                        ParIdtrabajador.SqlDbType = SqlDbType.Int;
                        ParIdtrabajador.Value = Trabajador.Idtrabajador;
                        command.Parameters.Add(ParIdtrabajador);
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

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("trabajador");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {

                        command.Connection = connection;
                        command.CommandText = "spmostrar_trabajador";
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

        public DataTable BuscarApellidos(DbTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {

                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spbuscar_trabajador_apellidos";
                        command.CommandType = CommandType.StoredProcedure;


                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Trabajador.TextoBuscar;
                        command.Parameters.Add(ParTextoBuscar);

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
        public DataTable BuscarNum_Documento(DbTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {

                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spbuscar_trabajador_num_documento";
                        command.CommandType = CommandType.StoredProcedure;


                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Trabajador.TextoBuscar;
                        command.Parameters.Add(ParTextoBuscar);

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

        public DataTable Login(DbTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            using (var connection = GetConnection()) 
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "splogin";
                        command.CommandType = CommandType.StoredProcedure;
                        

                        SqlParameter ParUsuario = new SqlParameter();
                        ParUsuario.ParameterName = "@usuario";
                        ParUsuario.SqlDbType = SqlDbType.VarChar;
                        ParUsuario.Size = 20;
                        ParUsuario.Value = Trabajador.Usuario;
                        command.Parameters.Add(ParUsuario);

                        SqlParameter ParPassword = new SqlParameter();
                        ParPassword.ParameterName = "@password";
                        ParPassword.SqlDbType = SqlDbType.VarChar;
                        ParPassword.Size = 20;
                        ParPassword.Value = Trabajador.Password;
                        command.Parameters.Add(ParPassword);

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
