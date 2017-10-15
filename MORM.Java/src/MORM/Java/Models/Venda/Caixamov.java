package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "CAIXAMOV")
public class Caixamov extends CollectionItem
{
    @CampoAttribute(Campo = "ID_CAIXA", Tipo = CampoTipo.Key)
    public Integer Id_Caixa;
    @CampoAttribute(Campo = "NR_SEQ", Tipo = CampoTipo.Key)
    public Integer Nr_Seq;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "TP_LANCTO", Tipo = CampoTipo.Req)
    public Integer Tp_Lancto;
    @CampoAttribute(Campo = "VL_LANCTO", Tipo = CampoTipo.Req)
    public Float Vl_Lancto;
    @CampoAttribute(Campo = "NR_DOC", Tipo = CampoTipo.Req)
    public Integer Nr_Doc;
    @CampoAttribute(Campo = "DS_AUX", Tipo = CampoTipo.Req)
    public String Ds_Aux;
}