using System;
using System.Windows.Forms;

namespace CefSharpDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            var newChild = new BrowserForm {MdiParent = this};
            newChild.Show();
        }
    }
}
