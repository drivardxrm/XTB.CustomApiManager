using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTB.CustomApiManager.Entities;

namespace XTB.CustomApiManager.Proxy
{
    internal class SolutionProxy
    {
        

        public Entity SolutionRow;

        

        public SolutionProxy(Entity solutionentity)
        {
            SolutionRow = solutionentity;
        }

       

        public string Prefix => $"{SolutionRow[$"P.{Publisher.Prefix}"]}_";


        public string FriendlyName => SolutionRow[Solution.PrimaryName].ToString();
        public string UniqueName => SolutionRow[Solution.Name].ToString(); 

       

        #region Public Methods

        public override string ToString()
        {
            return $"{FriendlyName} ({UniqueName})";
        }

        #endregion Public Methods
    }
}
