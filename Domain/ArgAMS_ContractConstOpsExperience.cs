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
    
    public partial class ArgAMS_ContractConstOpsExperience
    {
        public int ExperienceID { get; set; }
        public decimal ContractAmount { get; set; }
        public Nullable<int> Year { get; set; }
        public string Owner { get; set; }
        public string ProjectDesc { get; set; }
        public string ScopeofWork { get; set; }
        public Nullable<int> ConstOpsID { get; set; }
    
        public virtual ArgAMS_ContractConstOps ArgAMS_ContractConstOps { get; set; }
    }
}
