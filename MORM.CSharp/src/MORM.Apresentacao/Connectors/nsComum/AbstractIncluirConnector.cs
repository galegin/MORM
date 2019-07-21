using MORM.Dominio.Atributos;

namespace MORM.Apresentacao.Connectors
{
    [MTD("Incluir")]
    public class AbstractIncluirConnector<TEntrada, TRetorno> : AbstractConnector<TEntrada, TRetorno>
        where TEntrada : class
        where TRetorno : class
    {
    }
}