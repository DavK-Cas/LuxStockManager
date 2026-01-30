using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaJoyería.Model.DTO
{
    public class EmployeesViewDTO : dbContext
    {
        private int idEmployees;

        private string firstNameEmployees ;

        private string LastNameEmployees;

        private string PhoneEmployees;

        private string EmailEmployees;

        private DateTime BirthDateEmployees;

        private string IdentityDocumentEmployees;

        private string AddressEmployees;

        public int IdEmployees { get => idEmployees; set => idEmployees = value; }
        public string FirstNameEmployees { get => firstNameEmployees; set => firstNameEmployees = value; }
        public string LastNameEmployees1 { get => LastNameEmployees; set => LastNameEmployees = value; }
        public string PhoneEmployees1 { get => PhoneEmployees; set => PhoneEmployees = value; }
        public string EmailEmployees1 { get => EmailEmployees; set => EmailEmployees = value; }
        public DateTime BirthDateEmployees1 { get => BirthDateEmployees; set => BirthDateEmployees = value; }
        public string IdentityDocumentEmployees1 { get => IdentityDocumentEmployees; set => IdentityDocumentEmployees = value; }
        public string AddressEmployees1 { get => AddressEmployees; set => AddressEmployees = value; }
    }
}
