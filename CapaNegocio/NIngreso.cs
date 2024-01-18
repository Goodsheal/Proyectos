using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
    public  class NIngreso
    {
        public static string Insertar(int idtrabajador, int idproveedor, DateTime fecha,
           string tipo_comprobante, string serie, string correlativo, decimal igv,
           string estado, DataTable dtDetalles)
        {
            DbIngreso Obj = new DbIngreso();
            Obj.Idtrabajador = idtrabajador;
            Obj.Idproveedor = idproveedor;
            Obj.Fecha = fecha;
            Obj.Tipo_Comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            Obj.Estado = estado;
            List<DbDetalle_Ingreso> detalles = new List<DbDetalle_Ingreso>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DbDetalle_Ingreso detalle = new DbDetalle_Ingreso();
                detalle.Idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                detalle.Precio_Compra = Convert.ToDecimal(row["precio_compra"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Stock_Inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Fecha_Produccion = Convert.ToDateTime(row["fecha_produccion"].ToString());
                detalle.Fecha_Vencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }

        public static string Anular(int idingreso)
        {
            DbIngreso Obj = new DbIngreso();
            Obj.Idingreso = idingreso;
            return Obj.Anular(Obj);
        }
        public static DataTable Mostrar()
        {
            return new DbIngreso().Mostrar();
        }
        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            DbIngreso Obj = new DbIngreso();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }

        public static DataTable MostrarDetalle(string textobuscar)
        {
            DbIngreso Obj = new DbIngreso();
            return Obj.MostrarDetalle(textobuscar);
        }

    }
}
