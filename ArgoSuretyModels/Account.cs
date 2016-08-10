using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factset.Data.ArgoSuretyModels
{
    public class AnchorAccount
    {
        public int AccountNumber { get; set; }
        public string PrincipalName { get; set; }
        public string PrimaryUW { get; set; }
        public string Agency { get; set; }
        public string Region { get; set; }
    }
}