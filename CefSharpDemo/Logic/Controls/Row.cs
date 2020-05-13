using System.Collections.Generic;

namespace CefSharpDemo.Logic.Controls
{
    public class Row : AbstractBaseControl, IContainer
    {
        public Row()
        {
            Type = ControlTypeEnum.Row;
        }

        public List<int> Columns { get; set; }
    }
}
