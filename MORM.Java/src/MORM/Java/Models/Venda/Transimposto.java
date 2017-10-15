package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "TRANSIMPOSTO")
public class Transimposto extends CollectionItem
{
    @CampoAttribute(Campo = "ID_TRANSACAO", Tipo = CampoTipo.Key)
    public String Id_Transacao;
    @CampoAttribute(Campo = "NR_ITEM", Tipo = CampoTipo.Key)
    public Integer Nr_Item;
    @CampoAttribute(Campo = "CD_IMPOSTO", Tipo = CampoTipo.Key)
    public Integer Cd_Imposto;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "PR_ALIQUOTA", Tipo = CampoTipo.Req)
    public Float Pr_Aliquota;
    @CampoAttribute(Campo = "VL_BASECALCULO", Tipo = CampoTipo.Req)
    public Float Vl_Basecalculo;
    @CampoAttribute(Campo = "PR_BASECALCULO", Tipo = CampoTipo.Req)
    public Float Pr_Basecalculo;
    @CampoAttribute(Campo = "PR_REDBASECALCULO", Tipo = CampoTipo.Req)
    public Float Pr_Redbasecalculo;
    @CampoAttribute(Campo = "VL_IMPOSTO", Tipo = CampoTipo.Req)
    public Float Vl_Imposto;
    @CampoAttribute(Campo = "VL_OUTRO", Tipo = CampoTipo.Req)
    public Float Vl_Outro;
    @CampoAttribute(Campo = "VL_ISENTO", Tipo = CampoTipo.Req)
    public Float Vl_Isento;
    @CampoAttribute(Campo = "CD_CST", Tipo = CampoTipo.Req)
    public String Cd_Cst;
    @CampoAttribute(Campo = "CD_CSOSN", Tipo = CampoTipo.Nul)
    public String Cd_Csosn;
}