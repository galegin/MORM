package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "TRANSITEM")
public class Transitem extends CollectionItem
{
    @CampoAttribute(Campo = "ID_TRANSACAO", Tipo = CampoTipo.Key)
    public String Id_Transacao;
    @CampoAttribute(Campo = "NR_ITEM", Tipo = CampoTipo.Key)
    public Integer Nr_Item;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "ID_PRODUTO", Tipo = CampoTipo.Req)
    public String Id_Produto;
    @CampoAttribute(Campo = "CD_PRODUTO", Tipo = CampoTipo.Req)
    public Integer Cd_Produto;
    @CampoAttribute(Campo = "DS_PRODUTO", Tipo = CampoTipo.Req)
    public String Ds_Produto;
    @CampoAttribute(Campo = "CD_CFOP", Tipo = CampoTipo.Req)
    public Integer Cd_Cfop;
    @CampoAttribute(Campo = "CD_ESPECIE", Tipo = CampoTipo.Req)
    public String Cd_Especie;
    @CampoAttribute(Campo = "CD_NCM", Tipo = CampoTipo.Req)
    public String Cd_Ncm;
    @CampoAttribute(Campo = "QT_ITEM", Tipo = CampoTipo.Req)
    public Float Qt_Item;
    @CampoAttribute(Campo = "VL_CUSTO", Tipo = CampoTipo.Req)
    public Float Vl_Custo;
    @CampoAttribute(Campo = "VL_UNITARIO", Tipo = CampoTipo.Req)
    public Float Vl_Unitario;
    @CampoAttribute(Campo = "VL_ITEM", Tipo = CampoTipo.Req)
    public Float Vl_Item;
    @CampoAttribute(Campo = "VL_VARIACAO", Tipo = CampoTipo.Req)
    public Float Vl_Variacao;
    @CampoAttribute(Campo = "VL_VARIACAOCAPA", Tipo = CampoTipo.Req)
    public Float Vl_Variacaocapa;
    @CampoAttribute(Campo = "VL_FRETE", Tipo = CampoTipo.Req)
    public Float Vl_Frete;
    @CampoAttribute(Campo = "VL_SEGURO", Tipo = CampoTipo.Req)
    public Float Vl_Seguro;
    @CampoAttribute(Campo = "VL_OUTRO", Tipo = CampoTipo.Req)
    public Float Vl_Outro;
    @CampoAttribute(Campo = "VL_DESPESA", Tipo = CampoTipo.Req)
    public Float Vl_Despesa;
}