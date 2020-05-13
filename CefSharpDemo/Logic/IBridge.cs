using System;
using System.Collections.Generic;

namespace CefSharpDemo.Logic
{
    public interface IBridge
    {
        List<AbstractBaseControl> Controls { get; set; }
        List<BindInfo> EntityFields { get; set; }
        event EventHandler<AbstractBaseControl> OnAdd;
        event EventHandler<AbstractBaseControl> OnChange;
        event EventHandler<AbstractBaseControl> OnDuplicated;
        event EventHandler<string> OnSelect;
        event EventHandler<object[]> OnMultiSelect;
        event EventHandler<bool> OnSave;
        event EventHandler<bool> OnAnythingChanged;
        event EventHandler<bool> OnRefreshNeeded;
        event EventHandler<int> OnPageSizeChanged;

        string HostGetControlById(string serverId);
        string GetEntityFields();
        void OnControlAdded(ControlTypeEnum controlType, string prop);
        void OnControlChanged(ControlTypeEnum controlType, string serverId, string propertyName, object propertyValue);
        string RequestDuplicate(string serverId);
        string DuplicateControl(string id, string parentId = "");
        string RequestDelete(string serverId);
        void RequestSelectControl(string serverId);
        bool RequestLayoutChange(string serverId, object[] cols);
        void RequestUpdateProperty(string serverId, string name, string value);
        string RequestAddControl(ControlTypeEnum controlType, string data);
        string RequestControlData(string serverId);
        string RequestSampleData();
        string RequestToolBarItems();
        int RequestOrderId(string serverId, string prevServerId, string parentId);
        string RequestApplicationFileData(string fileId);
        void RequestSave();
        void RequestSelectTab(string tabPageServerId);
        void RequestSetPageSize(int size);
        string RequestPageSize();
        void RequestRefresh();
    }
}