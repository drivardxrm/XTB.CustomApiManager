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


        public Entity CustomApiResponsePropertyRow;



        public CustomApiResponsePropertyProxy(Entity customapiresponsepropertyrow)
        {
            CustomApiResponsePropertyRow = customapiresponsepropertyrow;
        }

       

        public string Name => CustomApiResponsePropertyRow[CustomAPI.PrimaryName].ToString();
        public string UniqueName => CustomApiResponsePropertyRow[CustomAPI.UniqueName].ToString();



        
    }
}
