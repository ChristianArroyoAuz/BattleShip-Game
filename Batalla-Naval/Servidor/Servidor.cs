using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Collections;
using System.Drawing;
using System.Data;
using System.Text;
using System.Net;
using System;


namespace Servidor
{
    public partial class Servidor : Form
    {
        struct ClienteInformacion
        {
            public Socket socket;
            public string nombredeusuario;
        }
        ArrayList listaDeClientes;
        Socket servidorSocket;
        byte[] bytedeDatos = new byte[1024];
        public Servidor()
        {
            InitializeComponent();
            listaDeClientes = new ArrayList();
        }
        private void Servidor_Load(object sender, EventArgs e)
        {
            try
            {
                servidorSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint puntoFinal = new IPEndPoint(IPAddress.Any, 5500);
                servidorSocket.Bind(puntoFinal);
                servidorSocket.Listen(4);
                servidorSocket.BeginAccept(new AsyncCallback(AcceptarLLamada), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Servidor TCP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AcceptarLLamada(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = servidorSocket.EndAccept(ar);
                servidorSocket.BeginAccept(new AsyncCallback(AcceptarLLamada), null);
                clientSocket.BeginReceive(bytedeDatos, 0, bytedeDatos.Length, SocketFlags.None, new AsyncCallback(Recibir), clientSocket);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Recibir(IAsyncResult ar)
        {
            try
            {
                Socket clienteSocket = (Socket)ar.AsyncState;
                clienteSocket.EndReceive(ar);
                Datos mensajeRecibido = new Datos(bytedeDatos);
                Datos mensajesInformacion = new Datos(bytedeDatos);
                Datos mensajeEnviado = new Datos();
                byte[] mensaje;
                mensajeEnviado.comandos = mensajeRecibido.comandos;
                mensajeEnviado.nombreUsuarios = mensajeRecibido.nombreUsuarios;
                mensajeEnviado.comandos = mensajesInformacion.comandos;
                mensajeEnviado.nombreUsuarios = mensajesInformacion.nombreUsuarios;
                switch (mensajeRecibido.comandos)
                {
                    case Command.LOGIN:
                        ClienteInformacion clientesInfo = new ClienteInformacion();
                        clientesInfo.socket = clienteSocket;
                        clientesInfo.nombredeusuario = mensajeRecibido.nombreUsuarios;
                        listaDeClientes.Add(clientesInfo);
                        mensajeEnviado.mensajeTexto = "<<<" + mensajeRecibido.nombreUsuarios + " se ha unido al juego...>>>";
                        break;
                    case Command.LOGOUT:
                        int contador = 0;
                        foreach (ClienteInformacion cliente in listaDeClientes)
                        {
                            if (cliente.socket == clienteSocket)
                            {
                                listaDeClientes.RemoveAt(contador);
                                break;
                            }
                            ++contador;
                        }

                        clienteSocket.Close();
                        mensajeEnviado.mensajeTexto = "<<<" + mensajeRecibido.nombreUsuarios + " ha dejado el juego...>>>";
                        break;
                    case Command.MENSAJE:
                        mensajeEnviado.mensajeTexto = mensajeRecibido.nombreUsuarios + ": " + mensajeRecibido.mensajeTexto;
                        break;
                    case Command.LISTA:
                        mensajeEnviado.comandos = Command.LISTA;
                        mensajeEnviado.nombreUsuarios = null;
                        mensajeEnviado.mensajeTexto = null;
                        foreach (ClienteInformacion cliente in listaDeClientes)
                        {
                            mensajeEnviado.mensajeTexto += cliente.nombredeusuario + "*";
                        }
                        mensaje = mensajeEnviado.convertir_a_Bytes();
                        clienteSocket.BeginSend(mensaje, 0, mensaje.Length, SocketFlags.None, new AsyncCallback(Envio), clienteSocket);
                        break;
                    case Command.LISTO1:
                        mensajeEnviado.mensajeTexto = mensajesInformacion.nombreUsuarios + ": " + mensajesInformacion.mensajeTexto;
                        break;
                    case Command.LISTO2:
                        mensajeEnviado.mensajeTexto = mensajesInformacion.nombreUsuarios + ": " + mensajesInformacion.mensajeTexto;
                        break;
                    case Command.OK1:
                        mensajeEnviado.mensajeTexto = mensajesInformacion.nombreUsuarios + ": " + mensajesInformacion.mensajeTexto;
                        break;
                    case Command.OK2:
                        mensajeEnviado.mensajeTexto = mensajesInformacion.nombreUsuarios + ": " + mensajesInformacion.mensajeTexto;
                        break;
                    case Command.ATAQUE:
                        mensajeEnviado.mensajeTexto = mensajesInformacion.nombreUsuarios + ": " + mensajesInformacion.mensajeTexto;
                        break;
                    case Command.RESULTADO:
                        mensajeEnviado.mensajeTexto = mensajesInformacion.nombreUsuarios + ": " + mensajesInformacion.mensajeTexto;
                        break;
                    case Command.FIN:
                        mensajeEnviado.mensajeTexto = mensajesInformacion.nombreUsuarios + ": " + mensajesInformacion.mensajeTexto;
                        break;
                }
                if (mensajeEnviado.comandos != Command.LISTA)
                {
                    mensaje = mensajeEnviado.convertir_a_Bytes();
                    foreach (ClienteInformacion clientInfo in listaDeClientes)
                    {
                        if (clientInfo.socket != clienteSocket || mensajeEnviado.comandos != Command.LOGIN)
                        {
                            clientInfo.socket.BeginSend(mensaje, 0, mensaje.Length, SocketFlags.None,
                                new AsyncCallback(Envio), clientInfo.socket);
                        }
                    }
                }
                if (mensajeRecibido.comandos != Command.LOGOUT)
                {
                    clienteSocket.BeginReceive(bytedeDatos, 0, bytedeDatos.Length, SocketFlags.None, new AsyncCallback(Recibir), clienteSocket);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Envio(IAsyncResult ar)
        {
            try
            {
                Socket cliente = (Socket)ar.AsyncState;
                cliente.EndSend(ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    class Datos
    {
        public string nombreUsuarios;
        public string mensajeTexto;
        public Command comandos;
        public Datos()
        {
            comandos = Command.NULL;
            mensajeTexto = null;
            nombreUsuarios = null;
        }
        public Datos(byte[] datos_recibidos)
        {
            int longitud_Mensaje = BitConverter.ToInt32(datos_recibidos, 8);
            int longitud_Nombre = BitConverter.ToInt32(datos_recibidos, 4);
            comandos = (Command)BitConverter.ToInt32(datos_recibidos, 0);

            if (longitud_Nombre > 0)
            {
                nombreUsuarios = Encoding.UTF8.GetString(datos_recibidos, 12, longitud_Nombre);
            }
            else
            {
                nombreUsuarios = null;
            }
            if (longitud_Mensaje > 0)
            {
                mensajeTexto = Encoding.UTF8.GetString(datos_recibidos, 12 + longitud_Nombre, longitud_Mensaje);
            }
            else
            {
                mensajeTexto = null;
            }
        }
        public byte[] convertir_a_Bytes()
        {
            List<byte> resultado = new List<byte>();
            resultado.AddRange(BitConverter.GetBytes((int)comandos));
            if (nombreUsuarios != null)
            {
                resultado.AddRange(BitConverter.GetBytes(nombreUsuarios.Length));
            }
            else
            {
                resultado.AddRange(BitConverter.GetBytes(0));
            }
            if (mensajeTexto != null)
            {
                resultado.AddRange(BitConverter.GetBytes(mensajeTexto.Length));
            }
            else
            {
                resultado.AddRange(BitConverter.GetBytes(0));
            }
            if (nombreUsuarios != null)
            {
                resultado.AddRange(Encoding.UTF8.GetBytes(nombreUsuarios));
            }
            if (mensajeTexto != null)
            {
                resultado.AddRange(Encoding.UTF8.GetBytes(mensajeTexto));
            }
            return resultado.ToArray();
        }
    }
    enum Command
    {
        LOGIN,
        LOGOUT,
        MENSAJE,
        LISTA,
        LISTO1,
        LISTO2,
        ATAQUE,
        RESULTADO,
        FIN,
        OK1,
        OK2,
        NULL
    }
}