using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace CefSharpDemo
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var virtualUI = new Cybele.Thinfinity.VirtualUI();
            virtualUI.Start();
            virtualUI.AllowExecute("CefSharp.BrowserSubprocess.exe");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var settings = new CefSettings();
            settings.SetOffScreenRenderingBestPerformanceArgs();
            Cef.Initialize(settings);

            Application.Run(new MainForm());
        }
    }
}
