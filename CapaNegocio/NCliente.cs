using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;


namespace CapaNegocio
{
    public  class NCliente
    {
        public static string Insertar(string nombre, string apellidos, string sexo,
             DateTime fecha_nacimiento,
             string tipo_documento, string num_documento,
             string direccion, string telefono, string email)
        {
            DbClientes Obj = new DbClientes();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;

            return Obj.Insertar(Obj);
        }


        public static string Editar(int idcliente, string nombre, string apellidos, string sexo,
            DateTime fecha_nacimiento,
            string tipo_documento, string num_documento,
            string direccion, string telefono, string email)
        {
            DbClientes Obj = new DbClientes();
            Obj.Idcliente = idcliente;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idcliente)
        {
            DbClientes Obj = new DbClientes();
            Obj.Idcliente = idcliente;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DbClientes().Mostrar();
        }
        public static DataTable BuscarApellidos(string textobuscar)
        {
            DbClientes Obj = new DbClientes();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellidos(Obj);
        }

        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DbClientes Obj = new DbClientes();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }




    }
}
