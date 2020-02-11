namespace Cliente
{
    partial class Ingreso_Datos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ingreso_Datos));
            this.pictureBox_Presentacion = new System.Windows.Forms.PictureBox();
            this.txt_Puerto = new System.Windows.Forms.TextBox();
            this.txt_Ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Jugar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Usuario = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Presentacion)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Presentacion
            // 
            this.pictureBox_Presentacion.Image = global::Cliente.Properties.Resources.Presentacion;
            this.pictureBox_Presentacion.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Presentacion.Name = "pictureBox_Presentacion";
            this.pictureBox_Presentacion.Size = new System.Drawing.Size(483, 204);
            this.pictureBox_Presentacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Presentacion.TabIndex = 0;
            this.pictureBox_Presentacion.TabStop = false;
            // 
            // txt_Puerto
            // 
            this.txt_Puerto.Location = new System.Drawing.Point(338, 236);
            this.txt_Puerto.Name = "txt_Puerto";
            this.txt_Puerto.Size = new System.Drawing.Size(132, 20);
            this.txt_Puerto.TabIndex = 1;
            // 
            // txt_Ip
            // 
            this.txt_Ip.Location = new System.Drawing.Point(338, 262);
            this.txt_Ip.Name = "txt_Ip";
            this.txt_Ip.Size = new System.Drawing.Size(132, 20);
            this.txt_Ip.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Papyrus", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(12, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "INGRESE EL NÚMERO DE PUERTO: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Papyrus", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(12, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "INGRESE LA DIRECION IP DEL SERVIDOR:";
            // 
            // btn_Jugar
            // 
            this.btn_Jugar.Location = new System.Drawing.Point(167, 305);
            this.btn_Jugar.Name = "btn_Jugar";
            this.btn_Jugar.Size = new System.Drawing.Size(139, 39);
            this.btn_Jugar.TabIndex = 3;
            this.btn_Jugar.Text = "JUGAR";
            this.btn_Jugar.UseVisualStyleBackColor = true;
            this.btn_Jugar.Click += new System.EventHandler(this.btn_Jugar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Papyrus", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(12, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "INGRESE SU USUARIO:";
            // 
            // txt_Usuario
            // 
            this.txt_Usuario.Location = new System.Drawing.Point(338, 210);
            this.txt_Usuario.Name = "txt_Usuario";
            this.txt_Usuario.Size = new System.Drawing.Size(132, 20);
            this.txt_Usuario.TabIndex = 0;
            // 
            // Ingreso_Datos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(482, 356);
            this.Controls.Add(this.txt_Usuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Jugar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Ip);
            this.Controls.Add(this.txt_Puerto);
            this.Controls.Add(this.pictureBox_Presentacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ingreso_Datos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso_Datos";
            this.Load += new System.EventHandler(this.Ingreso_Datos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Presentacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.PictureBox pictureBox_Presentacion;
        private System.Windows.Forms.TextBox txt_Puerto;
        private System.Windows.Forms.TextBox txt_Ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Jugar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Usuario;
    }
}