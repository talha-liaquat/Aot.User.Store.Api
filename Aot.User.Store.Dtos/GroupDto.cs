using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aot.User.Store.Dtos
{
    public class GroupDto
    {
        [Required]
        public string Title { get; set; }
    }
}
