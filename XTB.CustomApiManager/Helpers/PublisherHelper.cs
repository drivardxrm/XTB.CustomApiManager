using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTB.CustomApiManager.Entities;

namespace XTB.CustomApiManager.Helpers
{
    public static class PublisherHelper
    {




        public static string GetPublisherPrefix(this IOrganizationService service, Guid publisherid)
        {
            
            return service.Retrieve(Publisher.EntityName,
                                    publisherid, 
                                    new ColumnSet(new string[] { Publisher.Prefix }))
                            .Attributes[Publisher.Prefix].ToString();
        }

        
    }
}
