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
    
    public partial class ArgSec_RoleScreen
    {
        public int RoleScreenID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public Nullable<int> ScreenID { get; set; }
        public Nullable<byte> AccessTypeID { get; set; }
    
        public virtual ArgSec_AccessType ArgSec_AccessType { get; set; }
    }
}
