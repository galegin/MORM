using System;

namespace MORM.Dtos
{
    public abstract class GravarLogAcessoDto
    {
        public class Envio
        {
            public DateTime DataLog { get; set; }
            public int SequenciaLog { get; set; }
            public int CodigoEmpresa { get; set; }
            public int CodigoUsuario { get; set; }
            public string CodigoServico { get; set; }
            public string CodigoMetodo { get; set; }
        }
    }
}