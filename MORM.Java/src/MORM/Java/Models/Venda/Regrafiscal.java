package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "REGRAFISCAL")
public class Regrafiscal extends CollectionItem
{
    @CampoAttribute(Campo = "ID_REGRAFISCAL", Tipo = CampoTipo.Key)
    public Integer Id_Regrafiscal;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "DS_REGRAFISCAL", Tipo = CampoTipo.Req)
    public String Ds_Regrafiscal;
    @CampoAttribute(Campo = "IN_CALCIMPOSTO", Tipo = CampoTipo.Req)
    public String In_Calcimposto;
}