using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using System.Data.Common;

namespace CapaNegocio
{
    public class NCategoria
    {
        public static string Insertar(string nombre, string descripcion)
        {
            DbCategoria Obj = new DbCategoria();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);

        }
        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            DbCategoria Obj = new DbCategoria();
            Obj.Nombre = nombre;
            Obj.Idcategoria = idcategoria;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj);

        }

        public static string Eliminar(int idcategoria)
        {
            DbCategoria Obj = new DbCategoria();
            Obj.Idcategoria = idcategoria;
            return Obj.Eliminar(Obj);

        }

        public static DataTable Mostrar()
        {
            return new DbCategoria().Mostrar();
        }


        public static DataTable BuscarNombre(string textobuscar)
        {
            DbCategoria Obj = new DbCategoria();
            Obj.Textobuscar = textobuscar;
            return Obj.BuscarNombre(Obj);

        }



    }
}