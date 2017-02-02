namespace Catalogador
{
    partial class Form1
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
            this.txtRutaEntrada = new System.Windows.Forms.TextBox();
            this.btnSeleccionarRuta = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRutaSalida = new System.Windows.Forms.TextBox();
            this.fBDCarpeta = new System.Windows.Forms.FolderBrowserDialog();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.pbArchivos = new System.Windows.Forms.ProgressBar();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRutaEntrada
            // 
            this.txtRutaEntrada.Location = new System.Drawing.Point(13, 13);
            this.txtRutaEntrada.Name = "txtRutaEntrada";
            this.txtRutaEntrada.Size = new System.Drawing.Size(435, 20);
            this.txtRutaEntrada.TabIndex = 0;
            // 
            // btnSeleccionarRuta
            // 
            this.btnSeleccionarRuta.Location = new System.Drawing.Point(455, 9);
            this.btnSeleccionarRuta.Name = "btnSeleccionarRuta";
            this.btnSeleccionarRuta.Size = new System.Drawing.Size(44, 23);
            this.btnSeleccionarRuta.TabIndex = 1;
            this.btnSeleccionarRuta.Text = "...";
            this.btnSeleccionarRuta.UseVisualStyleBackColor = true;
            this.btnSeleccionarRuta.Click += new System.EventHandler(this.btnSeleccionarRuta_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(455, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtRutaSalida
            // 
            this.txtRutaSalida.Location = new System.Drawing.Point(13, 39);
            this.txtRutaSalida.Name = "txtRutaSalida";
            this.txtRutaSalida.Size = new System.Drawing.Size(435, 20);
            this.txtRutaSalida.TabIndex = 2;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(13, 66);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // pbArchivos
            // 
            this.pbArchivos.Location = new System.Drawing.Point(13, 96);
            this.pbArchivos.Name = "pbArchivos";
            this.pbArchivos.Size = new System.Drawing.Size(678, 23);
            this.pbArchivos.TabIndex = 5;
            this.pbArchivos.Visible = false;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(13, 126);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 13);
            this.lblMensaje.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 294);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.pbArchivos);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtRutaSalida);
            this.Controls.Add(this.btnSeleccionarRuta);
            this.Controls.Add(this.txtRutaEntrada);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRutaEntrada;
        private System.Windows.Forms.Button btnSeleccionarRuta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtRutaSalida;
        private System.Windows.Forms.FolderBrowserDialog fBDCarpeta;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.ProgressBar pbArchivos;
        private System.Windows.Forms.Label lblMensaje;
    }
}

