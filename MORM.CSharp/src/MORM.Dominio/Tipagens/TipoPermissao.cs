namespace MORM.Dominio.Tipagens
{
    public enum TipoPermissao
    {
        Listar = 10,

        Consultar = 20,

        Incluir = 30,
        IncluirLista,

        Alterar = 40,
        AlterarLista,

        Salvar = 50,
        SalvarLista,

        Excluir = 60,
        ExcluirLista,
    }
}