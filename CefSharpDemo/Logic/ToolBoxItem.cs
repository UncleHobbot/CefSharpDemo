namespace CefSharpDemo.Logic
{
    public class ToolBoxItem
    {
        private string _cssClass;
        public string Tab { get; set; }
        public string Name { get; set; }
        public string Tooltip { get; set; }
        public AbstractBaseControl Properties { get; set; }
        public string CssClass
        {
            set => _cssClass = value;
            get => string.IsNullOrEmpty(_cssClass) ? $"{Properties.Type.ToString().ToLower()}-icon" : _cssClass;
        }
    }
}
