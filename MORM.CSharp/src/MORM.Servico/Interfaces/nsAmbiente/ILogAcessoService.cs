using MORM.Dominio.Entidades;

namespace MORM.Servico.Interfaces.nsAmbiente
{
    public interface ILogAcessoService : IAbstractService<LogAcesso>
    {
        void GravarLog(int codigoEmpresa, int codigoUsuario, string codigoServico, string codigoMetodo);
    }
}