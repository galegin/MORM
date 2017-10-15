package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "PESSOA")
public class Pessoa extends CollectionItem
{
    @CampoAttribute(Campo = "ID_PESSOA", Tipo = CampoTipo.Key)
    public String Id_Pessoa;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "CD_PESSOA", Tipo = CampoTipo.Req)
    public Integer Cd_Pessoa;
    @CampoAttribute(Campo = "NM_PESSOA", Tipo = CampoTipo.Req)
    public String Nm_Pessoa;
    @CampoAttribute(Campo = "NR_CPFCNPJ", Tipo = CampoTipo.Req)
    public String Nr_Cpfcnpj;
    @CampoAttribute(Campo = "NR_RGIE", Tipo = CampoTipo.Req)
    public String Nr_Rgie;
    @CampoAttribute(Campo = "NM_FANTASIA", Tipo = CampoTipo.Nul)
    public String Nm_Fantasia;
    @CampoAttribute(Campo = "CD_CEP", Tipo = CampoTipo.Req)
    public Integer Cd_Cep;
    @CampoAttribute(Campo = "NM_LOGRADOURO", Tipo = CampoTipo.Req)
    public String Nm_Logradouro;
    @CampoAttribute(Campo = "NR_LOGRADOURO", Tipo = CampoTipo.Req)
    public String Nr_Logradouro;
    @CampoAttribute(Campo = "DS_BAIRRO", Tipo = CampoTipo.Req)
    public String Ds_Bairro;
    @CampoAttribute(Campo = "DS_COMPLEMENTO", Tipo = CampoTipo.Nul)
    public String Ds_Complemento;
    @CampoAttribute(Campo = "CD_MUNICIPIO", Tipo = CampoTipo.Req)
    public Integer Cd_Municipio;
    @CampoAttribute(Campo = "DS_MUNICIPIO", Tipo = CampoTipo.Req)
    public String Ds_Municipio;
    @CampoAttribute(Campo = "CD_ESTADO", Tipo = CampoTipo.Req)
    public Integer Cd_Estado;
    @CampoAttribute(Campo = "DS_ESTADO", Tipo = CampoTipo.Req)
    public String Ds_Estado;
    @CampoAttribute(Campo = "DS_SIGLAESTADO", Tipo = CampoTipo.Req)
    public String Ds_Siglaestado;
    @CampoAttribute(Campo = "CD_PAIS", Tipo = CampoTipo.Req)
    public Integer Cd_Pais;
    @CampoAttribute(Campo = "DS_PAIS", Tipo = CampoTipo.Req)
    public String Ds_Pais;
    @CampoAttribute(Campo = "DS_FONE", Tipo = CampoTipo.Nul)
    public String Ds_Fone;
    @CampoAttribute(Campo = "DS_CELULAR", Tipo = CampoTipo.Nul)
    public String Ds_Celular;
    @CampoAttribute(Campo = "DS_EMAIL", Tipo = CampoTipo.Nul)
    public String Ds_Email;
    @CampoAttribute(Campo = "IN_CONSUMIDORFINAL", Tipo = CampoTipo.Nul)
    public String In_Consumidorfinal;
}