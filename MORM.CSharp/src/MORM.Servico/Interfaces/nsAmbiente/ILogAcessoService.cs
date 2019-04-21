using MORM.Dominio.Entidades;
using MORM.Dtos.nsAmbiente;

namespace MORM.Servico.Interfaces.nsAmbiente
{
    public interface ILogAcessoService : IAbstractService<LogAcesso>
    {
        void GravarLog(GravarLogAcessoDto.Envio dto);
    }
}