using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace MORM.CrossCutting
{
    public static class MailExtensions
    {
        #region variaveis
        private readonly static string _servidorEmail;
        private readonly static string _portaEmail;
        private readonly static string _usuarioEmail;
        private readonly static string _senhaEmail;
        #endregion

        #region construtores
        static MailExtensions()
        {
            _servidorEmail = ConfigurationManager.AppSettings["servidorEmail"] ?? "smtp-mail.outlook.com";
            _portaEmail = ConfigurationManager.AppSettings["portaEmail"] ?? "587";
            _usuarioEmail = ConfigurationManager.AppSettings["usuarioEmail"] ?? "ccbcianorte@hotmail.com";
            _senhaEmail = ConfigurationManager.AppSettings["senhaEmail"] ?? "ccb@cianorte";

        }
        #endregion

        #region metodos
        public static void Enviar(string emailPara, string assunto, string conteudo)
        {
            var client = new SmtpClient(_servidorEmail);

            int.TryParse(_portaEmail, out int portaEmail);

            client.Port = portaEmail;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(_usuarioEmail, _senhaEmail);

            try
            {
                var mail = new MailMessage(_usuarioEmail.Trim(), emailPara.Trim());
                mail.Subject = assunto;
                mail.Body = conteudo;
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }        
        #endregion
    }
}