using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTB.CustomApiManager.Helpers
{
    public static class EntityHelper
    {
        public static List<Entity> RetrieveAll(this IOrganizationService service, QueryExpression query)
        {
            var pageNumber = 1;
            var pagingCookie = string.Empty;
            var result = new List<Entity>();
            EntityCollection resp;
            do
            {
                if (pageNumber != 1)
                {
                    query.PageInfo.PageNumber = pageNumber;
                    query.PageInfo.PagingCookie = pagingCookie;
                }
                resp = service.RetrieveMultiple(query);
                if (resp.MoreRecords)
                {
                    pageNumber++;
                    pagingCookie = resp.PagingCookie;
                }
                //Add the result from RetrieveMultiple to the List to be returned.
                result.AddRange(resp.Entities);
            }
            while (resp.MoreRecords);

            return result;
        }


        public static QueryExpression QueryFromFetch(this IOrganizationService service, FetchExpression fetch)
        {
            var request = new FetchXmlToQueryExpressionRequest
            {
                FetchXml = fetch.Query
            };
            var response = (FetchXmlToQueryExpressionResponse)service.Execute(request);
            return response.Query;
        }
    }
}
