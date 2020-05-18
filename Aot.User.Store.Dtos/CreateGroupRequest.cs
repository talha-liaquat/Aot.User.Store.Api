using System.ComponentModel.DataAnnotations;

namespace Aot.User.Store.Dtos
{
    public class CreateGroupRequest
    {
        [Required]
        public string Title { get; set; }
    }
}
