using Control.Common;

namespace Control.Users.Entities
{
    public class Authority : BaseEntity
    {
        private string _authorityName;

        public string AuthorityName
        {
            get => _authorityName;
            set => _authorityName = value;
        }
    }
}