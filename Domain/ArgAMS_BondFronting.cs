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
    
    public partial class ArgAMS_BondFronting
    {
        public int BondFrontingID { get; set; }
        public Nullable<int> FrontingCompanyID { get; set; }
        public Nullable<int> BondID { get; set; }
        public Nullable<int> PrincipalID { get; set; }
        public Nullable<decimal> FeeAmount { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string FrontingNote { get; set; }
        public string CurrencyCode { get; set; }
        public Nullable<decimal> CurrencyRate { get; set; }
        public Nullable<System.DateTime> CurrencyDate { get; set; }
        public Nullable<decimal> ForeignBondAmount { get; set; }
        public Nullable<decimal> ForeignPremium { get; set; }
        public string ForeignBondNumber { get; set; }
        public Nullable<decimal> ForeignCommision { get; set; }
        public Nullable<int> AgentID { get; set; }
        public Nullable<bool> RateOverride { get; set; }
        public Nullable<decimal> ForeignCommission { get; set; }
        public Nullable<decimal> ForeignBrokerCommission { get; set; }
    
        public virtual ArgAMS_BondDetail ArgAMS_BondDetail { get; set; }
    }
}
