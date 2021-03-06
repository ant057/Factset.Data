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
    
    public partial class ArgAMS_BondClassCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArgAMS_BondClassCode()
        {
            this.ArgAMS_BondDetail = new HashSet<ArgAMS_BondDetail>();
            this.ArgAMS_ContractRateClassCode = new HashSet<ArgAMS_ContractRateClassCode>();
        }
    
        public Nullable<int> ClassCode { get; set; }
        public string BondType { get; set; }
        public string BondCATEGORY { get; set; }
        public Nullable<short> RISKFACTOR { get; set; }
        public string BONDDESCRIPTION { get; set; }
        public string EXPOSURETYPE { get; set; }
        public int BondClassCodeID { get; set; }
    
        public virtual ArgAMS_ClassCodeType ArgAMS_ClassCodeType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_BondDetail> ArgAMS_BondDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_ContractRateClassCode> ArgAMS_ContractRateClassCode { get; set; }
    }
}
