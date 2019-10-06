namespace MORM.CrossCutting
{
    public interface IPassword
    {
        string Cifrar(string atributo, string valor);
    }
}
