package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "REGRAIMPOSTO")
public class Regraimposto extends CollectionItem
{
    @CampoAttribute(Campo = "ID_REGRAFISCAL", Tipo = CampoTipo.Key)
    public Integer Id_Regrafiscal;
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
    @CampoAttribute(Campo = "PR_BASECALCULO", Tipo = CampoTipo.Req)
    public Float Pr_Basecalculo;
    @CampoAttribute(Campo = "CD_CST", Tipo = CampoTipo.Req)
    public String Cd_Cst;
    @CampoAttribute(Campo = "CD_CSOSN", Tipo = CampoTipo.Nul)
    public String Cd_Csosn;
    @CampoAttribute(Campo = "IN_ISENTO", Tipo = CampoTipo.Req)
    public String In_Isento;
    @CampoAttribute(Campo = "IN_OUTRO", Tipo = CampoTipo.Req)
    public String In_Outro;
}