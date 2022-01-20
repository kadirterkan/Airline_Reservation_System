using System.Collections.Generic;
using Control.Common;

namespace Control.Users.Entities
{
    public class BaseUser : BaseEntity
    {
        private string _userName;
        private string _password;
        private string _eMail;
        private List<Authority> _authorities;

        public string UserName
        {
            get => _userName;
            set => _userName = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public string EMail
        {
            get => _eMail;
            set => _eMail = value;
        }

        public List<Authority> Authorities
        {
            get => _authorities;
            set => _authorities = value;
        }

        public void AddAuthorityToUser(Authority authority)
        {
            _authorities.Add(authority);
        }
    }
}