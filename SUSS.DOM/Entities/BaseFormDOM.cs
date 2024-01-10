namespace SUSS.DOM.Entities
{
    public class BaseFormDOM
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CounsellingID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public bool Status { get; set; }
        public string PINumber { get; set; } = string.Empty;
        public int BookingID { get; set; }
    }
}
