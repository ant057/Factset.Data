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
    
    public partial class ArgAMS_ContractIndemnitors
    {
        public int IndemnitorID { get; set; }
        public string Name { get; set; }
        public Nullable<int> YearofBirth { get; set; }
        public Nullable<int> ownership { get; set; }
        public string Title { get; set; }
        public int IndemnityTypeID { get; set; }
        public Nullable<System.DateTime> LatestFS { get; set; }
        public Nullable<decimal> NetWorth { get; set; }
        public Nullable<decimal> WkgCap { get; set; }
        public int IndemnityID { get; set; }
        public Nullable<int> ModificationTypeID { get; set; }
    
        public virtual ArgAMS_ContractIndemnity ArgAMS_ContractIndemnity { get; set; }
    }
}