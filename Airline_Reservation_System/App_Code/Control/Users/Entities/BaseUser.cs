using System.Collections.Generic;
using Control.Common;

namespace Control.Users.Entities
{
    public class BaseUser : BaseEntity
    {
        private string UserName { get; set; }
        private string Password { get; set; }
        private ICollection<Authority> Authorities { get; set; }
    }
}