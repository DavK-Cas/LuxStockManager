using SistemaJoyería.Model;
using SistemaJoyería.Model.DTO;
using SistemaJoyería.View.ServerView;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SistemaJoyería.Controller.ServerControl
{
    internal class ControllerServer
    {
        FrmServer ObjServer;
        int origen;

        public ControllerServer(FrmServer View, int origen)
        {
            ObjServer = View;
            verificarOrigen(origen);
            // TabControl 2
            View.btnConnect.Click += new EventHandler(SaveRegistrer);
        }

        public void verificarOrigen(int origen)
        {
            if (origen == 2)
            {
                // Cambiar configuración
                ObjServer.txtServer.Text = DTOdbContext.Server;
                ObjServer.txtDataB.Text = DTOdbContext.Database;
                ObjServer.txtUserS.Text = DTOdbContext.User;
                ObjServer.txtPasswordS.Text = DTOdbContext.Password;
            }
        }

        void SaveRegistrer(object sender, EventArgs e)
        {
            SaveXMLconfiguration();
        }

        #region Configuración del servidor

        public void SaveXMLconfiguration()
        {
            try
            {
                // Se define que tipo de documento se va a crear
                XmlDocument doc = new XmlDocument();

                // Crear declaración XML
                XmlDeclaration decl = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(decl);

                // Crear elemento raíz
                XmlElement root = doc.CreateElement("Conn");
                doc.AppendChild(root);

                // Crear los elementos hijos y agregarlos al elemento raíz
                XmlElement servidor = doc.CreateElement("Server");
                string servidorCode = CodificarBase64String(ObjServer.txtServer.Text.Trim());
                servidor.InnerText = servidorCode;
                root.AppendChild(servidor);

                XmlElement Database = doc.CreateElement("Database");
                string DatabaseCode = CodificarBase64String(ObjServer.txtDataB.Text.Trim());
                Database.InnerText = DatabaseCode;
                root.AppendChild(Database);

                // Se eliminan las condiciones if y else, siempre se pedirá autenticación por SQL
                XmlElement SqlAuth = doc.CreateElement("SqlAuth");
                string sqlAuthCode = CodificarBase64String(ObjServer.txtUserS.Text.Trim());
                SqlAuth.InnerText = sqlAuthCode;
                root.AppendChild(SqlAuth);

                XmlElement SqlPass = doc.CreateElement("SqlPass");
                string SqlPassCode = CodificarBase64String(ObjServer.txtPasswordS.Text.Trim());
                SqlPass.InnerText = SqlPassCode;
                root.AppendChild(SqlPass);

                SqlConnection con = dbContext.testConnection(
                    ObjServer.txtServer.Text.Trim(),
                    ObjServer.txtDataB.Text.Trim(),
                    ObjServer.txtUserS.Text.Trim(),
                    ObjServer.txtPasswordS.Text.Trim()
                );

                if (con != null)
                {
                    doc.Save("config_server.xml");
                    DTOdbContext.Server = ObjServer.txtServer.Text.Trim();
                    DTOdbContext.Database = ObjServer.txtDataB.Text.Trim();
                    DTOdbContext.User = ObjServer.txtUserS.Text.Trim();
                    DTOdbContext.Password = ObjServer.txtPasswordS.Text.Trim();
                    MessageBox.Show("El archivo fue creado exitosamente.", "Archivo de configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ObjServer.Dispose();
                }
            }
            catch (XmlException ex)
            {
                MessageBox.Show($"{ex.Message}, no se pudo crear el archivo de configuración.", "Consulte el manual técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        public string CodificarBase64String(string textoacifrar)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(textoacifrar);
                // Codificación base 64
                string base64String = Convert.ToBase64String(bytes);
                return base64String;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}