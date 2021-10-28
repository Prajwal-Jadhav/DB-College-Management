

using System;
using System.ComponentModel.DataAnnotations;

namespace DB_College_Management.Model.Student
{
    public class CreateBindingModel
    {
        [Required]
        [MaxLength(length: 100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(length: 30)]
        public string PRN { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(length: 50)]
        public string Email { get; set; }

        [Required, DataType(DataType.PhoneNumber)]
        public long MobileNo { get; set; }

        [Required]
        public string Address { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        public int Year { get; set; }
    }
}