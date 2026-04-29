using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;
using Capa_Modelo_Seguridad;

namespace Capa_Modelo_MovInv
{
    public class Dao_MovimientoInventarios
    {

        Cls_Conexion conexion = new Cls_Conexion();
        Sentencias_MovimientoInventarios sentencias = new Sentencias_MovimientoInventarios();

        public int InsertarMovimiento(
            int fkTipoMovimiento,
            int fkIdMaterial,
            decimal cantidadMovida,
            int fkIdAlmacenOrigen,
            int fkIdAlmacenDestino,
            int? fkOrdenProduccion,
            int? fkIdRecepcionMaterial,
            string observacion)
        {
            int resultado = 0;

            string sql = sentencias.Insertar();

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("?", fkTipoMovimiento);
                    cmd.Parameters.AddWithValue("?", fkIdMaterial);
                    cmd.Parameters.AddWithValue("?", cantidadMovida);
                    cmd.Parameters.AddWithValue("?", fkIdAlmacenOrigen);
                    cmd.Parameters.AddWithValue("?", fkIdAlmacenDestino);
                    cmd.Parameters.AddWithValue("?", (object)fkOrdenProduccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("?", (object)fkIdRecepcionMaterial ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("?", observacion);

                    resultado = cmd.ExecuteNonQuery();
                }
            }

            return resultado;
        }
        public DataTable ListarMovimientos()
        {
            DataTable tabla = new DataTable();

            string sql = sentencias.Listar();

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcDataAdapter adapter = new OdbcDataAdapter(sql, conn))
                {
                    adapter.Fill(tabla);
                }
            }

            return tabla;
        }

        public DataTable ListarTipoMovimiento()
        {
            DataTable tabla = new DataTable();

            string sql = "SELECT Pk_Id_Tipo_Movimiento_Inventario, Nombre_Tipo_Movimiento_Inventario FROM Tbl_Tipo_Movimiento_Inventario";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcDataAdapter adapter = new OdbcDataAdapter(sql, conn))
                {
                    adapter.Fill(tabla);
                }
            }

            return tabla;
        }


        public DataTable ListarMateriales()
        {
            DataTable tabla = new DataTable();

            string sql = "SELECT Pk_Id_Materiales, Nombre_Material FROM Tbl_Materiales";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcDataAdapter adapter = new OdbcDataAdapter(sql, conn))
                {
                    adapter.Fill(tabla);
                }
            }

            return tabla;
        }

        public DataTable ListarAlmacenes()
        {
            DataTable tabla = new DataTable();

            string sql = "SELECT Pk_Id_Almacen, Nombre_Almacen FROM Tbl_Almacen";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcDataAdapter adapter = new OdbcDataAdapter(sql, conn))
                {
                    adapter.Fill(tabla);
                }
            }

            return tabla;
        }

        public DataTable ListarOrdenProduccion()
        {
            DataTable tabla = new DataTable();

            string sql = "SELECT Pk_Id_Orden_Produccion FROM Tbl_Orden_Produccion";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcDataAdapter adapter = new OdbcDataAdapter(sql, conn))
                {
                    adapter.Fill(tabla);
                }
            }

            return tabla;
        }

        public DataTable ListarRecepcionMaterial()
        {
            DataTable tabla = new DataTable();

            string sql = "SELECT Pk_Id_Recepcion_Material FROM Tbl_Recepcion_Material";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcDataAdapter adapter = new OdbcDataAdapter(sql, conn))
                {
                    adapter.Fill(tabla);
                }
            }

            return tabla;
        }

        public int ActualizarMovimiento(
            int id,
            int fkTipoMovimiento,
            int fkIdMaterial,
            decimal cantidadMovida,
            int fkIdAlmacenOrigen,
            int fkIdAlmacenDestino,
            int? fkOrdenProduccion,
            int? fkIdRecepcionMaterial,
            string observacion)
        {
            int resultado = 0;

            string sql = sentencias.Actualizar();

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("?", fkTipoMovimiento);
                    cmd.Parameters.AddWithValue("?", fkIdMaterial);
                    cmd.Parameters.AddWithValue("?", cantidadMovida);
                    cmd.Parameters.AddWithValue("?", fkIdAlmacenOrigen);
                    cmd.Parameters.AddWithValue("?", fkIdAlmacenDestino);
                    cmd.Parameters.AddWithValue("?", (object)fkOrdenProduccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("?", (object)fkIdRecepcionMaterial ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("?", observacion);
                    cmd.Parameters.AddWithValue("?", id);

                    resultado = cmd.ExecuteNonQuery();
                }
            }

            return resultado;
        }


        public int EliminarMovimiento(int id)
        {
            int resultado = 0;

            string sql = sentencias.Eliminar();

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("?", id);
                    resultado = cmd.ExecuteNonQuery();
                }
            }

            return resultado;
        }
    }
}
