using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace SimpleLoginViewModels
{
    public class UserProfileViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [DisplayName("Active ?")]
        public bool IsActive { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
    }
}
