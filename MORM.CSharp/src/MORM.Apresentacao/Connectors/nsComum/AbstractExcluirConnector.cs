using MORM.Dominio.Atributos;

namespace MORM.Apresentacao.Connectors
{
    [MTD("Excluir")]
    public class AbstractExcluirConnector<TEntrada, TRetorno> : AbstractConnector<TEntrada, TRetorno>
        where TEntrada : class
        where TRetorno : class
    {
    }
}