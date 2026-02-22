namespace Procesamiento_de_archivos_json
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnAbrir = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            btnEditar = new Button();
            btnRenombrar = new Button();
            btnEliminar = new Button();
            txtRutaArchivo = new TextBox();
            lblRuta = new Label();
            txtJsonRaw = new TextBox();
            btnVerJson = new Button();
            btnAgregarFila = new Button();
            btnEliminarFila = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            statusStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(7, 29);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(678, 409);
            dataGridView1.TabIndex = 0;
            // 
            // btnAbrir
            // 
            btnAbrir.Location = new Point(14, 16);
            btnAbrir.Margin = new Padding(3, 4, 3, 4);
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(114, 40);
            btnAbrir.TabIndex = 1;
            btnAbrir.Text = "Abrir Archivo";
            btnAbrir.UseVisualStyleBackColor = true;
            btnAbrir.Click += btnAbrir_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(135, 16);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(114, 40);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(256, 16);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(114, 40);
            btnNuevo.TabIndex = 3;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(377, 16);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(114, 40);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar JSON";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnRenombrar
            // 
            btnRenombrar.Location = new Point(498, 16);
            btnRenombrar.Margin = new Padding(3, 4, 3, 4);
            btnRenombrar.Name = "btnRenombrar";
            btnRenombrar.Size = new Size(114, 40);
            btnRenombrar.TabIndex = 5;
            btnRenombrar.Text = "Renombrar";
            btnRenombrar.UseVisualStyleBackColor = true;
            btnRenombrar.Click += btnRenombrar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(618, 16);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(133, 40);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar Archivo";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtRutaArchivo
            // 
            txtRutaArchivo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRutaArchivo.Location = new Point(109, 68);
            txtRutaArchivo.Margin = new Padding(3, 4, 3, 4);
            txtRutaArchivo.Name = "txtRutaArchivo";
            txtRutaArchivo.ReadOnly = true;
            txtRutaArchivo.Size = new Size(1327, 27);
            txtRutaArchivo.TabIndex = 7;
            // 
            // lblRuta
            // 
            lblRuta.AutoSize = true;
            lblRuta.Location = new Point(14, 72);
            lblRuta.Name = "lblRuta";
            lblRuta.Size = new Size(106, 20);
            lblRuta.TabIndex = 8;
            lblRuta.Text = "Archivo actual:";
            // 
            // txtJsonRaw
            // 
            txtJsonRaw.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtJsonRaw.Font = new Font("Consolas", 9F);
            txtJsonRaw.Location = new Point(7, 28);
            txtJsonRaw.Margin = new Padding(3, 4, 3, 4);
            txtJsonRaw.Multiline = true;
            txtJsonRaw.Name = "txtJsonRaw";
            txtJsonRaw.ScrollBars = ScrollBars.Both;
            txtJsonRaw.Size = new Size(701, 396);
            txtJsonRaw.TabIndex = 9;
            txtJsonRaw.WordWrap = false;
            // 
            // btnVerJson
            // 
            btnVerJson.Location = new Point(757, 16);
            btnVerJson.Margin = new Padding(3, 4, 3, 4);
            btnVerJson.Name = "btnVerJson";
            btnVerJson.Size = new Size(114, 40);
            btnVerJson.TabIndex = 10;
            btnVerJson.Text = "Ver JSON Raw";
            btnVerJson.UseVisualStyleBackColor = true;
            btnVerJson.Click += btnVerJson_Click;
            // 
            // btnAgregarFila
            // 
            btnAgregarFila.Location = new Point(877, 16);
            btnAgregarFila.Margin = new Padding(3, 4, 3, 4);
            btnAgregarFila.Name = "btnAgregarFila";
            btnAgregarFila.Size = new Size(114, 40);
            btnAgregarFila.TabIndex = 11;
            btnAgregarFila.Text = "Agregar Fila";
            btnAgregarFila.UseVisualStyleBackColor = true;
            btnAgregarFila.Click += btnAgregarFila_Click;
            // 
            // btnEliminarFila
            // 
            btnEliminarFila.Location = new Point(997, 16);
            btnEliminarFila.Margin = new Padding(3, 4, 3, 4);
            btnEliminarFila.Name = "btnEliminarFila";
            btnEliminarFila.Size = new Size(114, 40);
            btnEliminarFila.TabIndex = 12;
            btnEliminarFila.Text = "Eliminar Fila";
            btnEliminarFila.UseVisualStyleBackColor = true;
            btnEliminarFila.Click += btnEliminarFila_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 578);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1459, 26);
            statusStrip1.TabIndex = 13;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(49, 20);
            toolStripStatusLabel1.Text = "Listo...";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Location = new Point(14, 107);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(691, 446);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Vista de Datos (Tabla)";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(txtJsonRaw);
            groupBox2.Location = new Point(720, 120);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(716, 433);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "JSON Raw (Solo lectura)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1459, 604);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(statusStrip1);
            Controls.Add(btnEliminarFila);
            Controls.Add(btnAgregarFila);
            Controls.Add(btnVerJson);
            Controls.Add(lblRuta);
            Controls.Add(txtRutaArchivo);
            Controls.Add(btnEliminar);
            Controls.Add(btnRenombrar);
            Controls.Add(btnEditar);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnAbrir);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(912, 651);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Procesador de Archivos JSON";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnAbrir;
        private Button btnGuardar;
        private Button btnNuevo;
        private Button btnEditar;
        private Button btnRenombrar;
        private Button btnEliminar;
        private TextBox txtRutaArchivo;
        private Label lblRuta;
        private TextBox txtJsonRaw;
        private Button btnVerJson;
        private Button btnAgregarFila;
        private Button btnEliminarFila;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}
