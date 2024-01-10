using System.ComponentModel.DataAnnotations;

namespace SUSS.DOM.Entities
{
    public class LoginModel
    {
        public int ID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Gender { get; set; } = 0;
        [Required(ErrorMessage = "Email-ID is Required !")]
        public string EmailAddress { get; set; }
        //[Required(ErrorMessage = "Password is Required !")]
        public string Password { get; set; }= "Test@123";		
		public bool Status { get; set; }
    }
}
