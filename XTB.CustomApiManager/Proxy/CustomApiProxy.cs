using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTB.CustomApiManager.Entities;
//using static XTB.CustomApiManager.Entities.CustomAPI;

namespace XTB.CustomApiManager.Proxy
{
    public class CustomApiProxy
    {


        public Entity CustomApiRow;



        public CustomApiProxy(Entity customapi)
        {
            CustomApiRow = customapi;
        }

       

        public string Name => CustomApiRow.Attributes.Contains(CustomAPI.PrimaryName) ?
                                                    CustomApiRow[CustomAPI.PrimaryName].ToString() :
                                                    string.Empty;
        public string UniqueName => CustomApiRow.Attributes.Contains(CustomAPI.UniqueName) ?
                                                    CustomApiRow[CustomAPI.UniqueName].ToString() :
                                                    string.Empty;

        

        public string DisplayName => CustomApiRow.Attributes.Contains(CustomAPI.DisplayName) ?
                                                    CustomApiRow[CustomAPI.DisplayName].ToString() :
                                                    string.Empty;

        public string Description => CustomApiRow.Attributes.Contains(CustomAPI.Description) ?
                                                    CustomApiRow[CustomAPI.Description].ToString() :
                                                    string.Empty;


        public string BoundEntityLogicalName => CustomApiRow.Attributes.Contains(CustomAPI.BoundEntityLogicalName) ?
                                                    CustomApiRow[CustomAPI.BoundEntityLogicalName].ToString() :
                                                    string.Empty;


        public CustomAPI.BindingType_OptionSet BindingType => (CustomAPI.BindingType_OptionSet)(CustomApiRow[CustomAPI.BindingType] as OptionSetValue).Value;

        public CustomAPI.AllowedCustomProcessingStepType_OptionSet AllowedProcesingStep => (CustomAPI.AllowedCustomProcessingStepType_OptionSet)(CustomApiRow[CustomAPI.AllowedCustomProcessingStepType] as OptionSetValue).Value;

        public EntityReference PluginType => CustomApiRow.Attributes.Contains(CustomAPI.PluginType) ?
                                                    CustomApiRow[CustomAPI.PluginType] as EntityReference :
                                                    null;


        public string ExecutePrivilegeName => CustomApiRow.Attributes.Contains(CustomAPI.ExecutePrivilegeName) ?
                                                    CustomApiRow[CustomAPI.ExecutePrivilegeName].ToString() :
                                                    string.Empty;

        public bool IsFunction => CustomApiRow.Attributes.Contains(CustomAPI.IsFunction) && 
                                    (bool)CustomApiRow[CustomAPI.IsFunction];

        public bool EnabledforWorkflow => CustomApiRow.Attributes.Contains(CustomAPI.EnabledforWorkflow) &&
                                    (bool)CustomApiRow[CustomAPI.EnabledforWorkflow];

        public bool IsPrivate => CustomApiRow.Attributes.Contains(CustomAPI.IsPrivate) &&
                                    (bool)CustomApiRow[CustomAPI.IsPrivate];

        public bool IsManaged => CustomApiRow.Attributes.Contains(CustomAPI.IsManaged) &&
                                    (bool)CustomApiRow[CustomAPI.IsManaged];

        public bool IsCustomizable => CustomApiRow.Attributes.Contains(CustomAPI.IsCustomizable) &&
                                   ((BooleanManagedProperty)CustomApiRow[CustomAPI.IsCustomizable]).Value;


        public bool CanCustomize => !IsManaged || (IsManaged && IsCustomizable);


    }
}
