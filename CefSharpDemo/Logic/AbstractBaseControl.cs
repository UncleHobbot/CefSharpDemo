using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CefSharpDemo.Logic
{
    public class AbstractBaseControl
    {
        public ControlTypeEnum Type { get; set; }//=> (ControlTypeEnum)Enum.Parse(typeof(ControlTypeEnum), GetType().Name);

        public ControlContainer Container { get; set; }

        public static AbstractBaseControl CreateDefault(ControlTypeEnum controlType, ControlContainer container) 
            =>  CreateDefault(controlType, null, container);
        
        public static AbstractBaseControl CreateDefault(ControlTypeEnum controlType, string jsonPropData, ControlContainer container)
        {
            var controlAssemblyType = System.Type.GetType($"CefSharpDemo.Logic.Controls.{controlType}");
            var control = controlAssemblyType != null ? (AbstractBaseControl) Activator.CreateInstance(controlAssemblyType) : new AbstractBaseControl();

            control.Type = controlType;
            control.Container = container;

            if (jsonPropData != null)
                JsonConvert.PopulateObject(jsonPropData, control);
            return control;
        }

        public string Caption { get; set; }

        private string _serverId;
        public virtual string ServerId
        {
            get => _serverId;
            set
            {
                if (value == null)
                    return;

                //if (!NameHelper.ValidName(value))
                //    throw new Exception(lh.fs($"{value} is not valid"));

                //if (Container != null && _serverId?.ToLower() != value.ToLower() && Container.FormControls.Any(c => c.ServerId.EqualsIC(value)))
                //    throw new Exception(lh.fs($"{value} control name is not unique"));

                // Update childrens
                //if (Type == ControlTypeEnum.Row || Type == ControlTypeEnum.Column || this is IRayContainer)
                //{
                //    // when deserializing _container might be null
                //    if (Container != null && _serverId != null)
                //        foreach (var child in Container.FindChildren(_serverId))
                //            child.ParentId = value;
                //}

                // set server_id
                _serverId = value;
                //if (HasFormControl)
                //    FormControl.Name = value;
            }
        }

        public string ParentId { get; set; }
        public int Order { get; set; }
        protected virtual string CssClass => Type.ToString();

        private bool _serializeWithChildren;
        private bool _serializeWithServerId;
        public string ToJson(bool withChildren = true, bool withServerid = true)
        {
            var lastWithChildrenState = _serializeWithChildren;
            var lastWithServerIdState = _serializeWithServerId;
            try
            {
                _serializeWithChildren = withChildren;
                _serializeWithServerId = withServerid;

                return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            }
            finally
            {
                _serializeWithChildren = lastWithChildrenState;
                _serializeWithServerId = lastWithServerIdState;
            }
        }

        public List<AbstractBaseControl> Children => this is IContainer && !string.IsNullOrEmpty(ServerId)
            ? Container.FindChildren(ServerId).OrderBy(c => c.Order).ToList() : new List<AbstractBaseControl>();

        public virtual void SetPropertyValue(string property, string value)
        {
            var prop = GetType().GetProperty(property);

            object convertedValue = null;

            if (prop.PropertyType == typeof(int))
                convertedValue = Convert.ToInt32(value);
            else if (prop.PropertyType == typeof(long))
                convertedValue = Convert.ToInt64(value);
            else if (prop.PropertyType == typeof(float))
                convertedValue = (float)Convert.ToDouble(value);
            else if (prop.PropertyType == typeof(double))
                convertedValue = Convert.ToDouble(value);
            else if (prop.PropertyType == typeof(bool))
                convertedValue = Convert.ToBoolean(value);
            else if (prop.PropertyType == typeof(string))
                convertedValue = value;

            prop.SetValue(this, convertedValue);
        }
    }

    internal interface IContainer { }

    public class BindInfo
    {
        public string EntityName { get; set; }
        public string FieldName { get; set; }
        public string FieldCatpion { get; set; }
        public string FieldType { get; set; }
    }

}
