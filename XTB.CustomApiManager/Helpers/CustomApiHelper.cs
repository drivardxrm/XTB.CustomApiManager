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




        public static EntityCollection GetSolutions(this IOrganizationService service)
        {
            var fetchxml = @"<fetch>
                              <entity name='solution' >
                                <attribute name='friendlyname' />
                                <attribute name='publisherid' />
                                <attribute name='version' />
                                <attribute name='ismanaged' />
                                <attribute name='uniquename' />
                                <attribute name='organizationid' />
                                <attribute name='publisheridname' />
                                <attribute name='publisheridprefix' />
                                <link-entity name='publisher' from='publisherid' to='publisherid' link-type='outer' alias='P'>
                                  <attribute name='uniquename' />
                                  <attribute name='customizationprefix' />
                                </link-entity>
                              </entity>
                            </fetch>";

            var fetch = new FetchExpression(fetchxml);
            return service.RetrieveMultiple(fetch);
        }

        public static EntityCollection GetPublishers(this IOrganizationService service)
        {
            var fetchxml = @"<fetch>
                              <entity name='publisher' >
                                  <attribute name='uniquename' />
                                  <attribute name='customizationprefix' />    
                              </entity>
                            </fetch>";

            var fetch = new FetchExpression(fetchxml);
            return service.RetrieveMultiple(fetch);
        }

        public static EntityCollection GetCustomApisFor(this IOrganizationService service, Guid solutionid)
        {
            var fetchXml = $@"
            <fetch top='50'>
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

              </entity>
            </fetch>";


            var fetch = new FetchExpression(fetchXml);
            return service.RetrieveMultiple(fetch);
        }

        //public EntityCollection GetCustomApiFor(Guid solutionid)
        //{
        //    return new EntityCollection();
        //}

        //public EntityCollection GetCustomApiRequestParametersFor(Guid customapiid)
        //{
        //    return new EntityCollection();
        //}

        //public EntityCollection GetCustomApiResponseParametersFor(Guid customapiid)
        //{
        //    return new EntityCollection();
        //}

        public static Guid CreateCustomApi(this IOrganizationService service)
        {
            var api = new Entity(CustomAPI.EntityName);
            api[CustomAPI.AllowedCustomProcessingStepType] = new OptionSetValue(0);  //none
            api[CustomAPI.BindingType] = new OptionSetValue(0);  //Global
            api[CustomAPI.Description] = "A simple example of a Custom API";
            api[CustomAPI.DisplayName] = "Custom API Example";
            api[CustomAPI.ExecutePrivilegeName] = null;
            api[CustomAPI.IsFunction] = false;
            api[CustomAPI.IsPrivate] = false;
            api[CustomAPI.PrimaryName] = "CustomApiExample";
            //api[CustomAPI.PluginType] =  //entityref TODO
            api[CustomAPI.UniqueName] = "xrm_CustomApiExample";  //need publisher name here

            return service.Create(api);
        }
        //public void UpdateCustomApi()
        //{
        //    throw new NotImplementedException();
        //}
        //public void DeleteCustomApi()
        //{
        //    throw new NotImplementedException();
        //}

        public static Guid CreateCustomApiRequestParameter(this IOrganizationService service, EntityReference customapiref)
        {
            var parameter = new Entity(CustomAPIRequestParameter.EntityName);
            parameter[CustomAPIRequestParameter.Description] = "The StringParameter request parameter for Custom API Example";
            parameter[CustomAPIRequestParameter.DisplayName] = "Custom API Example String Parameter";
            parameter[CustomAPIRequestParameter.IsOptional] = false;
            parameter[CustomAPIRequestParameter.PrimaryName] = "";
            parameter[CustomAPIRequestParameter.Type] = new OptionSetValue(10); //string
            parameter[CustomAPIRequestParameter.UniqueName] = "StringParameter";
            parameter[CustomAPIRequestParameter.CustomAPI] = customapiref;

            return service.Create(parameter);
        }
        //public void UpdateCustomApiRequestParameter()
        //{
        //    throw new NotImplementedException();
        //}
        //public void DeleteCustomApiRequestParameter()
        //{
        //    throw new NotImplementedException();
        //}

        public static Guid CreateCustomApiResponseProperty(this IOrganizationService service, EntityReference customapiref)
        {
            var property = new Entity(CustomAPIResponseProperty.EntityName);
            property[CustomAPIResponseProperty.Description] = "The StringProperty response property for Custom API Example";
            property[CustomAPIResponseProperty.DisplayName] = "Custom API Example String Property";
            property[CustomAPIResponseProperty.PrimaryName] = "";
            property[CustomAPIResponseProperty.Type] = new OptionSetValue(10); //string
            property[CustomAPIResponseProperty.UniqueName] = "StringProperty";
            property[CustomAPIResponseProperty.CustomAPI] = customapiref;

            return service.Create(property);
        }
        //public void UpdateCustomApiResponseParameter()
        //{
        //    throw new NotImplementedException();
        //}
        //public void DeleteCustomApiResponseParameter()
        //{
        //    throw new NotImplementedException();
        //}

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
