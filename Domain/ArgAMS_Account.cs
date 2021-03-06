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
    
    public partial class ArgAMS_Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArgAMS_Account()
        {
            this.ArgAMS_AccountCommercialCredit = new HashSet<ArgAMS_AccountCommercialCredit>();
            this.ArgAMS_FinancialHeader = new HashSet<ArgAMS_FinancialHeader>();
            this.ArgAMS_BondDetail = new HashSet<ArgAMS_BondDetail>();
            this.ArgAMS_Collateral = new HashSet<ArgAMS_Collateral>();
            this.ArgAMS_CommercialIndemnityData = new HashSet<ArgAMS_CommercialIndemnityData>();
            this.ArgAMS_ContractCredit = new HashSet<ArgAMS_ContractCredit>();
            this.ArgAMS_ContractIndemnity = new HashSet<ArgAMS_ContractIndemnity>();
            this.ArgAMS_ContractRateDetails = new HashSet<ArgAMS_ContractRateDetails>();
            this.ArgAMS_ProducerCSR = new HashSet<ArgAMS_ProducerCSR>();
            this.ArgAMS_ProgramAuth = new HashSet<ArgAMS_ProgramAuth>();
            this.ArgAMS_WIP = new HashSet<ArgAMS_WIP>();
        }
    
        public long AccountNumber { get; set; }
        public int BusinessTypeID { get; set; }
        public int StatusID { get; set; }
        public int LocationID { get; set; }
        public int UW1ID { get; set; }
        public Nullable<int> UW2ID { get; set; }
        public int UWAId { get; set; }
        public Nullable<int> HomeOffice2Id { get; set; }
        public Nullable<int> HomeOffice1ID { get; set; }
        public int AgencyID { get; set; }
        public int PrincipalID { get; set; }
        public Nullable<int> PriorSuretyID { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public Nullable<int> SortIndex { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> NoteId { get; set; }
        public Nullable<System.DateTime> Mgmtcontroldt { get; set; }
        public Nullable<System.DateTime> Argoacqdt { get; set; }
        public Nullable<System.DateTime> LastAcctMtg { get; set; }
        public Nullable<bool> isQuoted { get; set; }
        public Nullable<bool> isProspect { get; set; }
        public Nullable<bool> isManualAddress { get; set; }
        public Nullable<bool> isLostToCompetitor { get; set; }
        public Nullable<bool> isRIAccept { get; set; }
        public string RIAcceptNote { get; set; }
        public Nullable<bool> isReverseFlow { get; set; }
        public Nullable<int> RegionId { get; set; }
        public Nullable<int> isMiddle { get; set; }
        public Nullable<bool> isLetterSent { get; set; }
        public Nullable<System.DateTime> LetterSentDate { get; set; }
        public Nullable<int> LetterDays { get; set; }
        public Nullable<System.DateTime> AuditDate { get; set; }
    
        public virtual ArgAMS_Account ArgAMS_Account1 { get; set; }
        public virtual ArgAMS_Account ArgAMS_Account2 { get; set; }
        public virtual ArgAMS_Account ArgAMS_Account11 { get; set; }
        public virtual ArgAMS_Account ArgAMS_Account3 { get; set; }
        public virtual ArgAMS_Account ArgAMS_Account12 { get; set; }
        public virtual ArgAMS_Account ArgAMS_Account4 { get; set; }
        public virtual ArgAMS_Account ArgAMS_Account13 { get; set; }
        public virtual ArgAMS_Account ArgAMS_Account5 { get; set; }
        public virtual ArgAMS_Agency ArgAMS_Agency { get; set; }
        public virtual ArgAMS_BusinessType ArgAMS_BusinessType { get; set; }
        public virtual ArgAMS_Principal ArgAMS_Principal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_AccountCommercialCredit> ArgAMS_AccountCommercialCredit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_FinancialHeader> ArgAMS_FinancialHeader { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_BondDetail> ArgAMS_BondDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_Collateral> ArgAMS_Collateral { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_CommercialIndemnityData> ArgAMS_CommercialIndemnityData { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_ContractCredit> ArgAMS_ContractCredit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_ContractIndemnity> ArgAMS_ContractIndemnity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_ContractRateDetails> ArgAMS_ContractRateDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_ProducerCSR> ArgAMS_ProducerCSR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_ProgramAuth> ArgAMS_ProgramAuth { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_WIP> ArgAMS_WIP { get; set; }
    }
}
