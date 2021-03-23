using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;

namespace CultureCompare.Shared
{
    public class CultureDTO
    {
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string ShortDatePattern { get; set; }
        public string LongDatePattern { get; set; }
        public string ShortTimePattern { get; set; }
        public string LongTimePattern { get; set; }
        public string NumberDecimalSeparator { get; set; }
        public string NumberGroupSeparator { get; set; }
        public string CurrencyDecimalSeparator { get; set; }
        public string CurrencyGroupSeparator { get; set; }
        public string CurrencySymbol { get; set; }
        public static CultureDTO[] GetAllCultures()
        {
            List<CultureInfo> selectedCultures =
                new List<CultureInfo>(CultureInfo.GetCultures(CultureTypes.AllCultures).Length);

            var allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures)
                              .OrderBy(c => c.Name, StringComparer.Ordinal);

            foreach (CultureInfo ci in allCultures)
            {
                try
                {
                    if (!string.IsNullOrEmpty(ci.DateTimeFormat.ShortDatePattern))
                        selectedCultures.Add(ci);
                }
                catch (Exception)
                {
                }
            }
            return selectedCultures.Select(c => new CultureDTO
            {
                Name = c.Name,
                EnglishName = c.EnglishName,
                ShortDatePattern = c.DateTimeFormat.ShortDatePattern,
                LongDatePattern = c.DateTimeFormat.LongDatePattern,
                ShortTimePattern = c.DateTimeFormat.ShortTimePattern,
                LongTimePattern = c.DateTimeFormat.LongTimePattern,
                NumberDecimalSeparator = c.NumberFormat.NumberDecimalSeparator,
                NumberGroupSeparator = c.NumberFormat.NumberGroupSeparator,
                CurrencyDecimalSeparator = c.NumberFormat.CurrencyDecimalSeparator,
                CurrencyGroupSeparator = c.NumberFormat.CurrencyGroupSeparator,
                CurrencySymbol = c.NumberFormat.CurrencySymbol
            }).ToArray();
        }
        //public static bool operator == (CultureDTO x, CultureDTO y)
        //{
        //    if (x == null && y == null)
        //        return true;
        //    if (x == null || y == null)
        //        return false;

        //    return x.Name.Equals(y.Name, StringComparison.Ordinal)
        //        && x.EnglishName.Equals(y.EnglishName, StringComparison.Ordinal)
        //        && x.ShortDatePattern.Equals(y.ShortDatePattern, StringComparison.Ordinal)
        //        && x.LongDatePattern.Equals(y.LongDatePattern, StringComparison.Ordinal)
        //        && x.ShortTimePattern.Equals(y.ShortTimePattern, StringComparison.Ordinal)
        //        && x.LongTimePattern.Equals(y.LongTimePattern, StringComparison.Ordinal)
        //        && x.NumberDecimalSeparator.Equals(y.NumberDecimalSeparator, StringComparison.Ordinal)
        //        && x.NumberGroupSeparator.Equals(y.NumberGroupSeparator, StringComparison.Ordinal)
        //        && x.CurrencyDecimalSeparator.Equals(y.CurrencyDecimalSeparator, StringComparison.Ordinal)
        //        && x.CurrencyGroupSeparator.Equals(y.CurrencyDecimalSeparator, StringComparison.Ordinal)
        //        && x.CurrencySymbol.Equals(y.CurrencySymbol, StringComparison.Ordinal);
        //}
        //public static bool operator !=(CultureDTO x, CultureDTO y)
        //{
        //    return !(x == y);
        //}
        //public override bool Equals(Object obj)
        //{
        //    return obj is CultureDTO && this == (CultureDTO)obj;
        //}
        //public override int GetHashCode()
        //{
        //    return Name.GetHashCode();
        //}
    }
}
