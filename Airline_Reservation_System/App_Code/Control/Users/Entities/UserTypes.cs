using Control.Common;

namespace Control.Users.Entities
{
    public class UserTypes : BaseEntity
    {
        private string _typeName;

        public string TypeName
        {
            get => _typeName;
            set => _typeName = value;
        }
    }
}