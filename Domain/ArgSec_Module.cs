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
    
    public partial class ArgSec_Module
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArgSec_Module()
        {
            this.ArgSec_RoleModule = new HashSet<ArgSec_RoleModule>();
            this.ArgSec_ScreenModule = new HashSet<ArgSec_ScreenModule>();
        }
    
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public int CreatedByUserId { get; set; }
        public Nullable<int> MainLevel { get; set; }
        public Nullable<int> SubMainLevel { get; set; }
        public Nullable<int> RoleIdRequired { get; set; }
        public Nullable<int> ViewAllowed { get; set; }
        public Nullable<int> AddAllowed { get; set; }
        public Nullable<int> DeleteAllowed { get; set; }
        public Nullable<int> EndorseAllowed { get; set; }
        public Nullable<int> ExecuteAllowed { get; set; }
        public Nullable<int> UnusedAllowed { get; set; }
        public string ModuleFilePathName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgSec_RoleModule> ArgSec_RoleModule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgSec_ScreenModule> ArgSec_ScreenModule { get; set; }
    }
}
