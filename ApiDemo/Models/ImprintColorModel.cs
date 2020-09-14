namespace ApiDemo.Models
{
    public class ImprintColorModel
    {
        public string ColorId { get; set; }
        public string ColorReference { get; set; }
        public string ColorDescription { get; set; }
        public ColorType ColorType => ColorId == "PMS" ? ColorType.Pms : ColorId == "DIG" ? ColorType.Digital : ColorType.Traditional;
    }
}
