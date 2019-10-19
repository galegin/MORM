using System.Collections.Generic;

namespace MORM.Apresentacao
{
    public enum MenuOpcaoTipo
    {
        Principal = 1,
        SubMenu,
        Opcao,
        Configuracao,
        Consulta,
        Filtro,
        Grafico,
        Listagem,
        Manutencao,
        Pesquisa,
        Processo,
        Relatorio
    }

    public enum MenuOpcaoPermissao
    {
        Suporte = 1,
        Administrador,
        Operador,
        Consulta
    }

    public interface IMenuOpcao
    {
        MenuOpcaoTipo Tipo { get; }
        string Codigo { get; }
        string Descricao { get; }
        string Image { get; }
        IList<IMenuOpcao> SubMenuOpcao { get; }
        MenuOpcaoPermissao Permissao { get; }
        void Executar();
    }

    // extension

    public static class MenuOpcaoTipoExtension
    {
        public static string GetComponente(this MenuOpcaoTipo tipo)
        {
            return $"Menu{tipo.ToString()}";
        }

        public static string GetImagem(this MenuOpcaoTipo tipo)
        {
            return $"Images\\{tipo.ToString().ToLower()}.png";
        }

        public static string GetTitulo(this MenuOpcaoTipo tipo)
        {
            return $"{tipo.ToString()}";
        }
    }
}