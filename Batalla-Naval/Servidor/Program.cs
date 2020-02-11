using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System;


namespace Servidor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Servidor());
        }
    }
}