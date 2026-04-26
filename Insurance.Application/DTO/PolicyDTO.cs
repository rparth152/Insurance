using Insurance.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.DTO
{
    public class PolicyDTO
    {
        public string Policy_Name { get; set; }
        public int Customer_Id { get; set; }
        public int PolicyType_Id { get; set; }
        public DateOnly Policy_Start { get; set; }
        public DateOnly Policy_End { get; set; }
        public int Premium_Ammount { get; set; }
        public string Status { get; set; }
    }
}
