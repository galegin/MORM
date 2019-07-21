using MORM.Dominio.Atributos;

namespace MORM.Apresentacao.Connectors
{
    [MTD("Exportar")]
    public class AbstractExportarConnector<TEntrada, TRetorno> : AbstractConnector<TEntrada, TRetorno>
        where TEntrada : class
        where TRetorno : class
    {
    }
}