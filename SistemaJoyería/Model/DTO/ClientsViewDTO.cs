using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaJoyería.Model.DTO
{
    public class ClientsViewDTO : dbContext
    {
        private int idClient;

        private string firstName;

        private string lastName;

        private string phone;

        private string email;

        private DateTime birthDate;

        private string identityDocument;

        private string addressClient;

        public int IdClient { get => idClient; set => idClient = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string IdentityDocument { get => identityDocument; set => identityDocument = value; }
        public string AddressClient { get => addressClient; set => addressClient = value; }
    }
}
