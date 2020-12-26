using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTB.CustomApiManager.Entities;

namespace XTB.CustomApiManager.Proxy
{
    internal class CustomApiResponsePropertyProxy
    {


        public Entity ResponsePropertyRow;



        public CustomApiResponsePropertyProxy(Entity responsepropertyrow)
        {
            ResponsePropertyRow = responsepropertyrow;
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

        public string BoundEntityLogicalName => ResponsePropertyRow.Attributes.Contains(CustomAPIResponseProperty.BoundEntityLogicalName) ?
                                                    ResponsePropertyRow[CustomAPIResponseProperty.BoundEntityLogicalName].ToString() :
                                                    string.Empty;



        public CustomAPIResponseProperty.Type_OptionSet Type => (CustomAPIResponseProperty.Type_OptionSet)(ResponsePropertyRow[CustomAPIResponseProperty.Type] as OptionSetValue).Value;






    }
}
