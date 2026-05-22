using System;
using System.Windows.Forms;

namespace Лабораторные_Windows_Forms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormLocomotiveCollection());  
        }
    }
}