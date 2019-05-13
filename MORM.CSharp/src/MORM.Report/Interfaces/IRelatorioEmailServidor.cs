namespace MORM.Report.Interfaces
{
    public interface IRelatorioEmailServidor
    {
        string Nome { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Host { get; set; }
        string Port { get; set; }
    }
}