using System;
using System.ComponentModel.DataAnnotations;

namespace DB_College_Management.Model.Professor
{
    /**
    * <summary>Used to bind the form values submitted through POST request to create a professor database model</summary>
    */
    public class CreateBindingModel
    {
        [MaxLength(length: 20)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Qualification { get; set; }

        public long MobileNo { get; set; }

        public string Address { get; set; }

        [MaxLength(length: 50)]
        [EmailAddress]
        public string Email { get; set; }

        public Decimal Salary { get; set; }
    }
}