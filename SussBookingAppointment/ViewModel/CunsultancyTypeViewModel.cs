using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SussBookingAppointment.ViewModel
{
    public class CunsultancyTypeViewModel
    {
        public string EmailID { get; set; }
        [Required(ErrorMessage = "Cunsultancy Type is Required !")]
        public int CunsultancyID { get; set; }
        public IEnumerable<SelectListItem>? CunsultancyTypes { get; set; }=null;
    }
}
