namespace Vista
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.btnAdministrador = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnVehiculo = new System.Windows.Forms.Button();
            this.lblApartados = new System.Windows.Forms.Label();
            this.btnReserva = new System.Windows.Forms.Button();
            this.btnAyuda = new System.Windows.Forms.PictureBox();
            this.btnCerrarSesión = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnAyuda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrarSesión)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdministrador
            // 
            this.btnAdministrador.BackColor = System.Drawing.Color.Transparent;
            this.btnAdministrador.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdministrador.BackgroundImage")));
            this.btnAdministrador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrador.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnAdministrador.Location = new System.Drawing.Point(487, 173);
            this.btnAdministrador.Name = "btnAdministrador";
            this.btnAdministrador.Size = new System.Drawing.Size(129, 28);
            this.btnAdministrador.TabIndex = 4;
            this.btnAdministrador.Text = "Administrador";
            this.btnAdministrador.UseVisualStyleBackColor = false;
            this.btnAdministrador.Click += new System.EventHandler(this.btnAdministrador_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUsuario.BackgroundImage")));
            this.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuario.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnUsuario.Location = new System.Drawing.Point(487, 236);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(129, 28);
            this.btnUsuario.TabIndex = 5;
            this.btnUsuario.Text = "Cliente";
            this.btnUsuario.UseVisualStyleBackColor = false;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnVehiculo
            // 
            this.btnVehiculo.BackColor = System.Drawing.Color.Transparent;
            this.btnVehiculo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVehiculo.BackgroundImage")));
            this.btnVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVehiculo.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehiculo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnVehiculo.Location = new System.Drawing.Point(487, 303);
            this.btnVehiculo.Name = "btnVehiculo";
            this.btnVehiculo.Size = new System.Drawing.Size(129, 28);
            this.btnVehiculo.TabIndex = 6;
            this.btnVehiculo.Text = "Vehiculo";
            this.btnVehiculo.UseVisualStyleBackColor = false;
            this.btnVehiculo.Click += new System.EventHandler(this.btnVehiculo_Click);
            // 
            // lblApartados
            // 
            this.lblApartados.AutoSize = true;
            this.lblApartados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblApartados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblApartados.Font = new System.Drawing.Font("Baskerville Old Face", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApartados.ForeColor = System.Drawing.Color.White;
            this.lblApartados.Location = new System.Drawing.Point(400, 44);
            this.lblApartados.Name = "lblApartados";
            this.lblApartados.Size = new System.Drawing.Size(304, 75);
            this.lblApartados.TabIndex = 8;
            this.lblApartados.Text = "Apartados";
            // 
            // btnReserva
            // 
            this.btnReserva.BackColor = System.Drawing.Color.Transparent;
            this.btnReserva.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReserva.BackgroundImage")));
            this.btnReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReserva.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReserva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnReserva.Location = new System.Drawing.Point(487, 366);
            this.btnReserva.Name = "btnReserva";
            this.btnReserva.Size = new System.Drawing.Size(129, 28);
            this.btnReserva.TabIndex = 9;
            this.btnReserva.Text = "Reserva";
            this.btnReserva.UseVisualStyleBackColor = false;
            this.btnReserva.Click += new System.EventHandler(this.btnReserva_Click);
            // 
            // btnAyuda
            // 
            this.btnAyuda.Image = global::Vista.Properties.Resources.Ayuda;
            this.btnAyuda.Location = new System.Drawing.Point(697, 373);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(40, 31);
            this.btnAyuda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAyuda.TabIndex = 12;
            this.btnAyuda.TabStop = false;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // btnCerrarSesión
            // 
            this.btnCerrarSesión.Image = global::Vista.Properties.Resources.Salir;
            this.btnCerrarSesión.Location = new System.Drawing.Point(697, 410);
            this.btnCerrarSesión.Name = "btnCerrarSesión";
            this.btnCerrarSesión.Size = new System.Drawing.Size(40, 31);
            this.btnCerrarSesión.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCerrarSesión.TabIndex = 11;
            this.btnCerrarSesión.TabStop = false;
            this.btnCerrarSesión.Click += new System.EventHandler(this.btnCerrarSesión_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Vista.Properties.Resources.azumlito;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(341, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(749, 450);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.btnCerrarSesión);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnReserva);
            this.Controls.Add(this.lblApartados);
            this.Controls.Add(this.btnVehiculo);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnAdministrador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            ((System.ComponentModel.ISupportInitialize)(this.btnAyuda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrarSesión)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdministrador;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnVehiculo;
        private System.Windows.Forms.Label lblApartados;
        private System.Windows.Forms.Button btnReserva;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnCerrarSesión;
        private System.Windows.Forms.PictureBox btnAyuda;
    }
}