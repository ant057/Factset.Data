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
    
    public partial class ArgAMS_SelfAuditQuestion
    {
        public int QuestionID { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public Nullable<int> AddedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> AuditTypeID { get; set; }
        public string Description { get; set; }
        public Nullable<int> ParentQuestionID { get; set; }
        public Nullable<decimal> SortOrder { get; set; }
        public string ChildTriggerAnswer { get; set; }
        public Nullable<bool> EnabledDefault { get; set; }
    }
}