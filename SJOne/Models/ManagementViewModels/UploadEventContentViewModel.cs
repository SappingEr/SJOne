using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJOne.Models.ManagementViewModels
{
    public class UploadEventContentViewModel
    {
        public long Id { get; set; }

        public HttpPostedFileBase[] Content { get; set; }
    }
}