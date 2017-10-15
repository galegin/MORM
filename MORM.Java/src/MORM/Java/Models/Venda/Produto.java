package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "PRODUTO")
public class Produto extends CollectionItem
{
    @CampoAttribute(Campo = "ID_PRODUTO", Tipo = CampoTipo.Key)
    public String Id_Produto;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "CD_PRODUTO", Tipo = CampoTipo.Req)
    public Integer Cd_Produto;
    @CampoAttribute(Campo = "DS_PRODUTO", Tipo = CampoTipo.Req)
    public String Ds_Produto;
    @CampoAttribute(Campo = "CD_ESPECIE", Tipo = CampoTipo.Req)
    public String Cd_Especie;
    @CampoAttribute(Campo = "CD_NCM", Tipo = CampoTipo.Req)
    public String Cd_Ncm;
    @CampoAttribute(Campo = "CD_CST", Tipo = CampoTipo.Req)
    public String Cd_Cst;
    @CampoAttribute(Campo = "CD_CSOSN", Tipo = CampoTipo.Req)
    public String Cd_Csosn;
    @CampoAttribute(Campo = "PR_ALIQUOTA", Tipo = CampoTipo.Req)
    public Float Pr_Aliquota;
    @CampoAttribute(Campo = "TP_PRODUCAO", Tipo = CampoTipo.Req)
    public Integer Tp_Producao;
    @CampoAttribute(Campo = "VL_CUSTO", Tipo = CampoTipo.Req)
    public Float Vl_Custo;
    @CampoAttribute(Campo = "VL_VENDA", Tipo = CampoTipo.Req)
    public Float Vl_Venda;
    @CampoAttribute(Campo = "VL_PROMOCAO", Tipo = CampoTipo.Req)
    public Float Vl_Promocao;
}