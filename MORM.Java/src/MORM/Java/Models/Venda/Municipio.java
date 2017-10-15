package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "MUNICIPIO")
public class Municipio extends CollectionItem
{
    @CampoAttribute(Campo = "ID_MUNICIPIO", Tipo = CampoTipo.Key)
    public Integer Id_Municipio;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "CD_MUNICIPIO", Tipo = CampoTipo.Req)
    public Integer Cd_Municipio;
    @CampoAttribute(Campo = "DS_MUNICIPIO", Tipo = CampoTipo.Req)
    public String Ds_Municipio;
    @CampoAttribute(Campo = "DS_SIGLA", Tipo = CampoTipo.Req)
    public String Ds_Sigla;
    @CampoAttribute(Campo = "ID_ESTADO", Tipo = CampoTipo.Req)
    public Integer Id_Estado;
}