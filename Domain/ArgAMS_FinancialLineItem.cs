//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Factset.Data.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class ArgAMS_FinancialLineItem
    {
        public int LineItemId { get; set; }
        public string Description { get; set; }
        public string grpIndicator { get; set; }
        public Nullable<int> sectionid { get; set; }
        public Nullable<int> AccountFlag { get; set; }
        public Nullable<int> FinancialBussinessTypeID { get; set; }
        public Nullable<int> SortOrder { get; set; }
    
        public virtual ArgAMS_FinancialSectionType ArgAMS_FinancialSectionType { get; set; }
    }
}
