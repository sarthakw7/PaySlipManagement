using System.ComponentModel.DataAnnotations;

namespace PaySlipManagement.UI.Models
{
    public class HolidayImageViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Image Name")]
        public string ImageName { get; set; }
        [Display(Name = "Image Data")]
        public byte[] ImageData { get; set; }
        [Display(Name = "Content Type")]
        public string ContentType { get; set; }
    }
    public class HolidayPdfViewModel
    {
        public int? Id { get; set; }
        [Display(Name = "File Name")]
        public string? FileName { get; set; }
        public byte[] Data { get; set; }
        [Display(Name = "Content Type")]
        public string ContentType { get; set; }
    }
    public class HolidayImagePDFViewModel
    {
        [Display(Name ="Holiday Image")]
        public HolidayImageViewModel HolidayImage { get; set; }
        [Display(Name = "Holiday Pdf")]
        public HolidayPdfViewModel HolidayPdf { get; set; }
    }


}
