namespace MORM.Infra.CrossCutting
{
    public interface IAbstractInstaller
    {
        void Install(IAbstractContainer container);
    }
}