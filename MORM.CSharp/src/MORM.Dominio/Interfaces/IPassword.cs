namespace MORM.Dominio.Interfaces
{
    public interface IPassword
    {
        string Cifrar(string atributo, string valor);
    }
}