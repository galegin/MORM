package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "OPERACAO")
public class Operacao extends CollectionItem
{
    @CampoAttribute(Campo = "ID_OPERACAO", Tipo = CampoTipo.Key)
    public String Id_Operacao;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "DS_OPERACAO", Tipo = CampoTipo.Req)
    public String Ds_Operacao;
    @CampoAttribute(Campo = "TP_MODELONF", Tipo = CampoTipo.Req)
    public Integer Tp_Modelonf;
    @CampoAttribute(Campo = "TP_MODALIDADE", Tipo = CampoTipo.Req)
    public Integer Tp_Modalidade;
    @CampoAttribute(Campo = "TP_OPERACAO", Tipo = CampoTipo.Req)
    public Integer Tp_Operacao;
    @CampoAttribute(Campo = "CD_SERIE", Tipo = CampoTipo.Req)
    public String Cd_Serie;
    @CampoAttribute(Campo = "CD_CFOP", Tipo = CampoTipo.Req)
    public Integer Cd_Cfop;
    @CampoAttribute(Campo = "ID_REGRAFISCAL", Tipo = CampoTipo.Req)
    public Integer Id_Regrafiscal;
}