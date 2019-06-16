using System;

namespace MORM.Dominio.Interfaces
{
    public interface ILogAcesso
    {
        DateTime DataLog { get; set; }
        int SequenciaLog { get; set; }
        int CodigoEmpresa { get; set; }
        int CodigoUsuario { get; set; }
        string CodigoServico { get; set; }
        string CodigoMetodo { get; set; }
        int QtdeAcesso { get; set; }
    }
}