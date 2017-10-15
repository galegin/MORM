package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "CFOP")
public class Cfop extends CollectionItem
{
    @CampoAttribute(Campo = "CD_CFOP", Tipo = CampoTipo.Key)
    public Integer Cd_Cfop;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "DS_CFOP", Tipo = CampoTipo.Req)
    public String Ds_Cfop;
}