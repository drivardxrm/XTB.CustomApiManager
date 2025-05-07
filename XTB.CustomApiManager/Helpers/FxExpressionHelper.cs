using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTB.CustomApiManager.Entities;

namespace XTB.CustomApiManager.Helpers
{
    public static class FxExpressionHelper
    {



        public static Entity GetFxExpression(this IOrganizationService service, Guid fxexpressionid)
        {

            return service.Retrieve(FxExpression.EntityName,
                                    fxexpressionid,
                                   new ColumnSet(new string[] {
                                       FxExpression.PrimaryName,
                                       FxExpression.UniqueName,
                                       FxExpression.Inputandoutputparametersassociatedwiththeexpression,
                                       FxExpression.Category,
                                       FxExpression.Context,
                                       FxExpression.EntityLogicalName,
                                       FxExpression.Expression,
                                       FxExpression.IsManaged }));
        }

        


    }


    public class FxExpressionContext
    {
        public string[] Tables { get; set; }
        public string[] CustomApis { get; set; }
        public string[] ConnectionReferences { get; set; }
        public string[] TabularConnectionReferences { get; set; }
        public string[] ActionConnectorConnectionReferences { get; set; }
    }

}
