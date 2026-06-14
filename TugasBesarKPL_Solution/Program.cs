using System;
using System.Windows.Forms;
using TugasBesarKPL_Solution.Forms;

namespace TugasBesarKPL_Solution
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MenuForm());
        }
    }
}