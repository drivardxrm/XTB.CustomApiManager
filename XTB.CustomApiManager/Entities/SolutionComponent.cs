// *********************************************************************
// Created by : Latebound Constants Generator 1.2020.2.1 for XrmToolBox
// Author     : Jonas Rapp https://twitter.com/rappen
// GitHub     : https://github.com/rappen/LCG-UDG
// Source Org : https://drivard-dev.crm.dynamics.com/
// Filename   : C:\Temp\LateBound\SolutionComponent.cs
// Created    : 2020-11-17 22:22:14
// *********************************************************************
namespace XTB.CustomApiManager.Entities
{
    /// <summary>DisplayName: Solution Component, OwnershipType: None, IntroducedVersion: 5.0.0.0</summary>
    public static class SolutionComponent
    {
        public const string EntityName = "solutioncomponent";
        public const string EntityCollectionName = "solutioncomponentss";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "solutioncomponentid";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string CreatedBy = "createdby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string CreatedOn = "createdon";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: True</summary>
        public const string Isthiscomponentmetadata = "ismetadata";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string ModifiedBy = "modifiedby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string ModifiedOn = "modifiedon";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Component Type, OptionSetType: Picklist</summary>
        public const string ObjectTypeCode = "componenttype";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string Regarding = "objectid";
        /// <summary>Type: Picklist, RequiredLevel: None, DisplayName: Include Behavior, OptionSetType: Picklist, DefaultFormValue: -1</summary>
        public const string RootComponentBehavior = "rootcomponentbehavior";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string RootSolutionComponentID = "rootsolutioncomponentid";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: solution</summary>
        public const string Solution = "solutionid";

        #endregion Attributes

        #region Relationships

        /// <summary>Parent: "Solution" Child: "SolutionComponent" Lookup: "Solution"</summary>
        public const string RelM1_SolutionComponentSolution = "solution_solutioncomponent";
        /// <summary>Parent: "SolutionComponent" Child: "SolutionComponent" Lookup: "RootSolutionComponentID"</summary>
        public const string Rel1M_SolutionComponentRootSolutionComponentID = "solutioncomponent_parent_solutioncomponent";

        #endregion Relationships

        #region OptionSets

        //public enum ObjectTypeCode_OptionSet
        //{
        //    Entity = 1,
        //    Attribute = 2,
        //    Relationship = 3,
        //    AttributePicklistValue = 4,
        //    AttributeLookupValue = 5,
        //    ViewAttribute = 6,
        //    LocalizedLabel = 7,
        //    RelationshipExtraCondition = 8,
        //    OptionSet = 9,
        //    EntityRelationship = 10,
        //    EntityRelationshipRole = 11,
        //    EntityRelationshipRelationships = 12,
        //    ManagedProperty = 13,
        //    EntityKey = 14,
        //    Privilege = 16,
        //    PrivilegeObjectTypeCode = 17,
        //    Role = 20,
        //    RolePrivilege = 21,
        //    DisplayString = 22,
        //    DisplayStringMap = 23,
        //    Form = 24,
        //    Organization = 25,
        //    SavedQuery = 26,
        //    Workflow = 29,
        //    Report = 31,
        //    ReportEntity = 32,
        //    ReportCategory = 33,
        //    ReportVisibility = 34,
        //    Attachment = 35,
        //    EmailTemplate = 36,
        //    ContractTemplate = 37,
        //    KBArticleTemplate = 38,
        //    MailMergeTemplate = 39,
        //    DuplicateRule = 44,
        //    DuplicateRuleCondition = 45,
        //    EntityMap = 46,
        //    AttributeMap = 47,
        //    RibbonCommand = 48,
        //    RibbonContextGroup = 49,
        //    RibbonCustomization = 50,
        //    RibbonRule = 52,
        //    RibbonTabToCommandMap = 53,
        //    RibbonDiff = 55,
        //    SavedQueryVisualization = 59,
        //    SystemForm = 60,
        //    WebResource = 61,
        //    SiteMap = 62,
        //    ConnectionRole = 63,
        //    ComplexControl = 64,
        //    FieldSecurityProfile = 70,
        //    FieldPermission = 71,
        //    PluginType = 90,
        //    PluginAssembly = 91,
        //    SDKMessageProcessingStep = 92,
        //    SDKMessageProcessingStepImage = 93,
        //    ServiceEndpoint = 95,
        //    RoutingRule = 150,
        //    RoutingRuleItem = 151,
        //    SLA = 152,
        //    SLAItem = 153,
        //    ConvertRule = 154,
        //    ConvertRuleItem = 155,
        //    HierarchyRule = 65,
        //    MobileOfflineProfile = 161,
        //    MobileOfflineProfileItem = 162,
        //    SimilarityRule = 165,
        //    CustomControl = 66,
        //    CustomControlDefaultConfig = 68,
        //    DataSourceMapping = 166,
        //    SDKMessage = 201,
        //    SDKMessageFilter = 202,
        //    SdkMessagePair = 203,
        //    SdkMessageRequest = 204,
        //    SdkMessageRequestField = 205,
        //    SdkMessageResponse = 206,
        //    SdkMessageResponseField = 207,
        //    WebWizard = 210,
        //    Index = 18,
        //    ImportMap = 208,
        //    CanvasApp = 300,
        //    Connector = 371,
        //    Connector = 372,
        //    EnvironmentVariableDefinition = 380,
        //    EnvironmentVariableValue = 381,
        //    AIProjectType = 400,
        //    AIProject = 401,
        //    AIConfiguration = 402,
        //    EntityAnalyticsConfiguration = 430,
        //    AttributeImageConfiguration = 431,
        //    EntityImageConfiguration = 432
        //}
        public enum RootComponentBehavior_OptionSet
        {
            IncludeSubcomponents = 0,
            Donotincludesubcomponents = 1,
            IncludeAsShellOnly = 2
        }

        #endregion OptionSets
    }
}
