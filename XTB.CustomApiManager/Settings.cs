using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTB.CustomApiManager
{
    /// <summary>
    /// This class can help you to store settings for your plugin
    /// </summary>
    /// <remarks>
    /// This class must be XML serializable
    /// </remarks>
    public class Settings
    {
        public string LastUsedOrganizationWebappUrl { get; set; }

        public string RequestParameterDefaultName { get; set; } = "{customapiname}-In-{uniquename}";
        public string ResponsePropertyDefaultName { get; set; } = "{customapiname}-Out-{uniquename}";

        public Guid DefaultPublisherId { get; set; } // connection based setting

        public string OpenApiDefaultFormat { get; set; } = "yaml"; // yaml or json

    }
}