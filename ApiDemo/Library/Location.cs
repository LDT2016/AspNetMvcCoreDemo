using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ApiDemo.Interface;
using ApiDemo.Library.Contracts;
using ApiDemo.Models;
using ApiDemo.Models.ui.locations;
using ApiDemo.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace ApiDemo.Library
{
    using Combinations = List<Combination>;

    public class Location : ILocation
    {
        #region fields

        public const string NOIMPRINT = "No Imprint";
        public const string DefaultThumbnailFileExtension = ".jpg";
        public const string IMPRINTDESC = "Imprint";
        public const string LETTER_Y = "Y";
        public const string NOTAPPLICABLE = "NA";
        public const string Semicolon = ";";
        public const string STANDARDDESC = "STANDARD";
        public const string ThumbnailPath = "/resources/icons/imprint/location/{0}.jpg";
        public const string ThumbnailPathWithoutFileExtension = "/resources/icons/imprint/location/{0}";

        // ImprintLocationOptions
        public const string Underline = "_";

        //public const string LocationBg = "url(/resources/icons/imprint/location/{0})";
        protected const string EndChar = " & ";
        protected const string LocationNone = "_NONE";
        private const char Comma = ',';
        private const string LetterG = "G";
        private const string LetterS = "S";
        private readonly IHostingEnvironment _hostingEnvironment;
        //private int _len;
        private readonly ILocationsService _locationsService;
        private readonly IMapper _mapper;

        #endregion

        #region constructors

        public Location(IHostingEnvironment hostingEnvironment, ILocationsService locationsService, IMapper mapper)
        {
            _locationsService = locationsService;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        #endregion

        #region methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async Task<Locations> GetLocations(string itemId)
        {
            var locations = await _locationsService.GetLocations(itemId);

            var formats = _mapper.Map<List<Format>>(locations);
            var groups = GetOptionCombinationList(formats);
            return new Locations
                   {
                       Formats = formats.ToDictionary(x => x.Key, x => x),
                       Groups = groups.ToDictionary(x => x.Name, x => x),
                       //testDic = testDic
                   };

            //var testDic = new Dictionary<string , string>();
            //testDic.Add("PCL", "TRM");
            //return await Task.Run(() => new Locations
            //{
            //    Formats = formats.ToDictionary(x => x.Key, x => x),
            //    Groups = groups,
            //    //testDic = testDic
            //});
        }
        private static void InitAutoMapper()
        {
            try
            {

            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void LocationThumbnailPathGenerator(Combination imprintFormatGroup, List<Format> formats, out string bgFileName, out string tnFilename, out string tempNoneTnNm)
        {
            var combinedFormats = formats.FindAll(x => imprintFormatGroup.Formats.Contains(x.Key))
                                         .ToList();

            //CombinationsText
            imprintFormatGroup.CombinationsText = string.Join(EndChar,
                                                              combinedFormats.Select(x => x.Description.ToTitleCaseAdvance())
                                                                             .ToArray()).ToTitleCaseAdvance();

            var connectImprintgroup = string.Join(Semicolon,
                                                  combinedFormats.Select(x => x.ImprintGroup.ToTitleCaseAdvance())
                                                                 .ToArray());

            var connectLocation = string.Join(Semicolon,
                                              combinedFormats.Select(x => x.Location.ToTitleCaseAdvance())
                                                             .ToArray());

            var connectStyleId = string.Join(Semicolon,
                                             combinedFormats.Select(x => x.StyleId.ToTitleCaseAdvance())
                                                            .ToArray());

            var lstGroups = formats.Select(f => f.ImprintGroup)
                                   .Distinct()
                                   .ToList();
            var needCombineGroup = lstGroups.Count > 1 && lstGroups.Count == formats.Count;

            var locationCom = new StringBuilder();

            /*
             * Old
             */
            //Location
            var lstLocation = connectLocation.Split(Semicolon.ToCharArray())
                                             .OrderBy(txt => txt)
                                             .ToList();

            foreach (var code in lstLocation)
            {
                locationCom.Append(code.ToUpperAdvance());
            }

            //GroupName
            var groupCom = (needCombineGroup
                                ? connectImprintgroup.Replace(Semicolon, string.Empty)
                                : connectImprintgroup.Split(Semicolon.ToCharArray())[0]).ToUpperAdvance();

            var backgroundFileNameOld = string.Concat(groupCom, Underline, locationCom)
                                              .ToRemoveSpace();

            /*
             * New
             */
            var backgroundFileNameNew = new StringBuilder();

            var locations = connectLocation.Split(Semicolon.ToCharArray())
                                           .ToList();

            var styleIDs = connectStyleId.Split(Semicolon.ToCharArray())
                                         .ToList();

            var imprintGroups = connectImprintgroup.Split(Semicolon.ToCharArray())
                                                   .ToList();

            if (locations.Count == styleIDs.Count && imprintGroups.Count == styleIDs.Count)
            {
                var nameLength = locations.Count;

                for (var k = 0; k < nameLength; k++)
                {
                    if (k == 0)
                    {
                        backgroundFileNameNew.Append(imprintGroups[k]
                                                         .ToUpper());
                    }
                    else if (needCombineGroup)
                    {
                        backgroundFileNameNew.Append(Underline);

                        backgroundFileNameNew.Append(imprintGroups[k]
                                                         .ToUpper());
                    }

                    backgroundFileNameNew.Append(Underline);

                    backgroundFileNameNew.Append(locations[k]
                                                     .ToUpper());
                    backgroundFileNameNew.Append(Underline);

                    backgroundFileNameNew.Append(styleIDs[k]
                                                     .ToUpper());
                }
            }

            tempNoneTnNm = backgroundFileNameNew.ToString();

            try
            {
                var combination = backgroundFileNameNew.ToString()
                                                       .ToRemoveSpace();
                var thumbnailFilename = _locationsService.GetImprintThumbnailFilename(combination);

                if (!string.IsNullOrEmpty(thumbnailFilename) && File.Exists(_hostingEnvironment.WebRootPath + string.Format(ThumbnailPathWithoutFileExtension, thumbnailFilename)))
                {
                    bgFileName = combination;
                    tnFilename = thumbnailFilename;
                }
                else if (File.Exists(_hostingEnvironment.WebRootPath
                                     + string.Format(ThumbnailPath,
                                                     backgroundFileNameNew.ToString()
                                                                          .ToRemoveSpace())))
                {
                    bgFileName = backgroundFileNameNew.ToString()
                                                      .ToRemoveSpace();
                    tnFilename = bgFileName + DefaultThumbnailFileExtension;
                }
                else
                {
                    bgFileName = backgroundFileNameOld.ToRemoveSpace();
                    tnFilename = bgFileName + DefaultThumbnailFileExtension;
                }
            }
            catch (Exception)
            {
                bgFileName = backgroundFileNameOld.ToRemoveSpace();
                tnFilename = bgFileName + DefaultThumbnailFileExtension;
            }
        }

        private static bool CombinationResult(string outindex, int lastIndex, Format[] imps)
        {
            var rel = false;

            if (outindex.Length == 0)
            {
                rel = true;
            }
            else
            {
                var indexArr = outindex.Split(Comma);

                if (indexArr.Length > 1)
                {
                    foreach (var index in indexArr)
                    {
                        rel = CombinationResult(index, lastIndex, imps);

                        if (!rel)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    if (imps[Convert.ToInt32(indexArr[0])]
                        .ImprintRule.Trim()
                        .ToUpper()
                        == LetterG
                        || imps[lastIndex]
                           .ImprintRule.Trim()
                           .ToUpper()
                        == LetterG)
                    {
                        rel = true;
                    }
                    else
                    {
                        var rule = imps[Convert.ToInt32(indexArr[0])]
                                   .ImprintRule.Trim()
                                   .ToUpper();

                        var lastRule = imps[lastIndex]
                                       .ImprintRule.Trim()
                                       .ToUpper();

                        if (rule.Length > 0 && lastRule.Length > 0)
                        {
                            if (rule.Substring(0, 1) == LetterS && lastRule.Substring(0, 1) == LetterS && rule.Remove(0, 1) == lastRule.Remove(0, 1))
                            {
                                rel = true;
                            }
                        }
                    }
                }
            }

            return rel;
        }

        private void AddNoneImprintFormat(IList<Combination> combinations, List<Format> formats)
        {
            //var combinedFormats = formats.FindAll(x => combinations[0].Formats.Contains(x.Key)).ToList();

            var noneImprintFormat = GetNaFormat(NOTAPPLICABLE);

            var noneImprintFormatGroup = new Combination
            {
                Index = combinations.Count,
                Formats = new List<string>
                                                       {
                                                           noneImprintFormat.Key
                                                       },
                CombinationsText = NOIMPRINT
            };

            var lstGroups = formats.Select(f => f.ImprintGroup)
                                   .Distinct()
                                   .ToList();
            var needCombineGroup = lstGroups.Count > 1 && lstGroups.Count == formats.Count;

            // GroupName
            var groupCom = combinations.Count > 0
                               ? needCombineGroup ? string.Join(string.Empty,
                                                                formats.FindAll(x => combinations[0]
                                                                                     .Formats.Contains(x.Key))
                                                                       .ToList()
                                                                       .NewSort()
                                                                       .Select(x => x.ImprintGroup))
                                                          .ToUpperAdvance() : formats.FindAll(x => combinations[0]
                                                                                                   .Formats.Contains(x.Key))
                                                                                     .ToList()
                                                                                     .NewSort()[0]
                                                                                     .ImprintGroup.ToUpperAdvance()
                               : string.Empty;

            var genericNoneNm = combinations.Count > 0
                                    ? string.Concat(formats.FindAll(x => combinations[0]
                                                                         .Formats.Contains(x.Key))
                                                           .ToList()
                                                           .FirstOrDefault(x => x.IsDefault)
                                                           ?.ImprintGroup.ToUpperAdvance(),
                                                    LocationNone)
                                            .ToRemoveSpace()
                                    : string.Concat(groupCom, LocationNone)
                                            .ToRemoveSpace();

            var newNoneNm = string.Empty;

            foreach (var formatGroup in combinations)
            {
                var firstFormat = formats.FindAll(x => formatGroup.Formats.Contains(x.Key))
                                         .ToList()
                                         .NewSort()
                                         .First();

                if (firstFormat != null && firstFormat.IsDefault)
                {
                    newNoneNm = string.Concat(formatGroup.BackgroundFileName, LocationNone)
                                      .ToRemoveSpace();

                    break;
                }
            }

            if (newNoneNm.Length == 0 && combinations.Count > 0)
            {
                newNoneNm = string.Concat(combinations[0]
                                              .TempNoImprintThumbnailNm,
                                          LocationNone)
                                  .ToRemoveSpace();
            }

            string bgFileName;
            string tnFilename;

            try
            {
                var thumbnailFilename = _locationsService.GetImprintThumbnailFilename(newNoneNm);

                if (!string.IsNullOrEmpty(thumbnailFilename) && File.Exists(_hostingEnvironment.WebRootPath + string.Format(ThumbnailPathWithoutFileExtension, thumbnailFilename)))
                {
                    bgFileName = newNoneNm;
                    tnFilename = thumbnailFilename;
                }
                else if (File.Exists(_hostingEnvironment.WebRootPath + string.Format(ThumbnailPath, newNoneNm)))
                {
                    bgFileName = newNoneNm;
                    tnFilename = newNoneNm + DefaultThumbnailFileExtension;
                }
                else
                {
                    bgFileName = genericNoneNm;
                    tnFilename = genericNoneNm + DefaultThumbnailFileExtension;
                }
            }
            catch (Exception)
            {
                bgFileName = genericNoneNm;
                tnFilename = genericNoneNm + DefaultThumbnailFileExtension;
            }

            //BackgroundFileName
            noneImprintFormatGroup.BackgroundFileName = bgFileName;

            //ThumbnailFilename
            noneImprintFormatGroup.ThumbnailFilename = tnFilename;

            formats.Add(noneImprintFormat);
            combinations.Add(noneImprintFormatGroup);
        }


        private Combinations GetCombination(List<Format> lstFormats)
        {
            //var impFormats = lstFormats.NewSort().ToArray();
            var impFormats = lstFormats.NewSort()
                                       .ToArray();
            var len = impFormats.Length;
            
            var iIndex = new int[len];

            for (var i = 0; i < len; i++)
            {
                iIndex[i] = i;
            }

            var combinationIndex = new List<string>();

            for (var j = 1; j <= iIndex.Length; j++)
            {
                combinationIndex.AddRange(GetIndex(iIndex, 0, j, string.Empty, len, ref impFormats));
            }

            var combination = new Combinations();

            foreach (var com in combinationIndex)
            {
                var indexArr = com.Split(Comma);

                var formats = indexArr.Select(t => impFormats[Convert.ToInt32(t)])
                                      .ToList();

                combination.Add(new Combination
                {
                    Formats = formats.Select(x => x.Key)
                                                     .ToList()
                });
            }

            return combination;
        }

        private List<string> GetIndex(int[] k, int start, int wanted, string outindex, int len, ref Format[] imprints)
        {
            var lstRel = new List<string>();

            if (wanted == 0)
            {
                lstRel.Add(outindex.TrimStart(Comma));
            }
            else
            {
                var lastIndex = len - wanted;

                for (var i = start; i <= lastIndex; i++)
                {
                    var rel = CombinationResult(outindex.TrimStart(Comma), k[i], imprints);

                    if (rel)
                    {
                        lstRel.AddRange(GetIndex(k,
                                                 i + 1,
                                                 wanted - 1,
                                                 string.Concat(outindex,
                                                               Comma,
                                                               k[i]
                                                                   .ToString()),
                                                 len,
                                                 ref imprints));
                    }
                }
            }

            return lstRel;
        }


        private Format GetNaFormat(string defaultImprintAreaCodeKey)
        {
            var fomat = new Format
            {
                ImprintAreaCode = defaultImprintAreaCodeKey,
                Description = STANDARDDESC,
                ImprintRule = NOTAPPLICABLE,
                ImprintGroup = NOTAPPLICABLE,
                StyleId = NOTAPPLICABLE,
                Location = NOTAPPLICABLE,
                Sequence = -1
            };
            //todo:ProcessType,LogoOnly??? from ImprintAreaCode
            //if (imprintAreaHeaderDict != null && !string.IsNullOrEmpty(defaultImprintAreaCodeKey))
            //{
            //    var imprintAreaHeader = imprintAreaHeaderDict.Contains(defaultImprintAreaCodeKey) ? imprintAreaHeaderDict[defaultImprintAreaCodeKey] : null;
            //    if (imprintAreaHeader != null)
            //    {
            //        var imprintAreaHeaderBo = (ImprintAreaHeaderBO)imprintAreaHeader;
            //        fomat.ProcessType = imprintAreaHeaderBo.ProcessType;
            //        fomat.LogoOnly = imprintAreaHeaderBo.LogoOnly;
            //    }
            //}

            return fomat;
        }

        private List<ApiDemo.Models.ui.locations.ImprintGroup> GetOptionCombinationList(List<Format> formats)
        {
            //var groups = new Dictionary<string, Combinations>();
            var groups = new List<ApiDemo.Models.ui.locations.ImprintGroup>();


            //var lstCombination = new List<Combinations>();
            Combinations combination;

            //get distinct group name
            var lstGroups = formats.Select(f => f.ImprintGroup)
                                   .Distinct()
                                   .ToList();

            if (lstGroups.Count == 1)
            {
                combination = GetCombination(formats);

                //lstCombination.Add(combination);
                //if (!groups.ContainsKey(lstGroups[0]))
                if (!groups.Any(x => x.Name.Equals(lstGroups[0], StringComparison.OrdinalIgnoreCase)))
                {
                    groups.Add(new ImprintGroup
                               {
                                   Name = lstGroups[0],
                                   Combinations = combination
                               });
                }
            }
            else
            {
                foreach (var gName in lstGroups)
                {
                    var _groupDivide = formats.FindAll(m => m.ImprintGroup == gName)
                                              .ToList();
                    combination = GetCombination(_groupDivide);

                    //lstCombination.Add(combination);
                    //if (!groups.ContainsKey(gName))
                    //{
                    //    groups.Add(gName, combination);
                    //}
                    if (!groups.Any(x => x.Name.Equals(gName, StringComparison.OrdinalIgnoreCase)))
                    {
                        groups.Add(new ImprintGroup
                                   {
                                       Name = gName,
                                       Combinations = combination
                                   });
                    }

                }
            }

            foreach (var group in groups)
            {
                for (var j = 0; j
                                < group.Combinations.Count; j++)
                {
                    group.Combinations[j]
                         .Index = j;
                    ImprintFormatGroupInitialze(group.Combinations[j], formats);
                }

                //todo:!SessionMgr.Item.IsImprintRequired
                if (true) //(!SessionMgr.Item.IsImprintRequired)
                {
                    AddNoneImprintFormat(group.Combinations, formats.NewSort());
                }
            }



            //foreach (var gname in groups.Keys)
            //{
            //    for (var j = 0; j
            //                    < groups[gname]
            //                        .Count; j++)
            //    {
            //        groups[gname][j]
            //            .Index = j;
            //        ImprintFormatGroupInitialze(groups[gname][j], formats);
            //    }

            //    if (true) //(!SessionMgr.Item.IsImprintRequired)
            //    {
            //        AddNoneImprintFormat(groups[gname], formats.NewSort());
            //    }
            //}

            //if (true)//(!SessionMgr.Item.IsImprintRequired)
            //{
            //    for (int i = 0; i < groups.Count; i++)
            //    {
            //        AddNoneImprintFormat(groups[i]
            //                                 .Combinations,
            //                             formats);
            //    }
            //}
            return groups;
        }


        /// <summary>
        /// ImprintFormatGroupInitialze
        /// </summary>
        /// <param name="lstDefaultItem">for IsSelected, selected option by edit from database</param>
        /// <param name="imprintFormatGroup"></param>
        private void ImprintFormatGroupInitialze(Combination imprintFormatGroup, List<Format> formats)
        {
            //var imprintFormats = formats.FindAll(x=> imprintFormatGroup.Formats.Contains(x.Key)).ToList();

            ////CombinationsText
            //imprintFormatGroup.CombinationsText = string.Join(EndChar, imprintFormats.Select(x => x.Description.ToTitleCaseAdvance()).ToArray());

            //var formatImprintgroup = string.Join(Semicolon, imprintFormats.Select(x => x.ImprintGroup.ToTitleCaseAdvance()).ToArray());
            //var formatLocation = string.Join(Semicolon, imprintFormats.Select(x => x.Location.ToTitleCaseAdvance()).ToArray());
            //var formatStyleId = string.Join(Semicolon, imprintFormats.Select(x => x.StyleId.ToTitleCaseAdvance()).ToArray());
            //string bgFileName, tnFilename, tempNoneTnNm;

            //TODO
            LocationThumbnailPathGenerator(imprintFormatGroup, formats, out var bgFileName, out var tnFilename, out var tempNoneTnNm);

            //BackgroundFileName
            imprintFormatGroup.BackgroundFileName = bgFileName;

            //ThumbnailFilename
            imprintFormatGroup.ThumbnailFilename = tnFilename;

            //NoImprintThumbnailFilename
            imprintFormatGroup.TempNoImprintThumbnailNm = tempNoneTnNm;

            //IsSelected
            //imprintFormatGroup.IsSelected = string.Empty;

            //todo:IsSelected
            //if (imprintFormats.Count == lstDefaultItem.Count)
            //{
            //    var tempFormats = imprintFormats;
            //    FormatSort(ref tempFormats);
            //    FormatSort(ref lstDefaultItem);
            //    if (tempFormats.SequenceEqual(lstDefaultItem, new FormatsComparer()))
            //    {
            //        //IsSelected
            //        imprintFormatGroup.IsSelected = "1";
            //    }
            //}
            //todo:OptionCharge
            //imprintFormatGroup.OptionCharge = CalculateOptionCharge(imprintFormats).ToString(CultureInfo.InvariantCulture);
        }



        #region FormatSort

        private static void FormatSort(ref List<Format> imprintFormats)
        {
            var formatobj = new Format();
            var sortByImprintAreaCode = new Rank<Format>(formatobj, "ImprintAreaCode", RankInfo.DirectionType.Desc);
            var sortByStyleId = new Rank<Format>(formatobj, "StyleId", RankInfo.DirectionType.Desc);
            var sortByLocation = new Rank<Format>(formatobj, "Location", RankInfo.DirectionType.Desc);
            imprintFormats.Sort(sortByImprintAreaCode);
            imprintFormats.Sort(sortByStyleId);
            imprintFormats.Sort(sortByLocation);
        }


        private decimal CalculateOptionCharge(List<Format> imprintFormatGroup)
        {
            var charge = 0m;

            //if (imprintFormatGroup == null || imprintFormatGroup.Count == 0) return charge;
            //if (!Vendor.AllowPrice || SessionMgr.Item == null) return charge;

            //if (imprintFormatGroup.Count > 1)
            //{
            //    var additionalImprintCharges = ImprintOptionsBL.GetLocationCharge(SessionMgr.Item);
            //    var qty = SessionMgr.Item.StudioItemOptions.Quantity;
            //    charge = ImprintOptionsBL.GetLocationChargesTotal(additionalImprintCharges, qty) * (imprintFormatGroup.Count - 1);
            //    foreach (var format in imprintFormatGroup)
            //    {
            //        charge += GetInsideCoverCharge(format);
            //        charge += GetSuperSizedEngravingCharge(format);
            //    }
            //    return charge;
            //}

            //charge = GetInsideCoverCharge(imprintFormatGroup.First());
            //if (charge > 0m) return charge;

            //charge = GetSuperSizedEngravingCharge(imprintFormatGroup.First());
            return charge;
        }
        private decimal GetInsideCoverCharge(Format format)
        {
            var charge = 0m;

            //if (format == null || !format.IsInsideCover) return charge;
            //if (!Vendor.AllowPrice || SessionMgr.Item == null) return charge;

            //var insideCoverCharge = SessionMgr.Item.Charges.Find(m => !m.IsNotAvailable && m.ChargeConditionNumber.Equals((int)SpecialChargeCondition.CustomizeYourInsideCover));
            //if (insideCoverCharge == null) return charge;

            //var insideCoverChargeList = new List<ChargeModel> { insideCoverCharge };
            //var qty = SessionMgr.Item.StudioItemOptions.Quantity;
            //charge = ImprintOptionsBL.GetLocationChargesTotal(insideCoverChargeList, qty);
            return charge;
        }

        private decimal GetSuperSizedEngravingCharge(Format format)
        {
            var charge = 0m;

            //if (!Vendor.AllowPrice || SessionMgr.Item == null || format == null) return charge;

            //var isSuperSizedEngraving = format.Description.IndexOf("Super-Sized", StringComparison.OrdinalIgnoreCase) >= 0;
            //var superSizedEngravingCharge = SessionMgr.Item.Charges.Find(m => !m.IsNotAvailable && m.ChargeConditionNumber.Equals((int)SpecialChargeCondition.LogoEnhancement));
            //if (!isSuperSizedEngraving || superSizedEngravingCharge == null) return charge;

            //var superSizedEngravingChargeList = new List<ChargeModel> { superSizedEngravingCharge };
            //var qty = SessionMgr.Item.StudioItemOptions.Quantity;
            //charge = ImprintOptionsBL.GetLocationChargesTotal(superSizedEngravingChargeList, qty);
            return charge;
        }

        #endregion


        #endregion

        #region nested types

        public struct RankInfo
        {
            public enum DirectionType
            {
                Asc = 0,
                Desc
            }

            public string Name
            {
                set; get;
            }
            public DirectionType Direction
            {
                set; get;
            }
        }

        protected class Rank<T> : IComparer<T>
        {
            #region fields

            private readonly Type _type;
            private RankInfo _info;

            #endregion

            #region constructors

            public Rank(T t, string name, RankInfo.DirectionType direction)
            {
                _type = t.GetType();
                _info.Name = name;
                _info.Direction = direction;
            }

            #endregion

            #region methods

            private static void Swap(ref object x, ref object y)
            {
                var temp = x;
                x = y;
                y = temp;
            }

            int IComparer<T>.Compare(T t1, T t2)
            {
                var x = _type.InvokeMember(_info.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty, null, t1, null);
                var y = _type.InvokeMember(_info.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty, null, t2, null);

                if (_info.Direction != RankInfo.DirectionType.Asc)
                {
                    Swap(ref x, ref y);
                }

                return new CaseInsensitiveComparer().Compare(x, y);
            }

            #endregion
        }

        private class FormatsComparer : IEqualityComparer<Format>
        {
            #region methods

            public bool Equals(Format x, Format y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                {
                    return false;
                }

                return x.ImprintAreaCode.ToUpperAdvance() == y.ImprintAreaCode.ToUpperAdvance() && x.StyleId.ToUpperAdvance() == y.StyleId.ToUpperAdvance() && x.Location.ToUpperAdvance() == y.Location.ToUpperAdvance();
            }

            public int GetHashCode(Format format)
            {
                // Check whether the object is null
                if (ReferenceEquals(format, null))
                {
                    return 0;
                }

                // Get hash code for the field if it is not null.
                var hashImprintAreaCode = format.ImprintAreaCode?.GetHashCode() ?? 0;
                var hashDescription = format.Description?.GetHashCode() ?? 0;
                var hashStyleId = format.StyleId?.GetHashCode() ?? 0;
                var hashLocation = format.Location?.GetHashCode() ?? 0;

                // Calculate the hash code for the Format.
                return hashImprintAreaCode ^ hashDescription ^ hashStyleId ^ hashLocation;
            }

            #endregion
        }

        #endregion
    }
}
