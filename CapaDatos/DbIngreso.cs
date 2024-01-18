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
    public class DbIngreso :DbConnection
    {
        private int _Idingreso;
        private int _Idtrabajador;
        private int _Idproveedor;
        private DateTime _Fecha;
        private string _Tipo_Comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;
        private string _Estado;

        public int Idingreso
        {
            get { return _Idingreso; }
            set { _Idingreso = value; }
        }


        public int Idtrabajador
        {
            get { return _Idtrabajador; }
            set { _Idtrabajador = value; }
        }


        public int Idproveedor
        {
            get { return _Idproveedor; }
            set { _Idproveedor = value; }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public string Tipo_Comprobante
        {
            get { return _Tipo_Comprobante; }
            set { _Tipo_Comprobante = value; }
        }

        public string Serie
        {
            get { return _Serie; }
            set { _Serie = value; }
        }


        public string Correlativo
        {
            get { return _Correlativo; }
            set { _Correlativo = value; }
        }

        public decimal Igv
        {
            get { return _Igv; }
            set { _Igv = value; }
        }


        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        //Constructores
        public DbIngreso()
        {

        }

        public DbIngreso(int idingreso, int idtrabajador, int idproveedor,
           DateTime fecha, string tipo_comprobante, string serie,
           string correlativo, decimal igv, string estado)
        {
            this.Idingreso = idingreso;
            this.Idtrabajador = idtrabajador;
            this.Idproveedor = idproveedor;
            this.Fecha = fecha;
            this.Tipo_Comprobante = tipo_comprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
            this.Estado = estado;
        }
       public string Insertar(DbIngreso Ingreso, List<DbDetalle_Ingreso> Detalle) 
        {
            string rpta = "";
            SqlConnection Sqlcon=new SqlConnection();
            try 
            {
                Sqlcon.ConnectionString=DbConnection.cn;
                Sqlcon.Open();

                SqlTransaction SqlTra= Sqlcon.BeginTransaction();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction= SqlTra;
                SqlCmd.CommandText = "spinsertar_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdingreso);

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idtrabajador";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Value = Ingreso.Idtrabajador;
                SqlCmd.Parameters.Add(ParIdtrabajador);

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@idproveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Value = Ingreso.Idproveedor;
                SqlCmd.Parameters.Add(ParIdproveedor);


                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Ingreso.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParTipo_Comprobante = new SqlParameter();
                ParTipo_Comprobante.ParameterName = "@tipo_comprobante";
                ParTipo_Comprobante.SqlDbType = SqlDbType.VarChar;
                ParTipo_Comprobante.Size = 20;
                ParTipo_Comprobante.Value = Ingreso.Tipo_Comprobante;
                SqlCmd.Parameters.Add(ParTipo_Comprobante);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 4;
                ParSerie.Value = Ingreso.Serie;
                SqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 7;
                ParCorrelativo.Value = Ingreso.Correlativo;
                SqlCmd.Parameters.Add(ParCorrelativo);

                SqlParameter ParIgv = new SqlParameter();
                ParIgv.ParameterName = "@igv";
                ParIgv.SqlDbType = SqlDbType.Decimal;
                ParIgv.Precision = 4;
                ParIgv.Scale = 2;
                ParIgv.Value = Ingreso.Igv;
                SqlCmd.Parameters.Add(ParIgv);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 7;
                ParEstado.Value = Ingreso.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";
                if (rpta.Equals("OK")) 
                {
                    this.Idingreso = Convert.ToInt32(SqlCmd.Parameters["@idingreso"].Value);
                    foreach(DbDetalle_Ingreso det in Detalle) 
                    {
                        det.Idingreso = this.Idingreso;
                        rpta = det.Insertar(det, ref Sqlcon, ref SqlTra);
                        if(!rpta.Equals("OK")) 
                        {
                            break;
                        }
                    }
                
                }
                if(rpta.Equals("OK")) 
                {
                    SqlTra.Commit();
                }
                else 
                {
                    SqlTra.Rollback();
                }





            }
            catch (Exception ex) 
            
            {
                rpta = ex.Message;
            }
            finally 
            {
             if(Sqlcon.State==ConnectionState.Open)Sqlcon.Close();
            
            }
            return rpta;
        
        
        }
        
        public string Anular(DbIngreso Ingreso) 
        
        
        {
            string rpta = "";
            using (var connection = GetConnection()) 
            {
                connection.Open();
                using (var command=new SqlCommand()) 
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spanular_ingreso";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdingreso = new SqlParameter();
                        ParIdingreso.ParameterName = "@idingreso";
                        ParIdingreso.SqlDbType = SqlDbType.Int;
                        ParIdingreso.Value = Ingreso.Idingreso;
                        command.Parameters.Add(ParIdingreso);

                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO se anulo el Registro";

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


        public  DataTable Mostrar() 
        {
        
        DataTable DtResultado= new DataTable("ingreso");
            using (var connection = GetConnection()) 
            
            {
                connection.Open();
                using (var command=new SqlCommand()) 
                {
                    try 
                    {
                    command.Connection= connection;
                        command.CommandText = "spmostrar_ingreso";
                        command.CommandType= CommandType.StoredProcedure;

                        SqlDataAdapter sqlDat= new SqlDataAdapter(command);
                        sqlDat.Fill(DtResultado);

                    }
                    catch (Exception ) 
                    {
                        DtResultado = null;
                    
                    }


                }
            }
          return DtResultado;
        }

        public DataTable BuscarFechas(string TextoBuscar1, string TextoBuscar2) 
        {
            DataTable DtResultado = new DataTable("ingreso");
            using (var connection = GetConnection()) 
            {
                connection.Open();
                using (var command=new SqlCommand()) 
                {
                    try 
                    {
                     command.Connection = connection;
                     command.CommandText= "spbuscar_ingreso_fecha";
                    command.CommandType= CommandType.StoredProcedure;


                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = TextoBuscar1;
                        command.Parameters.Add(ParTextoBuscar);

                        SqlParameter ParTextoBuscar2 = new SqlParameter();
                        ParTextoBuscar2.ParameterName = "@textobuscar2";
                        ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar2.Size = 50;
                        ParTextoBuscar2.Value = TextoBuscar2;
                        command.Parameters.Add(ParTextoBuscar2);

                        SqlDataAdapter SqlDat = new SqlDataAdapter(command);
                        SqlDat.Fill(DtResultado);






                    }
                    catch (Exception)
                    {
                    DtResultado= null;
                    }

                
                }
            
            
            }
          return DtResultado;
        
        
        
        
        
        }

        public DataTable MostrarDetalle(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("detalle_ingreso");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spmostar_detalle_ingreso";
                        command.CommandType = CommandType.StoredProcedure;


                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = TextoBuscar;
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
