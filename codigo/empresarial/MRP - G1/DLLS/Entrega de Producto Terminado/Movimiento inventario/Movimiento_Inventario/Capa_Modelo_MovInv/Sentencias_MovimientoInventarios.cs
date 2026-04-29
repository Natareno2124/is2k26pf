using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_MovInv
{
    public class Sentencias_MovimientoInventarios
    {
        public string Insertar()
        {
            return @"INSERT INTO tbl_movimiento_inventarios
            (
                Fk_Tipo_Movimiento,
                Fk_Id_Material,
                Cantidad_Movida_Movimiento_Inventarios,
                Fk_Id_Almacen_Origen,
                Fk_Id_Almacen_Destino,
                Fk_Orden_Produccion,
                Fk_Id_Recepcion_Material,
                Observacion_Movimiento_Inventarios
            )
            VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
        }

        public string Listar()
        {
            return @"SELECT 
                    Pk_Id_Movimiento_Inventarios,
                    Fk_Tipo_Movimiento,
                    Fk_Id_Material,
                    Cantidad_Movida_Movimiento_Inventarios,
                    Fk_Id_Almacen_Origen,
                    Fk_Id_Almacen_Destino,
                    Fk_Orden_Produccion,
                    Fk_Id_Recepcion_Material,
                    Fecha_Movimiento_Inventarios,
                    Observacion_Movimiento_Inventarios
                   FROM tbl_movimiento_inventarios";
        }

        public string Actualizar()
        {
            return @"UPDATE tbl_movimiento_inventarios SET
                    Fk_Tipo_Movimiento = ?,
                    Fk_Id_Material = ?,
                    Cantidad_Movida_Movimiento_Inventarios = ?,
                    Fk_Id_Almacen_Origen = ?,
                    Fk_Id_Almacen_Destino = ?,
                    Fk_Orden_Produccion = ?,
                    Fk_Id_Recepcion_Material = ?,
                    Observacion_Movimiento_Inventarios = ?
                   WHERE Pk_Id_Movimiento_Inventarios = ?";
        }

        public string Eliminar()
        {
            return @"DELETE FROM tbl_movimiento_inventarios
                    WHERE Pk_Id_Movimiento_Inventarios = ?";
        }
    }
}
