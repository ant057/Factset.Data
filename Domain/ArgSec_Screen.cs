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
    
    public partial class ArgSec_Screen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArgSec_Screen()
        {
            this.ArgSec_ScreenModule = new HashSet<ArgSec_ScreenModule>();
            this.ArgSec_UserScreen = new HashSet<ArgSec_UserScreen>();
        }
    
        public int ScreenID { get; set; }
        public string ScreenName { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string TokenString { get; set; }
        public Nullable<byte> SortIndex { get; set; }
        public System.DateTime EffectiveDate { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgSec_ScreenModule> ArgSec_ScreenModule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgSec_UserScreen> ArgSec_UserScreen { get; set; }
    }
}