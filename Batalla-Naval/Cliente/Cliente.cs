using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System;


namespace Cliente
{
    public partial class Cliente : Form
    {
        int aircraftCarrier_Golpes_Remanentes = 5;
        List<String> celdas = new List<String>();
        private Cuadrado tamaño_total_Cuadricula;
        private Cuadrado[,] cuadricula_Oponente;
        private Cuadricula enemigo_coloca_Ficha;
        private Cuadricula jugador_coloca_Ficha;
        private Cuadrado[,] cuadricula_Jugador;
        private bool aircraftCarrier_Colocado;
        private byte[] datos = new byte[1024];
        int battleships_Golpes_Remanentes = 4;
        int patrolBoat_Golpes_Remanentes = 2;
        int submarine_Golpes_Remanentes = 3;
        int destroyer_Golpes_Remanentes = 2;
        Point posicion_mouse_panel_Enemigo;
        private bool battleship_Colocado;
        private bool patrolBoat_Colocado;
        private bool submarine_Colocado;
        private bool destroyer_Colocado;
        Point ultima_coordenada_Atacada;
        public string cliente_servidor;
        private bool mouse_Presionado;
        private bool rotar_Izquierda;
        private bool juego_Corriendo;
        private Point posicion_Mouse;
        public Socket clienteSocket;
        private Point tanaño_Panel;
        private bool rotar_Derecha;
        private int codigo_Ficha;
        private int ancho_Cuadro;
        private int alto_Cuadro;
        public string usuario;
        public string puerto;
        public bool iniciar;
        public string ip;
        int vidas = 0;

        public Cliente()
        {
            InitializeComponent();
            aircraftCarrier_Colocado = false;
            battleship_Colocado = false;
            patrolBoat_Colocado = false;
            submarine_Colocado = false;
            destroyer_Colocado = false;
            mouse_Presionado = false;
            juego_Corriendo = false;
            rotar_Izquierda = false;
            rotar_Derecha = false;
            codigo_Ficha = 0;
            cuadricula_Jugador = new Cuadrado[10, 10];
            cuadricula_Oponente = new Cuadrado[10, 10];
            tanaño_Panel.X = Panel_Jugador.Width;
            tanaño_Panel.Y = Panel_Jugador.Height;
            ancho_Cuadro = (tanaño_Panel.X / 10);
            alto_Cuadro = (tanaño_Panel.Y / 10);
            jugador_coloca_Ficha = new Cuadricula(Panel_Jugador, ancho_Cuadro, alto_Cuadro);
            enemigo_coloca_Ficha = new Cuadricula(Panel_Oponente, ancho_Cuadro, alto_Cuadro);
            Panel_Oponente.Enabled = false;
            Panel_Jugador.Enabled = false;
        }
        private void Cliente_Load(object sender, EventArgs e)
        {
            Data mensajeEnvio = new Data();
            mensajeEnvio.comando = Command.LISTA;
            mensajeEnvio.nombre = usuario;
            mensajeEnvio.mensaje = null;
            datos = mensajeEnvio.convertir_a_Bytes();
            clienteSocket.BeginSend(datos, 0, datos.Length, SocketFlags.None, new AsyncCallback(Enviar), null);
            datos = new byte[1024];
            clienteSocket.BeginReceive(datos, 0, datos.Length, SocketFlags.None, new AsyncCallback(Recibir), null);
            if (cliente_servidor == "cliente")
            {
                Text = "Huesped (Cliente)";
                btn_Iniciar.Enabled = true;
                btn_Iniciar.Visible = false;
            }
            if (cliente_servidor == "servidor")
            {
                Text = "Anfitrio (Servidor)";
                btn_Iniciar.Enabled = false;
                btn_Iniciar.Visible = false;
            }
            lista_Coordenadas.Enabled = false;
            lista_Coordenadas.Visible = false;
        }
        private bool Revisar_Cuadros_Habiles(bool X_Y)
        {
            if (X_Y == false)
            {
                for (int i = 0; i < tamaño_total_Cuadricula.tamaño; i++)
                {
                    if (cuadricula_Jugador[(int)(tamaño_total_Cuadricula.minimo.X / ancho_Cuadro), (int)((tamaño_total_Cuadricula.minimo.Y / alto_Cuadro) + i)].poner == true)
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (X_Y == true)
                {
                    for (int i = 0; i < tamaño_total_Cuadricula.tamaño; i++)
                    {
                        if (cuadricula_Jugador[(int)((tamaño_total_Cuadricula.minimo.X / ancho_Cuadro) + i), (int)(tamaño_total_Cuadricula.minimo.Y / alto_Cuadro)].poner == true)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private void Dibujar_Cuadricula(Cuadricula dibujar, Cuadrado[,] cuadrados)
        {
            for (int i = 1; i < 10; i++)
            {
                dibujar.Lineas_Verticales(dibujar.lineas_negras, tanaño_Panel, i);
                dibujar.Lineas_Horizontales(dibujar.lineas_negras, tanaño_Panel, i);
            }
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    cuadrados[x, y] = new Cuadrado(new Point(x * ancho_Cuadro, y * alto_Cuadro), new Point((x * ancho_Cuadro) + ancho_Cuadro, (y * alto_Cuadro) + alto_Cuadro));
                }
            }
        }
        private void Dibujar_Barco(int tamaño_Barco)
        {
            codigo_Ficha = tamaño_Barco;
            if (tamaño_total_Cuadricula != null)
            {
                for (int i = 0; i < tamaño_total_Cuadricula.tamaño; i++)
                {
                    if (rotar_Izquierda == false)
                    {
                        if (((int)((tamaño_total_Cuadricula.minimo.Y / alto_Cuadro) + i)) <= 9)
                        {
                            if (cuadricula_Jugador[(int)(tamaño_total_Cuadricula.minimo.X / ancho_Cuadro), (int)((tamaño_total_Cuadricula.minimo.Y / alto_Cuadro) + i)].poner != true)
                            {
                                jugador_coloca_Ficha.Llenar_Rectangulo(jugador_coloca_Ficha.color_blanco, tamaño_total_Cuadricula, i, 0);
                            }
                        }
                    }
                    if (rotar_Izquierda == true)
                    {
                        if (((int)((tamaño_total_Cuadricula.minimo.X / ancho_Cuadro) + i)) <= 9)
                        {
                            if (cuadricula_Jugador[(int)((tamaño_total_Cuadricula.minimo.X / ancho_Cuadro) + i), (int)(tamaño_total_Cuadricula.minimo.Y / alto_Cuadro)].poner != true)
                            {
                                jugador_coloca_Ficha.Llenar_Rectangulo(jugador_coloca_Ficha.color_blanco, tamaño_total_Cuadricula, 0, i);
                            }
                        }
                    }
                }
            }
            int coordenadas_X = (int)(posicion_Mouse.X / ancho_Cuadro);
            int coordenadas_Y = (int)(posicion_Mouse.Y / alto_Cuadro);
            if (coordenadas_X > 9)
            {
                coordenadas_X = 9;
            }
            if (coordenadas_Y > 9)
            {
                coordenadas_Y = 9;
            }
            tamaño_total_Cuadricula = cuadricula_Jugador[coordenadas_X, coordenadas_Y];
            if (tamaño_Barco == 1)
            {
                tamaño_Barco = 2;
            }
            tamaño_total_Cuadricula.tamaño = tamaño_Barco;
            if (rotar_Derecha == false)
            {
                if (coordenadas_Y + (tamaño_Barco - 1) <= 9 && Revisar_Cuadros_Habiles(rotar_Derecha))
                {
                    for (int i = 0; i < tamaño_Barco; i++)
                    {
                        jugador_coloca_Ficha.Elipse(jugador_coloca_Ficha.lineas_verdes, tamaño_total_Cuadricula, i, 0);
                    }
                    tamaño_total_Cuadricula.ok = true;
                }
                else
                {
                    if (tamaño_total_Cuadricula.poner != true)
                    {
                        jugador_coloca_Ficha.Elipse(jugador_coloca_Ficha.lineas_rojas, tamaño_total_Cuadricula, 0, 0);
                        tamaño_total_Cuadricula.ok = false;
                    }
                }
            }
            if (rotar_Derecha == true)
            {
                if (coordenadas_X + (tamaño_Barco - 1) <= 9 && Revisar_Cuadros_Habiles(rotar_Derecha))
                {
                    for (int i = 0; i < tamaño_Barco; i++)
                    {
                        jugador_coloca_Ficha.Elipse(jugador_coloca_Ficha.lineas_verdes, tamaño_total_Cuadricula, 0, i);
                    }
                    tamaño_total_Cuadricula.ok = true;
                }
                else
                {
                    if (tamaño_total_Cuadricula.poner != true)
                    {
                        jugador_coloca_Ficha.Elipse(jugador_coloca_Ficha.lineas_rojas, tamaño_total_Cuadricula, 0, 0);
                        tamaño_total_Cuadricula.ok = false;
                    }
                }
            }
            rotar_Izquierda = rotar_Derecha;
        }
        private void Enviar(IAsyncResult ar)
        {
            try
            {
                clienteSocket.EndSend(ar);
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cliente: " + usuario, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Recibir(IAsyncResult ar)
        {
            try
            {
                clienteSocket.EndReceive(ar);
                Data mensajeRecibido = new Data(datos);
                switch (mensajeRecibido.comando)
                {
                    case Command.LOGIN:
                        lstChatters.Items.Add(mensajeRecibido.nombre);
                        break;
                    case Command.LOGOUT:
                        lstChatters.Items.Remove(mensajeRecibido.nombre);
                        break;
                    case Command.MENSAJE:
                        txtChatBox.Text += mensajeRecibido.mensaje + "\r\n";
                        break;
                    case Command.LISTA:
                        txtChatBox.Text += "<<<" + usuario + " se ha unido al juego...>>>\r\n";
                        break;
                    case Command.LISTO1:
                        rxt_Resumen.Text += mensajeRecibido.mensaje + "\r\n";
                        rxt_Resumen.Text += "Mensaje Recibido (OK1)" + "\r\n";
                        rxt_Resumen.ScrollToCaret();
                        break;
                    case Command.LISTO2:
                        rxt_Resumen.Text += mensajeRecibido.mensaje + "\r\n";
                        rxt_Resumen.Text += "Mensaje Recibido (OK2)" + "\r\n";
                        rxt_Resumen.ScrollToCaret();
                        break;
                    case Command.OK1:
                        rxt_Resumen.Text += mensajeRecibido.mensaje + "\r\n";
                        rxt_Resumen.ScrollToCaret();
                        break;
                    case Command.OK2:
                        rxt_Resumen.Text += mensajeRecibido.mensaje + "\r\n";
                        rxt_Resumen.ScrollToCaret();
                        break;
                    case Command.ATAQUE:
                        rxt_Resumen.Text += mensajeRecibido.mensaje + "\r\n";
                        rxt_Resumen.ScrollToCaret();
                        break;
                    case Command.RESULTADO:
                        rxt_Resumen.Text += mensajeRecibido.mensaje + "\r\n";
                        rxt_Resumen.ScrollToCaret();
                        break;
                    case Command.FIN:
                        rxt_Resumen.Text += mensajeRecibido.mensaje + "\r\n";
                        rxt_Resumen.ScrollToCaret();
                        break;
                }
                datos = new byte[1024];
                clienteSocket.BeginReceive(datos, 0, datos.Length, SocketFlags.None, new AsyncCallback(Recibir), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cliente: " + usuario, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Panel_Jugador_MouseClick(object sender, MouseEventArgs e)
        {
            if (tamaño_total_Cuadricula != null && !juego_Corriendo)
            {
                if (tamaño_total_Cuadricula.ok == true)
                {
                    bool continuar = Revisar_Cuadros_Habiles(rotar_Derecha);
                    if (continuar)
                    {
                        switch (codigo_Ficha)
                        {
                            case 5:
                                if (aircraftCarrier_Colocado)
                                {
                                    return;
                                }
                                else
                                {
                                    aircraftCarrier_Colocado = true;
                                }
                                break;
                            case 4:
                                if (battleship_Colocado)
                                {
                                    return;
                                }
                                else
                                {
                                    battleship_Colocado = true;
                                }
                                break;
                            case 3:
                                if (submarine_Colocado)
                                {
                                    return;
                                }
                                else
                                {
                                    submarine_Colocado = true;
                                }
                                break;
                            case 2:
                                if (destroyer_Colocado)
                                {
                                    return;
                                }
                                else
                                {
                                    destroyer_Colocado = true;
                                }
                                break;
                            case 1:
                                if (patrolBoat_Colocado)
                                {
                                    return;
                                }
                                else
                                {
                                    patrolBoat_Colocado = true;
                                }
                                break;
                        }
                        if (rotar_Derecha == false)
                        {
                            for (int i = 0; i < tamaño_total_Cuadricula.tamaño; i++)
                            {
                                jugador_coloca_Ficha.Llenar_Rectangulo(jugador_coloca_Ficha.color_blanco, tamaño_total_Cuadricula, i, 0);
                            }
                            for (int i = 0; i < tamaño_total_Cuadricula.tamaño; i++)
                            {
                                jugador_coloca_Ficha.Llenar_Elipse(jugador_coloca_Ficha.color_verde, tamaño_total_Cuadricula, i, 0);
                                cuadricula_Jugador[(int)(tamaño_total_Cuadricula.minimo.X / ancho_Cuadro), (int)((tamaño_total_Cuadricula.minimo.Y / alto_Cuadro) + i)].poner = true;
                                cuadricula_Jugador[(int)(tamaño_total_Cuadricula.minimo.X / ancho_Cuadro), (int)((tamaño_total_Cuadricula.minimo.Y / alto_Cuadro) + i)].poner_codigo_barco(codigo_Ficha);
                            }
                            for (int i = 0; i < codigo_Ficha; i++)
                            {
                                if (codigo_Ficha == 1)
                                {
                                    Point point = new Point((int)(tamaño_total_Cuadricula.minimo.X / ancho_Cuadro), (int)(tamaño_total_Cuadricula.minimo.Y / alto_Cuadro));
                                    lista_Coordenadas.Items.Add(point.X + "," + (point.Y + i));
                                    lista_Coordenadas.Items.Add(point.X + "," + (point.Y + i + 1));
                                }
                                else
                                {
                                    Point point = new Point((int)(tamaño_total_Cuadricula.minimo.X / ancho_Cuadro), (int)(tamaño_total_Cuadricula.minimo.Y / alto_Cuadro));
                                    lista_Coordenadas.Items.Add(point.X + "," + (point.Y + i));
                                }
                            }
                        }
                        else
                        {
                            if (rotar_Derecha == true)
                            {
                                for (int i = 0; i < tamaño_total_Cuadricula.tamaño; i++)
                                {
                                    jugador_coloca_Ficha.Llenar_Rectangulo(jugador_coloca_Ficha.color_blanco, tamaño_total_Cuadricula, 0, i);
                                }
                                for (int i = 0; i < tamaño_total_Cuadricula.tamaño; i++)
                                {
                                    jugador_coloca_Ficha.Llenar_Elipse(jugador_coloca_Ficha.color_verde, tamaño_total_Cuadricula, 0, i);
                                    cuadricula_Jugador[(int)((tamaño_total_Cuadricula.minimo.X / ancho_Cuadro) + i), (int)(tamaño_total_Cuadricula.minimo.Y / alto_Cuadro)].poner = true;
                                    cuadricula_Jugador[(int)((tamaño_total_Cuadricula.minimo.X / ancho_Cuadro) + i), (int)(tamaño_total_Cuadricula.minimo.Y / alto_Cuadro)].poner_codigo_barco(codigo_Ficha);
                                }
                            }
                            for (int i = 0; i < codigo_Ficha; i++)
                            {
                                if (codigo_Ficha == 1)
                                {
                                    Point point = new Point((int)(tamaño_total_Cuadricula.minimo.X / ancho_Cuadro), (int)(tamaño_total_Cuadricula.minimo.Y / alto_Cuadro));
                                    lista_Coordenadas.Items.Add((point.X + i) + "," + point.Y);
                                    lista_Coordenadas.Items.Add((point.X + i + 1) + "," + point.Y);
                                }
                                else
                                {
                                    Point point = new Point((int)(tamaño_total_Cuadricula.minimo.X / ancho_Cuadro), (int)(tamaño_total_Cuadricula.minimo.Y / alto_Cuadro));
                                    lista_Coordenadas.Items.Add((point.X + i) + "," + point.Y);
                                }
                            }
                        }
                    }
                }
            }
            if (aircraftCarrier_Colocado && battleship_Colocado && submarine_Colocado && destroyer_Colocado && patrolBoat_Colocado && !juego_Corriendo)
            {
                juego_Corriendo = true;
                btn_Colocar_Fichas.Enabled = true;
                btn_Colocar_Fichas.Visible = true;
            }
        }
        private void btn_IniciarJuego_Click(object sender, EventArgs e)
        {
            if (cliente_servidor == "cliente")
            {
                if (!juego_Corriendo)
                {
                    Panel_Jugador.Enabled = true;
                    Panel_Oponente.Enabled = true;
                    Dibujar_Cuadricula(jugador_coloca_Ficha, cuadricula_Jugador);
                    Dibujar_Cuadricula(enemigo_coloca_Ficha, cuadricula_Oponente);
                    tamaño_total_Cuadricula = null;
                    btn_Colocar_Fichas.Text = "Conectar";
                    btn_Colocar_Fichas.Enabled = true;
                    btn_Colocar_Fichas.Visible = true;
                }
                if (juego_Corriendo)
                {
                    Panel_Jugador.Enabled = true;
                    Panel_Oponente.Enabled = true;
                    btn_Colocar_Fichas.Enabled = false;
                    btn_Colocar_Fichas.Visible = false;
                    btn_Iniciar.Enabled = true;
                    btn_Iniciar.Visible = true;
                    listBox_Fichas.Enabled = false;
                    listBox_Fichas.Visible = false;
                    etiqueta_ColocarFichas.Visible = false;
                }

            }
            if (cliente_servidor == "servidor")
            {
                if (!juego_Corriendo)
                {
                    Panel_Jugador.Enabled = true;
                    Panel_Oponente.Enabled = true;
                    Dibujar_Cuadricula(jugador_coloca_Ficha, cuadricula_Jugador);
                    Dibujar_Cuadricula(enemigo_coloca_Ficha, cuadricula_Oponente);
                    tamaño_total_Cuadricula = null;
                    btn_Colocar_Fichas.Text = "Conectar";
                    btn_Colocar_Fichas.Enabled = true;
                    btn_Colocar_Fichas.Visible = true;
                }
                if (juego_Corriendo)
                {
                    Panel_Jugador.Enabled = true;
                    Panel_Oponente.Enabled = true;
                    btn_Colocar_Fichas.Enabled = false;
                    btn_Colocar_Fichas.Visible = false;
                    listBox_Fichas.Enabled = false;
                    listBox_Fichas.Visible = false;
                    etiqueta_ColocarFichas.Visible = false;
                    try
                    {
                        Data mensajeParaEnvio = new Data();
                        mensajeParaEnvio.nombre = usuario;
                        mensajeParaEnvio.mensaje = "Esperando por oponente... (LISTO1)";
                        mensajeParaEnvio.comando = Command.LISTO1;
                        byte[] bytedatos = mensajeParaEnvio.convertir_a_Bytes();
                        clienteSocket.BeginSend(bytedatos, 0, bytedatos.Length, SocketFlags.None, new AsyncCallback(Enviar), null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btn_Iniciar_Click(object sender, EventArgs e)
        {
            btn_Iniciar.Enabled = false;
            btn_Iniciar.Visible = false;
            Panel_Oponente.Enabled = true;
            Panel_Oponente.Visible = true;
            try
            {
                Data mensajeParaEnvio = new Data();
                mensajeParaEnvio.nombre = usuario;
                mensajeParaEnvio.mensaje = "ha iniciado la partida... (LISTO2)";
                mensajeParaEnvio.comando = Command.LISTO2;
                byte[] bytedatos = mensajeParaEnvio.convertir_a_Bytes();
                clienteSocket.BeginSend(bytedatos, 0, bytedatos.Length, SocketFlags.None, new AsyncCallback(Enviar), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_enviar_Mensaje_Click(object sender, EventArgs e)
        {
            try
            {
                Data mensajeParaEnvio = new Data();
                mensajeParaEnvio.nombre = usuario;
                mensajeParaEnvio.mensaje = txtMessage.Text;
                mensajeParaEnvio.comando = Command.MENSAJE;
                byte[] bytedatos = mensajeParaEnvio.convertir_a_Bytes();
                clienteSocket.BeginSend(bytedatos, 0, bytedatos.Length, SocketFlags.None, new AsyncCallback(Enviar), null);
                txtMessage.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo enviar el mensaje al servidor", "cliente: " + usuario, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Panel_Jugador_MouseMove(object sender, MouseEventArgs e)
        {
            posicion_Mouse = new Point(e.X, e.Y);
            if (!mouse_Presionado)
            {
                int coordenadas_X = (int)(posicion_Mouse.X / ancho_Cuadro);
                int coordenadas_Y = (int)(posicion_Mouse.Y / alto_Cuadro);
                if (coordenadas_X > 9)
                {
                    coordenadas_X = 9;
                }
                if (coordenadas_Y > 9)
                {
                    coordenadas_Y = 9;
                }
                if (tamaño_total_Cuadricula != cuadricula_Jugador[coordenadas_X, coordenadas_Y] || tamaño_total_Cuadricula == null || (rotar_Derecha != rotar_Izquierda))
                {
                    switch (listBox_Fichas.GetItemText(listBox_Fichas.SelectedItem))
                    {
                        case "AircraftCarrier":
                            if (!aircraftCarrier_Colocado)
                            {
                                Dibujar_Barco(5);
                            }
                            break;
                        case "Battleship":
                            if (!battleship_Colocado)
                            {
                                Dibujar_Barco(4);
                            }
                            break;
                        case "Submarine":
                            if (!submarine_Colocado)
                            {
                                Dibujar_Barco(3);
                            }
                            break;
                        case "Destroyer":
                            if (!destroyer_Colocado)
                            {
                                Dibujar_Barco(2);
                            }
                            break;
                        case "PatrolBoat":
                            if (!patrolBoat_Colocado)
                            {
                                Dibujar_Barco(1);
                            }
                            break;
                    }
                }
            }
        }
        private void Panel_Jugador_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_Presionado = false;
        }
        private void Panel_Oponente_MouseMove(object sender, MouseEventArgs e)
        {
            posicion_mouse_panel_Enemigo = new Point(e.X, e.Y);
        }
        private void Panel_Jugador_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_Presionado = true;
        }
        private void Cliente_KeyDown(object sender, KeyEventArgs e)
        {
            switch (codigo_Ficha)
            {
                case 5:
                    if (aircraftCarrier_Colocado)
                    {
                        return;
                    }
                    break;
                case 4:
                    if (battleship_Colocado)
                    {
                        return;
                    }
                    break;
                case 3:
                    if (submarine_Colocado)
                    {
                        return;
                    }
                    break;
                case 2:
                    if (destroyer_Colocado)
                    {
                        return;
                    }
                    break;
                case 1:
                    if (patrolBoat_Colocado)
                    {
                        return;
                    }
                    break;
            }
            if (e.KeyCode.ToString() == "R")
            {
                if (tamaño_total_Cuadricula != null && !juego_Corriendo)
                {
                    rotar_Derecha = !rotar_Derecha;
                    Dibujar_Barco(codigo_Ficha);
                }
            }
        }
        private void Panel_Oponente_Click(object sender, EventArgs e)
        {
            Point point = new Point((int)(posicion_mouse_panel_Enemigo.X / ancho_Cuadro), (int)(posicion_mouse_panel_Enemigo.Y / alto_Cuadro));
            cuadricula_Oponente[point.X, point.Y].disparo = true;
            ultima_coordenada_Atacada = point;
            string celda = point.X + "," + point.Y;
            Data mensajeParaEnvio = new Data();
            mensajeParaEnvio.nombre = usuario;
            mensajeParaEnvio.mensaje = "Ataco la celda " + celda + " (ATAQUE)";
            mensajeParaEnvio.comando = Command.ATAQUE;
            byte[] bytedatos = mensajeParaEnvio.convertir_a_Bytes();
            clienteSocket.BeginSend(bytedatos, 0, bytedatos.Length, SocketFlags.None, new AsyncCallback(Enviar), null);
            foreach (var item in lista_Coordenadas.Items)
            {
                if (item.Equals(celda) == true)
                {
                    vidas++;
                    Text = vidas.ToString();
                    enemigo_coloca_Ficha.Llenar_Elipse(enemigo_coloca_Ficha.color_rojo, cuadricula_Oponente[point.X, point.Y], 0, 0);
                    Data resultado_acierto = new Data();
                    resultado_acierto.nombre = usuario;
                    resultado_acierto.mensaje = "Acerto a la " + celda + " (RESULTADO)";
                    resultado_acierto.comando = Command.RESULTADO;
                    byte[] bytedatos_acierto = resultado_acierto.convertir_a_Bytes();

                    clienteSocket.BeginSend(bytedatos_acierto, 0, bytedatos_acierto.Length, SocketFlags.None, new AsyncCallback(Enviar), null);
                    if (vidas == 16)
                    {
                        MessageBox.Show(usuario + " Ha ganado la partida");
                        Data final = new Data();
                        final.nombre = usuario;
                        final.mensaje = "Ha ganado la partida (FIN)";
                        final.comando = Command.FIN;
                        byte[] bytedatos_final = final.convertir_a_Bytes();
                        clienteSocket.BeginSend(bytedatos_final, 0, bytedatos_final.Length, SocketFlags.None, new AsyncCallback(Enviar), null);
                        Panel_Jugador.Enabled = false;
                        Panel_Oponente.Enabled = false;
                    }
                    break;
                }
                else
                {
                    Data resultado_fallo = new Data();
                    resultado_fallo.nombre = usuario;
                    resultado_fallo.mensaje = "Fallo a la " + celda + " (RESULTADO)";
                    resultado_fallo.comando = Command.RESULTADO;
                    byte[] bytedatos_fallo = resultado_fallo.convertir_a_Bytes();
                    clienteSocket.BeginSend(bytedatos_fallo, 0, bytedatos_fallo.Length, SocketFlags.None, new AsyncCallback(Enviar), null);

                    enemigo_coloca_Ficha.Llenar_Elipse(enemigo_coloca_Ficha.color_verde, cuadricula_Oponente[point.X, point.Y], 0, 0);
                }
            }
        }
        private bool golpes_Remanentes(int codigo)
        {
            if (codigo == 5)
            {
                if (--aircraftCarrier_Golpes_Remanentes == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (codigo == 4)
                {
                    if (--battleships_Golpes_Remanentes == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (codigo == 3)
                    {
                        if (--submarine_Golpes_Remanentes == 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (codigo == 2)
                        {
                            if (--destroyer_Golpes_Remanentes == 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (--patrolBoat_Golpes_Remanentes == 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
        }
    }
    class Data
    {
        public string nombre;
        public string mensaje;
        public Command comando;

        public Data()
        {
            comando = Command.NULL;
            mensaje = null;
            nombre = null;
        }
        public Data(byte[] data)
        {
            int longitud_Mensaje = BitConverter.ToInt32(data, 8);
            int longitud_Nombre = BitConverter.ToInt32(data, 4);
            comando = (Command)BitConverter.ToInt32(data, 0);
            if (longitud_Nombre > 0)
            {
                this.nombre = Encoding.UTF8.GetString(data, 12, longitud_Nombre);
            }
            else
            {
                this.nombre = null;
            }
            if (longitud_Mensaje > 0)
            {
                this.mensaje = Encoding.UTF8.GetString(data, 12 + longitud_Nombre, longitud_Mensaje);
            }
            else
            {
                this.mensaje = null;
            }
        }
        public byte[] convertir_a_Bytes()
        {
            List<byte> resultado = new List<byte>();
            resultado.AddRange(BitConverter.GetBytes((int)comando));
            if (nombre != null)
            {
                resultado.AddRange(BitConverter.GetBytes(nombre.Length));
            }
            else
            {
                resultado.AddRange(BitConverter.GetBytes(0));
            }
            if (mensaje != null)
            {
                resultado.AddRange(BitConverter.GetBytes(mensaje.Length));
            }
            else
            {
                resultado.AddRange(BitConverter.GetBytes(0));
            }
            if (nombre != null)
            {
                resultado.AddRange(Encoding.UTF8.GetBytes(nombre));
            }
            if (mensaje != null)
            {
                resultado.AddRange(Encoding.UTF8.GetBytes(mensaje));
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