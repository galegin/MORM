using MORM.Dominio.Entidades;
using MORM.Dtos;
using MORM.Repositorio.Extensions;
using MORM.Repositorio.Uow;
using MORM.Servico.Interfaces;
using System;

namespace MORM.Servico.Services
{
    public class LogAcessoService : AbstractService<LogAcesso>, ILogAcessoService
    {
        public LogAcessoService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }

        private LogAcesso GetLogAcesso(GravarLogAcessoDto.Envio dto)
        {
            return AbstractRepository.FirstOrDefault(f =>
                f.DataLog == dto.DataLog &&
                f.SequenciaLog == dto.SequenciaLog &&
                f.CodigoEmpresa == dto.CodigoEmpresa &&
                f.CodigoUsuario == dto.CodigoUsuario &&
                f.CodigoServico == dto.CodigoServico &&
                f.CodigoMetodo == dto.CodigoMetodo);
        }

        public void GravarLog(GravarLogAcessoDto.Envio dto)
        {
            dto.DataLog = DateTime.Today;
            dto.SequenciaLog = 1;

            var logAcesso = GetLogAcesso(dto);

            if (logAcesso.CodigoEmpresa <= 0)
                logAcesso = new LogAcesso
                {
                    DataLog = dto.DataLog,
                    SequenciaLog = dto.SequenciaLog,
                    CodigoEmpresa = dto.CodigoEmpresa,
                    CodigoUsuario = dto.CodigoUsuario,
                    CodigoServico = dto.CodigoServico,
                    CodigoMetodo = dto.CodigoMetodo,
                };

            logAcesso.QtdeAcesso += 1;

            AbstractRepository.Salvar(logAcesso);
        }
    }
}