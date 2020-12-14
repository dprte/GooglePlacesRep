using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Aircash.Shared.Components
{
    public class NumberFormat
    {
        private NumberFormat _numberFormat;
        private NumberFormat()
        {

        }
        public NumberFormat Instance()
        {
            if (_numberFormat == null)
            {
                _numberFormat = new NumberFormat();
            }
            return _numberFormat;
        }
        public static NumberFormatInfo GetFormat()
        {
            return new NumberFormatInfo {
                NegativeSign = "-",
                NumberDecimalSeparator = "."
            };
        }
    }
}
