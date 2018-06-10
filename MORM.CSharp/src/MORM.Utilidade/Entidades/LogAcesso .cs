using MORM.Utilidade.Atributos;
using System;

namespace MORM.Utilidade.Entidades
{
    //-- galeg - 26/05/2018 17:19:26
    [Tabela("WEB_LOGACESSO")]
    public class LogAcesso
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