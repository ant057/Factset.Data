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
    
    public partial class ArgAMS_ContractContinuity
    {
        public int ContinuityID { get; set; }
        public Nullable<bool> Formalagreement { get; set; }
        public Nullable<int> ContinuityTypeID { get; set; }
        public Nullable<bool> CopyinFile { get; set; }
        public Nullable<bool> FundedByLifeIns { get; set; }
        public Nullable<decimal> AmtLifeIns { get; set; }
        public Nullable<System.DateTime> DateLastConfirmed { get; set; }
        public Nullable<int> NoteID { get; set; }
        public int CreditID { get; set; }
        public Nullable<int> NotesIDTransUnion { get; set; }
    
        public virtual ArgAMS_ContractContinuity ArgAMS_ContractContinuity1 { get; set; }
        public virtual ArgAMS_ContractContinuity ArgAMS_ContractContinuity2 { get; set; }
        public virtual ArgAMS_ContractContinuity ArgAMS_ContractContinuity11 { get; set; }
        public virtual ArgAMS_ContractContinuity ArgAMS_ContractContinuity3 { get; set; }
        public virtual ArgAMS_ContractCredit ArgAMS_ContractCredit { get; set; }
    }
}