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

        private LogAcesso GetLogAcesso(GravarLogAcessoInModel model)
        {
            return AbstractService.AbstractRepository.FirstOrDefault(f =>
                f.DataLog == model.DataLog &&
                f.SequenciaLog == model.SequenciaLog &&
                f.CodigoEmpresa == model.CodigoEmpresa &&
                f.CodigoUsuario == model.CodigoUsuario &&
                f.CodigoServico == model.CodigoServico &&
                f.CodigoMetodo == model.CodigoMetodo);
        }

        public void GravarLog(GravarLogAcessoInModel model)
        {
            model.DataLog = DateTime.Today;
            model.SequenciaLog = 1;

            var logAcesso = GetLogAcesso(model);

            if (logAcesso.CodigoEmpresa <= 0)
                logAcesso = new LogAcesso
                {
                    DataLog = model.DataLog,
                    SequenciaLog = model.SequenciaLog,
                    CodigoEmpresa = model.CodigoEmpresa,
                    CodigoUsuario = model.CodigoUsuario,
                    CodigoServico = model.CodigoServico,
                    CodigoMetodo = model.CodigoMetodo,
                };

            logAcesso.QtdeAcesso += 1;

            AbstractService.AbstractRepository.Salvar(logAcesso);
        }
    }
}