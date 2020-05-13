using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace CefSharpDemo.Logic.Controls
{
    public class Column : AbstractBaseControl, IContainer
    {
        public int Width { get; set; }

        protected override string CssClass => "RayColumn";

        public bool IsBorder { get; set; }

        private bool _IsDefaultcolor;

        public bool IsDefaultColor
        {
            get => _IsDefaultcolor;
            set
            {
                _IsDefaultcolor = value;
                if (value)
                    BackgroundColor = Color.Transparent;
            }
        }

        public bool BackColorEnable => !_IsDefaultcolor;
        public Color BorderColor { get; set; } = Color.Black;

        public string ColorRgba => $"#{BorderColor.R:x2}{BorderColor.G:x2}{BorderColor.B:x2}";

        public Color BackgroundColor { get; set; } = Color.Transparent;

        public string BackgroundColorRgba => $"#{BackgroundColor.R:x2}{BackgroundColor.G:x2}{BackgroundColor.B:x2}";
    }
}
