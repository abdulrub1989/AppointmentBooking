namespace SUSS.DAL
{
    internal class DBConstant
    {

        #region Suss Booking System
        public const string CheckIsUserValid = "PROC_CheckIsUserValid";
        public const string CheckUserIsvalidByEmailID = "PROC_CheckUserIsvalidByEmailID";
        public const string GetUsersDetailByMyEmailID = "PROC_GetUsersDetailByMyEmailID";
        public const string SelectUsersDetail = "PROC_GetUsersDetail";
        public const string SelectUsersDetailById = "PROC_GetUsersDetailById";

        public const string CreateBooing = "PROC_CreateBooing";
        public const string CreateFormD = "PROC_CreateFormD";
        public const string CreateFormM = "PROC_CreateFormM";
        public const string CreateFormN = "PROC_CreateFormN";
        public const string CreateFormO = "PROC_CreateFormO";
        #endregion
        #region Approvers
        public const string GetCounsellingMaster = "PROC_GetCounsellingMaster";
        public const string GetApproverDetailByBookingID = "PROC_GetApproverDetailByBookingID";
        public const string ApproverRequest = "PROC_UpdateApproveStatus";
        #endregion
    }
}
