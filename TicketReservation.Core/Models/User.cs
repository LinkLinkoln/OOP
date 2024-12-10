using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TicketReservation.Core.Models
{
    public class User
    {
        private User(Guid id, string lastName, string firstName, string email, string phone) 
        { 
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Phone = phone;
        }
        public Guid Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

        public static (User User, string Error) Create(Guid id, string firstName, string lastName, string email, string phone)
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(firstName))
            {
                sb.Append("First Name can not be empty");
            }

            var user = new User(id, lastName, firstName, email, phone);

            return (user, sb.ToString());
        }
    }
}
