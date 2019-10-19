namespace MORM.Apresentacao
{
    public enum CommandTipo
    {
        Fechar,
        Voltar,
        Alterar,
        Consultar,
        Excluir,
        Exportar,
        Importar,
        Imprimir,
        Incluir,
        Limpar,
        Listar,
        Retornar,
        Salvar,
        Selecionar,
        Confirmar,
        Cancelar,
        InverterSelecao,
        SelecionarTodos,
    }

    public static class CommandTipoExtensions
    {
        public static CommandTipo GetCommandTipo(this string value)
        {
            System.Enum.TryParse(value, true, out CommandTipo tipo);
            return tipo;
        }
    }
}