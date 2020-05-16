using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aot.User.Store.Entities
{
    public class User : BaseEntity
    {
        [StringLength(1000)]
        public string Token { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public virtual ICollection<UserGroupRole> UserGroupRoles { get; set; }
    }
}
