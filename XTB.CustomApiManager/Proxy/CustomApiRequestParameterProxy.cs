using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTB.CustomApiManager.Entities;
using XTB.CustomApiManager.Helpers;

namespace XTB.CustomApiManager.Proxy
{
    public class CustomApiRequestParameterProxy
    {


        public Entity RequestParameterRow;
        /// <summary>
        /// Whether we are working against online env or on-premises?
        /// </summary>
        readonly bool _isOnline;


        public CustomApiRequestParameterProxy(Entity requestparameter, bool isOnline)
        {
            RequestParameterRow = requestparameter;
            _isOnline = isOnline;
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

        public string BoundEntityLogicalName {
            get {
                var boundEntityLogicalName = _isOnline ? CustomAPIRequestParameter.BoundEntityLogicalName : CustomApiHelper.OnPremBoundEntityLogicalName;
                return RequestParameterRow == null ? string.Empty :
                    (RequestParameterRow.Attributes.Contains(boundEntityLogicalName) && 
                        !string.IsNullOrEmpty(RequestParameterRow.Attributes[boundEntityLogicalName].ToString()) ?
                        RequestParameterRow[boundEntityLogicalName]?.ToString() :
                        (IsBoundToEntity() ? "expando" : string.Empty));
            }
        }


        public bool IsOptional => RequestParameterRow.Attributes.Contains(CustomAPIRequestParameter.IsOptional) &&
                                    (bool)RequestParameterRow[CustomAPIRequestParameter.IsOptional];

        public bool IsManaged => RequestParameterRow.Attributes.Contains(CustomAPIRequestParameter.IsManaged) &&
                                    (bool)RequestParameterRow[CustomAPIRequestParameter.IsManaged];

        public bool IsCustomizable => RequestParameterRow.Attributes.Contains(CustomAPIRequestParameter.IsCustomizable) &&
                                    ((BooleanManagedProperty)RequestParameterRow[CustomAPIRequestParameter.IsCustomizable]).Value;

        public CustomAPIRequestParameter.Type_OptionSet Type => (CustomAPIRequestParameter.Type_OptionSet)(RequestParameterRow[CustomAPIRequestParameter.Type] as OptionSetValue).Value;



        public bool CanCustomize => !IsManaged || (IsManaged && IsCustomizable);

        public bool IsBoundToEntity()
        {
            return Type == CustomAPIRequestParameter.Type_OptionSet.Entity
                    ||
                    Type == CustomAPIRequestParameter.Type_OptionSet.EntityReference;
        }


    }
}
