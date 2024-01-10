using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUSS.DOM.EmailEnitiies
{
    public class EmailTemplate
    {
        public string Subject { get; set; }
        public string HtmlBody { get; set; }
        public string EmailTo { get; set; }
        public string BCC_recipients { get; set; }
        public string CC_recipients { get; set; }
        public string BookingID { get; set; }
    }
}
