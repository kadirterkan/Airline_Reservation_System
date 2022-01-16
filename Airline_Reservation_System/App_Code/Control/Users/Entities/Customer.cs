using Control.Common;

namespace Control.Users.Entities
{
    public class Customer : BaseEntity
    {
        private string Username { get; set; }
        private Passenger.Passenger Passenger { get; set; }
        private string Password { get; set; }
    }
}