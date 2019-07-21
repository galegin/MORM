using MORM.Dominio.Atributos;

namespace MORM.Apresentacao.Connectors
{
    [MTD("Imprimir")]
    public class AbstractImprimirConnector<TEntrada, TRetorno> : AbstractConnector<TEntrada, TRetorno>
        where TEntrada : class
        where TRetorno : class
    {
    }
}