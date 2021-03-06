﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4984
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.50727.4984.
// 
namespace QHMobile.ItemQH {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ItemQH_Binding", Namespace="urn:microsoft-dynamics-schemas/page/itemqh")]
    public partial class ItemQH_Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public ItemQH_Service() {
            this.Url = "http://dpmaster.dptech.local:7045/DynamicsNAVQH/WS/Qian%20Hu/Page/ItemQH";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/itemqh:Read", RequestNamespace="urn:microsoft-dynamics-schemas/page/itemqh", ResponseElementName="Read_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/itemqh", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("ItemQH")]
        public ItemQH Read(string No) {
            object[] results = this.Invoke("Read", new object[] {
                        No});
            return ((ItemQH)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginRead(string No, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Read", new object[] {
                        No}, callback, asyncState);
        }
        
        /// <remarks/>
        public ItemQH EndRead(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((ItemQH)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/itemqh:ReadByRecId", RequestNamespace="urn:microsoft-dynamics-schemas/page/itemqh", ResponseElementName="ReadByRecId_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/itemqh", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("ItemQH")]
        public ItemQH ReadByRecId(string recId) {
            object[] results = this.Invoke("ReadByRecId", new object[] {
                        recId});
            return ((ItemQH)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginReadByRecId(string recId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ReadByRecId", new object[] {
                        recId}, callback, asyncState);
        }
        
        /// <remarks/>
        public ItemQH EndReadByRecId(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((ItemQH)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/itemqh:ReadMultiple", RequestNamespace="urn:microsoft-dynamics-schemas/page/itemqh", ResponseElementName="ReadMultiple_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/itemqh", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("ReadMultiple_Result")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public ItemQH[] ReadMultiple([System.Xml.Serialization.XmlElementAttribute("filter")] ItemQH_Filter[] filter, string bookmarkKey, int setSize) {
            object[] results = this.Invoke("ReadMultiple", new object[] {
                        filter,
                        bookmarkKey,
                        setSize});
            return ((ItemQH[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginReadMultiple(ItemQH_Filter[] filter, string bookmarkKey, int setSize, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ReadMultiple", new object[] {
                        filter,
                        bookmarkKey,
                        setSize}, callback, asyncState);
        }
        
        /// <remarks/>
        public ItemQH[] EndReadMultiple(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((ItemQH[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/itemqh:IsUpdated", RequestNamespace="urn:microsoft-dynamics-schemas/page/itemqh", ResponseElementName="IsUpdated_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/itemqh", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("IsUpdated_Result")]
        public bool IsUpdated(string Key) {
            object[] results = this.Invoke("IsUpdated", new object[] {
                        Key});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginIsUpdated(string Key, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("IsUpdated", new object[] {
                        Key}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndIsUpdated(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/itemqh:GetRecIdFromKey", RequestNamespace="urn:microsoft-dynamics-schemas/page/itemqh", ResponseElementName="GetRecIdFromKey_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/itemqh", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetRecIdFromKey_Result")]
        public string GetRecIdFromKey(string Key) {
            object[] results = this.Invoke("GetRecIdFromKey", new object[] {
                        Key});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetRecIdFromKey(string Key, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetRecIdFromKey", new object[] {
                        Key}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetRecIdFromKey(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/itemqh")]
    public partial class ItemQH {
        
        private string keyField;
        
        private string noField;
        
        private string descriptionField;
        
        private string description_2Field;
        
        private bool created_From_Nonstock_ItemField;
        
        private bool created_From_Nonstock_ItemFieldSpecified;
        
        private bool substitutes_ExistField;
        
        private bool substitutes_ExistFieldSpecified;
        
        private bool stockkeeping_Unit_ExistsField;
        
        private bool stockkeeping_Unit_ExistsFieldSpecified;
        
        private string production_BOM_NoField;
        
        private string routing_NoField;
        
        private string base_Unit_of_MeasureField;
        
        private string shelf_NoField;
        
        private Costing_Method costing_MethodField;
        
        private bool costing_MethodFieldSpecified;
        
        private bool cost_is_AdjustedField;
        
        private bool cost_is_AdjustedFieldSpecified;
        
        private decimal standard_CostField;
        
        private bool standard_CostFieldSpecified;
        
        private decimal unit_CostField;
        
        private bool unit_CostFieldSpecified;
        
        private decimal last_Direct_CostField;
        
        private bool last_Direct_CostFieldSpecified;
        
        private Price_Profit_Calculation price_Profit_CalculationField;
        
        private bool price_Profit_CalculationFieldSpecified;
        
        private decimal profit_PercentField;
        
        private bool profit_PercentFieldSpecified;
        
        private decimal unit_PriceField;
        
        private bool unit_PriceFieldSpecified;
        
        private string inventory_Posting_GroupField;
        
        private string gen_Prod_Posting_GroupField;
        
        private string vAT_Prod_Posting_GroupField;
        
        private string item_Disc_GroupField;
        
        private string vendor_NoField;
        
        private string vendor_Item_NoField;
        
        private string tariff_NoField;
        
        private string search_DescriptionField;
        
        private decimal overhead_RateField;
        
        private bool overhead_RateFieldSpecified;
        
        private decimal indirect_Cost_PercentField;
        
        private bool indirect_Cost_PercentFieldSpecified;
        
        private string item_Category_CodeField;
        
        private string product_Group_CodeField;
        
        private bool blockedField;
        
        private bool blockedFieldSpecified;
        
        private System.DateTime last_Date_ModifiedField;
        
        private bool last_Date_ModifiedFieldSpecified;
        
        private string sales_Unit_of_MeasureField;
        
        private Replenishment_System replenishment_SystemField;
        
        private bool replenishment_SystemFieldSpecified;
        
        private string purch_Unit_of_MeasureField;
        
        private string lead_Time_CalculationField;
        
        private Manufacturing_Policy manufacturing_PolicyField;
        
        private bool manufacturing_PolicyFieldSpecified;
        
        private Flushing_Method flushing_MethodField;
        
        private bool flushing_MethodFieldSpecified;
        
        private string item_Tracking_CodeField;
        
        /// <remarks/>
        public string Key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        public string No {
            get {
                return this.noField;
            }
            set {
                this.noField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public string Description_2 {
            get {
                return this.description_2Field;
            }
            set {
                this.description_2Field = value;
            }
        }
        
        /// <remarks/>
        public bool Created_From_Nonstock_Item {
            get {
                return this.created_From_Nonstock_ItemField;
            }
            set {
                this.created_From_Nonstock_ItemField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Created_From_Nonstock_ItemSpecified {
            get {
                return this.created_From_Nonstock_ItemFieldSpecified;
            }
            set {
                this.created_From_Nonstock_ItemFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public bool Substitutes_Exist {
            get {
                return this.substitutes_ExistField;
            }
            set {
                this.substitutes_ExistField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Substitutes_ExistSpecified {
            get {
                return this.substitutes_ExistFieldSpecified;
            }
            set {
                this.substitutes_ExistFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public bool Stockkeeping_Unit_Exists {
            get {
                return this.stockkeeping_Unit_ExistsField;
            }
            set {
                this.stockkeeping_Unit_ExistsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Stockkeeping_Unit_ExistsSpecified {
            get {
                return this.stockkeeping_Unit_ExistsFieldSpecified;
            }
            set {
                this.stockkeeping_Unit_ExistsFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Production_BOM_No {
            get {
                return this.production_BOM_NoField;
            }
            set {
                this.production_BOM_NoField = value;
            }
        }
        
        /// <remarks/>
        public string Routing_No {
            get {
                return this.routing_NoField;
            }
            set {
                this.routing_NoField = value;
            }
        }
        
        /// <remarks/>
        public string Base_Unit_of_Measure {
            get {
                return this.base_Unit_of_MeasureField;
            }
            set {
                this.base_Unit_of_MeasureField = value;
            }
        }
        
        /// <remarks/>
        public string Shelf_No {
            get {
                return this.shelf_NoField;
            }
            set {
                this.shelf_NoField = value;
            }
        }
        
        /// <remarks/>
        public Costing_Method Costing_Method {
            get {
                return this.costing_MethodField;
            }
            set {
                this.costing_MethodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Costing_MethodSpecified {
            get {
                return this.costing_MethodFieldSpecified;
            }
            set {
                this.costing_MethodFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public bool Cost_is_Adjusted {
            get {
                return this.cost_is_AdjustedField;
            }
            set {
                this.cost_is_AdjustedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Cost_is_AdjustedSpecified {
            get {
                return this.cost_is_AdjustedFieldSpecified;
            }
            set {
                this.cost_is_AdjustedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public decimal Standard_Cost {
            get {
                return this.standard_CostField;
            }
            set {
                this.standard_CostField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Standard_CostSpecified {
            get {
                return this.standard_CostFieldSpecified;
            }
            set {
                this.standard_CostFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public decimal Unit_Cost {
            get {
                return this.unit_CostField;
            }
            set {
                this.unit_CostField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Unit_CostSpecified {
            get {
                return this.unit_CostFieldSpecified;
            }
            set {
                this.unit_CostFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public decimal Last_Direct_Cost {
            get {
                return this.last_Direct_CostField;
            }
            set {
                this.last_Direct_CostField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Last_Direct_CostSpecified {
            get {
                return this.last_Direct_CostFieldSpecified;
            }
            set {
                this.last_Direct_CostFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public Price_Profit_Calculation Price_Profit_Calculation {
            get {
                return this.price_Profit_CalculationField;
            }
            set {
                this.price_Profit_CalculationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Price_Profit_CalculationSpecified {
            get {
                return this.price_Profit_CalculationFieldSpecified;
            }
            set {
                this.price_Profit_CalculationFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public decimal Profit_Percent {
            get {
                return this.profit_PercentField;
            }
            set {
                this.profit_PercentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Profit_PercentSpecified {
            get {
                return this.profit_PercentFieldSpecified;
            }
            set {
                this.profit_PercentFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public decimal Unit_Price {
            get {
                return this.unit_PriceField;
            }
            set {
                this.unit_PriceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Unit_PriceSpecified {
            get {
                return this.unit_PriceFieldSpecified;
            }
            set {
                this.unit_PriceFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Inventory_Posting_Group {
            get {
                return this.inventory_Posting_GroupField;
            }
            set {
                this.inventory_Posting_GroupField = value;
            }
        }
        
        /// <remarks/>
        public string Gen_Prod_Posting_Group {
            get {
                return this.gen_Prod_Posting_GroupField;
            }
            set {
                this.gen_Prod_Posting_GroupField = value;
            }
        }
        
        /// <remarks/>
        public string VAT_Prod_Posting_Group {
            get {
                return this.vAT_Prod_Posting_GroupField;
            }
            set {
                this.vAT_Prod_Posting_GroupField = value;
            }
        }
        
        /// <remarks/>
        public string Item_Disc_Group {
            get {
                return this.item_Disc_GroupField;
            }
            set {
                this.item_Disc_GroupField = value;
            }
        }
        
        /// <remarks/>
        public string Vendor_No {
            get {
                return this.vendor_NoField;
            }
            set {
                this.vendor_NoField = value;
            }
        }
        
        /// <remarks/>
        public string Vendor_Item_No {
            get {
                return this.vendor_Item_NoField;
            }
            set {
                this.vendor_Item_NoField = value;
            }
        }
        
        /// <remarks/>
        public string Tariff_No {
            get {
                return this.tariff_NoField;
            }
            set {
                this.tariff_NoField = value;
            }
        }
        
        /// <remarks/>
        public string Search_Description {
            get {
                return this.search_DescriptionField;
            }
            set {
                this.search_DescriptionField = value;
            }
        }
        
        /// <remarks/>
        public decimal Overhead_Rate {
            get {
                return this.overhead_RateField;
            }
            set {
                this.overhead_RateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Overhead_RateSpecified {
            get {
                return this.overhead_RateFieldSpecified;
            }
            set {
                this.overhead_RateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public decimal Indirect_Cost_Percent {
            get {
                return this.indirect_Cost_PercentField;
            }
            set {
                this.indirect_Cost_PercentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Indirect_Cost_PercentSpecified {
            get {
                return this.indirect_Cost_PercentFieldSpecified;
            }
            set {
                this.indirect_Cost_PercentFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Item_Category_Code {
            get {
                return this.item_Category_CodeField;
            }
            set {
                this.item_Category_CodeField = value;
            }
        }
        
        /// <remarks/>
        public string Product_Group_Code {
            get {
                return this.product_Group_CodeField;
            }
            set {
                this.product_Group_CodeField = value;
            }
        }
        
        /// <remarks/>
        public bool Blocked {
            get {
                return this.blockedField;
            }
            set {
                this.blockedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BlockedSpecified {
            get {
                return this.blockedFieldSpecified;
            }
            set {
                this.blockedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime Last_Date_Modified {
            get {
                return this.last_Date_ModifiedField;
            }
            set {
                this.last_Date_ModifiedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Last_Date_ModifiedSpecified {
            get {
                return this.last_Date_ModifiedFieldSpecified;
            }
            set {
                this.last_Date_ModifiedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Sales_Unit_of_Measure {
            get {
                return this.sales_Unit_of_MeasureField;
            }
            set {
                this.sales_Unit_of_MeasureField = value;
            }
        }
        
        /// <remarks/>
        public Replenishment_System Replenishment_System {
            get {
                return this.replenishment_SystemField;
            }
            set {
                this.replenishment_SystemField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Replenishment_SystemSpecified {
            get {
                return this.replenishment_SystemFieldSpecified;
            }
            set {
                this.replenishment_SystemFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Purch_Unit_of_Measure {
            get {
                return this.purch_Unit_of_MeasureField;
            }
            set {
                this.purch_Unit_of_MeasureField = value;
            }
        }
        
        /// <remarks/>
        public string Lead_Time_Calculation {
            get {
                return this.lead_Time_CalculationField;
            }
            set {
                this.lead_Time_CalculationField = value;
            }
        }
        
        /// <remarks/>
        public Manufacturing_Policy Manufacturing_Policy {
            get {
                return this.manufacturing_PolicyField;
            }
            set {
                this.manufacturing_PolicyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Manufacturing_PolicySpecified {
            get {
                return this.manufacturing_PolicyFieldSpecified;
            }
            set {
                this.manufacturing_PolicyFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public Flushing_Method Flushing_Method {
            get {
                return this.flushing_MethodField;
            }
            set {
                this.flushing_MethodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Flushing_MethodSpecified {
            get {
                return this.flushing_MethodFieldSpecified;
            }
            set {
                this.flushing_MethodFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Item_Tracking_Code {
            get {
                return this.item_Tracking_CodeField;
            }
            set {
                this.item_Tracking_CodeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/itemqh")]
    public enum Costing_Method {
        
        /// <remarks/>
        FIFO,
        
        /// <remarks/>
        LIFO,
        
        /// <remarks/>
        Specific,
        
        /// <remarks/>
        Average,
        
        /// <remarks/>
        Standard,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/itemqh")]
    public enum Price_Profit_Calculation {
        
        /// <remarks/>
        Profit_x003D_Price_Cost,
        
        /// <remarks/>
        Price_x003D_Cost_x002B_Profit,
        
        /// <remarks/>
        No_Relationship,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/itemqh")]
    public enum Replenishment_System {
        
        /// <remarks/>
        Purchase,
        
        /// <remarks/>
        Prod_Order,
        
        /// <remarks/>
        _blank_,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/itemqh")]
    public enum Manufacturing_Policy {
        
        /// <remarks/>
        Make_to_Stock,
        
        /// <remarks/>
        Make_to_Order,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/itemqh")]
    public enum Flushing_Method {
        
        /// <remarks/>
        Manual,
        
        /// <remarks/>
        Forward,
        
        /// <remarks/>
        Backward,
        
        /// <remarks/>
        Pick__x002B__Forward,
        
        /// <remarks/>
        Pick__x002B__Backward,
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/itemqh")]
    public partial class ItemQH_Filter {
        
        private ItemQH_Fields fieldField;
        
        private string criteriaField;
        
        /// <remarks/>
        public ItemQH_Fields Field {
            get {
                return this.fieldField;
            }
            set {
                this.fieldField = value;
            }
        }
        
        /// <remarks/>
        public string Criteria {
            get {
                return this.criteriaField;
            }
            set {
                this.criteriaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/itemqh")]
    public enum ItemQH_Fields {
        
        /// <remarks/>
        No,
        
        /// <remarks/>
        Description,
        
        /// <remarks/>
        Description_2,
        
        /// <remarks/>
        Created_From_Nonstock_Item,
        
        /// <remarks/>
        Substitutes_Exist,
        
        /// <remarks/>
        Stockkeeping_Unit_Exists,
        
        /// <remarks/>
        Production_BOM_No,
        
        /// <remarks/>
        Routing_No,
        
        /// <remarks/>
        Base_Unit_of_Measure,
        
        /// <remarks/>
        Shelf_No,
        
        /// <remarks/>
        Costing_Method,
        
        /// <remarks/>
        Cost_is_Adjusted,
        
        /// <remarks/>
        Standard_Cost,
        
        /// <remarks/>
        Unit_Cost,
        
        /// <remarks/>
        Last_Direct_Cost,
        
        /// <remarks/>
        Price_Profit_Calculation,
        
        /// <remarks/>
        Profit_Percent,
        
        /// <remarks/>
        Unit_Price,
        
        /// <remarks/>
        Inventory_Posting_Group,
        
        /// <remarks/>
        Gen_Prod_Posting_Group,
        
        /// <remarks/>
        VAT_Prod_Posting_Group,
        
        /// <remarks/>
        Item_Disc_Group,
        
        /// <remarks/>
        Vendor_No,
        
        /// <remarks/>
        Vendor_Item_No,
        
        /// <remarks/>
        Tariff_No,
        
        /// <remarks/>
        Search_Description,
        
        /// <remarks/>
        Overhead_Rate,
        
        /// <remarks/>
        Indirect_Cost_Percent,
        
        /// <remarks/>
        Item_Category_Code,
        
        /// <remarks/>
        Product_Group_Code,
        
        /// <remarks/>
        Blocked,
        
        /// <remarks/>
        Last_Date_Modified,
        
        /// <remarks/>
        Sales_Unit_of_Measure,
        
        /// <remarks/>
        Replenishment_System,
        
        /// <remarks/>
        Purch_Unit_of_Measure,
        
        /// <remarks/>
        Lead_Time_Calculation,
        
        /// <remarks/>
        Manufacturing_Policy,
        
        /// <remarks/>
        Flushing_Method,
        
        /// <remarks/>
        Item_Tracking_Code,
    }
}
