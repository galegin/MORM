package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "TRANSDFE")
public class Transdfe extends CollectionItem
{
    @CampoAttribute(Campo = "ID_TRANSACAO", Tipo = CampoTipo.Key)
    public String Id_Transacao;
    @CampoAttribute(Campo = "NR_SEQUENCIA", Tipo = CampoTipo.Key)
    public Integer Nr_Sequencia;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "TP_EVENTO", Tipo = CampoTipo.Req)
    public Integer Tp_Evento;
    @CampoAttribute(Campo = "TP_AMBIENTE", Tipo = CampoTipo.Req)
    public Integer Tp_Ambiente;
    @CampoAttribute(Campo = "TP_EMISSAO", Tipo = CampoTipo.Req)
    public Integer Tp_Emissao;
    @CampoAttribute(Campo = "DS_ENVIOXML", Tipo = CampoTipo.Req)
    public String Ds_Envioxml;
    @CampoAttribute(Campo = "DS_RETORNOXML", Tipo = CampoTipo.Nul)
    public String Ds_Retornoxml;
}