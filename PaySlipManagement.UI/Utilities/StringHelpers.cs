namespace PaySlipManagement.UI.Utilities
{
    public static class StringHelpers
    {
        public static string MaskPanNumber(string PAN_Number)
        {
            if (string.IsNullOrEmpty(PAN_Number) || PAN_Number.Length < 10)
            {
                return PAN_Number;
            }
            return "xxxxxx" + PAN_Number.Substring(6);
        }
        //public static string MaskPFAccountNumber(string PFAccountNumber)
        //{
        //    if (string.IsNullOrEmpty(PFAccountNumber) || PFAccountNumber.Length < 22)
        //    {
        //        return PFAccountNumber; // or throw an exception
        //    }

        //    return "xxxxxx" + PFAccountNumber.Substring(16);
        //}
    }
}
