package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "CAIXA")
public class Caixa extends CollectionItem
{
    @CampoAttribute(Campo = "ID_CAIXA", Tipo = CampoTipo.Key)
    public Integer Id_Caixa;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "ID_EMPRESA", Tipo = CampoTipo.Req)
    public Integer Id_Empresa;
    @CampoAttribute(Campo = "ID_TERMINAL", Tipo = CampoTipo.Req)
    public Integer Id_Terminal;
    @CampoAttribute(Campo = "DT_ABERTURA", Tipo = CampoTipo.Req)
    public Date Dt_Abertura;
    @CampoAttribute(Campo = "VL_ABERTURA", Tipo = CampoTipo.Req)
    public Float Vl_Abertura;
    @CampoAttribute(Campo = "IN_FECHADO", Tipo = CampoTipo.Req)
    public String In_Fechado;
    @CampoAttribute(Campo = "DT_FECHADO", Tipo = CampoTipo.Nul)
    public Date Dt_Fechado;
}