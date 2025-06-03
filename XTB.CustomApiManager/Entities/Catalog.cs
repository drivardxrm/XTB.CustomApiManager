// *********************************************************************
// Created by : Latebound Constants Generator 1.2021.1.2 for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://drivard-dev.crm.dynamics.com/
// Filename   : C:\GithubRepos\Driv.XTB.CatalogManager\Driv.XTB.CatalogManager\Driv.XTB.CatalogManager\Entities\Catalog.cs
// Created    : 2021-06-11 00:10:32
// *********************************************************************

namespace XTB.CustomApiManager.Entities
{
    /// <summary>OwnershipType: OrganizationOwned, IntroducedVersion: 1.0.0.0</summary>
    public static class Catalog
    {
        public const string EntityName = "catalog";
        public const string EntityCollectionName = "catalogs";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "catalogid";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        public const string PrimaryName = "name";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Component State, OptionSetType: Picklist</summary>
        public const string ComponentState = "componentstate";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string CreatedBy = "createdby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string CreatedOn = "createdon";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        public const string Description = "description";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        public const string DisplayName = "displayname";
        /// <summary>Type: ManagedProperty, RequiredLevel: SystemRequired</summary>
        public const string IsCustomizable = "iscustomizable";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string IsManaged = "ismanaged";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string ModifiedBy = "modifiedby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string ModifiedOn = "modifiedon";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: organization</summary>
        public const string OrganizationId = "organizationid";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: catalog</summary>
        public const string ParentCatalog = "parentcatalogid";
        /// <summary>Type: DateTime, RequiredLevel: SystemRequired, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string RecordOverwriteTime = "overwritetime";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string Rowidunique = "componentidunique";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string Solution = "solutionid";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string Solution1 = "supportingsolutionid";
        /// <summary>Type: State, RequiredLevel: SystemRequired, DisplayName: Status, OptionSetType: State</summary>
        public const string Status = "statecode";
        /// <summary>Type: Status, RequiredLevel: None, DisplayName: Status Reason, OptionSetType: Status</summary>
        public const string StatusReason = "statuscode";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 128, Format: Text</summary>
        public const string UniqueName = "uniquename";

        #endregion Attributes

        #region Relationships

        /// <summary>Parent: "Catalog" Child: "Catalog" Lookup: "ParentCatalog"</summary>
        public const string Rel1M_CatalogParentCatalog = "parentcatalog_catalog";
        /// <summary>Parent: "Catalog" Child: "CatalogAssignment" Lookup: "catalog"</summary>
        public const string Rel1M_CatalogAssignmentcatalog = "catalog_catalogassignment";

        #endregion Relationships

        #region OptionSets

        public enum ComponentState_OptionSet
        {
            Published = 0,
            Unpublished = 1,
            Deleted = 2,
            DeletedUnpublished = 3
        }
        public enum Status_OptionSet
        {
            Active = 0,
            Inactive = 1
        }
        public enum StatusReason_OptionSet
        {
            Active = 1,
            Inactive = 2
        }

        #endregion OptionSets
    }
}
