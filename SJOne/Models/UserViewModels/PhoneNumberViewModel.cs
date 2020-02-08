using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJOne.Models.UserViewModels
{
    public class PhoneNumberViewModel
    {
        public long Id { get; set; }

        [StringLength(12, ErrorMessage = "Превышено количество допустимых символов(не более 12).")]
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"\+7[0-9]{10}", ErrorMessage = "Введите номер без пробелов и дефисов. Возможно Вы пропустили цифру.")]        
        public string PhoneNumber { get; set; }
    }
}