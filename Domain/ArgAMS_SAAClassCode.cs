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
    
    public partial class ArgAMS_SAAClassCode
    {
        public int ClassCodeID { get; set; }
        public int SAAClassCode { get; set; }
        public string BondType { get; set; }
        public string BondCategory { get; set; }
        public string BondDescription { get; set; }
        public Nullable<short> Riskfactor { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public Nullable<int> SortIndex { get; set; }
    }
}