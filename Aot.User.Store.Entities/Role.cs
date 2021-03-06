﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aot.User.Store.Entities
{
    public class Role : BaseEntity
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<UserGroupRole> UserGroupRoles { get; set; }
    }
}
