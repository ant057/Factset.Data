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
    
    public partial class ArgAMS_POAAgency
    {
        public int ID { get; set; }
        public string POANumber { get; set; }
        public int WritingCompanyID { get; set; }
        public int AgencyID { get; set; }
        public string Status { get; set; }
    
        public virtual ArgAMS_Agency ArgAMS_Agency { get; set; }
    }
}
