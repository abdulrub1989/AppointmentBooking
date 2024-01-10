using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUSS.DOM.Entities
{
    public class ApproverDOM
    {
        public UsersDetail Users_Detail { get; set; }
        public UserRegistration Form_D { get; set; }
        public FormM Form_M { get; set; }
        public FormN Form_N { get; set; }
        public FormO Form_O { get; set; }
        public string ApproverID { get; set; }
    }
}
