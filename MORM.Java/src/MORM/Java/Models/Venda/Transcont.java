package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "TRANSCONT")
public class Transcont extends CollectionItem
{
    @CampoAttribute(Campo = "ID_TRANSACAO", Tipo = CampoTipo.Key)
    public String Id_Transacao;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "TP_SITUACAO", Tipo = CampoTipo.Req)
    public Integer Tp_Situacao;
    @CampoAttribute(Campo = "CD_TERMINAL", Tipo = CampoTipo.Req)
    public Integer Cd_Terminal;
}