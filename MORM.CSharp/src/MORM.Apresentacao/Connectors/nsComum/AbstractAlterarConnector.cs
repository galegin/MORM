using MORM.Dominio.Atributos;

namespace MORM.Apresentacao.Connectors
{
    [MTD("Alterar")]
    public class AbstractAlterarConnector<TEntrada, TRetorno> : AbstractConnector<TEntrada, TRetorno> 
        where TEntrada : class
        where TRetorno : class
    {
    }
}