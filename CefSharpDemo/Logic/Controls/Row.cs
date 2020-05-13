using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharpDemo.Logic.Controls
{
    public class Row : AbstractBaseControl, IContainer
    {
        public List<int> Columns { get; set; }
    }
}
