using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Net;
using Servidor;
using System;


namespace Cliente
{
    public partial class Ingreso_Datos : Form
    {
        public string cliente_servidor;
        public string nombreUsuarios;
        public Socket clienteSocket;
        bool servidor_activo;
        public Ingreso_Datos()
        {
            InitializeComponent();
            servidor_activo = false;
        }
        private void Ingreso_Datos_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }
        private void btn_Jugar_Click(object sender, EventArgs e)
        {
            if (txt_Puerto.Text == "" || txt_Ip.Text == "" || txt_Usuario.Text == "")
            {
                MessageBox.Show("Debe ingresar todos os parametros...");
            }
            else
            {
                if (cliente_servidor == "cliente")
                {
                    try
                    {
                        clienteSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        IPAddress ipAddress = IPAddress.Parse(txt_Ip.Text);
                        IPEndPoint puntofinal = new IPEndPoint(ipAddress, Convert.ToInt32(txt_Puerto.Text));
                        clienteSocket.BeginConnect(puntofinal, new AsyncCallback(Conectado), null);
                        if (servidor_activo == true)
                        {
                            Cliente nuevo_Formulario = new Cliente();
                            Data datos = new Data();
                            datos.nombre = txt_Usuario.Text;
                            nuevo_Formulario.cliente_servidor = cliente_servidor;
                            nuevo_Formulario.clienteSocket = clienteSocket;
                            nuevo_Formulario.usuario = txt_Usuario.Text;
                            nuevo_Formulario.puerto = txt_Puerto.Text;
                            nuevo_Formulario.ip = txt_Ip.Text;
                            nuevo_Formulario.iniciar = true;
                            Hide();
                            nuevo_Formulario.Show();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (cliente_servidor == "servidor")
                {
                    try
                    {
                        clienteSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        IPAddress ipAddress = IPAddress.Parse(txt_Ip.Text);
                        IPEndPoint puntofinal = new IPEndPoint(ipAddress, Convert.ToInt32(txt_Puerto.Text));
                        clienteSocket.BeginConnect(puntofinal, new AsyncCallback(Conectado), null);
                        if (servidor_activo == true)
                        {
                            Cliente nuevo_Formulario = new Cliente();
                            Data datos = new Data();
                            datos.nombre = txt_Usuario.Text;
                            nuevo_Formulario.cliente_servidor = cliente_servidor;
                            nuevo_Formulario.clienteSocket = clienteSocket;
                            nuevo_Formulario.usuario = txt_Usuario.Text;
                            nuevo_Formulario.puerto = txt_Puerto.Text;
                            nuevo_Formulario.ip = txt_Ip.Text;
                            nuevo_Formulario.iniciar = true;
                            Hide();
                            nuevo_Formulario.Show();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void Enviar(IAsyncResult ar)
        {
            try
            {
                clienteSocket.EndSend(ar);
                nombreUsuarios = txt_Usuario.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Conectado(IAsyncResult ar)
        {
            try
            {
                clienteSocket.EndConnect(ar);
                Data mensajeEnviado = new Data();
                mensajeEnviado.comando = Command.LOGIN;
                mensajeEnviado.nombre = txt_Usuario.Text;
                mensajeEnviado.mensaje = null;
                byte[] datos = mensajeEnviado.convertir_a_Bytes();
                clienteSocket.BeginSend(datos, 0, datos.Length, SocketFlags.None, new AsyncCallback(Enviar), null);
                servidor_activo = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                servidor_activo = false;
            }
        }
    }
}