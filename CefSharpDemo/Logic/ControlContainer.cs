using System.Collections.Generic;
using System.Linq;

namespace CefSharpDemo.Logic
{
    public class ControlContainer
    {
        public List<AbstractBaseControl> FormControls { get; private set; } = new List<AbstractBaseControl>();

        public void Add(AbstractBaseControl control) => FormControls.Add(control);
        public AbstractBaseControl Find(string id) => FormControls.FirstOrDefault(c => c.ServerId == id);

        public List<AbstractBaseControl> FindChildren(string parentId) =>
            FormControls.Where(c => c.ParentId == parentId).OrderBy(c => c.Order).ToList();

        public List<AbstractBaseControl> Remove(string id)
        {
            var control = Find(id);
            var deletedItems = new List<AbstractBaseControl> { control };

            foreach (var child in control.Children)
                deletedItems.AddRange(Remove(child.ServerId));

            FormControls.Remove(control);
            return deletedItems;
        }

        public string GenerateName(string originalName)
        {
            var name = originalName;

            var counter = 0;
            while (FormControls.Any(c => c.ServerId == name))
                name = $"{originalName}{++counter}";

            return name;
        }
    }
}
