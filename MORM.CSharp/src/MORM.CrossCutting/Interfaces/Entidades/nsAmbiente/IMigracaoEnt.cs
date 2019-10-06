namespace MORM.CrossCutting
{
    public interface IMigracaoEnt
    {
        string Codigo { get; set; }
        string Versao { get; set; }
    }
}