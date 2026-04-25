using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Model
{
    public class InsurancePolicy
    {
        [Key]
        public int Policy_Id { get; set; }
        public string Policy_Name { get; set; }
        public int Customer_Id { get; set; }
        [ForeignKey("Customer_Id")]
        public Customer Customer { get; set; }
        public int PolicyType_Id { get; set; }
        [ForeignKey("PolicyType_Id")]
        public TypeOfPolicy PolicyType { get; set; }
        public DateOnly Policy_Start { get; set; }
        public DateOnly Policy_End { get; set; }
        public int Premium_Ammount { get; set; }
        public string Status { get; set; }

        public int CreatedBy { get; set; }

        public DateOnly CreatedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateOnly? ModifiedAt { get; set; }

        public int? DeletedBy { get; set; }

        public DateOnly? DeletedAt { get; set; }

    }
}
