namespace AppFormRestaurante
{
    partial class Form2
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
            this.txtIniciar = new System.Windows.Forms.Button();
            this.txtCrear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIniciar
            // 
            this.txtIniciar.Location = new System.Drawing.Point(62, 67);
            this.txtIniciar.Name = "txtIniciar";
            this.txtIniciar.Size = new System.Drawing.Size(201, 23);
            this.txtIniciar.TabIndex = 0;
            this.txtIniciar.Text = "Iniciar Sesion";
            this.txtIniciar.UseVisualStyleBackColor = true;
            this.txtIniciar.Click += new System.EventHandler(this.txtIniciar_Click);
            // 
            // txtCrear
            // 
            this.txtCrear.Location = new System.Drawing.Point(62, 129);
            this.txtCrear.Name = "txtCrear";
            this.txtCrear.Size = new System.Drawing.Size(201, 23);
            this.txtCrear.TabIndex = 1;
            this.txtCrear.Text = "Crear Usuario";
            this.txtCrear.UseVisualStyleBackColor = true;
            this.txtCrear.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 216);
            this.Controls.Add(this.txtCrear);
            this.Controls.Add(this.txtIniciar);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button txtIniciar;
        private System.Windows.Forms.Button txtCrear;
    }
}