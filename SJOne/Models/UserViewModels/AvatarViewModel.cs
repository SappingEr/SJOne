using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models
{
    public class AvatarViewModel
    {
        public long Id { get; set; }

        public bool Delete { get; set; }

        [DataType(DataType.Upload)]        
        public byte[] Avatar { get; set; }
    }
}