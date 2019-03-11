using MORM.Utilidade.Entidades;

namespace MORM.Repositorio.Services.nsAmbiente
{
    //-- galeg - 26/05/2018 17:38:11
    public interface ILogAcessoService : IAbstractService<LogAcesso>
    {
        void GravarLog(int codigoEmpresa, int codigoUsuario, string codigoServico, string codigoMetodo);
    }
}