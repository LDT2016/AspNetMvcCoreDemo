using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDemo.Models.ui.locations
{
    public class Format
    {
        #region properties

        public string Description { get; set; }
        public string ImprintAreaCode { get; set; }
        public string ImprintGroup { get; set; }
        public string ImprintRule { get; set; }
        public bool IsDefault { get; set; }
        public bool IsInsideCover => Description.IndexOf("inside", StringComparison.OrdinalIgnoreCase) >= 0;

        public string Key
        {
            get
            {
                var builder = new StringBuilder();
                builder.Append(ImprintAreaCode);
                builder.Append("-");
                builder.Append(Location);
                builder.Append("-");
                builder.Append(StyleId);

                return builder.ToString();
            }
        }

        public string Location { get; set; }
        public bool LogoOnly { get; set; }
        public ProcessTypes ProcessType { get; set; }
        public int Sequence { get; set; }
        public bool ShowOnWeb { get; set; }
        public string StyleId { get; set; }

        #endregion

        #region nested types

        public class FormatCompare : IComparer<Format>
        {
            #region methods

            public int Compare(Format x, Format y)
            {
                if (x.IsDefault == y.IsDefault)
                {
                    if (x.ImprintRule.Equals(y.ImprintRule, StringComparison.OrdinalIgnoreCase))
                    {
                        if (x.Sequence == y.Sequence)
                        {
                            return string.Compare(y.Description, x.Description, StringComparison.OrdinalIgnoreCase);
                        }

                        return y.Sequence.CompareTo(x.Sequence);
                    }

                    return string.Compare(y.ImprintRule, x.ImprintRule, StringComparison.OrdinalIgnoreCase);
                }

                return x.IsDefault
                           ? 1
                           : -1;
            }

            #endregion
        }

        #endregion
    }
}
