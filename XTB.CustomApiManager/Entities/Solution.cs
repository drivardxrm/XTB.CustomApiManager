// *********************************************************************
// Created by : Latebound Constants Generator 1.2020.2.1 for XrmToolBox
// Author     : Jonas Rapp https://twitter.com/rappen
// GitHub     : https://github.com/rappen/LCG-UDG
// Source Org : https://drivard-dev.crm.dynamics.com/
// Filename   : C:\Users\DavidRivard\Desktop\Solution.cs
// Created    : 2020-11-16 21:14:47
// *********************************************************************
namespace XTB.CustomApiManager.Entities
{
    /// <summary>OwnershipType: OrganizationOwned, IntroducedVersion: 5.0.0.0</summary>
    public static class Solution
    {
        public const string EntityName = "solution";
        public const string EntityCollectionName = "solutions";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "solutionid";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 256, Format: Text</summary>
        public const string PrimaryName = "friendlyname";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: webresource</summary>
        public const string ConfigurationPage = "configurationpageid";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string CreatedBy = "createdby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string CreatedOn = "createdon";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 2000, Format: TextArea</summary>
        public const string Description = "description";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateOnly, DateTimeBehavior: UserLocal</summary>
        public const string InstalledOn = "installedon";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string IsApiManagedSolution = "isapimanaged";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Isinternalsolution = "isinternal";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: True</summary>
        public const string IsVisibleOutsidePlatform = "isvisible";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string ModifiedBy = "modifiedby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string ModifiedOn = "modifiedon";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 65, Format: Text</summary>
        public const string Name = "uniquename";
        /// <summary>Type: Lookup, RequiredLevel: SystemRequired, Targets: organization</summary>
        public const string Organization = "organizationid";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string PackageType = "ismanaged";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: solution</summary>
        public const string ParentSolution = "parentsolutionid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 255, Format: Text</summary>
        public const string pinpointassetid = "pinpointassetid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 16, Format: Text</summary>
        public const string pinpointsolutiondefaultlocale = "pinpointsolutiondefaultlocale";
        /// <summary>Type: BigInt, RequiredLevel: None, MinValue: -9223372036854775808, MaxValue: 9223372036854775807</summary>
        public const string pinpointsolutionid = "pinpointsolutionid";
        /// <summary>Type: Lookup, RequiredLevel: SystemRequired, Targets: publisher</summary>
        public const string Publisher = "publisherid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 256, Format: VersionNumber</summary>
        public const string SolutionPackageVersion = "solutionpackageversion";
        /// <summary>Type: Picklist, RequiredLevel: None, DisplayName: Solution Type, OptionSetType: Picklist, DefaultFormValue: 0</summary>
        public const string SolutionType = "solutiontype";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 65, Format: Text</summary>
        public const string Suffix = "templatesuffix";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string UpdatedOn = "updatedon";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 256, Format: VersionNumber</summary>
        public const string Version = "version";

        #endregion Attributes

        #region Relationships

        /// <summary>Parent: "Publisher" Child: "Solution" Lookup: "Publisher"</summary>
        public const string RelM1_SolutionPublisher = "publisher_solution";

        #endregion Relationships

        #region OptionSets

        public enum SolutionType_OptionSet
        {
            None = 0,
            Snapshot = 1,
            Internal = 2
        }

        #endregion OptionSets
    }
}
