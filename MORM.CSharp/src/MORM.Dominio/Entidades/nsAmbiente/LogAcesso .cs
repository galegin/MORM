using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("WEB_LOGACESSO")]
    public class LogAcesso : ILogAcesso
    {
        [Campo("DT_LOQ", CampoTipo.Key)]
        public DateTime DataLog { get; set; }
        [Campo("NR_SEQLOG", CampoTipo.Key)]
        public int SequenciaLog { get; set; }
        [Campo("CD_EMPRESA", CampoTipo.Key)]
        public int CodigoEmpresa { get; set; }
        [Campo("CD_USUARIO", CampoTipo.Key)]
        public int CodigoUsuario { get; set; }
        [Campo("CD_SERVICO", CampoTipo.Key)]
        public string CodigoServico { get; set; }
        [Campo("CD_METODO", CampoTipo.Key)]
        public string CodigoMetodo { get; set; }
        [Campo("QT_ACESSO", CampoTipo.Req)]
        public int QtdeAcesso { get; set; }
    }
}