// *********************************************************************
// Created by : Latebound Constants Generator 1.2024.11.4 for XrmToolBox
// Tool Author: Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://drivdev.crm3.dynamics.com/
// Filename   : C:\Users\david\Downloads\latebooundCustomApiManager\FxExpression.cs
// Created    : 2025-05-04 17:00:34
// *********************************************************************
namespace XTB.CustomApiManager.Entities
{
    /// <summary>OwnershipType: UserOwned, IntroducedVersion: 1.0</summary>
    public static class FxExpression
    {
        public const string EntityName = "fxexpression";
        public const string EntityCollectionName = "fxexpressions";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        /// <remarks>Unique identifier for entity instances</remarks>
        public const string PrimaryKey = "fxexpressionid";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 100, Format: Text</summary>
        /// <remarks>The name of the custom entity.</remarks>
        public const string PrimaryName = "name";
        /// <summary>Type: Picklist, RequiredLevel: None, DisplayName: Category, OptionSetType: Picklist, DefaultFormValue: -1</summary>
        public const string Category = "category";
        /// <summary>Type: Memo, RequiredLevel: None, MaxLength: 200000</summary>
        public const string CompiledExpression = "compiledexpression";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Component State, OptionSetType: Picklist</summary>
        /// <remarks>For internal use only.</remarks>
        public const string ComponentState = "componentstate";
        /// <summary>Type: Memo, RequiredLevel: None, MaxLength: 200000</summary>
        public const string Context = "context";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        /// <remarks>The name of the primary entity on which expression is defined.</remarks>
        public const string EntityLogicalName = "entitylogicalname";
        /// <summary>Type: Memo, RequiredLevel: None, MaxLength: 200000</summary>
        public const string Expression = "expression";
        /// <summary>Type: Memo, RequiredLevel: None, MaxLength: 200000</summary>
        public const string Inputandoutputparametersassociatedwiththeexpression = "parameters";
        /// <summary>Type: ManagedProperty, RequiredLevel: SystemRequired</summary>
        /// <remarks>For internal use only.</remarks>
        public const string IsCustomizable = "iscustomizable";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        /// <remarks>Indicates whether the solution component is part of a managed solution.</remarks>
        public const string IsManaged = "ismanaged";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        /// <remarks>The sdkMessage on which will trigger expression execution.</remarks>
        public const string MessageName = "messagename";
        /// <summary>Type: Owner, RequiredLevel: SystemRequired, Targets: systemuser,team</summary>
        /// <remarks>Owner Id</remarks>
        public const string Owner = "ownerid";
        /// <summary>Type: Memo, RequiredLevel: None, MaxLength: 20000</summary>
        /// <remarks>The dependencies for powerfx expressions</remarks>
        public const string PowerFxExpressiondependencies = "dependencies";
        /// <summary>Type: DateTime, RequiredLevel: SystemRequired, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        /// <remarks>For internal use only.</remarks>
        public const string RecordOverwriteTime = "overwritetime";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        /// <remarks>For internal use only.</remarks>
        public const string Rowidunique = "componentidunique";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        /// <remarks>Unique identifier of the associated solution.</remarks>
        public const string Solution = "solutionid";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        /// <remarks>For internal use only.</remarks>
        public const string Solution1 = "supportingsolutionid";
        /// <summary>Type: State, RequiredLevel: SystemRequired, DisplayName: Status, OptionSetType: State</summary>
        /// <remarks>Status of the FxExpression</remarks>
        public const string Status = "statecode";
        /// <summary>Type: Status, RequiredLevel: None, DisplayName: Status Reason, OptionSetType: Status</summary>
        /// <remarks>Reason for the status of the FxExpression</remarks>
        public const string StatusReason = "statuscode";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 128, Format: Text</summary>
        /// <remarks>Unique Name for the entity.</remarks>
        public const string UniqueName = "uniquename";

        #endregion Attributes

        #region OptionSets

        public enum Category_OptionSet
        {
            Workflow = 0,
            BusinessRule = 1
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
