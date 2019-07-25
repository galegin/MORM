using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Servico.Models;

namespace MORM.Servico.Interfaces
{
    public interface ILogAcessoAppService : IAbstractAppService<LogAcesso>
    {
        void GravarLog(GravarLogAcessoInModel model);
    }
}