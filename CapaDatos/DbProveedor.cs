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
    public class DbProveedor :DbConnection
    {
        private int _Idproveedor;

        private string _Razon_Social;

        private string _Sector_Comercial;

        private string _Tipo_Documento;

        private string _Num_Documento;

        private string _Direccion;

        private string _Telefono;

        private string _Email;

        private string _Url;

        private string _TextoBuscar;


        public int Idproveedor
        {
            get { return _Idproveedor; }
            set { _Idproveedor = value; }
        }
        public string Razon_Social
        {
            get { return _Razon_Social; }
            set { _Razon_Social = value; }
        }
        public string Sector_Comercial
        {
            get { return _Sector_Comercial; }
            set { _Sector_Comercial = value; }
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

        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }


        public DbProveedor()
        {

        }
        public DbProveedor(int idproveedor, string razon_social, string sector_comercial, string tipo_documento, string num_documento, string direccion, string telefono, string email, string url, string textobuscar)
        {
            this.Idproveedor = idproveedor;
            this.Razon_Social = razon_social;
            this.Sector_Comercial = sector_comercial;
            this.Tipo_Documento = tipo_documento;
            this.Num_Documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Url = url;
            this.TextoBuscar = textobuscar;

        }
        public string Insertar(DbProveedor Proveedor)
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
                        command.CommandText = "spinsertar_proveedor";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdproveedor = new SqlParameter();
                        ParIdproveedor.ParameterName = "@idproveedor";
                        ParIdproveedor.SqlDbType = SqlDbType.Int;
                        ParIdproveedor.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIdproveedor);

                        SqlParameter ParRazon_Social = new SqlParameter();
                        ParRazon_Social.ParameterName = "@razon_social";
                        ParRazon_Social.SqlDbType = SqlDbType.VarChar;
                        ParRazon_Social.Size = 150;
                        ParRazon_Social.Value = Proveedor.Razon_Social;
                        command.Parameters.Add(ParRazon_Social);

                        SqlParameter ParSectorComercial = new SqlParameter();
                        ParSectorComercial.ParameterName = "@sector_comercial";
                        ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                        ParSectorComercial.Size = 50;
                        ParSectorComercial.Value = Proveedor.Sector_Comercial;
                        command.Parameters.Add(ParSectorComercial);

                        SqlParameter ParTipoDocumento = new SqlParameter();
                        ParTipoDocumento.ParameterName = "@tipo_documento";
                        ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                        ParTipoDocumento.Size = 20;
                        ParTipoDocumento.Value = Proveedor.Tipo_Documento;
                        command.Parameters.Add(ParTipoDocumento);

                        SqlParameter ParNum_Documento = new SqlParameter();
                        ParNum_Documento.ParameterName = "@num_documento";
                        ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                        ParNum_Documento.Size = 11;
                        ParNum_Documento.Value = Proveedor.Num_Documento;
                        command.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter();
                        ParDireccion.ParameterName = "@direccion";
                        ParDireccion.SqlDbType = SqlDbType.VarChar;
                        ParDireccion.Size = 100;
                        ParDireccion.Value = Proveedor.Direccion;
                        command.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter();
                        ParTelefono.ParameterName = "@telefono";
                        ParTelefono.SqlDbType = SqlDbType.VarChar;
                        ParTelefono.Size = 11;
                        ParTelefono.Value = Proveedor.Telefono;
                        command.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter();
                        ParEmail.ParameterName = "@email";
                        ParEmail.SqlDbType = SqlDbType.VarChar;
                        ParEmail.Size = 50;
                        ParEmail.Value = Proveedor.Email;
                        command.Parameters.Add(ParEmail);


                        SqlParameter ParUrl = new SqlParameter();
                        ParUrl.ParameterName = "@url";
                        ParUrl.SqlDbType = SqlDbType.VarChar;
                        ParUrl.Size = 150;
                        ParUrl.Value = Proveedor.Url;
                        command.Parameters.Add(ParUrl);



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

        public string Editar(DbProveedor Proveedor)
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
                        command.CommandText = "speditar_proveedor";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdproveedor = new SqlParameter();
                        ParIdproveedor.ParameterName = "@idproveedor";
                        ParIdproveedor.SqlDbType = SqlDbType.Int;
                        ParIdproveedor.Value = Proveedor.Idproveedor;
                        command.Parameters.Add(ParIdproveedor);

                        SqlParameter ParRazon_Social = new SqlParameter();
                        ParRazon_Social.ParameterName = "@razon_social";
                        ParRazon_Social.SqlDbType = SqlDbType.VarChar;
                        ParRazon_Social.Size = 150;
                        ParRazon_Social.Value = Proveedor.Razon_Social;
                        command.Parameters.Add(ParRazon_Social);

                        SqlParameter ParSectorComercial = new SqlParameter();
                        ParSectorComercial.ParameterName = "@sector_comercial";
                        ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                        ParSectorComercial.Size = 50;
                        ParSectorComercial.Value = Proveedor.Sector_Comercial;
                        command.Parameters.Add(ParSectorComercial);

                        SqlParameter ParTipoDocumento = new SqlParameter();
                        ParTipoDocumento.ParameterName = "@tipo_documento";
                        ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                        ParTipoDocumento.Size = 20;
                        ParTipoDocumento.Value = Proveedor.Tipo_Documento;
                        command.Parameters.Add(ParTipoDocumento);

                        SqlParameter ParNum_Documento = new SqlParameter();
                        ParNum_Documento.ParameterName = "@num_documento";
                        ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                        ParNum_Documento.Size = 11;
                        ParNum_Documento.Value = Proveedor.Num_Documento;
                        command.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter();
                        ParDireccion.ParameterName = "@direccion";
                        ParDireccion.SqlDbType = SqlDbType.VarChar;
                        ParDireccion.Size = 100;
                        ParDireccion.Value = Proveedor.Direccion;
                        command.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter();
                        ParTelefono.ParameterName = "@telefono";
                        ParTelefono.SqlDbType = SqlDbType.VarChar;
                        ParTelefono.Size = 11;
                        ParTelefono.Value = Proveedor.Telefono;
                        command.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter();
                        ParEmail.ParameterName = "@email";
                        ParEmail.SqlDbType = SqlDbType.VarChar;
                        ParEmail.Size = 50;
                        ParEmail.Value = Proveedor.Email;
                        command.Parameters.Add(ParEmail);


                        SqlParameter ParUrl = new SqlParameter();
                        ParUrl.ParameterName = "@url";
                        ParUrl.SqlDbType = SqlDbType.VarChar;
                        ParUrl.Size = 150;
                        ParUrl.Value = Proveedor.Url;
                        command.Parameters.Add(ParUrl);

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

        public string Eliminar(DbProveedor Proveedor)
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
                        command.CommandText = "speliminar_proveedor";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdproveedor = new SqlParameter();
                        ParIdproveedor.ParameterName = "@idproveedor";
                        ParIdproveedor.SqlDbType = SqlDbType.Int;
                        ParIdproveedor.Value = Proveedor.Idproveedor;
                        command.Parameters.Add(ParIdproveedor);


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
            DataTable DtResultado = new DataTable("proveedor");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {

                        command.Connection = connection;
                        command.CommandText = "spmostrar_proveedor";
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

        public DataTable BuscarRazon_Social(DbProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {

                        command.Connection = connection;
                        command.CommandText = "spbuscar_proveedor_razon_social";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Proveedor.TextoBuscar;
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




        public DataTable BuscarNum_Documento(DbProveedor Proveedor)
        {

            DataTable DtResultado = new DataTable("proveedor");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {

                        command.Connection = connection;
                        command.CommandText = "spbuscar_proveedor_num_documento";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Proveedor.TextoBuscar;
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
    }
}
