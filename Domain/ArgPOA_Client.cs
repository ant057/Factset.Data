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
    
    public partial class ArgPOA_Client
    {
        public int ClientID { get; set; }
        public string ClientAppointee { get; set; }
        public Nullable<System.DateTime> ClientIssueDate { get; set; }
        public Nullable<decimal> ClientLimit { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public bool RequireSignature { get; set; }
        public Nullable<long> AgencyId { get; set; }
        public Nullable<int> DocumentTypeId { get; set; }
    }
}
