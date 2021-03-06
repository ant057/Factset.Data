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
    
    public partial class ArgAMS_ContractCredit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArgAMS_ContractCredit()
        {
            this.ArgAMS_ContractContinuity = new HashSet<ArgAMS_ContractContinuity>();
            this.ArgAMS_ContractCreditBankLine = new HashSet<ArgAMS_ContractCreditBankLine>();
            this.ArgAMS_ContractOwnerDetails = new HashSet<ArgAMS_ContractOwnerDetails>();
        }
    
        public int CreditID { get; set; }
        public System.DateTime EffectiveDate { get; set; }
        public long AccountNumber { get; set; }
        public Nullable<System.DateTime> DBDate { get; set; }
        public Nullable<int> DBRatingID { get; set; }
        public string DBPaydex { get; set; }
        public Nullable<bool> DBSuits { get; set; }
        public Nullable<bool> DBLiens { get; set; }
        public Nullable<int> NoteID { get; set; }
        public Nullable<bool> ReferenceInFile { get; set; }
        public string DatePerformed { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<int> DbCompositratingID { get; set; }
        public Nullable<bool> Judgement { get; set; }
        public Nullable<int> DBCommCreditScore { get; set; }
        public Nullable<int> DBFinacialStress { get; set; }
    
        public virtual ArgAMS_Account ArgAMS_Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_ContractContinuity> ArgAMS_ContractContinuity { get; set; }
        public virtual ArgAMS_ContractCredit ArgAMS_ContractCredit1 { get; set; }
        public virtual ArgAMS_ContractCredit ArgAMS_ContractCredit2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_ContractCreditBankLine> ArgAMS_ContractCreditBankLine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgAMS_ContractOwnerDetails> ArgAMS_ContractOwnerDetails { get; set; }
    }
}
