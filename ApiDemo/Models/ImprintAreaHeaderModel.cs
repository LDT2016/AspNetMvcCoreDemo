using Taylor.Apl.Dapper;

namespace ApiDemo.Models
{

    public class ImprintAreaHeaderModel
    {
        public string ImprintAreaCode { get; set; }
        public string ImageCodeType { get; set; }
        public string Orientation { get; set; }
        public decimal? MediumPer { get; set; }
        public decimal? SmallPer { get; set; }
        public decimal? AreaWidth { get; set; }
        public decimal? AreaHeight { get; set; }
        public decimal? MaximumPointSize { get; set; }
        public decimal? MinimumPointSize { get; set; }
        public decimal? MaxScalePer { get; set; }
        public decimal? MinScalePer { get; set; }
        public decimal? DesiredScale { get; set; }
        public decimal? Tracking { get; set; }
        public string Slogan { get; set; }
        public string SloganAttribute { get; set; }
        [Column(Name = "ProcessId")]
        public ProcessTypes ProcessType { get; set; }
        public int RRN_Field_Data { get; set; }
        public bool? LogoOnly { get; set; }
    }
}
