using System;
using System.Collections;
using System.Collections.Generic;

namespace Factset.Data.Models
{
    public class Financial
    {
        public string PermanentSecurityID { get; set; }
        public IEnumerable<FinancialDetail> AnnualFinancialStatements { get; set; }
        public IEnumerable<FinancialDetail> QuarterlyFinancialStatements { get; set; }
        public IEnumerable<FinancialDetail> LTMFinancialStatements { get; set; }
        public IEnumerable<FinancialDetail> SemiAnnualFinancialStatements { get; set; }
    }

    public class FinancialDetail
    {
        public DateTime Date { get; set; }
        public DateTime? AdjustedDate { get; set; }
        public string Currency { get; set; }
        public IEnumerable<BalanceModel> FinancialStatements { get; set; }
    }

    public class BalanceModel
    {
        public string ReportCode { get; set; }
        public int? DisplayOrder { get; set; }
        public string DisplayLevel { get; set; }
        public string Description { get; set; }
        public string FieldName { get; set; }
        public short? Negative { get; set; }

        public short Annual { get; set; }
        public short Quarterly { get; set; }
        public short LTM { get; set; }
        public short SemiAnnual { get; set; }

        public string Value { get; set; }

    }
}