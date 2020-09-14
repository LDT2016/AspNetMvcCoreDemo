using System.Collections.Generic;

namespace ApiDemo.Models
{
    public class TestPageModel
    {
        public string ServerIp { get; set; }
        public IList<TestProduct> ProductList { get; set; }
    }
    public class TestProduct
    {
        /// <summary>
        /// 
        /// </summary>
        public string ItemId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Bom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? Vignette { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? FoldLine { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? MultipleSides { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Upsell { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? Prop65 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VendorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? Verse { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? Sentiment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Slogan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? ImprintRequired { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? GroupedQuantity { get; set; }
        public string ImprintColorType { get; set; }
        public int MaxImprintColorCount { get; set; }
    }
}
