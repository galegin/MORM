using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Repositorio.Extensions;
using MORM.Repositorio.Uow;
using MORM.Servico.Interfaces.nsAmbiente;
using System;

namespace MORM.Servico.Services.nsAmbiente
{
    public class LogAcessoService : AbstractService<LogAcesso>, ILogAcessoService
    {
        public LogAcessoService(IAbstractUnityOfWork unityOfWork) : base(unityOfWork)
        {
        }

        public LogAcessoService(IAmbiente ambiente) : base(ambiente)
        {
        }

        private LogAcesso GetLogAcesso(DateTime dataLog, int sequenciaLog, int codigoEmpresa, int codigoUsuario, string codigoServico, string codigoMetodo)
        {
            return AbstractRepository.FirstOrDefault(f =>
                f.DataLog == dataLog &&
                f.SequenciaLog == sequenciaLog &&
                f.CodigoEmpresa == codigoEmpresa &&
                f.CodigoUsuario == codigoUsuario &&
                f.CodigoServico == codigoServico &&
                f.CodigoMetodo == codigoMetodo);
        }

        public void GravarLog(int codigoEmpresa, int codigoUsuario, string codigoServico, string codigoMetodo)
        {
            var dataLog = DateTime.Today;
            var sequenciaLog = 1;

            var logAcesso = GetLogAcesso(dataLog, sequenciaLog, codigoEmpresa, codigoUsuario, codigoServico, codigoMetodo);

            if (logAcesso.CodigoEmpresa <= 0)
                logAcesso = new LogAcesso
                {
                    DataLog = dataLog,
                    SequenciaLog = sequenciaLog,
                    CodigoEmpresa = codigoEmpresa,
                    CodigoUsuario = codigoUsuario,
                    CodigoServico = codigoServico,
                    CodigoMetodo = codigoMetodo,
                };

            logAcesso.QtdeAcesso += 1;

            AbstractRepository.Salvar(logAcesso);
        }
    }
}