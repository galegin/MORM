package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "PAIS")
public class Pais extends CollectionItem
{
    @CampoAttribute(Campo = "ID_PAIS", Tipo = CampoTipo.Key)
    public Integer Id_Pais;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "CD_PAIS", Tipo = CampoTipo.Req)
    public Integer Cd_Pais;
    @CampoAttribute(Campo = "DS_PAIS", Tipo = CampoTipo.Req)
    public String Ds_Pais;
    @CampoAttribute(Campo = "DS_SIGLA", Tipo = CampoTipo.Req)
    public String Ds_Sigla;
}