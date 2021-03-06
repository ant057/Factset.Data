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
    
    public partial class ArgAMS_Agency
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArgAMS_Agency()
        {
            this.ArgAgency_AgentDetail = new HashSet<ArgAgency_AgentDetail>();
            this.ArgAMS_Account = new HashSet<ArgAMS_Account>();
            this.ArgAgency_Notes = new HashSet<ArgAgency_Notes>();
            this.ArgAMS_BondDetail = new HashSet<ArgAMS_BondDetail>();
            this.ArgAMS_BondNumberAgency = new HashSet<ArgAMS_BondNumberAgency>();
            this.ArgAMS_POAAgency = new HashSet<ArgAMS_POAAgency>();
        }
    
        public int AgencyID { get; set; }
        public string AgencyName { get; set; }
        public string AgencyCode { get; set; }
        public string LegalName { get; set; }
        public string BillingName { get; set; }
        public Nullable<int> AgencyGroupID { get; set; }
        public string LicenseNumber { get; set; }
        public string FedTaxID { get; set; }
        public Nullable<short> StatusID { get; set; }
        public string AgencyEmail { get; set; }
        public string AgencyProducer { get; set; }
        public string AgencyCSR { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public Nullable<int> sortIndex { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> AddressID { get; set; }
        public string LicenseName { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<short> IsSureTec { get; set; }
        public Nullable<int> DemographyId { get; set; }
        public Nullable<int> ARegionId { get; set; }
        public Nullable<System.DateTime> AppointmentDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public Nullable<System.DateTime> TerminationDateSign { get; set; }
        public Nullable<System.DateTime> ProducerAgreementDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAgency_AgentDetail> ArgAgency_AgentDetail { get; set; }
        public virtual ArgAgency_Demography ArgAgency_Demography { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_Account> ArgAMS_Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAgency_Notes> ArgAgency_Notes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_BondDetail> ArgAMS_BondDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_BondNumberAgency> ArgAMS_BondNumberAgency { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_POAAgency> ArgAMS_POAAgency { get; set; }
    }
}
