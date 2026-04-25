using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Model
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Customer_Name { get; set; }
        [Required(ErrorMessage = "DOB is required")]
        [DataType(DataType.Date)]
        public DateTime Customer_DOB { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Contact is required")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter only numeric values")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Number must be 10 digits")]
        public string Contact { get; set; }
       
        public string status { get; set; }

        public int CreatedBy { get; set; }

        public DateOnly CreatedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateOnly? ModifiedAt { get; set; }

        public int? DeletedBy { get; set; }

        public DateOnly? DeletedAt { get; set; }
        public ICollection<Customer_Address> Address { get; set; }

        //one customer to many policy
        public ICollection<InsurancePolicy> Policies { get; set; }
    }
}
