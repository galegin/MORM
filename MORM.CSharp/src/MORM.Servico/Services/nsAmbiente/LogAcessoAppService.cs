using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Servico.Models;
using MORM.Servico.Interfaces;
using System;
using MORM.Dominio.Extensions;

namespace MORM.Servico.Services
{
    public class LogAcessoAppService : AbstractAppService<LogAcesso>, ILogAcessoAppService
    {
        public LogAcessoAppService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }

        private LogAcesso GetLogAcesso(GravarLogAcessoInModel dto)
        {
            return AbstractService.AbstractRepository.FirstOrDefault(f =>
                f.DataLog == dto.DataLog &&
                f.SequenciaLog == dto.SequenciaLog &&
                f.CodigoEmpresa == dto.CodigoEmpresa &&
                f.CodigoUsuario == dto.CodigoUsuario &&
                f.CodigoServico == dto.CodigoServico &&
                f.CodigoMetodo == dto.CodigoMetodo);
        }

        public void GravarLog(GravarLogAcessoInModel dto)
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

            AbstractService.AbstractRepository.Salvar(logAcesso);
        }
    }
}