using System.ComponentModel.DataAnnotations;

namespace SJOne.Models.UserViewModels
{
    public class InfoUserViewModel
    {
        public long Id { get; set; }

        public byte[] Avatar { get; set; }

        public string Data { get; set; }

        [Display(Name = "Пол")]
        public Gender Gender { get; set; }

        [Display(Name = "Населённый пункт")]
        public string Locality { get; set; }

        [Display(Name = "Спортивный клуб")]
        public string Club { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        public bool EmptyProp { get; set; }
    }
}