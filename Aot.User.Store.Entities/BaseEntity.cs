using System;
using System.ComponentModel.DataAnnotations;

namespace Aot.User.Store.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime CreateOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
