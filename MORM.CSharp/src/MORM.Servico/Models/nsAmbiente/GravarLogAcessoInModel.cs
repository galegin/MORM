using System;

namespace MORM.Servico.Models
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