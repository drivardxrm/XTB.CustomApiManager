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
    public static class PrivilegeHelper
    {


        public static EntityCollection GetPrivileges(this IOrganizationService service)
        {
            var fetchxml = $@"
                            <fetch>
                              <entity name='privilege'>
                                <order attribute='name' />
                              </entity>
                            </fetch>";

            var fetch = new FetchExpression(fetchxml);
            var query = service.QueryFromFetch(fetch);
            var result = service.RetrieveAll(query);

            return new EntityCollection(result);

        }




    }
}
