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
                new ToolBoxItem {Tab = "Layouts", Name = "Full Row", Properties = new Row {Columns = new List<int> {12}}},
                new ToolBoxItem {Tab = "Layouts", Name = "2 Columns", Properties = new Row {Columns = new List<int> {6, 6}}},
                new ToolBoxItem {Tab = "Layouts", Name = "3 Columns", Properties = new Row {Columns = new List<int> {4, 4, 4}}},
                new ToolBoxItem {Tab = "Layouts", Name = "4 Columns", Properties = new Row {Columns = new List<int> {3, 3, 3, 3}}},
                new ToolBoxItem {Tab = "Layouts", Name = "2 Columns - 30-70", Properties = new Row {Columns = new List<int> {4, 8}}},
                new ToolBoxItem {Tab = "Layouts", Name = "2 Columns - 70-30", Properties = new Row {Columns = new List<int> {8, 4}}},
  
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
                new ToolBoxItem {Tab = "Controls", Name = "Static Image", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.ImageControl, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Table", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.GenericGrid, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Chart", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.Chart, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Interactive Chart", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.ClientChart, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Map", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.Map, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Gauge", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.Gauge, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Gantt Chart", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.GanttChart, container)},
                new ToolBoxItem {Tab = "Controls", Name = "File Attachment", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.FileAttachment, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Image Viewer", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.ImageViewer, container)},
                new ToolBoxItem {Tab = "Controls", Name = "User Signature", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.UserSignature, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Search Panel", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.SearchPanel, container)},
                new ToolBoxItem {Tab = "Controls", Name = "User Picture", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.UserPicture, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Picture", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.DynamicImage, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Grid", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.Grid, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Rich TextBox", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.RichTextBox, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Comment", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.Comment, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Nested Form Link", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.NestedLink, container)},
                new ToolBoxItem {Tab = "Controls", Name = "Canvas", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.CanvasPanel, container)},
                new ToolBoxItem {Tab = "Controls", Name = "DateTimePicker", Properties = AbstractBaseControl.CreateDefault(ControlTypeEnum.DateTimePicker, container)}
            };

            items.Sort((a, b) => string.Compare(a.Name.Trim(), b.Name.Trim(), StringComparison.OrdinalIgnoreCase));

            return items;
        }
    }
}