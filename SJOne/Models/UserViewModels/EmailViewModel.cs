using System.ComponentModel.DataAnnotations;

namespace SJOne.Models.UserViewModels
{
    public class EmailViewModel
    {
        public long Id { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}