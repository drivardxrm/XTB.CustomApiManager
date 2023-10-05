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
    public class CustomApiResponsePropertyProxy
    {


        public Entity ResponsePropertyRow;
        /// <summary>
        /// Whether we are working against online env or on-premises?
        /// </summary>
        readonly bool _isOnline;



        public CustomApiResponsePropertyProxy(Entity responseproperty, bool isOnline)
        {
            ResponsePropertyRow = responseproperty;
            _isOnline = isOnline;
        }



        public string Name => ResponsePropertyRow.Attributes.Contains(CustomAPIResponseProperty.PrimaryName) ?
                                                    ResponsePropertyRow[CustomAPIResponseProperty.PrimaryName].ToString() :
                                                    string.Empty;
        public string UniqueName => ResponsePropertyRow.Attributes.Contains(CustomAPIResponseProperty.UniqueName) ?
                                                    ResponsePropertyRow[CustomAPIResponseProperty.UniqueName].ToString() :
                                                    string.Empty;



        public string DisplayName => ResponsePropertyRow.Attributes.Contains(CustomAPIResponseProperty.DisplayName) ?
                                                    ResponsePropertyRow[CustomAPIResponseProperty.DisplayName].ToString() :
                                                    string.Empty;

        public string Description => ResponsePropertyRow.Attributes.Contains(CustomAPIResponseProperty.Description) ?
                                                    ResponsePropertyRow[CustomAPIResponseProperty.Description].ToString() :
                                                    string.Empty;

        public string BoundEntityLogicalName
        {
            get
            {
                var boundEntityLogicalName = _isOnline ? CustomAPIResponseProperty.BoundEntityLogicalName : CustomApiHelper.OnPremBoundEntityLogicalName;
                return ResponsePropertyRow == null ? string.Empty :
                    (ResponsePropertyRow.Attributes.Contains(boundEntityLogicalName) &&
                        !string.IsNullOrEmpty(ResponsePropertyRow.Attributes[boundEntityLogicalName].ToString()) ?
                        ResponsePropertyRow[boundEntityLogicalName]?.ToString() :
                        (IsBoundToEntity() ? "expando" : string.Empty));
            }
        }

        public bool IsManaged => ResponsePropertyRow.Attributes.Contains(CustomAPIResponseProperty.IsManaged) &&
                           (bool)ResponsePropertyRow[CustomAPIResponseProperty.IsManaged];

        public bool IsCustomizable => ResponsePropertyRow.Attributes.Contains(CustomAPIResponseProperty.IsCustomizable) &&
                            ((BooleanManagedProperty)ResponsePropertyRow[CustomAPIResponseProperty.IsCustomizable]).Value;



        public CustomAPIResponseProperty.Type_OptionSet Type => (CustomAPIResponseProperty.Type_OptionSet)(ResponsePropertyRow[CustomAPIResponseProperty.Type] as OptionSetValue).Value;



        public bool CanCustomize => !IsManaged || (IsManaged && IsCustomizable);

        public bool IsBoundToEntity()
        {
            return Type == CustomAPIResponseProperty.Type_OptionSet.Entity
                    ||
                    Type == CustomAPIResponseProperty.Type_OptionSet.EntityReference;
        }


    }
}
