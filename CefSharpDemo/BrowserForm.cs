using CefSharp;
using CefSharp.WinForms;
using CefSharpDemo.Logic;
using System;
using System.IO;
using System.Windows.Forms;

namespace CefSharpDemo
{
    public partial class BrowserForm : Form
    {
        private readonly ChromiumWebBrowser _browser;
        private readonly Bridge _bridge;

        public BrowserForm()
        {
            InitializeComponent();

            var startHomePage = @"./Browser/index.html";
            startHomePage = new Uri(Path.GetFullPath(startHomePage)).LocalPath;

            _bridge = new Bridge();

            _browser = new ChromiumWebBrowser(startHomePage);
            _browser.JavascriptObjectRepository.NameConverter = null;
            _browser.JavascriptObjectRepository.Register("bridge", _bridge, false, new BindingOptions());

            _browser.IsBrowserInitializedChanged += (s, e) =>
            {
                try
                {
                    _browser.ShowDevTools();
                }
                catch { }
            };

            tpBrowser.AutoScroll = true;
            splitContainer1.Panel2.Controls.Add(_browser);
        }
    }
}
