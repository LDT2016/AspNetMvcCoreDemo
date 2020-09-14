namespace ApiDemo.Models
{
    /// <summary>
    /// the constants for app
    /// </summary>
    /// <remarks>
    /// the naming convention: Pascal without underscore(_)
    /// </remarks>
    public static class GeneralConstant
    {
        public const string Pms = "PMS";
        public const string CustomPms = "Custom PMS:{0}";
        public const int MaxExtraMarginWidth = 20;
        public const int QuantityOverflow = -1;
        public const string Space = " ";
        public const string SpaceHtml = "%20";
        public const string CultureinfoEnUs = "en-US";
        public const string Dash = "-";
        public const char Comma = ',';
        public const string Semicolon = ";";
        public const string Underline = "_";
        public const string QuestionMark = "?";
        public const string And = "&";
        public const string SlashSlash = "//";
        public const string Https = "https:";
        public const string Http = "http:";
        public const string Equals = "=";
        public static readonly int[] AmsterdamVendors = new int[] { 100010, 100020, 100030, 100050, 100060, 100070, 31 };
        public static readonly string[] MatchTrimCode = {"MAT", "MAC", "TRM", "MCT", "ICL", "SEO"};

        #region Imprint
        public const string NoImprint = "No Imprint";
        public const string DefaultThumbnailExtension = ".jpg";
        public const string ImprintDescription = "Imprint";
        public const string NotApplicable = "NA";
        public const string StandardDescription = "STANDARD";
        public const string ThumbnailPath = "/resources/assets/imprint/location/{0}.jpg";
        public const string ThumbnailPathWithoutExtension = "/resources/assets/imprint/location/{0}";
        public const string LocationNone = "_NONE";
        public const string EndChar = " & ";
        public const string LetterG = "G";
        public const string LetterS = "S";
        public const string LetterY = "Y";
        public const string Logo = "LOGO";
        public const string OutputPdfExt = "_edited.pdf";
        public const string DefaultFontValue = "H";
        public const string DefaultFontText = "HELVETICA                001";
        public const string DefaultFontSize = "S";
        public const string DefaultColorValue = "BLK";
        public const string DefaultColorText = "BLACK";
        public const string DefaultImprintPositionCode = "STD";
        public const string DefaultImprintPositionDescription = "standard";
        public const string LogoLocationCode = "LOGO";
        public const string None = "NONE";

        #endregion

        public const int ImageProductionMaxDimension = 2000;
        public const string NucleusHost = "https://nucleus.promotionalstore.com/";
        public const string NucleusUserGenerateContent = "api/v1/entity/Promo/content/";
        public const string NucleusImage = "/image";
        public const string NucleusImageColorize = "op_colorize";
        public const string NucleusWidth = "wid";

        //Upload
        public const string SLASH = "/";
        public const string LOGO_FOLDER = "logos/";
        public const string API_UPLOAD_LOGO = "api/v1/uploadlogo";
        public const string IMAGING_SERVICE_STATE_KEY = "ImagingServiceStateData";
        public const decimal DecimalValueOfNotAvailable = -1m;
        public const string StringValueOfNotAvailable = "N/A";
        public const int Scene7MaxDimension = 2000;
        public const int PreviewMaxDimension = 500;
        public const int Dpi72 = 72;
        public const string DigitalPdfFolder = "Digital-PDF\\";
        public const string CustomerDesignsFolder = "Customer-Designs\\Model\\";
        public const string PngFileExtension = ".png";

        //Bom
        public const string SelectionTypeMultiple = "M";
        public const string SelectionTypeSingle = "S";
        public const string CalendarYearQuestionCode = "CYR";
        public static readonly string DictionaryKeyDelimiter = new string((char)157, 1);
        public const string DefaultHeading = "Product option";
        //
        public const string FolderRootPathIndicator = "~";

        public const string PromotionalStore = "PromotionalStore/";
        //shipping
        public const string TbdShippingText = "TBD";
        public const string ShippingMethodFree = "FREE";
        public const string DefaultShippingId = "UPSG";

        //text
        public const string CustomTextDefaultValue = "Custom Text";

        public const string PPTFECODE_VRSID = "VRSID";
        public const string PPTFECODE_SENTI = "SENTI";
        public const string VERSESCENE7FOLDER = "PromotionalStore/verse_";
        public const string SENTIMENTSCENE7FOLDER = "PromotionalStore/sentiment_";
    }
    public class LOGOTYPE
    {
        public const string UPLOADLOGO = "CST";
        public const string STOCKART = "STK";
        public const string SLOGAN = "SLO";
        public const string SHAREDART = "SHR";
        public const string STATIC = "STC";
        public const string SAVEDART = "SAV";
    }
}
