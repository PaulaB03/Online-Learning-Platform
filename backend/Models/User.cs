using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public virtual Instructor Instructor { get; set; }
    }
}
