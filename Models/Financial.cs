using System;
using System.Collections;
using System.Collections.Generic;

namespace Factset.Data.Models
{
    public class Financial
    {
        public string PermanentSecurityID { get; set; }

        //financial?
        public DateTime Date { get; set; }
        public DateTime AdjustedDate { get; set; }
        public string Currency { get; set; }

        Dictionary<string, float> Ratios { get; set; }
        Hashtable LineItems { get; set; }
    }

    public class BalanceModel
    {
        public string ReportCode { get; set; }
        public int DisplayOrder { get; set; }
        public string DisplayLevel { get; set; }
        public string Description { get; set; }
        public string FieldName { get; set; }
        public short Negative { get; set; }

    }
}