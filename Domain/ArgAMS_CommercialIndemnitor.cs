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
    
    public partial class ArgAMS_CommercialIndemnitor
    {
        public int IndemnitorID { get; set; }
        public string IndemnitorName { get; set; }
        public int IndemnitorTypeID { get; set; }
        public int IndemnityID { get; set; }
        public Nullable<System.DateTime> ExpDate { get; set; }
    
        public virtual ArgAMS_CommercialIndemnitor ArgAMS_CommercialIndemnitor1 { get; set; }
        public virtual ArgAMS_CommercialIndemnitor ArgAMS_CommercialIndemnitor2 { get; set; }
        public virtual ArgAMS_CommercialIndemnityData ArgAMS_CommercialIndemnityData { get; set; }
    }
}