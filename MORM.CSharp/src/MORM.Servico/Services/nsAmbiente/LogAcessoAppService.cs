using MORM.CrossCutting;
using MORM.Servico.Models;
using MORM.Servico.Interfaces;
using System;
using System.Linq;

namespace MORM.Servico.Services
{
    public class LogAcessoAppService : ILogAcessoAppService
    {
        private readonly ILogAcessoRepository _logAcessoRepository;

        public LogAcessoAppService(ILogAcessoRepository logAcessoRepository)
        {
            _logAcessoRepository = logAcessoRepository;
        }

        private LogAcesso GetLogAcesso(GravarLogAcessoInModel model)
        {
            return _logAcessoRepository.GetAll().FirstOrDefault(f =>
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

            _logAcessoRepository.AddOrUpdate(logAcesso);
        }
    }
}