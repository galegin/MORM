namespace MORM.Dominio.Interfaces
{
    public interface IMigracao
    {
        string Codigo { get; set; }
        string Versao { get; set; }
    }
}