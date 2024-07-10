using iText.Html2pdf;
using iText.Kernel.Exceptions;
using iText.Kernel.Pdf;
using PayslipManagement.Common.Models;


namespace PaySlipManagement.Common.Utilities
{
    public class GeneratePDF
    {
        

    }
    public static class NumberToWordsConverter
    {
        private static readonly string[] UnitsMap = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private static readonly string[] TensMap = { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private static readonly string[] TeensMap = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

        public static string ConvertToWords(decimal number)
        {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return "Minus " + ConvertToWords(Math.Abs(number));

            var parts = number.ToString("F2").Split('.');
            var integerPart = Convert.ToInt64(parts[0]);
            var decimalPart = Convert.ToInt32(parts[1]);

            var words = ConvertWholeNumberToWords(integerPart);

            //if (decimalPart > 0)
            //{
            //    words += " Point " + ConvertWholeNumberToWords(decimalPart);
            //}

            return words;
        }

        private static string ConvertWholeNumberToWords(long number)
        {
            if (number == 0)
                return string.Empty;

            if (number < 10)
                return UnitsMap[number];

            if (number < 20)
                return TeensMap[number - 10];

            if (number < 100)
                return TensMap[number / 10] + (number % 10 > 0 ? " " + ConvertWholeNumberToWords(number % 10) : string.Empty);

            if (number < 1000)
                return UnitsMap[number / 100] + " Hundred" + (number % 100 > 0 ? " and " + ConvertWholeNumberToWords(number % 100) : string.Empty);

            if (number < 1000000)
                return ConvertWholeNumberToWords(number / 1000) + " Thousand" + (number % 1000 > 0 ? " " + ConvertWholeNumberToWords(number % 1000) : string.Empty);

            if (number < 1000000000)
                return ConvertWholeNumberToWords(number / 1000000) + " Million" + (number % 1000000 > 0 ? " " + ConvertWholeNumberToWords(number % 1000000) : string.Empty);

            return ConvertWholeNumberToWords(number / 1000000000) + " Billion" + (number % 1000000000 > 0 ? " " + ConvertWholeNumberToWords(number % 1000000000) : string.Empty);
        }
    }
}
