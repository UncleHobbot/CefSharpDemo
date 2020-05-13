using CefSharpDemo.Logic.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CefSharpDemo.Logic
{
    public class Bridge : IBridge
    {
        private readonly ToolBarContainer _toolbarContainer;

        public List<AbstractBaseControl> Controls { get; set; } = new List<AbstractBaseControl>();
        public List<BindInfo> EntityFields { get; set; }

        public ControlContainer _container;
        public Action RefreshAction;

        public Bridge()
        {
            Controls = new List<AbstractBaseControl>();
            EntityFields = new List<BindInfo>();

            // Sample EntityFieldsForTest  
            _container = new ControlContainer();
            _toolbarContainer = new ToolBarContainer();
        }

        public event EventHandler<AbstractBaseControl> OnAdd;
        public event EventHandler<AbstractBaseControl> OnChange;
        public event EventHandler<AbstractBaseControl> OnDuplicated;
        public event EventHandler<string> OnSelect;
        public event EventHandler<object[]> OnMultiSelect;
        public event EventHandler<bool> OnSave;
        public event EventHandler<bool> OnAnythingChanged;
        public event EventHandler<bool> OnRefreshNeeded;
        public event EventHandler<int> OnPageSizeChanged;

        public string Loc(string str) => str;

        public string HostGetControlById(string serverId)
            => JsonConvert.SerializeObject(Controls.Single(c => c.ServerId == serverId));

        public string GetEntityFields() => JsonConvert.SerializeObject(EntityFields);

        public void OnControlAdded(ControlTypeEnum controlType, string prop)
        {
            var controlAssemblyType = Type.GetType($"CefSharpDemo.Logic.Controls.{controlType}");
            var control = controlAssemblyType != null ? (AbstractBaseControl)Activator.CreateInstance(controlAssemblyType) : new AbstractBaseControl();

            JsonConvert.PopulateObject(prop, control);
            //control.Container = _container;
            OnAdd?.Invoke(this, control);
        }

        internal void SelectControl(string selectedItem) { }

        public void OnControlChanged(ControlTypeEnum controlType, string serverId, string propertyName, object propertyValue)
        {
            //var ctrl = _container.Find(serverId);
            //var mem = ctrl.GetType().GetMember(propertyName);

        }

        public string RequestDuplicate(string serverId)
        {
            var newId = DuplicateControl(serverId);
            OnRefreshNeeded?.Invoke(this, true);
            return _container.Find(newId).ToJson();
        }

        public string DuplicateControl(string id, string parentId = "")
        {
            var control = _container.Find(id);
            var copy = AbstractBaseControl.CreateDefault(control.Type, control.ToJson(false, false), _container);

            copy.ServerId = _container.GenerateName(copy.Type.ToString());
            //copy.Container = _container;

            if (parentId != string.Empty)
                copy.ParentId = parentId;

            //if (OnDuplicated != null && string.IsNullOrEmpty(parentId))
            OnDuplicated?.Invoke(this, copy);

            _container.Add(copy);
            control.Children.ForEach(c => DuplicateControl(c.ServerId, copy.ServerId));
            return copy.ServerId;
        }

        public string RequestDelete(string serverId)
        {
            if (!IsDeleteAllowed(serverId))
                return "You can't remove converted control";

            _container.Remove(serverId);

            OnAnythingChanged?.Invoke(this, true);
            OnRefreshNeeded?.Invoke(this, true);

            return "True";
        }

        private bool IsDeleteAllowed(string serverId)
        {
            var isAllowed = true;
            var children = _container.FindChildren(serverId);
            if (children.Any())
            {
                foreach (var ctrl in children)
                    isAllowed = isAllowed && IsDeleteAllowed(ctrl.ServerId);
                return isAllowed;
            }

            return true;
        }

        public void RequestSelectControl(string serverId) => OnSelect?.Invoke(this, serverId);
        public void RequestSelectControls(object[] serverId) => OnMultiSelect?.Invoke(this, serverId);

        public bool RequestLayoutChange(string serverId, object[] cols)
        {
            int index;

            // Container of columns => the row
            var row = _container.Find(serverId);
            // The columns of the row
            var rowColumns = row.Children.Cast<Column>().ToList();

            var requestedCols = cols.Cast<int>().ToArray();
            var colsToRemove = rowColumns.Count - requestedCols.Length;

            // before we do anything we should check if the cells are empty
            if (colsToRemove > 0)
                for (index = rowColumns.Count - 1; index >= rowColumns.Count - colsToRemove; index--)
                    if (rowColumns[index].Children.Count != 0)
                        return false;

            // Update widths
            index = 0;
            foreach (var col in rowColumns)
            {
                if (index >= requestedCols.Length)
                    break;

                col.Width = requestedCols[index++];
            }

            // Insert any new column
            if (requestedCols.Length >= rowColumns.Count)
            {
                var maxOrder = rowColumns.Max(c => c.Order);
                for (; index < requestedCols.Length; index++)
                {
                    var newColumn = new Column { Container = _container };

                    newColumn.ServerId = _container.GenerateName(newColumn.Type.ToString());
                    newColumn.ParentId = serverId;
                    newColumn.Width = requestedCols[index];
                    newColumn.Order = ++maxOrder;

                    _container.Add(newColumn);
                }

                OnAnythingChanged?.Invoke(this, true);

                return true;
            }

            // Remove 
            for (index = rowColumns.Count - 1; index >= rowColumns.Count - colsToRemove; index--)
                _container.Remove(rowColumns[index].ServerId);

            OnAnythingChanged?.Invoke(this, true);

            return true;

            // ToDo: Perhaps it will be needed to update Row.Columns property too
        }

        public void RequestUpdateProperty(string serverId, string name, string value)
        {
            var control = _container.Find(serverId);
            control.SetPropertyValue(name, value);

            RequestSelectControl(serverId);

            OnAnythingChanged?.Invoke(this, true);
        }

        public string RequestAddControl(ControlTypeEnum controlType, string data)
        {
            var control = AbstractBaseControl.CreateDefault(controlType, data, _container);
            control.ServerId = _container.GenerateName(control.Type.ToString());
            control.Caption = control.ServerId;

            _container.Add(control);

            OnAdd?.Invoke(this, control);

            //if (control is RayTabControl)
            //{
            //    var tabPage = AbstractBaseControl.CreateDefault(ControlTypeEnum.RayTabPage, null, _container);
            //    tabPage.ServerId = _container.GenerateName(ControlTypeEnum.RayTabPage.ToString());
            //    tabPage.Caption = tabPage.ServerId;
            //    tabPage.ParentId = control.ServerId;
            //    tabPage.Order = 0;
            //    _container.Add(tabPage);

            //    OnAdd?.Invoke(this, tabPage);

            //    tabPage = AbstractBaseControl.CreateDefault(ControlTypeEnum.RayTabPage, null, _container);
            //    tabPage.ServerId = _container.GenerateName(ControlTypeEnum.RayTabPage.ToString());
            //    tabPage.Caption = tabPage.ServerId;
            //    tabPage.ParentId = control.ServerId;
            //    tabPage.Order = 1;
            //    _container.Add(tabPage);

            //    OnAdd?.Invoke(this, tabPage);
            //}

            OnRefreshNeeded?.Invoke(this, true);

            return control.ToJson();
        }

        public string RequestControlData(string serverId) => _container.Find(serverId).ToJson();

        public string RequestSampleData()
        {
            var cc = _container.FormControls.Where(fc => fc.ParentId == null).OrderBy(fc => fc.Order).ToList();
            return JsonConvert.SerializeObject(cc, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        public string RequestToolBarItems() =>
            JsonConvert.SerializeObject(_toolbarContainer.GetItems(_container), Formatting.Indented,
                new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });


        public int RequestOrderId(string serverId, string prevServerId, string parentId)
        {
            var newOrder = 0;
            var control = _container.Find(serverId);
            var children = _container.FindChildren(parentId);

            if (prevServerId != null)
                newOrder = _container.Find(prevServerId).Order + 1;

            var order = newOrder;

            children.ForEach(child =>
            {
                if (child.Order >= newOrder && child.ServerId != serverId)
                    child.Order = ++newOrder;
            });

            control.Order = order;
            OnAnythingChanged?.Invoke(this, true);
            return newOrder;
        }

        public string RequestApplicationFileData(string fileId)
        {
            var mimeType = "image/png";
            var sample = (byte[])new ImageConverter().ConvertTo(Properties.Resources.SampleImage, typeof(byte[]));
            var data = Convert.ToBase64String(sample);
            return $"data:{mimeType};base64,{data}";
        }

        public void RequestSave() => OnSave?.Invoke(this, false);

        public void RequestSelectTab(string tabPageServerId)
        {
            //var tabPage = _container.Find(tabPageServerId);
            //var tabControl = (RayTabControl)tabPage.Parent;
            //tabControl.SelectedTab = (Controls.RayTabPage)tabPage;
        }

        public void RequestSetPageSize(int size) => OnPageSizeChanged?.Invoke(this, size);

        public string RequestPageSize() => "12";
        public void RequestRefresh()
        {
            RefreshAction?.Invoke();
        }

        public void Refresh() => OnRefreshNeeded?.Invoke(this, true);
    }
}