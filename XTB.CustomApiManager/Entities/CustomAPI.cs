// *********************************************************************
// Created by : Latebound Constants Generator 1.2020.2.1 for XrmToolBox
// Author     : Jonas Rapp https://twitter.com/rappen
// GitHub     : https://github.com/rappen/LCG-UDG
// Source Org : https://drivard-dev.crm.dynamics.com/
// Filename   : C:\Users\DavidRivard\Desktop\CustomAPI.cs
// Created    : 2020-11-16 21:14:47
// *********************************************************************
namespace XTB.CustomApiManager.Entities
{
    /// <summary>DisplayName: Custom API, OwnershipType: UserOwned, IntroducedVersion: 1.0.0.0</summary>
    public static class CustomAPI
    {
        public const string EntityName = "customapi";
        public const string EntityCollectionName = "customapis";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "customapiid";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        public const string PrimaryName = "name";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Allowed Custom Processing Step Type, OptionSetType: Picklist, DefaultFormValue: 0</summary>
        public const string AllowedCustomProcessingStepType = "allowedcustomprocessingsteptype";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Binding Type, OptionSetType: Picklist, DefaultFormValue: 0</summary>
        public const string BindingType = "bindingtype";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string BoundEntityLogicalName = "boundentitylogicalname";
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
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string ExecutePrivilegeName = "executeprivilegename";
        /// <summary>Type: ManagedProperty, RequiredLevel: SystemRequired</summary>
        public const string IsCustomizable = "iscustomizable";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string IsFunction = "isfunction";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string IsManaged = "ismanaged";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string IsPrivate = "isprivate";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string ModifiedBy = "modifiedby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string ModifiedOn = "modifiedon";
        /// <summary>Type: Owner, RequiredLevel: SystemRequired, Targets: systemuser,team</summary>
        public const string Owner = "ownerid";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: plugintype</summary>
        public const string PluginType = "plugintypeid";
        /// <summary>Type: DateTime, RequiredLevel: SystemRequired, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string RecordOverwriteTime = "overwritetime";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string Rowidunique = "componentidunique";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: sdkmessage</summary>
        public const string SdkMessage = "sdkmessageid";
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

        /// <summary>Parent: "CustomAPI" Child: "CustomAPIRequestParameter" Lookup: "CustomAPI"</summary>
        public const string Rel1M_CustomAPIRequestParameterCustomAPI = "customapi_customapirequestparameter";
        /// <summary>Parent: "CustomAPI" Child: "CustomAPIResponseProperty" Lookup: "CustomAPI"</summary>
        public const string Rel1M_CustomAPIResponsePropertyCustomAPI = "customapi_customapiresponseproperty";

        #endregion Relationships

        #region OptionSets

        public enum AllowedCustomProcessingStepType_OptionSet
        {
            None = 0,
            AsyncOnly = 1,
            SyncandAsync = 2
        }
        public enum BindingType_OptionSet
        {
            Global = 0,
            Entity = 1,
            EntityCollection = 2
        }
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
