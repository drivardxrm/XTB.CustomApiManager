using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;

namespace XTB.CustomApiManager.Helpers
{
    public static class MetadataHelper
    {
        /// <summary>
        /// Retrieves the entity collection name (EntitySetName) for a given entity logical name
        /// </summary>
        /// <param name="service">The organization service</param>
        /// <param name="entityLogicalName">The logical name of the entity</param>
        /// <returns>The entity collection name (EntitySetName) or null if not found</returns>
        public static string GetEntityCollectionName(this IOrganizationService service, string entityLogicalName)
        {
            if (string.IsNullOrEmpty(entityLogicalName))
                return null;

            try
            {
                var request = new RetrieveEntityRequest
                {
                    LogicalName = entityLogicalName,
                    EntityFilters = EntityFilters.Entity // Only retrieve basic entity metadata
                };

                var response = (RetrieveEntityResponse)service.Execute(request);
                return response.EntityMetadata.EntitySetName;
            }
            catch (Exception)
            {
                // Entity not found or access denied
                return null;
            }
        }

        /// <summary>
        /// Retrieves detailed entity metadata including collection name and display names
        /// </summary>
        /// <param name="service">The organization service</param>
        /// <param name="entityLogicalName">The logical name of the entity</param>
        /// <returns>Entity metadata information or null if not found</returns>
        public static EntityMetadataInfo GetEntityMetadataInfo(this IOrganizationService service, string entityLogicalName)
        {
            if (string.IsNullOrEmpty(entityLogicalName))
                return null;

            try
            {
                var request = new RetrieveEntityRequest
                {
                    LogicalName = entityLogicalName,
                    EntityFilters = EntityFilters.Entity
                };

                var response = (RetrieveEntityResponse)service.Execute(request);
                var metadata = response.EntityMetadata;

                return new EntityMetadataInfo
                {
                    LogicalName = metadata.LogicalName,
                    EntitySetName = metadata.EntitySetName,
                    DisplayName = metadata.DisplayName?.UserLocalizedLabel?.Label,
                    DisplayCollectionName = metadata.DisplayCollectionName?.UserLocalizedLabel?.Label,
                    SchemaName = metadata.SchemaName,
                    ObjectTypeCode = metadata.ObjectTypeCode
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    /// <summary>
    /// Container for entity metadata information
    /// </summary>
    public class EntityMetadataInfo
    {
        public string LogicalName { get; set; }
        public string EntitySetName { get; set; }
        public string DisplayName { get; set; }
        public string DisplayCollectionName { get; set; }
        public string SchemaName { get; set; }
        public int? ObjectTypeCode { get; set; }
    }
}