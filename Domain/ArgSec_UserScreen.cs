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
    
    public partial class ArgSec_UserScreen
    {
        public int UserID { get; set; }
        public int ScreenID { get; set; }
        public byte AccessTypeID { get; set; }
        public int UserScreenID { get; set; }
    
        public virtual ArgSec_AccessType ArgSec_AccessType { get; set; }
        public virtual ArgSec_Screen ArgSec_Screen { get; set; }
        public virtual ArgSec_User ArgSec_User { get; set; }
    }
}
