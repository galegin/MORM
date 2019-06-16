using System;

namespace MORM.Dominio.Interfaces
{
    public interface ITransacaoItemVariacao
    {
        int Id_TransacaoItemVariacao { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_TransacaoItem { get; set; }
        int Id_TipoVariacao { get; set; }
        int Id_TipoVariacaoMotivo { get; set; }
        TipoVariacaoValor Tp_TipoVariacaoValor { get; set; }
        TipoVariacaoCapa Tp_TipoVariacaoCapa { get; set; }
        double Vl_ItemAnterior { get; set; }
        double Vl_VariacaoCapa { get; set; }
        double Vl_VariacaoItem { get; set; }
        double Vl_ItemAtual { get; set; }

        ITipoVariacao TipoVariacao { get; set; }
        ITipoVariacaoMotivo TipoVariacaoMotivo { get; set; }
    }
}