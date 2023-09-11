using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Db.Entities
{
    public class UserEntiry : BaseEntity
    {
        public string LastName { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Avatar { get; set; } = default!;
    }
}
