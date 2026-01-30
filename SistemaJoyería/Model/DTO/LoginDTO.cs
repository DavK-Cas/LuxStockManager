using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaJoyería.Model.DTO
{
    public class DTOLogin : dbContext
    {

        private int IDUser;

        private string LoginName;

        private string Password;

        private string UserEmail;

        private bool Estado;

        private int idRol;

        public int IDUser1 { get => IDUser; set => IDUser = value; }
        public string LoginName1 { get => LoginName; set => LoginName = value; }
        public string Password1 { get => Password; set => Password = value; }
        public string UserEmail1 { get => UserEmail; set => UserEmail = value; }
        public bool Estado1 { get => Estado; set => Estado = value; }
        public int IdRol { get => idRol; set => idRol = value; }
    }
}

