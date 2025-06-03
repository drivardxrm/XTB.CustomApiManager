// *********************************************************************
// Created by : Latebound Constants Generator 1.2024.11.4 for XrmToolBox
// Tool Author: Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://drivdev.crm3.dynamics.com/
// Filename   : C:\Users\david\Downloads\latebooundCustomApiManager\CustomAPI.cs
// Created    : 2025-05-04 17:00:34
// *********************************************************************
namespace XTB.CustomApiManager.Entities
{
    /// <summary>DisplayName: Custom API, OwnershipType: UserOwned, IntroducedVersion: 1.0.0.0</summary>
    /// <remarks>Entity that defines a custom API</remarks>
    public static class CustomAPI
    {
        public const string EntityName = "customapi";
        public const string EntityCollectionName = "customapis";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        /// <remarks>Unique identifier for custom API instances</remarks>
        public const string PrimaryKey = "customapiid";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        /// <remarks>The primary name of the custom API</remarks>
        public const string PrimaryName = "name";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Allowed Custom Processing Step Type, OptionSetType: Picklist, DefaultFormValue: 0</summary>
        /// <remarks>The type of custom processing step allowed</remarks>
        public const string AllowedCustomProcessingStepType = "allowedcustomprocessingsteptype";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Binding Type, OptionSetType: Picklist, DefaultFormValue: 0</summary>
        /// <remarks>The binding type of the custom API</remarks>
        public const string BindingType = "bindingtype";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        /// <remarks>The logical name of the entity bound to the custom API</remarks>
        public const string BoundEntityLogicalName = "boundentitylogicalname";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Component State, OptionSetType: Picklist</summary>
        /// <remarks>For internal use only.</remarks>
        public const string ComponentState = "componentstate";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 300, Format: Text</summary>
        /// <remarks>Localized description for custom API instances</remarks>
        public const string Description = "description";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        /// <remarks>Localized display name for custom API instances</remarks>
        public const string DisplayName = "displayname";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        /// <remarks>Indicates if the custom API is enabled as a workflow action</remarks>
        public const string EnabledforWorkflow = "workflowsdkstepenabled";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        /// <remarks>Name of the privilege that allows execution of the custom API</remarks>
        public const string ExecutePrivilegeName = "executeprivilegename";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: fxexpression</summary>
        /// <remarks>Unique identifier for fxexpression associated with Custom API.</remarks>
        public const string FxExpression = "fxexpressionid";
        /// <summary>Type: ManagedProperty, RequiredLevel: SystemRequired</summary>
        /// <remarks>For internal use only.</remarks>
        public const string IsCustomizable = "iscustomizable";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        /// <remarks>Indicates if the custom API is a function (GET is supported) or not (POST is supported)</remarks>
        public const string IsFunction = "isfunction";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        /// <remarks>Indicates whether the solution component is part of a managed solution.</remarks>
        public const string IsManaged = "ismanaged";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        /// <remarks>Indicates if the custom API is private (hidden from metadata and documentation)</remarks>
        public const string IsPrivate = "isprivate";
        /// <summary>Type: Owner, RequiredLevel: SystemRequired, Targets: systemuser,team</summary>
        /// <remarks>Owner Id</remarks>
        public const string Owner = "ownerid";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: plugintype</summary>
        public const string PluginType = "plugintypeid";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: powerfxrule</summary>
        /// <remarks>Unique identifier for powerfxrule associated with Custom API.</remarks>
        public const string PowerFxRule = "powerfxruleid";
        /// <summary>Type: DateTime, RequiredLevel: SystemRequired, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        /// <remarks>For internal use only.</remarks>
        public const string RecordOverwriteTime = "overwritetime";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        /// <remarks>For internal use only.</remarks>
        public const string Rowidunique = "componentidunique";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: sdkmessage</summary>
        public const string SdkMessage = "sdkmessageid";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        /// <remarks>Unique identifier of the associated solution.</remarks>
        public const string Solution = "solutionid";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        /// <remarks>For internal use only.</remarks>
        public const string Solution1 = "supportingsolutionid";
        /// <summary>Type: State, RequiredLevel: SystemRequired, DisplayName: Status, OptionSetType: State</summary>
        /// <remarks>Status of the Custom API</remarks>
        public const string Status = "statecode";
        /// <summary>Type: Status, RequiredLevel: None, DisplayName: Status Reason, OptionSetType: Status</summary>
        /// <remarks>Reason for the status of the Custom API</remarks>
        public const string StatusReason = "statuscode";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 128, Format: Text</summary>
        /// <remarks>Unique name for the custom API</remarks>
        public const string UniqueName = "uniquename";

        #endregion Attributes

        #region Relationships

        /// <summary>Parent: "Plug_inType" Child: "CustomAPI" Lookup: "PluginType"</summary>
        public const string RelM1_CustomAPIPluginType = "plugintype_customapi";
        /// <summary>Parent: "FxExpression" Child: "CustomAPI" Lookup: "FxExpression"</summary>
        public const string RelM1_CustomAPIFxExpression = "fxexpression_customapi";

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
