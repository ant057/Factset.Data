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
    
    public partial class ArgAMS_Endorsement
    {
        public int EndorsementID { get; set; }
        public Nullable<int> BondID { get; set; }
        public Nullable<int> EndorsementTypeID { get; set; }
        public string EndorsementNumber { get; set; }
        public Nullable<System.DateTime> DateEntered { get; set; }
        public string EnteredBy { get; set; }
        public string EndorsementDesc { get; set; }
        public Nullable<decimal> PriorEarnedPremium { get; set; }
        public Nullable<decimal> PriorUnearnedPremium { get; set; }
        public Nullable<decimal> EndorsementPremium { get; set; }
        public string RenewalNumber { get; set; }
        public Nullable<System.DateTime> EndorsementEffectiveDate { get; set; }
        public Nullable<decimal> EndorsementAmount { get; set; }
    
        public virtual ArgAMS_BondDetail ArgAMS_BondDetail { get; set; }
        public virtual ArgAms_EndorsementType ArgAms_EndorsementType { get; set; }
    }
}
