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

        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string Phone { get; set; }

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

        public short UniverseAmerica { get; set; }
        public short UniverseEurope { get; set; }
        public short UniverseAsiaPacific { get; set; }

        public string EntityTypeDescription { get; set; }
        public string SICCode { get; set; }
        public string SICDescription { get; set; }
        public string IndustryDescription { get; set; }
        public string SectorDescription { get; set; }
        public string Ticker { get; set; }
        public string Exchange { get; set; }

        public Financial FinancialStatements { get; set; }

    }
}