using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string currentDirectoryPath = Path.GetDirectoryName(Application.ExecutablePath);

            if (!File.Exists($"{currentDirectoryPath}\\DateB.db"))
            {
                new DateB("Data Source=DateB.db;Version=3;").InitializeDatabase();
            }

            Application.Run(new FormMain());
        }
    }
}
