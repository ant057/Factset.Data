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
    
    public partial class ArgAMS_ContractRateType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArgAMS_ContractRateType()
        {
            this.ArgAMS_ContractRatePlan = new HashSet<ArgAMS_ContractRatePlan>();
        }
    
        public int ContractRateTypeID { get; set; }
        public string ContractRateType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_ContractRatePlan> ArgAMS_ContractRatePlan { get; set; }
    }
}
