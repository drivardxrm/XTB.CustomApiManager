// *********************************************************************
// Created by : Latebound Constants Generator 1.2020.2.1 for XrmToolBox
// Author     : Jonas Rapp https://twitter.com/rappen
// GitHub     : https://github.com/rappen/LCG-UDG
// Source Org : https://drivard-dev.crm.dynamics.com/
// Filename   : C:\Temp\LateBound\Plug_inType.cs
// Created    : 2020-11-22 22:48:37
// *********************************************************************
namespace XTB.CustomApiManager.Entities
{
    /// <summary>DisplayName: Plug-in Type, OwnershipType: OrganizationOwned, IntroducedVersion: 5.0.0.0</summary>
    public static class Plug_inType
    {
        public const string EntityName = "plugintype";
        public const string EntityCollectionName = "plugintypes";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "plugintypeid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 256, Format: Text</summary>
        public const string PrimaryName = "name";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Component State, OptionSetType: Picklist, DefaultFormValue: -1</summary>
        public const string ComponentState = "componentstate";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string CreatedBy = "createdby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string CreatedOn = "createdon";
        /// <summary>Type: Memo, RequiredLevel: None, MaxLength: 1048576</summary>
        public const string CustomWorkflowActivityInfo = "customworkflowactivityinfo";
        /// <summary>Type: Integer, RequiredLevel: SystemRequired, MinValue: -255, MaxValue: 255</summary>
        public const string customizationlevel = "customizationlevel";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 256, Format: Text</summary>
        public const string Description = "description";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 256, Format: Text</summary>
        public const string DisplayName = "friendlyname";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string IsWorkflowActivity = "isworkflowactivity";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string ismanaged = "ismanaged";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string ModifiedBy = "modifiedby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string ModifiedOn = "modifiedon";
        /// <summary>Type: Lookup, RequiredLevel: SystemRequired, Targets: organization</summary>
        public const string organizationid = "organizationid";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: pluginassembly</summary>
        public const string PluginAssembly = "pluginassemblyid";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string plugintypeidunique = "plugintypeidunique";
        /// <summary>Type: DateTime, RequiredLevel: SystemRequired, Format: DateOnly, DateTimeBehavior: UserLocal</summary>
        public const string RecordOverwriteTime = "overwritetime";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string Solution = "solutionid";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string Solution1 = "supportingsolutionid";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 256, Format: Text</summary>
        public const string TypeName = "typename";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 256, Format: Text</summary>
        public const string WorkflowActivityGroupName = "workflowactivitygroupname";

        #endregion Attributes

        #region Relationships

        /// <summary>Parent: "Plug_inType" Child: "CustomAPI" Lookup: "PluginType"</summary>
        public const string Rel1M_CustomAPIPluginType = "plugintype_customapi";

        #endregion Relationships

        #region OptionSets

        public enum ComponentState_OptionSet
        {
            Published = 0,
            Unpublished = 1,
            Deleted = 2,
            DeletedUnpublished = 3
        }

        #endregion OptionSets
    }
}
