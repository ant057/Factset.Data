using Factset.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Factset.Data.Models
{
    interface ICompanyRepository
    {
        Company GetCompany(string permSecurityId);
    }

    public class CompanyRespository : ICompanyRepository
    {
        private FactsetEntities _db = null;

        private DbSet<ff_basic_v2> _basic = null;
        private DbSet<h_entity> _entity = null;
        private DbSet<h_entity_sector> _entity_sector_map = null;
        private DbSet<h_security_ticker_exchange> _sec_tick_exch = null;
        private DbSet<entity_type_map> _entity_type_map = null;
        private DbSet<sic_map> _sic_map = null;
        private DbSet<factset_industry_map> _industry_map = null;
        private DbSet<factset_sector_map> _sector_map = null;
        private DbSet<fref_sec_exchange_map> _exch_map = null;
        private DbSet<ent_entity_address> _entity_address = null;

        public CompanyRespository(FactsetEntities db)
        {
            _db = db;

            _basic = _db.ff_basic_v2;
            _entity = _db.h_entity;
            _entity_sector_map = _db.h_entity_sector;
            _sec_tick_exch = _db.h_security_ticker_exchange;
            _entity_type_map = _db.entity_type_map;
            _sic_map = _db.sic_map;
            _industry_map = _db.factset_industry_map;
            _sector_map = _db.factset_sector_map;
            _exch_map = _db.fref_sec_exchange_map;
            _entity_address = db.ent_entity_address;
        }

        public Company GetCompany(string permSecurityId)
        {

            var results = from Basic in _basic
                          join Entity in _entity on Basic.factset_entity_id equals Entity.factset_entity_id
                          join EntityTypeMap in _entity_type_map on Entity.entity_type equals EntityTypeMap.entity_type_code
                          join EntitySector in _entity_sector_map on Entity.factset_entity_id equals EntitySector.factset_entity_id
                          join SICMap in _sic_map on EntitySector.primary_sic_code equals SICMap.sic_code
                          join IndustryMap in _industry_map on EntitySector.industry_code equals IndustryMap.factset_industry_code
                          join SectorMap in _sector_map on EntitySector.sector_code equals SectorMap.factset_sector_code
                          join TickerExchange in _sec_tick_exch on Basic.fs_perm_sec_id equals TickerExchange.fs_perm_sec_id
                          join ExchangeMap in _exch_map on TickerExchange.ticker_exchange.Substring(TickerExchange.ticker_exchange.IndexOf("-") + 1) equals ExchangeMap.fref_exchange_code
                          join EntityAddress in _entity_address on Entity.factset_entity_id equals EntityAddress.FACTSET_ENTITY_ID into Inners
                          from EntityAddress2 in Inners.DefaultIfEmpty()
                          where (Basic.fs_perm_sec_id == permSecurityId)
                          select new Company()
                          {
                              PermanentSecurityID = Basic.fs_perm_sec_id,
                              EntityId = Basic.factset_entity_id,
                              City = EntityAddress2.LOCATION_CITY,
                              State = EntityAddress2.STATE_PROVINCE,
                              ZipCode = EntityAddress2.LOCATION_POSTAL_CODE,
                              Street1 = EntityAddress2.LOCATION_STREET1,
                              Street2 = EntityAddress2.LOCATION_STREET2,
                              Street3 = EntityAddress2.LOCATION_STREET3,
                              Phone = EntityAddress2.TELE_FULL,
                              CountryISO = Basic.ff_country_iso,
                              LatestAnnualUpdate = Basic.fa_latest_ann_update,
                              CompanyName = Basic.ff_co_name,
                              BusinessDescriptionAbbrev = Basic.ff_bus_desc_abbrev,
                              MarketValueCurrent = Basic.ff_mkt_val_curr,
                              CashFlowPerShare = Basic.ff_curr_ps_cf,
                              DividendsPerShare = Basic.ff_dps_ltm_secs,
                              PriceToBookValue = Basic.ff_pbk_secs_curr,
                              DividendYield = Basic.ff_div_yld_curr,
                              DividendPayoutPerShare = Basic.ff_div_pay_out_ps_curr,
                              PriceToEarnings = Basic.ff_pe_secs_curr,
                              UniverseAmerica = Basic.universe_am,
                              UniverseAsiaPacific = Basic.universe_ap,
                              UniverseEurope = Basic.universe_eu,
                              EntityTypeDescription = EntityTypeMap.entity_type_desc,
                              SICCode = SICMap.sic_code,
                              SICDescription = SICMap.sic_desc,
                              IndustryDescription = IndustryMap.factset_industry_desc,
                              SectorDescription = SectorMap.factset_sector_desc,
                              Ticker = TickerExchange.ticker_exchange,
                              Exchange = ExchangeMap.fref_exchange_desc
                          };

            return results.DefaultIfEmpty().FirstOrDefault();
        }
    }
}