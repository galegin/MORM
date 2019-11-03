using MORM.CrossCutting;
using System.IO;
using System.Linq;

namespace MORM.Apresentacao.Report
{
    public partial class Relatorio
    {
        public void Enviar(string nomeArquivo = null, RelatorioFormato? formato = null)
        {
            var arquivo = this.GetNomeArquivo(nomeArquivo);
            var formatoExp = this.GetFormato(formato);
            var conteudo = this.GetConteudoExportacao(formatoExp);
            File.WriteAllLines(arquivo, conteudo);

            var emailParaMail = string.Join(";", Emails.ToList().ConvertAll(e => e.Email));
            var assuntoMail = Titulo;
            var conteudoMail = "Exportacao de relatorio";
            var anexosMail = new[] { arquivo };

            MailExtensions.Enviar(
                emailPara: emailParaMail,
                assunto: assuntoMail,
                conteudo: conteudoMail,
                anexos: anexosMail);
        }
    }
}