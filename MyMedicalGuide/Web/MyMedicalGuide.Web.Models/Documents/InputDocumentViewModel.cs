using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyMedicalGuide.Web.Models.Documents
{
    public class InputDocumentViewModel
    {
        public string RealFileName { get; set; }

        public HttpPostedFileBase Document { get; set; }

    }
}
