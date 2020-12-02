using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTB.CustomApiManager.Entities;
using static XTB.CustomApiManager.Entities.CustomAPI;

namespace XTB.CustomApiManager.Proxy
{
    internal class CustomApiProxy
    {


        public Entity CustomApiRow;



        public CustomApiProxy(Entity customapirow)
        {
            CustomApiRow = customapirow;
        }

       

        public string Name => CustomApiRow[CustomAPI.PrimaryName].ToString();
        public string UniqueName => CustomApiRow[CustomAPI.UniqueName].ToString();


        public BindingType_OptionSet BindingType => (BindingType_OptionSet)(CustomApiRow[CustomAPI.BindingType] as OptionSetValue).Value;

        public AllowedCustomProcessingStepType_OptionSet AllowedProcesingStep => (AllowedCustomProcessingStepType_OptionSet)(CustomApiRow[CustomAPI.AllowedCustomProcessingStepType] as OptionSetValue).Value;

        public EntityReference PluginType => CustomApiRow[CustomAPI.PluginType] as EntityReference;

    }
}
