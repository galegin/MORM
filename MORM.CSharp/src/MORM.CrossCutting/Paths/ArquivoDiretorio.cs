using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MORM.CrossCutting
{
    public class ArquivoDiretorio
    {
        public static string GetPastaRequisicao() => 
            CaminhoPadrao.GetPathSubPasta("requisicao", isCreateSubPasta: true);
        public static string GetPastaRequisicaoProcessado() =>
            CaminhoPadrao.GetPathSubPasta("processado", isCreateSubPasta: true, pastaPadrao: GetPastaRequisicao());
        public static string GetPastaResposta() =>
            CaminhoPadrao.GetPathSubPasta("resposta", isCreateSubPasta: true);

        public static List<string> GetListaDeArquivo(string pasta, string extensao = "*.xml")
        {
            return Directory.GetFiles(pasta, extensao).ToList();
        }

        public static string CarregarArquivo(string arquivo)
        {
            if (File.Exists(arquivo))
                return File.ReadAllText(arquivo);
            return null;
        }

        public static void GravarArquivo(string arquivo, string conteudo, bool isDeleteOnExists = true)
        {
            if (isDeleteOnExists && File.Exists(arquivo))
                File.Delete(arquivo);
            File.WriteAllText(arquivo, conteudo);
        }

        public static void MoverArquivo(string arquivo, string arquivoDestino, bool isDeleteOnExists = true)
        {
            if (isDeleteOnExists && File.Exists(arquivoDestino))
                File.Delete(arquivoDestino);
            File.Move(arquivo, arquivoDestino);
        }
    }
}