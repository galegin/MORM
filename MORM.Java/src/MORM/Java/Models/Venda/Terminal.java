package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "TERMINAL")
public class Terminal extends CollectionItem
{
    @CampoAttribute(Campo = "ID_TERMINAL", Tipo = CampoTipo.Key)
    public Integer Id_Terminal;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "CD_TERMINAL", Tipo = CampoTipo.Req)
    public Integer Cd_Terminal;
    @CampoAttribute(Campo = "DS_TERMINAL", Tipo = CampoTipo.Req)
    public String Ds_Terminal;
}