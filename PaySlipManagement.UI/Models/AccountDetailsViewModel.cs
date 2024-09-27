
using PaySlipManagement.UI.Utilities;
using System.ComponentModel.DataAnnotations;

namespace PaySlipManagement.UI.Models
{
    public class AccountDetailsViewModel
    {
        public int? Id { get; set; }
        public String Emp_Code { get; set; }
        public String BankName { get; set; }

        [RegularExpression(@"^\d{9,18}$", ErrorMessage = "The bank account number must be between 9 and 18 digits long.")]
        public long BankAccountNumber { get; set; }
        public string MaskedBankAccountNumber => StringHelpers.MaskBankAccountNumber(BankAccountNumber);

        [RegularExpression(@"^\d{12}$", ErrorMessage = "The UAN number must be 12 digits long.")]
        public long UANNumber { get; set; }
        public string MaskedUanNumber => StringHelpers.MaskUanNumber(UANNumber);

        [RegularExpression(@"^[A-Z]{2,6}\d{11,20}$", ErrorMessage = "The PF account number must be in the format XX-1234567-0000 (where X is an alphabet and 0 is a digit).")]
        public String PFAccountNumber { get; set; }
        
        public string MaskedPfAccountNumber => StringHelpers.MaskPfAccountNumber(PFAccountNumber);


    }
}
