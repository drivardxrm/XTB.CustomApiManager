using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTB.CustomApiManager.Entities;


namespace XTB.CustomApiManager.Proxy
{
    public class CatalogAssignmentProxy
    {


        public Entity CatalogAssignmentRow;



        public CatalogAssignmentProxy(Entity catalogassignment)
        {
            CatalogAssignmentRow = catalogassignment;
        }



        public string Name => CatalogAssignmentRow.Attributes.Contains(CatalogAssignment.PrimaryName) ?
                                                    CatalogAssignmentRow[CatalogAssignment.PrimaryName].ToString() :
                                                    string.Empty;
        public EntityReference Object => CatalogAssignmentRow.Attributes.Contains(CatalogAssignment.CatalogAssignmentObject) ?
                                                    CatalogAssignmentRow[CatalogAssignment.CatalogAssignmentObject] as EntityReference :
                                                    null;

        public string ObjectType => Object?.LogicalName;



        public string ObjectIdType => CatalogAssignmentRow.Attributes.Contains(CatalogAssignment.objectidtype) ?
                                                    CatalogAssignmentRow[CatalogAssignment.objectidtype].ToString() :
                                                    string.Empty;

        

        public bool IsCustomizable => CatalogAssignmentRow.Attributes.Contains(CatalogAssignment.IsCustomizable) &&
                                   ((BooleanManagedProperty)CatalogAssignmentRow[CatalogAssignment.IsCustomizable]).Value;


        public bool IsManaged => CatalogAssignmentRow.Attributes.Contains(CatalogAssignment.IsManaged) &&
                                    (bool)CatalogAssignmentRow[CatalogAssignment.IsManaged];

        


        public bool CanCustomize => !IsManaged || IsManaged && IsCustomizable;

        public EntityReference CatalogRef => CatalogAssignmentRow.Attributes.Contains(CatalogAssignment.catalog) ?
                                                    (EntityReference)CatalogAssignmentRow[CatalogAssignment.catalog] :
                                                    null;

        public string CatalogName => CatalogAssignmentRow.Attributes.Contains($"parentcatalog.{Catalog.PrimaryName}") ?
                                        (string)((AliasedValue)CatalogAssignmentRow[$"parentcatalog.{Catalog.PrimaryName}"]).Value :
                                        string.Empty;

        public string CategoryName => CatalogAssignmentRow.Attributes.Contains($"catalog.{Catalog.PrimaryName}") ?
                                        (string)((AliasedValue)CatalogAssignmentRow[$"catalog.{Catalog.PrimaryName}"]).Value :
                                        string.Empty;


    }
}
