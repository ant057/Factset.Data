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
    
    public partial class ArgAMS_BondPOA
    {
        public int BondPOAID { get; set; }
        public Nullable<int> BondID { get; set; }
        public string POANumber { get; set; }
    
        public virtual ArgAMS_BondDetail ArgAMS_BondDetail { get; set; }
    }
}
