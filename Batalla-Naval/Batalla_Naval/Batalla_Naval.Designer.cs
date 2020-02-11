namespace Batalla_Naval
{
    partial class Batalla_Naval
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
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Batalla_Naval));
            this.pictureBox_Presentacion = new System.Windows.Forms.PictureBox();
            this.btn_Cliente = new System.Windows.Forms.Button();
            this.btn_Servidor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Presentacion)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Presentacion
            // 
            this.pictureBox_Presentacion.Image = global::Batalla_Naval.Properties.Resources.Presentacion;
            this.pictureBox_Presentacion.Location = new System.Drawing.Point(1, -2);
            this.pictureBox_Presentacion.Name = "pictureBox_Presentacion";
            this.pictureBox_Presentacion.Size = new System.Drawing.Size(482, 213);
            this.pictureBox_Presentacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Presentacion.TabIndex = 0;
            this.pictureBox_Presentacion.TabStop = false;
            // 
            // btn_Cliente
            // 
            this.btn_Cliente.Location = new System.Drawing.Point(160, 229);
            this.btn_Cliente.Name = "btn_Cliente";
            this.btn_Cliente.Size = new System.Drawing.Size(150, 43);
            this.btn_Cliente.TabIndex = 1;
            this.btn_Cliente.Text = "Cliente";
            this.btn_Cliente.UseVisualStyleBackColor = true;
            this.btn_Cliente.Click += new System.EventHandler(this.btn_Cliente_Click);
            // 
            // btn_Servidor
            // 
            this.btn_Servidor.Location = new System.Drawing.Point(160, 292);
            this.btn_Servidor.Name = "btn_Servidor";
            this.btn_Servidor.Size = new System.Drawing.Size(150, 43);
            this.btn_Servidor.TabIndex = 2;
            this.btn_Servidor.Text = "Servidor";
            this.btn_Servidor.UseVisualStyleBackColor = true;
            this.btn_Servidor.Click += new System.EventHandler(this.btn_Servidor_Click);
            // 
            // Batalla_Naval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(482, 356);
            this.Controls.Add(this.btn_Servidor);
            this.Controls.Add(this.btn_Cliente);
            this.Controls.Add(this.pictureBox_Presentacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Batalla_Naval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batalla Naval";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Presentacion)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.PictureBox pictureBox_Presentacion;
        private System.Windows.Forms.Button btn_Cliente;
        private System.Windows.Forms.Button btn_Servidor;
    }
}