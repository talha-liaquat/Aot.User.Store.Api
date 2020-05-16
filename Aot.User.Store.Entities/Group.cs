using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aot.User.Store.Entities
{
    public class Group : BaseEntity
    {
        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        public virtual ICollection<UserGroupRole> UserGroupRoles { get; set; }
    }
}
