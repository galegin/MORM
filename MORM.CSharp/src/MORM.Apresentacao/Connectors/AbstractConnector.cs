namespace MORM.Apresentacao.Connectors
{
    public abstract class AbstractConnector
    {
        public abstract object Executar(object instance);
    }

    public abstract class AbstractConnector<TObject> : AbstractConnector
    {
    }
}