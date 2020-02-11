namespace Cliente
{
    partial class Cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cliente));
            this.etiqueta_ColocarFichas = new System.Windows.Forms.Label();
            this.rxt_Resumen = new System.Windows.Forms.RichTextBox();
            this.etiqueta_Oponente = new System.Windows.Forms.Label();
            this.Panel_Oponente = new System.Windows.Forms.Panel();
            this.lista_Coordenadas = new System.Windows.Forms.ListBox();
            this.etiqueta_Jugador = new System.Windows.Forms.Label();
            this.listBox_Fichas = new System.Windows.Forms.ListBox();
            this.btn_Colocar_Fichas = new System.Windows.Forms.Button();
            this.Panel_Jugador = new System.Windows.Forms.Panel();
            this.lstChatters = new System.Windows.Forms.ListBox();
            this.txtChatBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_enviar_Mensaje = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btn_Iniciar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // etiqueta_ColocarFichas
            // 
            this.etiqueta_ColocarFichas.AutoSize = true;
            this.etiqueta_ColocarFichas.Location = new System.Drawing.Point(12, 295);
            this.etiqueta_ColocarFichas.Name = "etiqueta_ColocarFichas";
            this.etiqueta_ColocarFichas.Size = new System.Drawing.Size(205, 51);
            this.etiqueta_ColocarFichas.TabIndex = 26;
            this.etiqueta_ColocarFichas.Text = "Escoja una ficha,\r\nColoquela sobre el tablero.\r\nPara girar presione la letra \"R\"." +
    "";
            // 
            // rxt_Resumen
            // 
            this.rxt_Resumen.Location = new System.Drawing.Point(251, 299);
            this.rxt_Resumen.Margin = new System.Windows.Forms.Padding(4);
            this.rxt_Resumen.Name = "rxt_Resumen";
            this.rxt_Resumen.ReadOnly = true;
            this.rxt_Resumen.Size = new System.Drawing.Size(308, 96);
            this.rxt_Resumen.TabIndex = 25;
            this.rxt_Resumen.Text = "";
            // 
            // etiqueta_Oponente
            // 
            this.etiqueta_Oponente.AutoSize = true;
            this.etiqueta_Oponente.Location = new System.Drawing.Point(413, 9);
            this.etiqueta_Oponente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.etiqueta_Oponente.Name = "etiqueta_Oponente";
            this.etiqueta_Oponente.Size = new System.Drawing.Size(149, 17);
            this.etiqueta_Oponente.TabIndex = 22;
            this.etiqueta_Oponente.Text = "Jugador 2 (Oponente)";
            // 
            // Panel_Oponente
            // 
            this.Panel_Oponente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_Oponente.Location = new System.Drawing.Point(417, 28);
            this.Panel_Oponente.Margin = new System.Windows.Forms.Padding(4);
            this.Panel_Oponente.Name = "Panel_Oponente";
            this.Panel_Oponente.Size = new System.Drawing.Size(285, 263);
            this.Panel_Oponente.TabIndex = 21;
            this.Panel_Oponente.Click += new System.EventHandler(this.Panel_Oponente_Click);
            this.Panel_Oponente.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_Oponente_MouseMove);
            // 
            // lista_Coordenadas
            // 
            this.lista_Coordenadas.FormattingEnabled = true;
            this.lista_Coordenadas.ItemHeight = 16;
            this.lista_Coordenadas.Location = new System.Drawing.Point(13, 350);
            this.lista_Coordenadas.Margin = new System.Windows.Forms.Padding(4);
            this.lista_Coordenadas.Name = "lista_Coordenadas";
            this.lista_Coordenadas.Size = new System.Drawing.Size(230, 36);
            this.lista_Coordenadas.TabIndex = 0;
            // 
            // etiqueta_Jugador
            // 
            this.etiqueta_Jugador.AutoSize = true;
            this.etiqueta_Jugador.Location = new System.Drawing.Point(16, 9);
            this.etiqueta_Jugador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.etiqueta_Jugador.Name = "etiqueta_Jugador";
            this.etiqueta_Jugador.Size = new System.Drawing.Size(72, 17);
            this.etiqueta_Jugador.TabIndex = 20;
            this.etiqueta_Jugador.Text = "Jugador 1";
            // 
            // listBox_Fichas
            // 
            this.listBox_Fichas.FormattingEnabled = true;
            this.listBox_Fichas.ItemHeight = 16;
            this.listBox_Fichas.Items.AddRange(new object[] {
            "AircraftCarrier",
            "Battleship",
            "Submarine",
            "Destroyer",
            "PatrolBoat"});
            this.listBox_Fichas.Location = new System.Drawing.Point(309, 28);
            this.listBox_Fichas.Margin = new System.Windows.Forms.Padding(4);
            this.listBox_Fichas.Name = "listBox_Fichas";
            this.listBox_Fichas.Size = new System.Drawing.Size(99, 84);
            this.listBox_Fichas.TabIndex = 18;
            // 
            // btn_Colocar_Fichas
            // 
            this.btn_Colocar_Fichas.Location = new System.Drawing.Point(309, 121);
            this.btn_Colocar_Fichas.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Colocar_Fichas.Name = "btn_Colocar_Fichas";
            this.btn_Colocar_Fichas.Size = new System.Drawing.Size(100, 43);
            this.btn_Colocar_Fichas.TabIndex = 16;
            this.btn_Colocar_Fichas.Text = "Colocar Fichas";
            this.btn_Colocar_Fichas.UseVisualStyleBackColor = true;
            this.btn_Colocar_Fichas.Click += new System.EventHandler(this.btn_IniciarJuego_Click);
            // 
            // Panel_Jugador
            // 
            this.Panel_Jugador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_Jugador.Location = new System.Drawing.Point(16, 28);
            this.Panel_Jugador.Margin = new System.Windows.Forms.Padding(4);
            this.Panel_Jugador.Name = "Panel_Jugador";
            this.Panel_Jugador.Size = new System.Drawing.Size(285, 263);
            this.Panel_Jugador.TabIndex = 14;
            this.Panel_Jugador.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Panel_Jugador_MouseClick);
            this.Panel_Jugador.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_Jugador_MouseDown);
            this.Panel_Jugador.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_Jugador_MouseMove);
            this.Panel_Jugador.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel_Jugador_MouseUp);
            // 
            // lstChatters
            // 
            this.lstChatters.FormattingEnabled = true;
            this.lstChatters.ItemHeight = 16;
            this.lstChatters.Location = new System.Drawing.Point(711, 28);
            this.lstChatters.Margin = new System.Windows.Forms.Padding(4);
            this.lstChatters.Name = "lstChatters";
            this.lstChatters.Size = new System.Drawing.Size(196, 68);
            this.lstChatters.TabIndex = 27;
            // 
            // txtChatBox
            // 
            this.txtChatBox.Location = new System.Drawing.Point(711, 105);
            this.txtChatBox.Margin = new System.Windows.Forms.Padding(4);
            this.txtChatBox.Multiline = true;
            this.txtChatBox.Name = "txtChatBox";
            this.txtChatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChatBox.Size = new System.Drawing.Size(196, 186);
            this.txtChatBox.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(711, 299);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Escriba aqui su mensaje:";
            // 
            // btn_enviar_Mensaje
            // 
            this.btn_enviar_Mensaje.Location = new System.Drawing.Point(711, 368);
            this.btn_enviar_Mensaje.Margin = new System.Windows.Forms.Padding(4);
            this.btn_enviar_Mensaje.Name = "btn_enviar_Mensaje";
            this.btn_enviar_Mensaje.Size = new System.Drawing.Size(197, 28);
            this.btn_enviar_Mensaje.TabIndex = 30;
            this.btn_enviar_Mensaje.Text = "&Enviar";
            this.btn_enviar_Mensaje.UseVisualStyleBackColor = true;
            this.btn_enviar_Mensaje.Click += new System.EventHandler(this.btn_enviar_Mensaje_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(711, 319);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(196, 41);
            this.txtMessage.TabIndex = 29;
            // 
            // btn_Iniciar
            // 
            this.btn_Iniciar.Location = new System.Drawing.Point(309, 171);
            this.btn_Iniciar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Iniciar.Name = "btn_Iniciar";
            this.btn_Iniciar.Size = new System.Drawing.Size(100, 43);
            this.btn_Iniciar.TabIndex = 32;
            this.btn_Iniciar.Text = "Iniciar";
            this.btn_Iniciar.UseVisualStyleBackColor = true;
            this.btn_Iniciar.Click += new System.EventHandler(this.btn_Iniciar_Click);
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 405);
            this.Controls.Add(this.lista_Coordenadas);
            this.Controls.Add(this.btn_Iniciar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_enviar_Mensaje);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtChatBox);
            this.Controls.Add(this.lstChatters);
            this.Controls.Add(this.etiqueta_ColocarFichas);
            this.Controls.Add(this.rxt_Resumen);
            this.Controls.Add(this.etiqueta_Oponente);
            this.Controls.Add(this.Panel_Oponente);
            this.Controls.Add(this.etiqueta_Jugador);
            this.Controls.Add(this.listBox_Fichas);
            this.Controls.Add(this.btn_Colocar_Fichas);
            this.Controls.Add(this.Panel_Jugador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.Cliente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cliente_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label etiqueta_ColocarFichas;
        private System.Windows.Forms.RichTextBox rxt_Resumen;
        private System.Windows.Forms.Label etiqueta_Oponente;
        private System.Windows.Forms.Panel Panel_Oponente;
        private System.Windows.Forms.Label etiqueta_Jugador;
        private System.Windows.Forms.ListBox listBox_Fichas;
        private System.Windows.Forms.Button btn_Colocar_Fichas;
        private System.Windows.Forms.Panel Panel_Jugador;
        private System.Windows.Forms.ListBox lstChatters;
        private System.Windows.Forms.TextBox txtChatBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_enviar_Mensaje;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btn_Iniciar;
        private System.Windows.Forms.ListBox lista_Coordenadas;
    }
}