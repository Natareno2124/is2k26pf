
namespace Capa_Vista_MovInv
{
    partial class Movimiento_Inventario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Movimiento_Inventario));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Btn_modificar = new System.Windows.Forms.Button();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.Btn_refrescar = new System.Windows.Forms.Button();
            this.Btn_Imprimir = new System.Windows.Forms.Button();
            this.Btn_Ayuda = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Cbo_tipo_movimiento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Cbo_material = new System.Windows.Forms.ComboBox();
            this.Cbo_almacen_origen = new System.Windows.Forms.ComboBox();
            this.Cbo_almacen_destino = new System.Windows.Forms.ComboBox();
            this.Cbo_orden_produccion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Cbo_recepcion = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Num_cantidad = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.Txt_observacion = new System.Windows.Forms.TextBox();
            this.Dgv_movimientos = new System.Windows.Forms.DataGridView();
            this.Btn_inicio = new System.Windows.Forms.Button();
            this.Btn_fin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Num_cantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_movimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "Movimiento Inventario - 721";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 21);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_guardar.Image")));
            this.Btn_guardar.Location = new System.Drawing.Point(613, 12);
            this.Btn_guardar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(60, 47);
            this.Btn_guardar.TabIndex = 37;
            this.Btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_guardar.UseVisualStyleBackColor = true;
            this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click);
            // 
            // Btn_modificar
            // 
            this.Btn_modificar.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_modificar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_modificar.Image")));
            this.Btn_modificar.Location = new System.Drawing.Point(681, 13);
            this.Btn_modificar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_modificar.Name = "Btn_modificar";
            this.Btn_modificar.Size = new System.Drawing.Size(60, 47);
            this.Btn_modificar.TabIndex = 38;
            this.Btn_modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_modificar.UseVisualStyleBackColor = true;
            this.Btn_modificar.Click += new System.EventHandler(this.Btn_modificar_Click);
            // 
            // Btn_eliminar
            // 
            this.Btn_eliminar.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_eliminar.Image")));
            this.Btn_eliminar.Location = new System.Drawing.Point(749, 13);
            this.Btn_eliminar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_eliminar.Name = "Btn_eliminar";
            this.Btn_eliminar.Size = new System.Drawing.Size(60, 47);
            this.Btn_eliminar.TabIndex = 39;
            this.Btn_eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_eliminar.UseVisualStyleBackColor = true;
            this.Btn_eliminar.Click += new System.EventHandler(this.Btn_eliminar_Click);
            // 
            // Btn_refrescar
            // 
            this.Btn_refrescar.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_refrescar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_refrescar.Image")));
            this.Btn_refrescar.Location = new System.Drawing.Point(817, 13);
            this.Btn_refrescar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_refrescar.Name = "Btn_refrescar";
            this.Btn_refrescar.Size = new System.Drawing.Size(60, 47);
            this.Btn_refrescar.TabIndex = 40;
            this.Btn_refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_refrescar.UseVisualStyleBackColor = true;
            this.Btn_refrescar.Click += new System.EventHandler(this.Btn_refrescar_Click);
            // 
            // Btn_Imprimir
            // 
            this.Btn_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Imprimir.Image")));
            this.Btn_Imprimir.Location = new System.Drawing.Point(884, 12);
            this.Btn_Imprimir.Name = "Btn_Imprimir";
            this.Btn_Imprimir.Size = new System.Drawing.Size(60, 47);
            this.Btn_Imprimir.TabIndex = 41;
            this.Btn_Imprimir.UseVisualStyleBackColor = true;
            // 
            // Btn_Ayuda
            // 
            this.Btn_Ayuda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Ayuda.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Ayuda.Image")));
            this.Btn_Ayuda.Location = new System.Drawing.Point(950, 12);
            this.Btn_Ayuda.Name = "Btn_Ayuda";
            this.Btn_Ayuda.Size = new System.Drawing.Size(60, 47);
            this.Btn_Ayuda.TabIndex = 42;
            this.Btn_Ayuda.UseVisualStyleBackColor = true;
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Salir.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Salir.Image")));
            this.Btn_Salir.Location = new System.Drawing.Point(1016, 13);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(60, 47);
            this.Btn_Salir.TabIndex = 43;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 24);
            this.label2.TabIndex = 44;
            this.label2.Text = "Tipo de movimiento";
            // 
            // Cbo_tipo_movimiento
            // 
            this.Cbo_tipo_movimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_tipo_movimiento.FormattingEnabled = true;
            this.Cbo_tipo_movimiento.Location = new System.Drawing.Point(21, 147);
            this.Cbo_tipo_movimiento.Name = "Cbo_tipo_movimiento";
            this.Cbo_tipo_movimiento.Size = new System.Drawing.Size(201, 24);
            this.Cbo_tipo_movimiento.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(317, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 24);
            this.label3.TabIndex = 47;
            this.label3.Text = "Materiales";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 24);
            this.label4.TabIndex = 48;
            this.label4.Text = "Almacen origen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(279, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 24);
            this.label5.TabIndex = 49;
            this.label5.Text = "Almacén Destino";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(520, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 24);
            this.label6.TabIndex = 50;
            this.label6.Text = "Orden Producción";
            // 
            // Cbo_material
            // 
            this.Cbo_material.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_material.FormattingEnabled = true;
            this.Cbo_material.Location = new System.Drawing.Point(273, 147);
            this.Cbo_material.Name = "Cbo_material";
            this.Cbo_material.Size = new System.Drawing.Size(201, 24);
            this.Cbo_material.TabIndex = 51;
            // 
            // Cbo_almacen_origen
            // 
            this.Cbo_almacen_origen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_almacen_origen.FormattingEnabled = true;
            this.Cbo_almacen_origen.Location = new System.Drawing.Point(21, 247);
            this.Cbo_almacen_origen.Name = "Cbo_almacen_origen";
            this.Cbo_almacen_origen.Size = new System.Drawing.Size(201, 24);
            this.Cbo_almacen_origen.TabIndex = 52;
            // 
            // Cbo_almacen_destino
            // 
            this.Cbo_almacen_destino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_almacen_destino.FormattingEnabled = true;
            this.Cbo_almacen_destino.Location = new System.Drawing.Point(266, 247);
            this.Cbo_almacen_destino.Name = "Cbo_almacen_destino";
            this.Cbo_almacen_destino.Size = new System.Drawing.Size(201, 24);
            this.Cbo_almacen_destino.TabIndex = 53;
            // 
            // Cbo_orden_produccion
            // 
            this.Cbo_orden_produccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_orden_produccion.FormattingEnabled = true;
            this.Cbo_orden_produccion.Location = new System.Drawing.Point(520, 147);
            this.Cbo_orden_produccion.Name = "Cbo_orden_produccion";
            this.Cbo_orden_produccion.Size = new System.Drawing.Size(201, 24);
            this.Cbo_orden_produccion.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(794, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(223, 24);
            this.label7.TabIndex = 55;
            this.label7.Text = "Recepción materiales";
            // 
            // Cbo_recepcion
            // 
            this.Cbo_recepcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_recepcion.FormattingEnabled = true;
            this.Cbo_recepcion.Location = new System.Drawing.Point(817, 147);
            this.Cbo_recepcion.Name = "Cbo_recepcion";
            this.Cbo_recepcion.Size = new System.Drawing.Size(201, 24);
            this.Cbo_recepcion.TabIndex = 56;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(527, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 24);
            this.label8.TabIndex = 57;
            this.label8.Text = "Cantidad Movida";
            // 
            // Num_cantidad
            // 
            this.Num_cantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Num_cantidad.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_cantidad.Location = new System.Drawing.Point(520, 245);
            this.Num_cantidad.Name = "Num_cantidad";
            this.Num_cantidad.Size = new System.Drawing.Size(200, 27);
            this.Num_cantidad.TabIndex = 58;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(824, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 24);
            this.label9.TabIndex = 59;
            this.label9.Text = "Observación";
            // 
            // Txt_observacion
            // 
            this.Txt_observacion.Location = new System.Drawing.Point(744, 247);
            this.Txt_observacion.Name = "Txt_observacion";
            this.Txt_observacion.Size = new System.Drawing.Size(313, 22);
            this.Txt_observacion.TabIndex = 60;
            // 
            // Dgv_movimientos
            // 
            this.Dgv_movimientos.AllowUserToAddRows = false;
            this.Dgv_movimientos.AllowUserToDeleteRows = false;
            this.Dgv_movimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_movimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_movimientos.Location = new System.Drawing.Point(21, 303);
            this.Dgv_movimientos.MultiSelect = false;
            this.Dgv_movimientos.Name = "Dgv_movimientos";
            this.Dgv_movimientos.ReadOnly = true;
            this.Dgv_movimientos.RowHeadersWidth = 51;
            this.Dgv_movimientos.RowTemplate.Height = 24;
            this.Dgv_movimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_movimientos.Size = new System.Drawing.Size(1036, 268);
            this.Dgv_movimientos.TabIndex = 61;
            this.Dgv_movimientos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_movimientos_CellClick);
            // 
            // Btn_inicio
            // 
            this.Btn_inicio.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_inicio.Image = ((System.Drawing.Image)(resources.GetObject("Btn_inicio.Image")));
            this.Btn_inicio.Location = new System.Drawing.Point(929, 578);
            this.Btn_inicio.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_inicio.Name = "Btn_inicio";
            this.Btn_inicio.Size = new System.Drawing.Size(60, 47);
            this.Btn_inicio.TabIndex = 62;
            this.Btn_inicio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_inicio.UseVisualStyleBackColor = true;
            this.Btn_inicio.Click += new System.EventHandler(this.Btn_inicio_Click);
            // 
            // Btn_fin
            // 
            this.Btn_fin.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_fin.Image = ((System.Drawing.Image)(resources.GetObject("Btn_fin.Image")));
            this.Btn_fin.Location = new System.Drawing.Point(997, 578);
            this.Btn_fin.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_fin.Name = "Btn_fin";
            this.Btn_fin.Size = new System.Drawing.Size(60, 47);
            this.Btn_fin.TabIndex = 63;
            this.Btn_fin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_fin.UseVisualStyleBackColor = true;
            this.Btn_fin.Click += new System.EventHandler(this.Btn_fin_Click);
            // 
            // Movimiento_Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 630);
            this.Controls.Add(this.Btn_fin);
            this.Controls.Add(this.Btn_inicio);
            this.Controls.Add(this.Dgv_movimientos);
            this.Controls.Add(this.Txt_observacion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Num_cantidad);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Cbo_recepcion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Cbo_orden_produccion);
            this.Controls.Add(this.Cbo_almacen_destino);
            this.Controls.Add(this.Cbo_almacen_origen);
            this.Controls.Add(this.Cbo_material);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Cbo_tipo_movimiento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Ayuda);
            this.Controls.Add(this.Btn_Imprimir);
            this.Controls.Add(this.Btn_refrescar);
            this.Controls.Add(this.Btn_eliminar);
            this.Controls.Add(this.Btn_modificar);
            this.Controls.Add(this.Btn_guardar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Movimiento_Inventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimiento_Inventario";
            this.Load += new System.EventHandler(this.Movimiento_Inventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Num_cantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_movimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Button Btn_modificar;
        private System.Windows.Forms.Button Btn_eliminar;
        private System.Windows.Forms.Button Btn_refrescar;
        private System.Windows.Forms.Button Btn_Imprimir;
        private System.Windows.Forms.Button Btn_Ayuda;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Cbo_tipo_movimiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Cbo_material;
        private System.Windows.Forms.ComboBox Cbo_almacen_origen;
        private System.Windows.Forms.ComboBox Cbo_almacen_destino;
        private System.Windows.Forms.ComboBox Cbo_orden_produccion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Cbo_recepcion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown Num_cantidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Txt_observacion;
        private System.Windows.Forms.DataGridView Dgv_movimientos;
        private System.Windows.Forms.Button Btn_inicio;
        private System.Windows.Forms.Button Btn_fin;
    }
}