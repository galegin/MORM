using MORM.Utilidade.Interfaces;
using System.Collections.Generic;

namespace MORM.Apresentacao.Menus
{
    public enum IMenuOpcaoTipo
    {
        Principal,
        SubMenu,
        Opcao
    }

    public interface IMenuOpcao
    {
        IMenuOpcaoTipo Tipo { get; }
        string Codigo { get; }
        string Descricao { get; }
        IList<IMenuOpcao> SubMenuOpcao { get; }
        UsuarioPrivilegio Privilegio { get; }
        void Executar();
    }

    public interface IMenuOpcaoAcao : IMenuOpcao { }

    public interface IMenuOpcaoDescr : IMenuOpcao { }

    public interface IMenuOpcaoMetodo : IMenuOpcao { }

    public interface IMenuOpcaoClasse : IMenuOpcao { }

    public interface IMenuOpcaoObjeto : IMenuOpcao { }

    public interface IMenuOpcaoTipo<TObject> : IMenuOpcao where TObject : class { }
}