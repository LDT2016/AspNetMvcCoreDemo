using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Interface;
using ApiDemo.Library.Contracts;
using ApiDemo.Models;
using AutoMapper;

namespace ApiDemo.Library
{
    public class TestProductLib : ITestProductLib
    {
        private readonly ITestProductService _service;
        private readonly IMapper _mapper;
        public TestProductLib(ITestProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        public async Task<IList<TestProduct>> GetTestProduct()
        {
            var products = await _service.GetTestProduct();

            foreach (var prod in products)
            {
                if (!string.IsNullOrEmpty(prod.ItemId))
                {
                    prod.VendorId = (await _service.GetProductVendorId(prod.ItemId)).FirstOrDefault().ToString();
                    //var imprintColor = await GetImprintColor(prod.ItemId);
                    //prod.ImprintColorType = imprintColor.Item1;
                    //prod.MaxImprintColorCount = imprintColor.Item2;
                }

            }


            return products;

        }
        public static readonly string[] MatchTrimCode = { "MAT", "MAC", "TRM", "MCT", "ICL", "SEO" };
        public const string PPTFECODE_VRSID = "VRSID";
        public const string PPTFECODE_SENTI = "SENTI";
        public const string LetterY = "Y";
        private async Task<Tuple<string, int>> GetImprintColor(string itemId)
        {
            var imprintFormatModelDict = await GetImprintFormats(itemId, string.Empty);

            var imprints = imprintFormatModelDict.Values.ToList();
            var lstImprintAreaCode = imprints.Select(i => i.ImprintAreaCode).Distinct().ToList();
            var maxColorCount = -1;
            var imprintColorType = "";
            foreach (var imprintAreaCode in lstImprintAreaCode)
            {
                var imprintColors = await GetImprintColors(itemId, imprintAreaCode);

                var maxCount = imprintColors[imprintAreaCode].MaxColorCount;
                if (maxCount > maxColorCount)
                {
                    maxColorCount = maxCount;
                    var colors = imprintColors[imprintAreaCode].ImprintColor;
                    var hasPmsColor = colors.Any(i => i.ColorId.Equals("Pms", StringComparison.OrdinalIgnoreCase));
                    var hasTrimColor = colors.Any(i => MatchTrimCode.Contains(i.ColorId, StringComparer.OrdinalIgnoreCase));
                    var hasDigitalColor = colors.Any(i => i.ColorId.Equals("Dig", StringComparison.OrdinalIgnoreCase));

                    if (hasPmsColor && hasTrimColor)
                    {
                        imprintColorType = "Pms and Match Trim Color";
                    }
                    else if (hasPmsColor)
                    {
                        imprintColorType = "Pms";
                    }
                    else if (hasTrimColor)
                    {
                        imprintColorType = "Match Trim Color";
                    }
                    else if (hasDigitalColor)
                    {
                        imprintColorType = "Digital";
                    }
                }


            }
            return new Tuple<string, int>(imprintColorType, maxColorCount);
        }

        public async Task<Dictionary<string, ImprintFormatModel>> GetImprintFormats(string itemId, string defaultImprintAreaCode)
        {
            var imprintFormats = await _service.GetImprintFormat(itemId);
            var imprintFormatModels = _mapper.Map<List<ImprintFormatModel>>(imprintFormats);
            var imprintAreaHeaderList = new List<ImprintAreaHeaderModel>();

            if (!string.IsNullOrWhiteSpace(defaultImprintAreaCode) && imprintFormats.Count == 0)
            {
                var defaultImprintFormatModel = GetNaFormat(defaultImprintAreaCode);
                var imprintAreaHeaderRecord = await _service.GetImprintAreaHeader(defaultImprintAreaCode);
                imprintAreaHeaderList.Add(imprintAreaHeaderRecord);
                defaultImprintFormatModel.ProcessType = imprintAreaHeaderRecord.ProcessType;
                imprintFormatModels.Add(defaultImprintFormatModel);
            }

            foreach (var imprintFormat in imprintFormatModels)
            {
                var verseSequence = await _service.GetVerseSequenceByImageCode(imprintFormat.ImprintAreaCode, PPTFECODE_VRSID);

                imprintFormat.VerseAvailable = verseSequence > 0;

                if (verseSequence > 0)
                {
                    var autoDefaultVerse = await _service.AllowAutoDefaultVerse(imprintFormat.ImprintAreaCode, PPTFECODE_VRSID);
                    imprintFormat.AutoDefaultVerse = autoDefaultVerse;
                }
                var sentimentSequence = await _service.GetSentimentSequenceByImageCode(imprintFormat.ImprintAreaCode, PPTFECODE_SENTI);
                imprintFormat.SentimentAvailable = sentimentSequence > 0;

                imprintFormat.Description = imprintFormat.Description;

                var bo = imprintAreaHeaderList.Find(y => y.ImprintAreaCode.Equals(imprintFormat.ImprintAreaCode, StringComparison.OrdinalIgnoreCase));

                if (bo == null)
                {
                    bo = await _service.GetImprintAreaHeader(imprintFormat.ImprintAreaCode);
                    imprintAreaHeaderList.Add(bo);
                }

                imprintFormat.SloganAvailable = bo.Slogan.Equals(LetterY, StringComparison.OrdinalIgnoreCase);
            }

            return imprintFormatModels.ToDictionary(x => x.Key, x => x);
        }

        /// <summary>
        /// get Not Application ImprintFormat
        /// </summary>
        /// <param name="defaultImprintAreaCodeKey">default ImprintAreaCode</param>
        /// <returns>Not Application ImprintFormat</returns>
        private ImprintFormatModel GetNaFormat(string defaultImprintAreaCodeKey)
        {
            var fomat = new ImprintFormatModel
                        {
                            ImprintAreaCode = defaultImprintAreaCodeKey,
                            Description = GeneralConstant.StandardDescription,
                            ImprintRule = GeneralConstant.NotApplicable,
                            ImprintGroup = GeneralConstant.NotApplicable,
                            StyleId = GeneralConstant.NotApplicable,
                            Location = GeneralConstant.NotApplicable,
                            Sequence = -1
                        };

            return fomat;
        }

        public async Task<Dictionary<string, ImprintColorInfoModel>> GetImprintColors(string itemId, string imprintAreaCode = null)
        {
            var imprintColorModel = await _service.GetImprintColors(itemId, imprintAreaCode);

            var imprintColorModelWithCLR = imprintColorModel.Where(c => c.ColorId.EndsWith("-CLR"))
                                                            .ToList();

            var lstColorId = imprintColorModelWithCLR.Select(c => c.ColorId)
                                                     .ToList();

            var lstColorCount = lstColorId.Select(colorId => int.Parse(colorId.Split('-')[0]))
                                          .ToList();

            var maxColorCount = lstColorCount.Count > 0
                                    ? lstColorCount.Max()
                                    : 1;

            var imprintColorInfoModel = new ImprintColorInfoModel
                                        {
                                            MaxColorCount = maxColorCount,
                                            ImprintColor = imprintColorModel.Except(imprintColorModelWithCLR)
                                                                            .ToList()
                                        };

            var dicImprintColors = new Dictionary<string, ImprintColorInfoModel>
                                   {
                                       { imprintAreaCode, imprintColorInfoModel }
                                   };

            return dicImprintColors;
        }
    }
}
