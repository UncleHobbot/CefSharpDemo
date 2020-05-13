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
        private ChromiumWebBrowser _browser;
        private Bridge _bridge { get; }

        public BrowserForm()
        {
            InitializeComponent();

            var startHomePage = @"./Browser/index.html";
            startHomePage = new Uri(Path.GetFullPath(startHomePage)).LocalPath;
            
            _bridge = new Bridge();
            _browser = new ChromiumWebBrowser(startHomePage);
            _browser.JavascriptObjectRepository.Register("bridge", _bridge, false, new BindingOptions {CamelCaseJavascriptNames = false});

            _browser.IsBrowserInitializedChanged += (s, e) =>
            {
                    try
                    {
                        _browser.ShowDevTools();
                    }
                    catch { }
            };

            tpBrowser.AutoScroll = true;
            tpBrowser.Controls.Add(_browser);
        }
    }
}
