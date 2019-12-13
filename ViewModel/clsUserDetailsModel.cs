using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class clsUserDetailsModel: clsUserModel
    {
        public int iUserDetailsId { get; set; }
        public string sName { get; set; }
        public string sSurname { get; set; }
        public string sAddress { get; set; }
        public string sEmail { get; set; }
        public string sFixLine { get; set; }
        public string sFax { get; set; }
        public string sMobile { get; set; }
        public string sWebsite { get; set; }
        public string sNote { get; set; }
        public string sCompany { get; set; }
        public string sBRN { get; set; }
        public UserType eUserType { get; set; }
        public int iCountryId { get; set; }
        public bool bStatus { get; set; }
    }

    
}
