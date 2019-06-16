using System;

namespace MORM.Dominio.Interfaces
{
    public interface ITipoVariacaoMotivo
    {
        int Id_TipoVariacaoMotivo { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        string Cd_TipoVariacaoMotivo { get; set; }
        string Ds_TipoVariacaoMotivo { get; set; }
    }
}