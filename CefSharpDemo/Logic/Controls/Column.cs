namespace CefSharpDemo.Logic.Controls
{
    public class Column : AbstractBaseControl, IContainer
    {
        public Column()
        {
            Type = ControlTypeEnum.Column;
        }

        public int Width { get; set; }
    }
}
