package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "TRANSACAO")
public class Transacao extends CollectionItem
{
    @CampoAttribute(Campo = "ID_TRANSACAO", Tipo = CampoTipo.Key)
    public String Id_Transacao;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "ID_EMPRESA", Tipo = CampoTipo.Req)
    public Integer Id_Empresa;
    @CampoAttribute(Campo = "ID_PESSOA", Tipo = CampoTipo.Req)
    public String Id_Pessoa;
    @CampoAttribute(Campo = "ID_OPERACAO", Tipo = CampoTipo.Req)
    public String Id_Operacao;
    @CampoAttribute(Campo = "DT_TRANSACAO", Tipo = CampoTipo.Req)
    public Date Dt_Transacao;
    @CampoAttribute(Campo = "NR_TRANSACAO", Tipo = CampoTipo.Req)
    public Integer Nr_Transacao;
    @CampoAttribute(Campo = "TP_SITUACAO", Tipo = CampoTipo.Req)
    public Integer Tp_Situacao;
    @CampoAttribute(Campo = "DT_CANCELAMENTO", Tipo = CampoTipo.Nul)
    public Date Dt_Cancelamento;
}