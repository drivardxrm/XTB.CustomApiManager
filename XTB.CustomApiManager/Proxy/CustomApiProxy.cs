using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTB.CustomApiManager.Entities;

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



        
    }
}
