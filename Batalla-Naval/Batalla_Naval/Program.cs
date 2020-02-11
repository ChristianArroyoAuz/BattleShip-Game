using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System;


namespace Batalla_Naval
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Batalla_Naval());
        }
    }
}