using MORM.Dominio.Entidades;
using MORM.Dtos;

namespace MORM.Servico.Interfaces
{
    public interface ILogAcessoService : IAbstractService<LogAcesso>
    {
        void GravarLog(GravarLogAcessoDto.Envio dto);
    }
}