namespace FinalBasesDatosII
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUpdate = new System.Windows.Forms.TextBox();
            this.lbMensaje = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.rtbNotificacion = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtUpdate
            // 
            this.txtUpdate.Location = new System.Drawing.Point(24, 80);
            this.txtUpdate.Name = "txtUpdate";
            this.txtUpdate.Size = new System.Drawing.Size(753, 20);
            this.txtUpdate.TabIndex = 0;
            // 
            // lbMensaje
            // 
            this.lbMensaje.AutoSize = true;
            this.lbMensaje.Location = new System.Drawing.Point(21, 54);
            this.lbMensaje.Name = "lbMensaje";
            this.lbMensaje.Size = new System.Drawing.Size(295, 13);
            this.lbMensaje.TabIndex = 1;
            this.lbMensaje.Text = "Ingrese la sentencia UPDATE a efectuar el la Base de Datos";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(24, 121);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // rtbNotificacion
            // 
            this.rtbNotificacion.Location = new System.Drawing.Point(24, 165);
            this.rtbNotificacion.Name = "rtbNotificacion";
            this.rtbNotificacion.Size = new System.Drawing.Size(753, 265);
            this.rtbNotificacion.TabIndex = 3;
            this.rtbNotificacion.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbNotificacion);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lbMensaje);
            this.Controls.Add(this.txtUpdate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUpdate;
        private System.Windows.Forms.Label lbMensaje;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.RichTextBox rtbNotificacion;
    }
}

