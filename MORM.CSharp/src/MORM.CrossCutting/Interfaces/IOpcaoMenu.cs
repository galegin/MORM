using System;
using System.Collections.Generic;

namespace MORM.CrossCutting
{
    public enum OpcaoMenuTipo
    {
        Consulta = 1,
        Filtro,
        Grafico,
        Listagem,
        Manutencao,
        Pesquisa,
        Processo,
        Relatorio
    }

    public enum OpcaoMenuPermissao
    {
        Suporte = 1,
        Administrador,
        Operador,
        Consulta,
    }

    public interface IOpcaoMenu
    {
        string Codigo { get; }
        string Descricao { get; }
        string Image { get; }
        Type Classe { get; }
        object Objeto { get; }
        List<IOpcaoMenu> Lista { get; }
        OpcaoMenuTipo Tipo { get; }
        OpcaoMenuPermissao Permissao { get; }
    }
}