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
    
    public partial class ArgAMS_ContractIndemnityAgreementType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArgAMS_ContractIndemnityAgreementType()
        {
            this.ArgAMS_ContractIndemnitySubOrdination = new HashSet<ArgAMS_ContractIndemnitySubOrdination>();
        }
    
        public int AgreementTypeID { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_ContractIndemnitySubOrdination> ArgAMS_ContractIndemnitySubOrdination { get; set; }
    }
}