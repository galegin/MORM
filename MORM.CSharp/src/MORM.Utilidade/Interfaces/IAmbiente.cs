using MORM.Utilidade.Tipagens;

namespace MORM.Utilidade.Interfaces
{
    //-- galeg - 28/04/2018 15:34:52
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
    }
}