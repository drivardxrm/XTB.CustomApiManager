using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTB.CustomApiManager.Helpers
{
    public static class CatalogAssignmentHelper
    {
        public static EntityCollection GetCatalogAssignmentsFor(this IOrganizationService service, Guid customApiId)
        {

            var fetchXml = $@"<?xml version='1.0' encoding='utf-16'?>
                                <fetch >
                                  <entity name='catalogassignment'>
                                    <attribute name='name' />
                                    <filter>
                                      <condition attribute='object' operator='eq' value='{customApiId}' />
                                    </filter>
                                    <link-entity name='catalog' from='catalogid' to='catalogid' alias='catalog'>
                                      
                                      <attribute name='name' />
                                      
                                      <link-entity name='catalog' from='catalogid' to='parentcatalogid' alias='parentcatalog'>
                                        
                                        <attribute name='name' />
                                        
                                      </link-entity>
                                    </link-entity>
                                  </entity>
                                </fetch>";


            var fetch = new FetchExpression(fetchXml);

            var fetchresult = service.RetrieveMultiple(fetch);


            return fetchresult;
        }


        public static Entity GetCatalogAssignmentFor(this IOrganizationService service, Guid catalogAssignmentId)
        {

            var fetchXml = $@"<?xml version='1.0' encoding='utf-16'?>
                                <fetch >
                                  <entity name='catalogassignment'>
                                    <attribute name='catalogassignmentid' />
                                    <attribute name='catalogid' />
                                    <attribute name='iscustomizable' />
                                    <attribute name='ismanaged' />
                                    <attribute name='name' />
                                    <attribute name='object' />
                                    <attribute name='statecode' />
                                    <attribute name='statuscode' />
                                    <filter>
                                      <condition attribute='catalogassignmentid' operator='eq' value='{catalogAssignmentId}' />
                                    </filter>
                                    <link-entity name='catalog' from='catalogid' to='catalogid' alias='catalog'>
                                      <attribute name='description' />
                                      <attribute name='displayname' />
                                      <attribute name='name' />
                                      <attribute name='parentcatalogid' />
                                      <attribute name='uniquename' />
                                      <attribute name='statecode' />
                                      <attribute name='statuscode' />
                                      <link-entity name='catalog' from='catalogid' to='parentcatalogid' alias='parentcatalog'>
                                        <attribute name='catalogid' />
                                        <attribute name='description' />
                                        <attribute name='displayname' />
                                        <attribute name='name' />
                                        <attribute name='statecode' />
                                        <attribute name='statuscode' />
                                      </link-entity>
                                    </link-entity>
                                  </entity>
                                </fetch>";


            var fetch = new FetchExpression(fetchXml);

            var fetchresult = service.RetrieveMultiple(fetch);


            return fetchresult.Entities.FirstOrDefault();
        }

    }

    
}
