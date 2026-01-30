using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaJoyería.Model.DTO
{
    internal class DTOSecurityQuestions : dbContext
    {
        private string usuario;
        private string pregunta1;
        private string pregunta2;
        private string pregunta3;

        public string Usuario { get => usuario; set => usuario = value; }
        public string Pregunta1 { get => pregunta1; set => pregunta1 = value; }
        public string Pregunta2 { get => pregunta2; set => pregunta2 = value; }
        public string Pregunta3 { get => pregunta3; set => pregunta3 = value; }
    }
}
