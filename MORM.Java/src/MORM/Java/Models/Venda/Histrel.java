package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "HISTREL")
public class Histrel extends CollectionItem
{
    @CampoAttribute(Campo = "ID_HISTREL", Tipo = CampoTipo.Key)
    public Integer Id_Histrel;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "TP_DOCUMENTO", Tipo = CampoTipo.Req)
    public Integer Tp_Documento;
    @CampoAttribute(Campo = "CD_HISTREL", Tipo = CampoTipo.Req)
    public Integer Cd_Histrel;
    @CampoAttribute(Campo = "DS_HISTREL", Tipo = CampoTipo.Req)
    public String Ds_Histrel;
    @CampoAttribute(Campo = "NR_PARCELAS", Tipo = CampoTipo.Req)
    public Integer Nr_Parcelas;
}