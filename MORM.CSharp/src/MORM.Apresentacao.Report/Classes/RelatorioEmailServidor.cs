using MORM.Apresentacao.Report.Interfaces;
using System;

namespace MORM.Apresentacao.Report.Classes
{
    public class RelatorioEmailServidor : IRelatorioEmailServidor
    {
        public RelatorioEmailServidor(string nome, string username, string password, string host, string port)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Host = host ?? throw new ArgumentNullException(nameof(host));
            Port = port ?? throw new ArgumentNullException(nameof(port));
        }

        public string Nome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
    }
}