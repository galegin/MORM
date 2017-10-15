package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "ALIQICMS")
public class Aliqicms extends CollectionItem
{
    @CampoAttribute(Campo = "UF_ORIGEM", Tipo = CampoTipo.Key)
    public String Uf_Origem;
    @CampoAttribute(Campo = "UF_DESTINO", Tipo = CampoTipo.Key)
    public String Uf_Destino;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Req)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Req)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "PR_ALIQUOTA", Tipo = CampoTipo.Req)
    public Float Pr_Aliquota;
}