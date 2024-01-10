namespace SUSS.DOM.Entities
{
    public abstract class BaseEntity
    {
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string? ModifiedBy { get; set; }
        public int? Error_Code { get; set; } = 0;
        public string Error_Message { get; set; } = string.Empty;
    }
}
