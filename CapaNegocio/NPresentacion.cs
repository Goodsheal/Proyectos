using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaNegocio
{
    public class NPresentacion
    {
        public static string Insertar(string nombre, string descripcion)
        {
            DbPresentacion Obj = new DbPresentacion();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);

        }
        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            DbPresentacion Obj = new DbPresentacion();
            Obj.Nombre = nombre;
            Obj.Idpresentacion = idcategoria;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj);

        }

        public static string Eliminar(int idcategoria)
        {
            DbPresentacion Obj = new DbPresentacion();
            Obj.Idpresentacion = idcategoria;
            return Obj.Eliminar(Obj);

        }

        public static DataTable Mostrar()
        {
            return new DbPresentacion().Mostrar();
        }


        public static DataTable BuscarNombre(string textobuscar)
        {
            DbPresentacion Obj = new DbPresentacion();
            Obj.Textobuscar = textobuscar;
            return Obj.BuscarNombre(Obj);

        }












    }
}
