using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTB.CustomApiManager.Entities;

namespace XTB.CustomApiManager.Proxy
{
    internal class CustomApiRequestParameterProxy
    {


        public Entity RequestParameterRow;



        public CustomApiRequestParameterProxy(Entity requestparameterrow)
        {
            RequestParameterRow = requestparameterrow;
        }



        public string Name => RequestParameterRow.Attributes.Contains(CustomAPIRequestParameter.PrimaryName) ?
                                                    RequestParameterRow[CustomAPIRequestParameter.PrimaryName].ToString() :
                                                    string.Empty;
        public string UniqueName => RequestParameterRow.Attributes.Contains(CustomAPIRequestParameter.UniqueName) ?
                                                    RequestParameterRow[CustomAPIRequestParameter.UniqueName].ToString() :
                                                    string.Empty;



        public string DisplayName => RequestParameterRow.Attributes.Contains(CustomAPIRequestParameter.DisplayName) ?
                                                    RequestParameterRow[CustomAPIRequestParameter.DisplayName].ToString() :
                                                    string.Empty;

        public string Description => RequestParameterRow.Attributes.Contains(CustomAPIRequestParameter.Description) ?
                                                    RequestParameterRow[CustomAPIRequestParameter.Description].ToString() :
                                                    string.Empty;

        public string BoundEntityLogicalName => RequestParameterRow.Attributes.Contains(CustomAPIRequestParameter.BoundEntityLogicalName) ?
                                                    RequestParameterRow[CustomAPIRequestParameter.BoundEntityLogicalName].ToString() :
                                                    string.Empty;


        public bool IsOptional => RequestParameterRow.Attributes.Contains(CustomAPIRequestParameter.IsOptional) &&
                                    (bool)RequestParameterRow[CustomAPIRequestParameter.IsOptional];

        public CustomAPIRequestParameter.Type_OptionSet Type => (CustomAPIRequestParameter.Type_OptionSet)(RequestParameterRow[CustomAPIRequestParameter.Type] as OptionSetValue).Value;

        

        


    }
}
