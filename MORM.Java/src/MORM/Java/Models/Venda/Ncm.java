package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "NCM")
public class Ncm extends CollectionItem
{
    @CampoAttribute(Campo = "CD_NCM", Tipo = CampoTipo.Key)
    public String Cd_Ncm;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "DS_NCM", Tipo = CampoTipo.Req)
    public String Ds_Ncm;
}