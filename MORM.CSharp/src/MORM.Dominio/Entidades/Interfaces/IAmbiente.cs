using MORM.Dominio.Tipagens;

namespace MORM.Dominio.Interfaces
{
    public interface IAmbiente
    {
        string Codigo { get; set; }
        TipoDatabase TipoDatabase { get; set; }
        string ProviderName { get; set; }
        string Database { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Hostname { get; set; }
        int CodigoEmpresa { get; set; }
        int CodigoUsuario { get; set; }
        int CodigoTerminal { get; set; }
    }
}