package MORM.Java.Models.Venda;

import java.util.Date;
import MORM.Java.Classes.*;
import MORM.Java.Classes.Mapping.*;

@TabelaAttribute(Nome = "NCMSUBST")
public class Ncmsubst extends CollectionItem
{
    @CampoAttribute(Campo = "UF_ORIGEM", Tipo = CampoTipo.Key)
    public String Uf_Origem;
    @CampoAttribute(Campo = "UF_DESTINO", Tipo = CampoTipo.Key)
    public String Uf_Destino;
    @CampoAttribute(Campo = "CD_NCM", Tipo = CampoTipo.Key)
    public String Cd_Ncm;
    @CampoAttribute(Campo = "U_VERSION", Tipo = CampoTipo.Nul)
    public String U_Version;
    @CampoAttribute(Campo = "CD_OPERADOR", Tipo = CampoTipo.Nul)
    public Integer Cd_Operador;
    @CampoAttribute(Campo = "DT_CADASTRO", Tipo = CampoTipo.Nul)
    public Date Dt_Cadastro;
    @CampoAttribute(Campo = "CD_CEST", Tipo = CampoTipo.Nul)
    public String Cd_Cest;
}