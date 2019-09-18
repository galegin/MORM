using MORM.Servico.Models;

namespace MORM.Servico.Interfaces
{
    public interface ILogAcessoAppService
    {
        void GravarLog(GravarLogAcessoInModel model);
    }
}