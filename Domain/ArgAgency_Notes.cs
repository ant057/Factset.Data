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
    
    public partial class ArgAgency_Notes
    {
        public int NoteId { get; set; }
        public int AgencyId { get; set; }
        public string NoteDesc { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<int> AgentID { get; set; }
    
        public virtual ArgAMS_Agency ArgAMS_Agency { get; set; }
    }
}
