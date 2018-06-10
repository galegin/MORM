using MORM.Utilidade.Entidades;
using MORM.Utilidade.Interfaces;
using MORM.Utilidade.Tipagens;
using System;

namespace MORM.Repositorio.Services.nsAmbiente
{
    //-- galeg - 26/05/2018 17:38:22
    public class LogAcessoService : AbstractService<LogAcesso>, ILogAcessoService
    {
        public LogAcessoService(IAmbiente ambiente) : base(ambiente)
        {
        }

        private LogAcesso GetLogAcesso(DateTime dataLog, int sequenciaLog, int codigoEmpresa, int codigoUsuario, string codigoServico, string codigoMetodo)
        {
            var dataLogStr = Ambiente.TipoDatabase.GetValueData(dataLog);

            return ConsultarF((f) =>
                $"{nameof(f.DataLog)} = '{dataLogStr}' and " +
                $"{nameof(f.SequenciaLog)} = {sequenciaLog} and " +
                $"{nameof(f.CodigoEmpresa)} = {codigoEmpresa} and " +
                $"{nameof(f.CodigoUsuario)} = {codigoUsuario} and " +
                $"{nameof(f.CodigoServico)} = '{codigoServico}' and " +
                $"{nameof(f.CodigoMetodo)} = '{codigoMetodo}'");
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

            Salvar(logAcesso);
        }
    }
}