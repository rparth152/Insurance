using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.DTO
{
    public class UpdateCustomerDTO
    {
        public int Customer_Id { get; set; }
        public string Customer_Name { get; set; }
        public DateTime Customer_DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string status { get; set; }

    }
}
