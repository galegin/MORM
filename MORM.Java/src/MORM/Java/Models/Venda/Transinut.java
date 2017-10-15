package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "TRANSINUT")
public class Transinut extends CollectionItem
{
    @CampoAttribute(Campo = "ID_TRANSACAO", Tipo = CampoTipo.Key)
    public String Id_Transacao;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "DT_EMISSAO", Tipo = CampoTipo.Req)
    public Date Dt_Emissao;
    @CampoAttribute(Campo = "TP_MODELONF", Tipo = CampoTipo.Req)
    public Integer Tp_Modelonf;
    @CampoAttribute(Campo = "CD_SERIE", Tipo = CampoTipo.Req)
    public String Cd_Serie;
    @CampoAttribute(Campo = "NR_NF", Tipo = CampoTipo.Req)
    public Integer Nr_Nf;
    @CampoAttribute(Campo = "DT_RECEBIMENTO", Tipo = CampoTipo.Nul)
    public Date Dt_Recebimento;
    @CampoAttribute(Campo = "NR_RECIBO", Tipo = CampoTipo.Nul)
    public String Nr_Recibo;
}