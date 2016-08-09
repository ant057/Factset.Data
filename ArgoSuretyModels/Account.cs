using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factset.Data.ArgoSuretyModels
{
    public class AnchorAccount
    {
        int AccountNumber { get; set; }
        string PrincipalName { get; set; }
        string PrimaryUW { get; set; }
        string Agency { get; set; }
    }
}