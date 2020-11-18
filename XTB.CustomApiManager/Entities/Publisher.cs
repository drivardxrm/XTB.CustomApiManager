// *********************************************************************
// Created by : Latebound Constants Generator 1.2020.2.1 for XrmToolBox
// Author     : Jonas Rapp https://twitter.com/rappen
// GitHub     : https://github.com/rappen/LCG-UDG
// Source Org : https://drivard-dev.crm.dynamics.com/
// Filename   : C:\Users\DavidRivard\Desktop\Publisher.cs
// Created    : 2020-11-16 21:14:47
// *********************************************************************
namespace XTB.CustomApiManager.Entities
{
    /// <summary>OwnershipType: OrganizationOwned, IntroducedVersion: 5.0.0.0</summary>
    public static class Publisher
    {
        public const string EntityName = "publisher";
        public const string EntityCollectionName = "publishers";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "publisherid";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 256, Format: Text</summary>
        public const string PrimaryName = "friendlyname";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string CreatedBy = "createdby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string CreatedOn = "createdon";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 2000, Format: TextArea</summary>
        public const string Description = "description";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Email</summary>
        public const string Email = "emailaddress";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string EntityImageId = "entityimageid";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string IsRead_OnlyPublisher = "isreadonly";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string ModifiedBy = "modifiedby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string ModifiedOn = "modifiedon";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 256, Format: Text</summary>
        public const string Name = "uniquename";
        /// <summary>Type: Integer, RequiredLevel: SystemRequired, MinValue: 10000, MaxValue: 99999</summary>
        public const string OptionValuePrefix = "customizationoptionvalueprefix";
        /// <summary>Type: Lookup, RequiredLevel: SystemRequired, Targets: organization</summary>
        public const string Organization = "organizationid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 16, Format: Text</summary>
        public const string pinpointpublisherdefaultlocale = "pinpointpublisherdefaultlocale";
        /// <summary>Type: BigInt, RequiredLevel: None, MinValue: -9223372036854775808, MaxValue: 9223372036854775807</summary>
        public const string pinpointpublisherid = "pinpointpublisherid";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 8, Format: Text</summary>
        public const string Prefix = "customizationprefix";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 200, Format: Url</summary>
        public const string Website = "supportingwebsiteurl";

        #endregion Attributes

        #region Relationships

        /// <summary>Parent: "Publisher" Child: "Solution" Lookup: "Publisher"</summary>
        public const string Rel1M_SolutionPublisher = "publisher_solution";

        #endregion Relationships
    }
}
