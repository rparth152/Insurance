using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Model
{
    public class Customer_Address
    {
        [Key]
        public int Address_Id { get; set; }
        public int Customer_Id { get; set; }
        [ForeignKey("Customer_Id")]
        public Customer Customer { get; set; } 
        //[Required(ErrorMessage ="Req")]
        public string? Street { get; set; } 
        //[Required(ErrorMessage = "Req")]
        public string? City { get; set; } 
        //[Required(ErrorMessage = "Req")]
        public string? State { get; set; } 
        //[Required(ErrorMessage = "Req")]
        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter only numeric values")]

        public string? PinCode { get; set; } 
        public string? status { get; set; } = "Active";

        public int CreatedBy { get; set; }

        public DateOnly CreatedAt { get; set; }

        public int? ModifiedBy { get; set; } = null;

        public DateOnly? ModifiedAt { get; set; } = null;

        public int? DeletedBy { get; set; } = null;

        public DateOnly? DeletedAt { get; set; } = null;
    }
}
