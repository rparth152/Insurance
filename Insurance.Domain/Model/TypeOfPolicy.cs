using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Model
{
    public class TypeOfPolicy
    {
        [Key]
        public int Type_Id { get; set; }
        public string Type_Name { get; set; }
        public string Description { get; set; }


        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? DeletedAt { get; set; }
        public ICollection<InsurancePolicy> Policies { get; set; }
    }
}
