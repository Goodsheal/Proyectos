using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;


namespace CapaNegocio
{
    public class NTrabajador
    {
        public static string Insertar(string nombre, string apellidos, string sexo,
            DateTime fecha_nacimiento, string num_documento,
            string direccion, string telefono, string email, string acceso,
            string usuario, string password)
        {
            DbTrabajador Obj = new DbTrabajador();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Insertar(Obj);
        }

        public static string Editar(int idtrabajador, string nombre, string apellidos,
           string sexo,
           DateTime fecha_nacimiento, string num_documento,
           string direccion, string telefono, string email, string acceso, string usuario,
           string password)
        {
            DbTrabajador Obj = new DbTrabajador();
            Obj.Idtrabajador = idtrabajador;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Editar(Obj);
        }


        public static string Eliminar(int idtrabajador)
        {
            DbTrabajador Obj = new DbTrabajador();
            Obj.Idtrabajador = idtrabajador;
            return Obj.Eliminar(Obj);
        }


        public static DataTable Mostrar()
        {
            return new DbTrabajador().Mostrar();
        }

        public static DataTable BuscarApellidos(string textobuscar)
        {
            DbTrabajador Obj = new DbTrabajador();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellidos(Obj);
        }

        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DbTrabajador Obj = new DbTrabajador();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }

        public static DataTable Login(string usuario, string password)
        {
            DbTrabajador Obj = new DbTrabajador();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }





    }
}
