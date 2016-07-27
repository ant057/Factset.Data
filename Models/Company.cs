using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factset.Data.Models
{
    public class Company
    {
        public string PermanentSecurityID { get; set; }

        public string EntityId { get; set; }
        public string CountryISO { get; set; }
        public decimal? LatestAnnualUpdate { get; set; }
        public string CompanyName { get; set; }
        public string BusinessDescriptionAbbrev { get; set; }
        public double? MarketValueCurrent { get; set; }
        public double? CashFlowPerShare { get; set; }
        public double? DividendsPerShare { get; set; }
        public double? PriceToBookValue { get; set; }
        public double? DividendYield { get; set; }
        public double? DividendPayoutPerShare { get; set; }
        public double? PriceToEarnings { get; set; }

        public bool UniverseAmerica { get; set; }
        public bool UniverseEurope { get; set; }
        public bool UniverseAsiaPacific { get; set; }

        public Financial FinancialStatements { get; set; }

    }
}