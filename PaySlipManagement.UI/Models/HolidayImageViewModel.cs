namespace PaySlipManagement.UI.Models
{
    public class HolidayImageViewModel
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
    }
    public class HolidayPdfViewModel
    {
        public int? Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }
    }
    public class HolidayImagePDFViewModel
    {
        public HolidayImageViewModel HolidayImage { get; set; }
        public HolidayPdfViewModel HolidayPdf { get; set; }
    }


}
