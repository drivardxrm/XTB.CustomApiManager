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


        public Entity CustomApiRequestParameterRow;



        public CustomApiRequestParameterProxy(Entity customapirequestparameterrow)
        {
            CustomApiRequestParameterRow = customapirequestparameterrow;
        }

       

        public string Name => CustomApiRequestParameterRow[CustomAPIRequestParameter.PrimaryName].ToString();
        public string UniqueName => CustomApiRequestParameterRow[CustomAPIRequestParameter.UniqueName].ToString();



        
    }
}
