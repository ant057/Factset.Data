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
    
    public partial class ArgSec_ScreenModule
    {
        public int ModuleID { get; set; }
        public int ScreenID { get; set; }
        public int ScreenModuleID { get; set; }
    
        public virtual ArgSec_Module ArgSec_Module { get; set; }
        public virtual ArgSec_Screen ArgSec_Screen { get; set; }
    }
}
