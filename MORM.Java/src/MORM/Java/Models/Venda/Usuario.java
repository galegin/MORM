package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "USUARIO")
public class Usuario extends CollectionItem
{
    @CampoAttribute(Campo = "ID_USUARIO", Tipo = CampoTipo.Key)
    public Integer Id_Usuario;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "NM_USUARIO", Tipo = CampoTipo.Req)
    public String Nm_Usuario;
    @CampoAttribute(Campo = "NM_LOGIN", Tipo = CampoTipo.Req)
    public String Nm_Login;
    @CampoAttribute(Campo = "CD_SENHA", Tipo = CampoTipo.Req)
    public String Cd_Senha;
    @CampoAttribute(Campo = "CD_PAPEL", Tipo = CampoTipo.Nul)
    public String Cd_Papel;
    @CampoAttribute(Campo = "TP_BLOQUEIO", Tipo = CampoTipo.Req)
    public Integer Tp_Bloqueio;
    @CampoAttribute(Campo = "DT_BLOQUEIO", Tipo = CampoTipo.Nul)
    public Date Dt_Bloqueio;
}