using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aot.User.Store.Entities
{
    public class UserGroupRole : BaseEntity
    {
        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string GroupId { get; set; }
        public virtual Group Group { get; set; }

        [Required]
        public string RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
