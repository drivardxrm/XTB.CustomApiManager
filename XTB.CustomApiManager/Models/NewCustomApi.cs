using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTB.CustomApiManager.Models
{
    public class NewCustomApi
    {
        public string UniqueName { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public string ExecutePrivilegeName { get; set; }


        //var api = new Entity(CustomAPI.EntityName);
        //api[CustomAPI.AllowedCustomProcessingStepType] = new OptionSetValue(0);  //none
        //api[CustomAPI.BindingType] = new OptionSetValue(0);  //Global
        //api[CustomAPI.Description] = "A simple example of a Custom API";
        //    api[CustomAPI.DisplayName] = "Custom API Example";
        //    api[CustomAPI.ExecutePrivilegeName] = null;
        //    api[CustomAPI.IsFunction] = false;
        //    api[CustomAPI.IsPrivate] = false;
        //    api[CustomAPI.PrimaryName] = "CustomApiExample";
        //    //api[CustomAPI.PluginType] =  //entityref TODO
        //    api[CustomAPI.UniqueName] = "xrm_CustomApiExample";  //need publisher name here
    }
}
