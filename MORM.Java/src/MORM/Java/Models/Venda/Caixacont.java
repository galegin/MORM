package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "CAIXACONT")
public class Caixacont extends CollectionItem
{
    @CampoAttribute(Campo = "ID_CAIXA", Tipo = CampoTipo.Key)
    public Integer Id_Caixa;
    @CampoAttribute(Campo = "ID_HISTREL", Tipo = CampoTipo.Key)
    public Integer Id_Histrel;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "VL_CONTADO", Tipo = CampoTipo.Req)
    public Float Vl_Contado;
    @CampoAttribute(Campo = "VL_SISTEMA", Tipo = CampoTipo.Req)
    public Float Vl_Sistema;
    @CampoAttribute(Campo = "VL_RETIRADA", Tipo = CampoTipo.Req)
    public Float Vl_Retirada;
    @CampoAttribute(Campo = "VL_SUPRIMENTO", Tipo = CampoTipo.Req)
    public Float Vl_Suprimento;
    @CampoAttribute(Campo = "VL_DIFERENCA", Tipo = CampoTipo.Req)
    public Float Vl_Diferenca;
}