using System;

namespace MORM.Apresentacao.Report
{
    public class RelatorioEmail : IRelatorioEmail
    {
        public RelatorioEmail(string nome, string email)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        public string Nome { get; set; }
        public string Email { get; set; }
    }
}