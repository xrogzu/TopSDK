using System;
using Top.Api.Domain;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.wlb.waybill.get
    /// </summary>
    public class WlbWaybillGetRequest : ITopRequest<WlbWaybillGetResponse>
    {
        /// <summary>
        /// 顺丰(SF)、EMS(标准快递：EMS；经济快件：EYB)、宅急送(ZJS)、圆通(YTO)、中通(ZTO)、百世汇通(HTKY)、优速(UC)、申通(STO)、天天快递 (TTKDEX)、全峰 (QFKD)、快捷(FAST)
        /// </summary>
        public string CpCode { get; set; }

        /// <summary>
        /// 发货 地址
        /// </summary>
        public string ShippingAddress { get; set; }

        /// <summary>
        /// 订单数据
        /// </summary>
        public string TradeOrderInfoCols { get; set; }

        private IDictionary<string, string> otherParameters;

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.wlb.waybill.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cp_code", this.CpCode);
            parameters.Add("shipping_address", this.ShippingAddress);
            parameters.Add("trade_order_info_cols", this.TradeOrderInfoCols);
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("cp_code", this.CpCode);
            RequestValidator.ValidateRequired("shipping_address", this.ShippingAddress);
            RequestValidator.ValidateRequired("trade_order_info_cols", this.TradeOrderInfoCols);
            RequestValidator.ValidateMaxListSize("trade_order_info_cols", this.TradeOrderInfoCols, 1000);
        }

        #endregion

        public void AddOtherParameter(string key, string value)
        {
            if (this.otherParameters == null)
            {
                this.otherParameters = new TopDictionary();
            }
            this.otherParameters.Add(key, value);
        }
    }
}
