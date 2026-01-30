using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace SistemaJoyería.Model.DTO
{
    public class UserViewDTO : dbContext
    {
        private int IDUser;

        private string UserName;

        private string Password;

        private string UserEmail; 

        private string Estado;

        private string idRoles;

        public int IDUser1 { get => IDUser; set => IDUser = value; }
        public string UserName1 { get => UserName; set => UserName = value; }
        public string Password1 { get => Password; set => Password = value; }
        public string UserEmail1 { get => UserEmail; set => UserEmail = value; }
        public string Estado1 { get => Estado; set => Estado = value; }
        public string IdRoles1 { get => idRoles; set => idRoles = value; }
    }
}
