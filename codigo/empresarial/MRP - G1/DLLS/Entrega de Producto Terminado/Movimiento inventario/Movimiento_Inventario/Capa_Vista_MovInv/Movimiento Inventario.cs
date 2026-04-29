using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_MovInv;

namespace Capa_Vista_MovInv
{
    public partial class Movimiento_Inventario : Form
    {
        Controlador_MovimientoInventarios controlador = new Controlador_MovimientoInventarios();
        int idSeleccionado = 0;

        public Movimiento_Inventario()
        {
            InitializeComponent();
        }
        private void CargarCombos()
        {
            Cbo_tipo_movimiento.DataSource = controlador.ObtenerTipoMovimiento();
            Cbo_tipo_movimiento.DisplayMember = "Nombre_Tipo_Movimiento_Inventario";
            Cbo_tipo_movimiento.ValueMember = "Pk_Id_Tipo_Movimiento_Inventario";
            Cbo_tipo_movimiento.SelectedIndex = -1;

            Cbo_material.DataSource = controlador.ObtenerMateriales();
            Cbo_material.DisplayMember = "Nombre_Material";
            Cbo_material.ValueMember = "Pk_Id_Materiales";
            Cbo_material.SelectedIndex = -1;

            Cbo_almacen_origen.DataSource = controlador.ObtenerAlmacenes();
            Cbo_almacen_origen.DisplayMember = "Nombre_Almacen";
            Cbo_almacen_origen.ValueMember = "Pk_Id_Almacen";
            Cbo_almacen_origen.SelectedIndex = -1;

            Cbo_almacen_destino.DataSource = controlador.ObtenerAlmacenes();
            Cbo_almacen_destino.DisplayMember = "Nombre_Almacen";
            Cbo_almacen_destino.ValueMember = "Pk_Id_Almacen";
            Cbo_almacen_destino.SelectedIndex = -1;

            Cbo_orden_produccion.DataSource = controlador.ObtenerOrdenProduccion();
            Cbo_orden_produccion.DisplayMember = "Pk_Id_Orden_Produccion";
            Cbo_orden_produccion.ValueMember = "Pk_Id_Orden_Produccion";
            Cbo_orden_produccion.SelectedIndex = -1;

            Cbo_recepcion.DataSource = controlador.ObtenerRecepcionMaterial();
            Cbo_recepcion.DisplayMember = "Pk_Id_Recepcion_Material";
            Cbo_recepcion.ValueMember = "Pk_Id_Recepcion_Material";
            Cbo_recepcion.SelectedIndex = -1;
        }

        private void CargarMovimientos()
        {
            Dgv_movimientos.DataSource = controlador.ObtenerMovimientos();

            // Renombrar encabezados
            Dgv_movimientos.Columns["Pk_Id_Movimiento_Inventarios"].HeaderText = "ID";
            Dgv_movimientos.Columns["Fk_Tipo_Movimiento"].HeaderText = "Tipo Movimiento";
            Dgv_movimientos.Columns["Fk_Id_Material"].HeaderText = "Material";
            Dgv_movimientos.Columns["Cantidad_Movida_Movimiento_Inventarios"].HeaderText = "Cantidad";
            Dgv_movimientos.Columns["Fk_Id_Almacen_Origen"].HeaderText = "Almacén Origen";
            Dgv_movimientos.Columns["Fk_Id_Almacen_Destino"].HeaderText = "Almacén Destino";
            Dgv_movimientos.Columns["Fk_Orden_Produccion"].HeaderText = "Orden Producción";
            Dgv_movimientos.Columns["Fk_Id_Recepcion_Material"].HeaderText = "Recepción";
            Dgv_movimientos.Columns["Fecha_Movimiento_Inventarios"].HeaderText = "Fecha";
            Dgv_movimientos.Columns["Observacion_Movimiento_Inventarios"].HeaderText = "Observación";

            // Ajustar tamaño automático
            Dgv_movimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Opcional: altura de encabezado
            Dgv_movimientos.ColumnHeadersHeight = 30;
        }

        private void CargarDatosFilaSeleccionada()
        {
            if (Dgv_movimientos.CurrentRow == null)
                return;

            DataGridViewRow fila = Dgv_movimientos.CurrentRow;

            idSeleccionado = Convert.ToInt32(fila.Cells["Pk_Id_Movimiento_Inventarios"].Value);

            Cbo_tipo_movimiento.SelectedValue = fila.Cells["Fk_Tipo_Movimiento"].Value;
            Cbo_material.SelectedValue = fila.Cells["Fk_Id_Material"].Value;
            Num_cantidad.Value = Convert.ToDecimal(fila.Cells["Cantidad_Movida_Movimiento_Inventarios"].Value);
            Cbo_almacen_origen.SelectedValue = fila.Cells["Fk_Id_Almacen_Origen"].Value;
            Cbo_almacen_destino.SelectedValue = fila.Cells["Fk_Id_Almacen_Destino"].Value;

            if (fila.Cells["Fk_Orden_Produccion"].Value == DBNull.Value ||
                fila.Cells["Fk_Orden_Produccion"].Value == null)
            {
                Cbo_orden_produccion.SelectedIndex = -1;
            }
            else
            {
                Cbo_orden_produccion.SelectedValue = fila.Cells["Fk_Orden_Produccion"].Value;
            }

            if (fila.Cells["Fk_Id_Recepcion_Material"].Value == DBNull.Value ||
                fila.Cells["Fk_Id_Recepcion_Material"].Value == null)
            {
                Cbo_recepcion.SelectedIndex = -1;
            }
            else
            {
                Cbo_recepcion.SelectedValue = fila.Cells["Fk_Id_Recepcion_Material"].Value;
            }

            Txt_observacion.Text = fila.Cells["Observacion_Movimiento_Inventarios"].Value == DBNull.Value
                ? ""
                : fila.Cells["Observacion_Movimiento_Inventarios"].Value.ToString();
        }

        private void Movimiento_Inventario_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarMovimientos();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btn_inicio_Click(object sender, EventArgs e)
        {
            if (Dgv_movimientos.Rows.Count > 0 && Dgv_movimientos.CurrentRow != null)
            {
                int filaActual = Dgv_movimientos.CurrentRow.Index;

                if (filaActual > 0)
                {
                    Dgv_movimientos.ClearSelection();
                    Dgv_movimientos.Rows[filaActual - 1].Selected = true;
                    Dgv_movimientos.CurrentCell = Dgv_movimientos.Rows[filaActual - 1].Cells[0];

                    CargarDatosFilaSeleccionada();
                }
            }
        }

        private void Btn_fin_Click(object sender, EventArgs e)
        {
            if (Dgv_movimientos.Rows.Count > 0 && Dgv_movimientos.CurrentRow != null)
            {
                int filaActual = Dgv_movimientos.CurrentRow.Index;

                if (filaActual < Dgv_movimientos.Rows.Count - 1)
                {
                    Dgv_movimientos.ClearSelection();
                    Dgv_movimientos.Rows[filaActual + 1].Selected = true;
                    Dgv_movimientos.CurrentCell = Dgv_movimientos.Rows[filaActual + 1].Cells[0];

                    CargarDatosFilaSeleccionada();
                }
            }
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            int tipo = Convert.ToInt32(Cbo_tipo_movimiento.SelectedValue);
            int material = Convert.ToInt32(Cbo_material.SelectedValue);
            decimal cantidad = Num_cantidad.Value;
            int origen = Convert.ToInt32(Cbo_almacen_origen.SelectedValue);
            int destino = Convert.ToInt32(Cbo_almacen_destino.SelectedValue);

            int? orden = Cbo_orden_produccion.SelectedIndex == -1 ? (int?)null : Convert.ToInt32(Cbo_orden_produccion.SelectedValue);
            int? recepcion = Cbo_recepcion.SelectedIndex == -1 ? (int?)null : Convert.ToInt32(Cbo_recepcion.SelectedValue);

            string observacion = Txt_observacion.Text;

            string resultado = controlador.InsertarMovimiento(
                tipo, material, cantidad, origen, destino, orden, recepcion, observacion
            );

            MessageBox.Show(resultado);

            CargarMovimientos();
        }

        private void Dgv_movimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Dgv_movimientos.CurrentCell = Dgv_movimientos.Rows[e.RowIndex].Cells[0];
            Dgv_movimientos.Rows[e.RowIndex].Selected = true;

            CargarDatosFilaSeleccionada();
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un registro primero.");
                return;
            }

            int tipo = Convert.ToInt32(Cbo_tipo_movimiento.SelectedValue);
            int material = Convert.ToInt32(Cbo_material.SelectedValue);
            decimal cantidad = Num_cantidad.Value;
            int origen = Convert.ToInt32(Cbo_almacen_origen.SelectedValue);
            int destino = Convert.ToInt32(Cbo_almacen_destino.SelectedValue);

            int? orden = Cbo_orden_produccion.SelectedIndex == -1 ? (int?)null : Convert.ToInt32(Cbo_orden_produccion.SelectedValue);
            int? recepcion = Cbo_recepcion.SelectedIndex == -1 ? (int?)null : Convert.ToInt32(Cbo_recepcion.SelectedValue);

            string observacion = Txt_observacion.Text;

            string resultado = controlador.ActualizarMovimiento(
                idSeleccionado, tipo, material, cantidad,
                origen, destino, orden, recepcion, observacion
            );

            MessageBox.Show(resultado);

            CargarMovimientos();
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un movimiento primero.");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Desea eliminar este movimiento?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.Yes)
            {
                string resultado = controlador.EliminarMovimiento(idSeleccionado);

                MessageBox.Show(resultado);

                idSeleccionado = 0;
                CargarMovimientos();
            }
        }

        private void LimpiarControles()
        {
            Cbo_tipo_movimiento.SelectedIndex = -1;
            Cbo_material.SelectedIndex = -1;
            Cbo_almacen_origen.SelectedIndex = -1;
            Cbo_almacen_destino.SelectedIndex = -1;
            Cbo_orden_produccion.SelectedIndex = -1;
            Cbo_recepcion.SelectedIndex = -1;

            Num_cantidad.Value = 0;

            Txt_observacion.Text = "";

            idSeleccionado = 0;
        }

        private void Btn_refrescar_Click(object sender, EventArgs e)
        {
            CargarCombos();
            CargarMovimientos();
            LimpiarControles();

            idSeleccionado = 0;

        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
