using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Domain.Model;

namespace Insurance.Application.DTO
{
    public class Customer_addressDTO
    {
        public int Customer_Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PinCode { get; set; }
        public string? status { get; set; }
    }
}
