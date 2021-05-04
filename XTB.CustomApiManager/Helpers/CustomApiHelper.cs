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
    public static class CustomApiHelper
    {

        public static Entity GetCustomApi(this IOrganizationService service, Guid customapiid)
            => service.Retrieve(CustomAPI.EntityName, customapiid, new ColumnSet() { AllColumns = true });

        public static Entity GetRequestParameter(this IOrganizationService service, Guid requestparameterid)
            => service.Retrieve(CustomAPIRequestParameter.EntityName, requestparameterid, new ColumnSet() { AllColumns = true });

        public static Entity GetResponseProperty(this IOrganizationService service, Guid responsepropertyid)
            => service.Retrieve(CustomAPIResponseProperty.EntityName, responsepropertyid, new ColumnSet() { AllColumns = true });

        public static EntityCollection GetCustomApisFor(this IOrganizationService service, Guid solutionid)
        {
            var fetchXml = $@"
            <fetch>
              <entity name='customapi'>
                <attribute name='createdonbehalfbyyominame' />
                <attribute name='owninguser' />
                <attribute name='statecode' />
                <attribute name='owneridname' />
                <attribute name='description' />
                <attribute name='statecodename' />
                <attribute name='ismanagedname' />
                <attribute name='createdonbehalfby' />
                <attribute name='isfunctionname' />
                <attribute name='sdkmessageidname' />
                <attribute name='name' />
                <attribute name='componentidunique' />
                <attribute name='iscustomizable' />
                <attribute name='isprivate' />
                <attribute name='customapiid' />
                <attribute name='importsequencenumber' />
                <attribute name='bindingtypename' />
                <attribute name='modifiedbyyominame' />
                <attribute name='allowedcustomprocessingsteptype' />
                <attribute name='componentstate' />
                <attribute name='allowedcustomprocessingsteptypename' />
                <attribute name='utcconversiontimezonecode' />
                <attribute name='createdbyyominame' />
                <attribute name='owningbusinessunit' />
                <attribute name='modifiedbyname' />
                <attribute name='owningteam' />
                <attribute name='isfunction' />
                <attribute name='workflowsdkstepenabled' />
                <attribute name='modifiedby' />
                <attribute name='createdby' />
                <attribute name='timezoneruleversionnumber' />
                <attribute name='sdkmessageid' />
                <attribute name='plugintypeid' />
                <attribute name='owneridtype' />
                <attribute name='statuscodename' />
                <attribute name='overwritetime' />
                <attribute name='uniquename' />
                <attribute name='solutionid' />
                <attribute name='owneridyominame' />
                <attribute name='modifiedon' />
                <attribute name='displayname' />
                <attribute name='bindingtype' />
                <attribute name='ismanaged' />
                <attribute name='statuscode' />
                <attribute name='createdbyname' />
                <attribute name='createdon' />
                <attribute name='plugintypeidname' />
                <attribute name='componentstatename' />
                <attribute name='boundentitylogicalname' />
                <attribute name='executeprivilegename' />
                <attribute name='isprivatename' />
                <attribute name='ownerid' />
                <link-entity name='solutioncomponent' from='objectid' to='customapiid' link-type='inner' alias='SC'>
                    <attribute name='componenttype' />
                    <attribute name='solutionid' />
                    <filter>
                        <condition attribute='solutionid' operator='eq' value='{solutionid}'/>
                    </filter>
                    
                </link-entity>
                <order attribute='name' />
              </entity>
            </fetch>";


            var fetch = new FetchExpression(fetchXml);
            return service.RetrieveMultiple(fetch);
        }

        public static EntityCollection GetAllCustomApis(this IOrganizationService service)
        {
            var fetchXml = $@"
            <fetch>
              <entity name='customapi'>
                <attribute name='createdonbehalfbyyominame' />
                <attribute name='owninguser' />
                <attribute name='statecode' />
                <attribute name='owneridname' />
                <attribute name='description' />
                <attribute name='statecodename' />
                <attribute name='ismanagedname' />
                <attribute name='createdonbehalfby' />
                <attribute name='isfunctionname' />
                <attribute name='sdkmessageidname' />
                <attribute name='name' />
                <attribute name='componentidunique' />
                <attribute name='iscustomizable' />
                <attribute name='isprivate' />
                <attribute name='customapiid' />
                <attribute name='importsequencenumber' />
                <attribute name='bindingtypename' />
                <attribute name='modifiedbyyominame' />
                <attribute name='allowedcustomprocessingsteptype' />
                <attribute name='componentstate' />
                <attribute name='allowedcustomprocessingsteptypename' />
                <attribute name='utcconversiontimezonecode' />
                <attribute name='createdbyyominame' />
                <attribute name='owningbusinessunit' />
                <attribute name='modifiedbyname' />
                <attribute name='owningteam' />
                <attribute name='isfunction' />
                <attribute name='workflowsdkstepenabled' />
                <attribute name='modifiedby' />
                <attribute name='createdby' />
                <attribute name='timezoneruleversionnumber' />
                <attribute name='sdkmessageid' />
                <attribute name='plugintypeid' />
                <attribute name='owneridtype' />
                <attribute name='statuscodename' />
                <attribute name='overwritetime' />
                <attribute name='uniquename' />
                <attribute name='solutionid' />
                <attribute name='owneridyominame' />
                <attribute name='modifiedon' />
                <attribute name='displayname' />
                <attribute name='bindingtype' />
                <attribute name='ismanaged' />
                <attribute name='statuscode' />
                <attribute name='createdbyname' />
                <attribute name='createdon' />
                <attribute name='plugintypeidname' />
                <attribute name='componentstatename' />
                <attribute name='boundentitylogicalname' />
                <attribute name='executeprivilegename' />
                <attribute name='isprivatename' />
                <attribute name='ownerid' />
                <order attribute='name' />

              </entity>
            </fetch>";


            var fetch = new FetchExpression(fetchXml);
            return service.RetrieveMultiple(fetch);
        }


        
        //For Grid
        public static EntityCollection GetCustomApisRequestParametersFor(this IOrganizationService service, Entity customapi)
        {
            if (customapi == null) 
            {
                return new EntityCollection();
            }

            
            var fetchXml = $@"
            <fetch>
              <entity name='customapirequestparameter'>
                <attribute name='uniquename' />
                <attribute name='type' />
                <attribute name='isoptional' />
                
                <filter>
                  <condition attribute='customapiid' operator='eq' value='{customapi.Id}'/>
                </filter>
              </entity>
            </fetch>";


            var fetch = new FetchExpression(fetchXml);
            return service.RetrieveMultiple(fetch);
        }

        
        //For Grid
        public static EntityCollection GetCustomApisResponsePropertiesFor(this IOrganizationService service, Entity customapi)
        {
            if (customapi == null)
            {
                return new EntityCollection();
            }

            var fetchXml = $@"
            <fetch>
              <entity name='customapiresponseproperty'>
                
                <attribute name='uniquename' />
                <attribute name='type' />
                <filter>
                  <condition attribute='customapiid' operator='eq' value='{customapi.Id}'/>
                </filter>
              </entity>
            </fetch>";


            var fetch = new FetchExpression(fetchXml);
            return service.RetrieveMultiple(fetch);
        }

        

        

        public static void AddToSolution(this IOrganizationService service, Guid componentid, EntityCode componentcode, string solutionname)
        {
            var addReq = new AddSolutionComponentRequest()
            {
                ComponentType = (int)componentcode,
                ComponentId = componentid,
                SolutionUniqueName = solutionname
            };
            service.Execute(addReq);
        }
    }
}
