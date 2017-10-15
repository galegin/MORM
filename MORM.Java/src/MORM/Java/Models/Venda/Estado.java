package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "ESTADO")
public class Estado extends CollectionItem
{
    @CampoAttribute(Campo = "ID_ESTADO", Tipo = CampoTipo.Key)
    public Integer Id_Estado;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "CD_ESTADO", Tipo = CampoTipo.Req)
    public Integer Cd_Estado;
    @CampoAttribute(Campo = "DS_ESTADO", Tipo = CampoTipo.Req)
    public String Ds_Estado;
    @CampoAttribute(Campo = "DS_SIGLA", Tipo = CampoTipo.Req)
    public String Ds_Sigla;
    @CampoAttribute(Campo = "ID_PAIS", Tipo = CampoTipo.Req)
    public Integer Id_Pais;
}