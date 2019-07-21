using MORM.Dominio.Atributos;

namespace MORM.Apresentacao.Connectors
{
    [MTD("Salvar")]
    public class AbstractSalvarConnector<TEntrada, TRetorno> : AbstractConnector<TEntrada, TRetorno>
        where TEntrada : class
        where TRetorno : class
    {
    }
}