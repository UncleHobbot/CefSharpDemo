using CefSharpDemo.Logic.Controls;
using System;
using System.Collections.Generic;
using System.Threading;

namespace CefSharpDemo.Logic
{
    public class ToolBarContainer
    {
        public List<ToolBoxItem> GetItems(ControlContainer container)
        {
            Thread.CurrentThread.TrySetApartmentState(ApartmentState.STA);

            var items = new List<ToolBoxItem>
            {
                new ToolBoxItem {Tab = "Layouts",Name = "Full Row", Properties = new Row {Columns = new List<int> {12}}},
                new ToolBoxItem {Tab = "Layouts",Name = "2 Columns", Properties = new Row {Columns = new List<int> {6, 6}}},
                new ToolBoxItem {Tab = "Layouts",Name = "3 Columns", Properties = new Row {Columns = new List<int> {4, 4, 4}}},
                new ToolBoxItem {Tab = "Layouts",Name = "4 Columns", Properties = new Row {Columns = new List<int> {3, 3, 3, 3}}},
                new ToolBoxItem {Tab = "Layouts",Name = "2 Columns - 30-70", Properties = new Row {Columns = new List<int> {4, 8}}},
                new ToolBoxItem {Tab = "Layouts",Name = "2 Columns - 70-30", Properties = new Row {Columns = new List<int> {8, 4}}},

                new ToolBoxItem {Tab = "Controls", Name = "Assign-list", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.AssignControl, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Tree", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.Tree, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Tab Control", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.TabControl, container)},
                new ToolBoxItem {Tab = "Controls", Name = "TextBox", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.TextBox, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Multi-line TextBox", CssClass = "textarea-icon", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.TextBox, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Password Box", CssClass = "password-icon", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.TextBox, container)},
                new ToolBoxItem {Tab = "Controls", Name = "CheckBox", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.CheckBox, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Radio-button list", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.RadioButtonList, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Button", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.Button, container)},
                new ToolBoxItem {Tab = "Controls", Name = "AutoComplete Dropdown", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.DropDownList, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Numeric TextBox", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.NumericTextBox, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Label", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.Label, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Help", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.Help, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Line", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.Line, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Time Picker", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.Time, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Static Image", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.ImageControl, container)}
            };

            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "Table", Properties = new RayGenericGrid { Container = container, Height = 200 } });
            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "Chart", Properties = new RayChart { Container = container } });
            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "Interactive Chart", Properties = new RayClientChart { Container = container } });
            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "Map", Properties = new RayMap { Container = container } });
            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "Gauge", Properties = new RayGauge { Container = container } });
            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "Gantt Chart", Properties = new RayGanttChart() });
            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "File Attachment", Properties = new RayFileAttachment() });
            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "Image Viewer", Properties = new RayImageViewer() });
            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "User Signature", Properties = new RayUserSignature() });
            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "Search Panel", Properties = new RaySearchPanel() });
            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "User Picture", Properties = new RayUserPicture() });
            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "Picture", Properties = new RayDynamicImage() });
            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "Grid", Properties = new RayGrid { Container = container, Height = 400 } });
            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "Rich TextBox", Properties = new RayRichTextBox() });
            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "Comment", Properties = new RayComment() });
            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "Nested Form Link", Properties = new RayNestedLink() });
            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "Canvas", Properties = new RayCanvasPanel() });
            //items.Add(new ToolBoxItem { Tab = "Controls", Name = "DateTimePicker", Properties = new RayDateTimePicker() });

            items.Sort((a, b) => string.Compare(a.Name.Trim(), b.Name.Trim(), StringComparison.OrdinalIgnoreCase));

            return items;
        }
    }
}