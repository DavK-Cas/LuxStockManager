using SistemaJoyería.View.LoginView;
using System;
using System.Text.RegularExpressions;

namespace SistemaJoyería.Controller.LoginController
{
    public class ChangeOriginalPasswordController
    {
        FrmChangeOriginalPassword ObjVista;

        public ChangeOriginalPasswordController(FrmChangeOriginalPassword Vista)
        {
            ObjVista = Vista;
            ObjVista.btnNewPssword.Click += new EventHandler(this.ValidarContraseña);
        }

        private void ValidarContraseña(object sender, EventArgs e)
        {
            string nuevaContraseña = ObjVista.txtNewPassword.Text;
            string confirmarContraseña = ObjVista.txtConfirmPassword.Text;

            // Verificar si cumple con los requisitos
            if (!CumpleConRequisitos(nuevaContraseña))
            {
                // Mostrar mensaje de error (esto podría ser un mensaje en la UI)
                System.Windows.Forms.MessageBox.Show("La contraseña no cumple con los requisitos.");
                return;
            }

            // Verificar si las contraseñas coinciden
            if (nuevaContraseña != confirmarContraseña)
            {
                System.Windows.Forms.MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            // Aquí iría la lógica para cambiar la contraseña si es válida
            System.Windows.Forms.MessageBox.Show("Contraseña cambiada exitosamente.");
        }

        private bool CumpleConRequisitos(string password)
        {
            // Al menos 8 caracteres
            if (password.Length < 8)
                return false;

            // Al menos un signo como % $ #
            if (!Regex.IsMatch(password, @"[!@#$%^&*(),.?""{}|<>]"))
                return false;

            // Al menos una mayúscula A-Z
            if (!Regex.IsMatch(password, @"[A-Z]"))
                return false;

            // Al menos una minúscula a-z
            if (!Regex.IsMatch(password, @"[a-z]"))
                return false;

            // Al menos un número 0-9
            if (!Regex.IsMatch(password, @"[0-9]"))
                return false;

            return true;
        }
    }
}
