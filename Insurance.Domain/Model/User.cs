                            using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, StringLength(30)]
        public string UserFullName { get; set; }

        [Required, EmailAddress, StringLength(25)]
        public string Email { get; set; }

        [Required, StringLength(200)]
        public string PassWord { get; set; }

        [Required, StringLength(12)]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; } = true;

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? DeletedAt { get; set; }
        public string? TwoFactorSecret { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Roles Role { get; set; }
    }
}
