﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FactsetEntities : DbContext
    {
        public FactsetEntities()
            : base("name=FactsetEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FDS_COMMAND_HISTORY> FDS_COMMAND_HISTORY { get; set; }
        public virtual DbSet<FDS_DATA_SEQUENCES> FDS_DATA_SEQUENCES { get; set; }
        public virtual DbSet<FDS_FILE_HISTORY> FDS_FILE_HISTORY { get; set; }
        public virtual DbSet<FDS_SCHEMA_SEQUENCES> FDS_SCHEMA_SEQUENCES { get; set; }
        public virtual DbSet<FDS_ZIP_HISTORY> FDS_ZIP_HISTORY { get; set; }
        public virtual DbSet<ff_advanced_af_v2> ff_advanced_af_v2 { get; set; }
        public virtual DbSet<ff_advanced_der_af_v2> ff_advanced_der_af_v2 { get; set; }
        public virtual DbSet<ff_advanced_der_ltm_v2> ff_advanced_der_ltm_v2 { get; set; }
        public virtual DbSet<ff_advanced_der_qf_v2> ff_advanced_der_qf_v2 { get; set; }
        public virtual DbSet<ff_advanced_der_r_af_v2> ff_advanced_der_r_af_v2 { get; set; }
        public virtual DbSet<ff_advanced_der_saf_v2> ff_advanced_der_saf_v2 { get; set; }
        public virtual DbSet<ff_advanced_ltm_v2> ff_advanced_ltm_v2 { get; set; }
        public virtual DbSet<ff_advanced_qf_v2> ff_advanced_qf_v2 { get; set; }
        public virtual DbSet<ff_advanced_r_af_v2> ff_advanced_r_af_v2 { get; set; }
        public virtual DbSet<ff_advanced_saf_v2> ff_advanced_saf_v2 { get; set; }
        public virtual DbSet<ff_balance_model> ff_balance_model { get; set; }
        public virtual DbSet<ff_balance_model_ind> ff_balance_model_ind { get; set; }
        public virtual DbSet<ff_balance_model_rpt_map> ff_balance_model_rpt_map { get; set; }
        public virtual DbSet<ff_basic_af_v2> ff_basic_af_v2 { get; set; }
        public virtual DbSet<ff_basic_der_af_v2> ff_basic_der_af_v2 { get; set; }
        public virtual DbSet<ff_basic_der_ltm_v2> ff_basic_der_ltm_v2 { get; set; }
        public virtual DbSet<ff_basic_der_qf_v2> ff_basic_der_qf_v2 { get; set; }
        public virtual DbSet<ff_basic_der_r_af_v2> ff_basic_der_r_af_v2 { get; set; }
        public virtual DbSet<ff_basic_der_saf_v2> ff_basic_der_saf_v2 { get; set; }
        public virtual DbSet<ff_basic_ltm_v2> ff_basic_ltm_v2 { get; set; }
        public virtual DbSet<ff_basic_qf_v2> ff_basic_qf_v2 { get; set; }
        public virtual DbSet<ff_basic_r_af_v2> ff_basic_r_af_v2 { get; set; }
        public virtual DbSet<ff_basic_saf_v2> ff_basic_saf_v2 { get; set; }
        public virtual DbSet<ff_basic_v2> ff_basic_v2 { get; set; }
        public virtual DbSet<ff_financial_stmt_map> ff_financial_stmt_map { get; set; }
        public virtual DbSet<ff_gen_ind_map> ff_gen_ind_map { get; set; }
        public virtual DbSet<ff_metadata> ff_metadata { get; set; }
        public virtual DbSet<ff_security> ff_security { get; set; }
        public virtual DbSet<ff_segbus_af> ff_segbus_af { get; set; }
        public virtual DbSet<ff_segreg_af> ff_segreg_af { get; set; }
        public virtual DbSet<ff_stitch_af> ff_stitch_af { get; set; }
        public virtual DbSet<ff_stitch_ltm> ff_stitch_ltm { get; set; }
        public virtual DbSet<ff_stitch_qf> ff_stitch_qf { get; set; }
        public virtual DbSet<ff_stitch_saf> ff_stitch_saf { get; set; }
        public virtual DbSet<h_address> h_address { get; set; }
        public virtual DbSet<h_entity> h_entity { get; set; }
        public virtual DbSet<h_entity_sector> h_entity_sector { get; set; }
        public virtual DbSet<h_people> h_people { get; set; }
        public virtual DbSet<h_security_cusip> h_security_cusip { get; set; }
        public virtual DbSet<h_security_isin> h_security_isin { get; set; }
        public virtual DbSet<h_security_sedol> h_security_sedol { get; set; }
        public virtual DbSet<h_security_ticker_exchange> h_security_ticker_exchange { get; set; }
        public virtual DbSet<h_security_ticker_region> h_security_ticker_region { get; set; }
        public virtual DbSet<affiliate_type_map> affiliate_type_map { get; set; }
        public virtual DbSet<asset_class_map> asset_class_map { get; set; }
        public virtual DbSet<audit_type_map> audit_type_map { get; set; }
        public virtual DbSet<ce_event_type_map> ce_event_type_map { get; set; }
        public virtual DbSet<ce_fiscal_period_map> ce_fiscal_period_map { get; set; }
        public virtual DbSet<ce_market_time_map> ce_market_time_map { get; set; }
        public virtual DbSet<cic_classification_map> cic_classification_map { get; set; }
        public virtual DbSet<country_map> country_map { get; set; }
        public virtual DbSet<dcs_category_map> dcs_category_map { get; set; }
        public virtual DbSet<dcs_coupon_map> dcs_coupon_map { get; set; }
        public virtual DbSet<dcs_debt_map> dcs_debt_map { get; set; }
        public virtual DbSet<dcs_fiscal_year_map> dcs_fiscal_year_map { get; set; }
        public virtual DbSet<dcs_reporting_period_map> dcs_reporting_period_map { get; set; }
        public virtual DbSet<dcs_seniority_map> dcs_seniority_map { get; set; }
        public virtual DbSet<dcs_summary_map> dcs_summary_map { get; set; }
        public virtual DbSet<econ_category_map> econ_category_map { get; set; }
        public virtual DbSet<econ_concept_map> econ_concept_map { get; set; }
        public virtual DbSet<econ_country_inclusion> econ_country_inclusion { get; set; }
        public virtual DbSet<econ_event_type_map> econ_event_type_map { get; set; }
        public virtual DbSet<econ_frequency_map> econ_frequency_map { get; set; }
        public virtual DbSet<econ_importance_ind_map> econ_importance_ind_map { get; set; }
        public virtual DbSet<econ_indicator_map> econ_indicator_map { get; set; }
        public virtual DbSet<econ_source_map> econ_source_map { get; set; }
        public virtual DbSet<econ_subcategory_map> econ_subcategory_map { get; set; }
        public virtual DbSet<econ_unit_amounts_map> econ_unit_amounts_map { get; set; }
        public virtual DbSet<entity_profile_type_map> entity_profile_type_map { get; set; }
        public virtual DbSet<entity_relation_type_map> entity_relation_type_map { get; set; }
        public virtual DbSet<entity_status_map> entity_status_map { get; set; }
        public virtual DbSet<entity_sub_type_map> entity_sub_type_map { get; set; }
        public virtual DbSet<entity_type_map> entity_type_map { get; set; }
        public virtual DbSet<factset_industry_map> factset_industry_map { get; set; }
        public virtual DbSet<factset_sector_map> factset_sector_map { get; set; }
        public virtual DbSet<fe_actualflag_map> fe_actualflag_map { get; set; }
        public virtual DbSet<fe_cmtsubid_map> fe_cmtsubid_map { get; set; }
        public virtual DbSet<fe_item> fe_item { get; set; }
        public virtual DbSet<fe_item_map> fe_item_map { get; set; }
        public virtual DbSet<fe_revisionflag_map> fe_revisionflag_map { get; set; }
        public virtual DbSet<ff_accounting_standard_map> ff_accounting_standard_map { get; set; }
        public virtual DbSet<ff_auditor_opinion_map> ff_auditor_opinion_map { get; set; }
        public virtual DbSet<fp_div_ngflag_map> fp_div_ngflag_map { get; set; }
        public virtual DbSet<fp_div_tax_marker_map> fp_div_tax_marker_map { get; set; }
        public virtual DbSet<fp_div_type_map> fp_div_type_map { get; set; }
        public virtual DbSet<fp_sec_type_map> fp_sec_type_map { get; set; }
        public virtual DbSet<fref_sec_exchange_map> fref_sec_exchange_map { get; set; }
        public virtual DbSet<fref_security_type_map> fref_security_type_map { get; set; }
        public virtual DbSet<fund_type_map> fund_type_map { get; set; }
        public virtual DbSet<fx_rates_hist> fx_rates_hist { get; set; }
        public virtual DbSet<fx_rates_usd> fx_rates_usd { get; set; }
        public virtual DbSet<generic_id_map> generic_id_map { get; set; }
        public virtual DbSet<insider_tran_map> insider_tran_map { get; set; }
        public virtual DbSet<invt_obj_asset_type_map> invt_obj_asset_type_map { get; set; }
        public virtual DbSet<invt_obj_map> invt_obj_map { get; set; }
        public virtual DbSet<invt_obj_specialization_map> invt_obj_specialization_map { get; set; }
        public virtual DbSet<iso_currency_map> iso_currency_map { get; set; }
        public virtual DbSet<issue_type_map> issue_type_map { get; set; }
        public virtual DbSet<list_map> list_map { get; set; }
        public virtual DbSet<ma_acq_purpose_map> ma_acq_purpose_map { get; set; }
        public virtual DbSet<ma_closing_status_map> ma_closing_status_map { get; set; }
        public virtual DbSet<ma_company_role_map> ma_company_role_map { get; set; }
        public virtual DbSet<ma_deal_attitude_map> ma_deal_attitude_map { get; set; }
        public virtual DbSet<ma_deal_type_map> ma_deal_type_map { get; set; }
        public virtual DbSet<ma_profession_role_map> ma_profession_role_map { get; set; }
        public virtual DbSet<ma_profession_type_map> ma_profession_type_map { get; set; }
        public virtual DbSet<ma_term_change_types_map> ma_term_change_types_map { get; set; }
        public virtual DbSet<metro_map> metro_map { get; set; }
        public virtual DbSet<mic_exchange_map> mic_exchange_map { get; set; }
        public virtual DbSet<nace_classification_map> nace_classification_map { get; set; }
        public virtual DbSet<naics6_map> naics6_map { get; set; }
        public virtual DbSet<pe_event_id_map> pe_event_id_map { get; set; }
        public virtual DbSet<pe_fund_status_map> pe_fund_status_map { get; set; }
        public virtual DbSet<pe_fund_type_map> pe_fund_type_map { get; set; }
        public virtual DbSet<pe_instrument_map> pe_instrument_map { get; set; }
        public virtual DbSet<pe_security_categories_map> pe_security_categories_map { get; set; }
        public virtual DbSet<pe_transaction_map> pe_transaction_map { get; set; }
        public virtual DbSet<ppl_asset_type_map> ppl_asset_type_map { get; set; }
        public virtual DbSet<ppl_board_committee_map> ppl_board_committee_map { get; set; }
        public virtual DbSet<ppl_bus_map> ppl_bus_map { get; set; }
        public virtual DbSet<ppl_job_function_map> ppl_job_function_map { get; set; }
        public virtual DbSet<ppl_region_map> ppl_region_map { get; set; }
        public virtual DbSet<ppl_special_area_map> ppl_special_area_map { get; set; }
        public virtual DbSet<region_map> region_map { get; set; }
        public virtual DbSet<relationship_type_map> relationship_type_map { get; set; }
        public virtual DbSet<resolution_map> resolution_map { get; set; }
        public virtual DbSet<shrk_advisor_type_map> shrk_advisor_type_map { get; set; }
        public virtual DbSet<shrk_amendment_type_map> shrk_amendment_type_map { get; set; }
        public virtual DbSet<shrk_pill_status_map> shrk_pill_status_map { get; set; }
        public virtual DbSet<shrk_pill_type_map> shrk_pill_type_map { get; set; }
        public virtual DbSet<shrk_pill_version_type_map> shrk_pill_version_type_map { get; set; }
        public virtual DbSet<shrk_source_type_map> shrk_source_type_map { get; set; }
        public virtual DbSet<sic_map> sic_map { get; set; }
        public virtual DbSet<source_map> source_map { get; set; }
        public virtual DbSet<state_province_map> state_province_map { get; set; }
        public virtual DbSet<unit_amount_map> unit_amount_map { get; set; }
    }
}
