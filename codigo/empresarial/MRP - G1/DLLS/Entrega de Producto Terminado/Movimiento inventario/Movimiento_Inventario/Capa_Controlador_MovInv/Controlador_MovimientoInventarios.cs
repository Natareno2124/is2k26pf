using System;
using System.Data;
using Capa_Modelo_MovInv;
using Capa_Controlador_Seguridad;

namespace Capa_Controlador_MovInv
{
    public class Controlador_MovimientoInventarios
    {
        Dao_MovimientoInventarios dao = new Dao_MovimientoInventarios();
        private Cls_BitacoraControlador gCtrlBitacora = new Cls_BitacoraControlador();


        public DataTable ObtenerMovimientos()
        {
            Dao_MovimientoInventarios dao = new Dao_MovimientoInventarios();
            return dao.ListarMovimientos();
        }

        public string InsertarMovimiento(
            int fkTipoMovimiento,
            int fkIdMaterial,
            decimal cantidadMovida,
            int fkIdAlmacenOrigen,
            int fkIdAlmacenDestino,
            int? fkOrdenProduccion,
            int? fkIdRecepcionMaterial,
            string observacion)
        {
            // Validaciones básicas
            if (fkTipoMovimiento <= 0)
                return "Debe seleccionar un tipo de movimiento.";

            if (fkIdMaterial <= 0)
                return "Debe seleccionar un material.";

            if (cantidadMovida <= 0)
                return "La cantidad movida debe ser mayor a cero.";

            if (fkIdAlmacenOrigen <= 0)
                return "Debe seleccionar un almacén de origen.";

            if (fkIdAlmacenDestino <= 0)
                return "Debe seleccionar un almacén de destino.";

            if (fkIdAlmacenOrigen == fkIdAlmacenDestino)
                return "El almacén de origen y destino no pueden ser iguales.";

            if (string.IsNullOrWhiteSpace(observacion))
                observacion = "";

            // Inserción
            int resultado = dao.InsertarMovimiento(
                fkTipoMovimiento,
                fkIdMaterial,
                cantidadMovida,
                fkIdAlmacenOrigen,
                fkIdAlmacenDestino,
                fkOrdenProduccion,
                fkIdRecepcionMaterial,
                observacion
            );

            if (resultado > 0)
            {
                gCtrlBitacora.RegistrarAccion(
                    Cls_Usuario_Conectado.iIdUsuario,
                    721,
                    $"Se registró un movimiento de inventario. Material: {fkIdMaterial}, Tipo movimiento: {fkTipoMovimiento}, Cantidad: {cantidadMovida}",
                    true
                );
                return "Movimiento registrado correctamente.";

            }

            return "No se pudo registrar el movimiento.";
        }

        public DataTable ObtenerTipoMovimiento()
        {
            return dao.ListarTipoMovimiento();
        }

        public DataTable ObtenerMateriales()
        {
            return dao.ListarMateriales();
        }

        public DataTable ObtenerAlmacenes()
        {
            return dao.ListarAlmacenes();
        }

        public DataTable ObtenerOrdenProduccion()
        {
            return dao.ListarOrdenProduccion();
        }

        public DataTable ObtenerRecepcionMaterial()
        {
            return dao.ListarRecepcionMaterial();
        }

        public string ActualizarMovimiento(
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
            if (id <= 0)
                return "Seleccione un registro.";

            int resultado = dao.ActualizarMovimiento(
                id, fkTipoMovimiento, fkIdMaterial, cantidadMovida,
                fkIdAlmacenOrigen, fkIdAlmacenDestino,
                fkOrdenProduccion, fkIdRecepcionMaterial, observacion
            );

            if (resultado > 0)
            {
                gCtrlBitacora.RegistrarAccion(Cls_Usuario_Conectado.iIdUsuario, 721, $"Se modificó el movimiento con el id: '{id}'", true);
                return "Movimiento actualizado correctamente.";
            }


            return "No se pudo actualizar.";
        }

        public string EliminarMovimiento(int id)
        {
            if (id <= 0)
                return "Seleccione un registro.";

            int resultado = dao.EliminarMovimiento(id);

            if (resultado > 0)
            {
                gCtrlBitacora.RegistrarAccion(Cls_Usuario_Conectado.iIdUsuario, 721, $"Se eliminó el movimiento con el id: '{id}'", true);
                return "Movimiento eliminado correctamente.";

            }

            return "No se pudo eliminar.";
        }
    }
}