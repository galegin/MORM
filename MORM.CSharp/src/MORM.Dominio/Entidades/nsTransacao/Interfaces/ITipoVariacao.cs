using System;

namespace MORM.Dominio.Interfaces
{
    public enum TipoVariacaoValor
    {
        Acrescimo = 1,
        Desconto = -1
    }

    public enum TipoVariacaoCapa
    {
        Capa = 1,
        Item
    }

    public interface ITipoVariacao
    {
        int Id_TipoVariacao { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        string Cd_TipoVariacao { get; set; }
        string Ds_TipoVariacao { get; set; }
        TipoVariacaoValor Tp_TipoVariacaoValor { get; set; }
        TipoVariacaoCapa Tp_TipoVariacaoCapa { get; set; }
    }
}