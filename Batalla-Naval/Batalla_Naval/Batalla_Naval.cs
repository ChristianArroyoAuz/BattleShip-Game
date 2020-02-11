using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using Servidor;
using Cliente;
using System;


namespace Batalla_Naval
{
    public partial class Batalla_Naval : Form
    {
        public Batalla_Naval()
        {
            InitializeComponent();
        }
        private void btn_Servidor_Click(object sender, EventArgs e)
        {
            Cliente.Ingreso_Datos nuevo_Formulario = new Cliente.Ingreso_Datos();
            nuevo_Formulario.cliente_servidor = "servidor";
            Servidor.Servidor escuchar = new Servidor.Servidor();
            Hide();
            escuchar.Show();
            nuevo_Formulario.Show();
        }
        private void btn_Cliente_Click(object sender, EventArgs e)
        {
            Cliente.Ingreso_Datos nuevo_Formulario = new Cliente.Ingreso_Datos();
            nuevo_Formulario.cliente_servidor = "cliente";
            Hide();
            nuevo_Formulario.Show();
        }
    }
}