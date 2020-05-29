using Taylor.Apl.Dapper;

namespace ApiDemo.Models
{
    public class ImprintFormatBO
    {
        #region properties

        public string Description { get; set; }
        public string ImprintAreaCode { get; set; }
        public string ImprintGroup { get; set; }
        public string ImprintRule { get; set; }
        public string IsDefault { get; set; }
        public string Location { get; set; }
        public bool LogoOnly { get; set; }


        public int ProcessId
        {
            get; set;
        }
        //[Column(Name = "ProcessId")]
        //public ProcessTypes ProcessType
        //{
        //    get; set;
        //}
        public int Sequence { get; set; }
        public string ShowOnWeb { get; set; }
        public string StyleId { get; set; }

        #endregion
    }

    public enum ProcessTypes
    {
        ScreenPrinted = 1,
        HotStamped = 2,
        LaserEngraved = 3,
        Embroidered = 4,
        Deboss = 5,
        VendorDigital = 6,
        DigitalCeramicMug = 7,
        DigitalWaterBottle14 = 8,
        DigitalTumbler = 10,
        DigitalMixingGlass = 11,
        DigitalPen = 12,
        DigitalWaterBottle17 = 13,
        DigitalPens = 14,
        DigitalPocCal = 15,
        DigitalPocCalHor = 16,
        Digital7x10Cal = 17,
        DigitalMagnets = 18,
        DigitalBudPro = 19,
        DigitalBudWall = 20,
        DigitalDigitalWall = 21,
        DigitalFlipCalendars = 22,
        DigitalNotepad = 23,
        DigitalAtm = 24,
        DigitalApparel = 25,
        DigitalMimaki = 26,
        EnhancedImprintsLaser = 27,
        MultiImprtLaserPenBarrl = 28,
        MultiImprtLaserPenCap = 29,
        LaserVendor = 30,
        DrinkWareRimLine = 31,
        OneClrInkJet = 33,
        FoilFusing = 34,
        FullColorScreened = 35,
        IlluminatedLaser = 36,
        ColoredIlluminatedLaser = 37,
        DigitalIlluminatedLaser = 38,
        FullColorInkjetSoftex = 50,
        InactiveImprintAreaCode = 999
    }
}


//the 1st commit
//the 2nd commit
//the 3th commit