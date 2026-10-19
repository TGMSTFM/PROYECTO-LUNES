namespace MesaPartesDigital
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.gbRegistro = new System.Windows.Forms.GroupBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCiudadano = new System.Windows.Forms.Label();
            this.txtCiudadano = new System.Windows.Forms.TextBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.cmbDocumento = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblAsunto = new System.Windows.Forms.Label();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.lblEstadoInicial = new System.Windows.Forms.Label();
            this.gbConsulta = new System.Windows.Forms.GroupBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.btnOrdenar = new System.Windows.Forms.Button();
            this.dgvExpedientes = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpedientes)).BeginInit();
            this.gbRegistro.SuspendLayout();
            this.gbConsulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRegistro
            // 
            this.gbRegistro.Location = new System.Drawing.Point(12, 12);
            this.gbRegistro.Name = "gbRegistro";
            this.gbRegistro.Size = new System.Drawing.Size(836, 190);
            this.gbRegistro.TabStop = false;
            this.gbRegistro.Text = "Registro de expediente";
            this.gbRegistro.Controls.Add(this.lblCodigo);
            this.gbRegistro.Controls.Add(this.txtCodigo);
            this.gbRegistro.Controls.Add(this.lblCiudadano);
            this.gbRegistro.Controls.Add(this.txtCiudadano);
            this.gbRegistro.Controls.Add(this.lblDocumento);
            this.gbRegistro.Controls.Add(this.cmbDocumento);
            this.gbRegistro.Controls.Add(this.lblFecha);
            this.gbRegistro.Controls.Add(this.dtpFecha);
            this.gbRegistro.Controls.Add(this.lblAsunto);
            this.gbRegistro.Controls.Add(this.txtAsunto);
            this.gbRegistro.Controls.Add(this.btnRegistrar);
            this.gbRegistro.Controls.Add(this.lblEstadoInicial);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(15, 32);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(150, 29);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(150, 27);
            this.txtCodigo.MaxLength = 12;
            // 
            // lblCiudadano
            // 
            this.lblCiudadano.AutoSize = true;
            this.lblCiudadano.Location = new System.Drawing.Point(330, 32);
            this.lblCiudadano.Name = "lblCiudadano";
            this.lblCiudadano.Text = "Ciudadano:";
            // 
            // txtCiudadano
            // 
            this.txtCiudadano.Location = new System.Drawing.Point(430, 29);
            this.txtCiudadano.Name = "txtCiudadano";
            this.txtCiudadano.Size = new System.Drawing.Size(385, 27);
            this.txtCiudadano.MaxLength = 60;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(15, 72);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Text = "Tipo de documento:";
            // 
            // cmbDocumento
            // 
            this.cmbDocumento.Location = new System.Drawing.Point(150, 69);
            this.cmbDocumento.Name = "cmbDocumento";
            this.cmbDocumento.Size = new System.Drawing.Size(150, 28);
            this.cmbDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(330, 72);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Text = "Fecha de recepción:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(470, 69);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(130, 27);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // lblAsunto
            // 
            this.lblAsunto.AutoSize = true;
            this.lblAsunto.Location = new System.Drawing.Point(15, 112);
            this.lblAsunto.Name = "lblAsunto";
            this.lblAsunto.Text = "Asunto:";
            // 
            // txtAsunto
            // 
            this.txtAsunto.Location = new System.Drawing.Point(150, 109);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(665, 27);
            this.txtAsunto.MaxLength = 150;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(150, 148);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(170, 32);
            this.btnRegistrar.Text = "Registrar expediente";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            // 
            // lblEstadoInicial
            // 
            this.lblEstadoInicial.AutoSize = true;
            this.lblEstadoInicial.Location = new System.Drawing.Point(340, 155);
            this.lblEstadoInicial.Name = "lblEstadoInicial";
            this.lblEstadoInicial.Text = "Estado inicial: Recibido";
            // 
            // gbConsulta
            // 
            this.gbConsulta.Location = new System.Drawing.Point(12, 210);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(836, 70);
            this.gbConsulta.TabStop = false;
            this.gbConsulta.Text = "Consulta y orden";
            this.gbConsulta.Controls.Add(this.lblBuscar);
            this.gbConsulta.Controls.Add(this.txtBuscar);
            this.gbConsulta.Controls.Add(this.btnBuscar);
            this.gbConsulta.Controls.Add(this.btnMostrarTodos);
            this.gbConsulta.Controls.Add(this.btnOrdenar);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(15, 32);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Text = "Código a buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(135, 29);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(150, 27);
            this.txtBuscar.MaxLength = 12;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(300, 27);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(95, 31);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.Location = new System.Drawing.Point(405, 27);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(140, 31);
            this.btnMostrarTodos.Text = "Mostrar todos";
            this.btnMostrarTodos.UseVisualStyleBackColor = true;
            // 
            // btnOrdenar
            // 
            this.btnOrdenar.Location = new System.Drawing.Point(555, 27);
            this.btnOrdenar.Name = "btnOrdenar";
            this.btnOrdenar.Size = new System.Drawing.Size(170, 31);
            this.btnOrdenar.Text = "Ordenar por código";
            this.btnOrdenar.UseVisualStyleBackColor = true;
            // 
            // dgvExpedientes
            // 
            this.dgvExpedientes.Location = new System.Drawing.Point(12, 290);
            this.dgvExpedientes.Name = "dgvExpedientes";
            this.dgvExpedientes.Size = new System.Drawing.Size(836, 230);
            this.dgvExpedientes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(12, 528);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.lblTotal.Text = "Expedientes registrados: 0";
            this.txtCodigo.TabIndex = 0;
            this.txtCiudadano.TabIndex = 1;
            this.cmbDocumento.TabIndex = 2;
            this.dtpFecha.TabIndex = 3;
            this.txtAsunto.TabIndex = 4;
            this.btnRegistrar.TabIndex = 5;
            this.txtBuscar.TabIndex = 6;
            this.btnBuscar.TabIndex = 7;
            this.btnMostrarTodos.TabIndex = 8;
            this.btnOrdenar.TabIndex = 9;
            this.dgvExpedientes.TabStop = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            this.btnOrdenar.Click += new System.EventHandler(this.btnOrdenar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 560);
            this.Controls.Add(this.gbRegistro);
            this.Controls.Add(this.gbConsulta);
            this.Controls.Add(this.dgvExpedientes);
            this.Controls.Add(this.lblTotal);
            this.MinimumSize = new System.Drawing.Size(760, 480);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mesa de Partes Digital - Prototipo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpedientes)).EndInit();
            this.gbRegistro.ResumeLayout(false);
            this.gbRegistro.PerformLayout();
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox gbRegistro;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCiudadano;
        private System.Windows.Forms.TextBox txtCiudadano;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.ComboBox cmbDocumento;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblAsunto;
        private System.Windows.Forms.TextBox txtAsunto;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label lblEstadoInicial;
        private System.Windows.Forms.GroupBox gbConsulta;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.Button btnOrdenar;
        private System.Windows.Forms.DataGridView dgvExpedientes;
        private System.Windows.Forms.Label lblTotal;
    }
}
