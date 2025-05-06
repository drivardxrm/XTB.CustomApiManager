using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTB.CustomApiManager.Entities;

namespace XTB.CustomApiManager.Proxy
{
    public class FxExpressionProxy
    {
        

        public Entity FxEpressionRow;

        

        public FxExpressionProxy(Entity solution)
        {
            FxEpressionRow = solution;
        }

       

        


        public string Name => FxEpressionRow[FxExpression.PrimaryName].ToString();
        public string UniqueName => FxEpressionRow[FxExpression.UniqueName].ToString();


        public string Expression => FxEpressionRow[FxExpression.Expression].ToString();

        public string Context => FxEpressionRow[FxExpression.Context].ToString();

        public string Dependencies => FxEpressionRow[FxExpression.PowerFxExpressiondependencies].ToString();

        public string Parameters => FxEpressionRow[FxExpression.Inputandoutputparametersassociatedwiththeexpression].ToString();

    }
}
