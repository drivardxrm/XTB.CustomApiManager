// *********************************************************************
// Created by : Latebound Constants Generator 1.2021.1.2 for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://drivard-dev.crm.dynamics.com/
// Filename   : C:\GithubRepos\Driv.XTB.CatalogManager\Driv.XTB.CatalogManager\Driv.XTB.CatalogManager\Entities\CatalogAssignment.cs
// Created    : 2021-06-11 00:10:32
// *********************************************************************

namespace XTB.CustomApiManager.Entities
{
    /// <summary>DisplayName: Catalog Assignment, OwnershipType: OrganizationOwned, IntroducedVersion: 1.0.0.0</summary>
    public static class CatalogAssignment
    {
        public const string EntityName = "catalogassignment";
        public const string EntityCollectionName = "catalogassignments";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "catalogassignmentid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string PrimaryName = "name";
        /// <summary>Type: Lookup, RequiredLevel: SystemRequired, Targets: catalog</summary>
        public const string catalog = "catalogid";
        /// <summary>Type: Lookup, RequiredLevel: SystemRequired, Targets: customapi,entity,workflow</summary>
        public const string CatalogAssignmentObject = "object";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Component State, OptionSetType: Picklist</summary>
        public const string ComponentState = "componentstate";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string CreatedBy = "createdby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string CreatedOn = "createdon";
        /// <summary>Type: ManagedProperty, RequiredLevel: SystemRequired</summary>
        public const string IsCustomizable = "iscustomizable";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string IsManaged = "ismanaged";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string ModifiedBy = "modifiedby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string ModifiedOn = "modifiedon";
        /// <summary>Type: EntityName, RequiredLevel: None</summary>
        public const string objectidtype = "objectidtype";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 1000, Format: Text</summary>
        public const string objectname = "objectname";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 1000, Format: Text</summary>
        public const string objectyominame = "objectyominame";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: organization</summary>
        public const string OrganizationId = "organizationid";
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

        #endregion Attributes

        #region OptionSets

        public enum ComponentState_OptionSet
        {
            Published = 0,
            Unpublished = 1,
            Deleted = 2,
            DeletedUnpublished = 3
        }
        public enum objectidtype_OptionSet
        {
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
