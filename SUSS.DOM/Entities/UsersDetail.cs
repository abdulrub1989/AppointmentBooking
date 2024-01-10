namespace SUSS.DOM.Entities
{
    public class UsersDetail : BaseEntity
    {
        public int UserID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Gender { get; set; } = 0;
        public string EmailAddress { get; set; } = string.Empty;
        public bool Status { get; set; }
        public string PINumber { get; set; }=string.Empty;
        public string NRICFIN { get; set; } = string.Empty;
        public string Race { get; set; } = string.Empty;
        public string Ethnicity { get; set; } = string.Empty;
        public string Religion { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string MaritalStatus { get; set; } = string.Empty;
        public string HighestQualification { get; set; } = string.Empty;
        public string EnrolmentYearSem { get; set; } = string.Empty;
        public string School { get; set; } = string.Empty;
        public string StudyMode { get; set; } = string.Empty;
        public string ProgramName { get; set; } = string.Empty;
        public string ProgramCode { get; set; } = string.Empty;
        public string ProgramStatus { get; set; } = string.Empty;
        public string JoinedIntake { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public string MyEmailID { get; set; } = string.Empty;
        public string NextKin { get; set; } = string.Empty;
        public override string ToString()
        {
            //return base.ToString();
            return $"UserID :{UserID}, Full Name:{FullName}, Gender:{Gender}, EmailID:{EmailAddress}, MobileNo:{MobileNo}";
        }

    }
}
