package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "TRANSPAGTO")
public class Transpagto extends CollectionItem
{
    @CampoAttribute(Campo = "ID_TRANSACAO", Tipo = CampoTipo.Key)
    public String Id_Transacao;
    @CampoAttribute(Campo = "NR_SEQ", Tipo = CampoTipo.Key)
    public Integer Nr_Seq;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "ID_CAIXA", Tipo = CampoTipo.Req)
    public Integer Id_Caixa;
    @CampoAttribute(Campo = "TP_DOCUMENTO", Tipo = CampoTipo.Req)
    public Integer Tp_Documento;
    @CampoAttribute(Campo = "ID_HISTREL", Tipo = CampoTipo.Req)
    public Integer Id_Histrel;
    @CampoAttribute(Campo = "NR_PARCELA", Tipo = CampoTipo.Req)
    public Integer Nr_Parcela;
    @CampoAttribute(Campo = "NR_PARCELAS", Tipo = CampoTipo.Req)
    public Integer Nr_Parcelas;
    @CampoAttribute(Campo = "NR_DOCUMENTO", Tipo = CampoTipo.Nul)
    public Integer Nr_Documento;
    @CampoAttribute(Campo = "VL_DOCUMENTO", Tipo = CampoTipo.Req)
    public Float Vl_Documento;
    @CampoAttribute(Campo = "DT_VENCIMENTO", Tipo = CampoTipo.Req)
    public Date Dt_Vencimento;
    @CampoAttribute(Campo = "CD_AUTORIZACAO", Tipo = CampoTipo.Nul)
    public String Cd_Autorizacao;
    @CampoAttribute(Campo = "NR_NSU", Tipo = CampoTipo.Nul)
    public Integer Nr_Nsu;
    @CampoAttribute(Campo = "DS_REDETEF", Tipo = CampoTipo.Nul)
    public String Ds_Redetef;
    @CampoAttribute(Campo = "NM_OPERADORA", Tipo = CampoTipo.Nul)
    public String Nm_Operadora;
    @CampoAttribute(Campo = "NR_BANCO", Tipo = CampoTipo.Nul)
    public Integer Nr_Banco;
    @CampoAttribute(Campo = "NR_AGENCIA", Tipo = CampoTipo.Nul)
    public Integer Nr_Agencia;
    @CampoAttribute(Campo = "DS_CONTA", Tipo = CampoTipo.Nul)
    public String Ds_Conta;
    @CampoAttribute(Campo = "NR_CHEQUE", Tipo = CampoTipo.Nul)
    public Integer Nr_Cheque;
    @CampoAttribute(Campo = "DS_CMC7", Tipo = CampoTipo.Nul)
    public String Ds_Cmc7;
    @CampoAttribute(Campo = "TP_BAIXA", Tipo = CampoTipo.Nul)
    public Integer Tp_Baixa;
    @CampoAttribute(Campo = "CD_OPERBAIXA", Tipo = CampoTipo.Nul)
    public Integer Cd_Operbaixa;
    @CampoAttribute(Campo = "DT_BAIXA", Tipo = CampoTipo.Nul)
    public Date Dt_Baixa;
}