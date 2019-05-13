using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models
{
    public class InfoUserViewModel
    {
        public long Id { get; set; }

        public byte[] Avatar { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Дата рождения")]
        public virtual DateTime? DOB { get; set; }

        [Display(Name = "Пол")]
        public string Gender { get; set; }

        [Display(Name = "Город")]
        public string City { get; set; }

        [Display(Name = "Клуб")]
        public string Club { get; set; }

        public bool EmptyProp => string.IsNullOrWhiteSpace(Email) &&
                        string.IsNullOrWhiteSpace(Name) &&
                        string.IsNullOrWhiteSpace(Surname) &&
                        string.IsNullOrWhiteSpace(DOB.ToString()) &&
                        string.IsNullOrWhiteSpace(Gender) &&
                        string.IsNullOrWhiteSpace(City) &&
                        string.IsNullOrWhiteSpace(Club);
    }
}