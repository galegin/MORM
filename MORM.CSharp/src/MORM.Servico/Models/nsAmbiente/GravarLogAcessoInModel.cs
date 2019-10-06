using System;

namespace MORM.Servico
{
    public class GravarLogAcessoInModel
    {
        public DateTime DataLog { get; set; }
        public int SequenciaLog { get; set; }
        public int CodigoEmpresa { get; set; }
        public int CodigoUsuario { get; set; }
        public string CodigoServico { get; set; }
        public string CodigoMetodo { get; set; }
    }
}