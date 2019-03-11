using MORM.Utilidade.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao.Menus
{
    public abstract class MenuOpcao : IMenuOpcao
    {
        public MenuOpcao(IMenuOpcaoTipo tipo, string codigo, string descricao, 
            IList<IMenuOpcao> subMenuOpcao = null, UsuarioPrivilegio privilegio = UsuarioPrivilegio.Padrao
        )
        {
            Tipo = tipo;
            Codigo = codigo ?? throw new ArgumentNullException(nameof(codigo));
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            SubMenuOpcao = subMenuOpcao;
            Privilegio = privilegio;
        }

        public IMenuOpcaoTipo Tipo { get; }
        public string Codigo { get; }
        public string Descricao { get; }
        public IList<IMenuOpcao> SubMenuOpcao { get; }
        public UsuarioPrivilegio Privilegio { get; }
        public abstract void Executar();
    }

    public class MenuOpcaoAcao : MenuOpcao, IMenuOpcaoAcao
    {
        private readonly Action _acao;

        public MenuOpcaoAcao(IMenuOpcaoTipo tipo, string codigo, string descricao, Action acao, IList<IMenuOpcao> subMenuOpcao = null) 
            : base(tipo, codigo, descricao, subMenuOpcao)
        {
            _acao = acao ?? throw new ArgumentNullException(nameof(acao));
        }

        public override void Executar() => _acao.Invoke();
    }

    public class MenuOpcaoDescr : MenuOpcao, IMenuOpcaoDescr
    {
        public MenuOpcaoDescr(IMenuOpcaoTipo tipo, string codigo, string descricao, IList<IMenuOpcao> subMenuOpcao = null)
            : base(tipo, codigo, descricao, subMenuOpcao)
        {
        }

        public override void Executar() { }
    }

    public class MenuOpcaoMetodo : MenuOpcao, IMenuOpcaoMetodo
    {
        private readonly RoutedEventHandler _metodo;

        public MenuOpcaoMetodo(IMenuOpcaoTipo tipo, string codigo, string descricao, RoutedEventHandler metodo,
            IList<IMenuOpcao> subMenuOpcao = null) : base(tipo, codigo, descricao, subMenuOpcao)
        {
            _metodo = metodo ?? throw new ArgumentNullException(nameof(metodo));
        }

        public override void Executar() => _metodo(null, null);
    }

    public class MenuOpcaoClasse : MenuOpcao, IMenuOpcaoClasse
    {
        private readonly Type _classe;
        private readonly IMenuResolverClasse _resolver;

        public MenuOpcaoClasse(IMenuOpcaoTipo tipo, string codigo, string descricao, Type classe, IMenuResolverClasse resolver, 
            IList<IMenuOpcao> subMenuOpcao = null) : base(tipo, codigo, descricao, subMenuOpcao)
        {
            _classe = classe ?? throw new ArgumentNullException(nameof(classe));
            _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public override void Executar() => _resolver.Executar(_classe);
    }

    public class MenuOpcaoObjeto : MenuOpcao, IMenuOpcaoObjeto
    {
        private readonly UserControl _userControl;
        private readonly IMenuResolverObjeto _resolver;

        public MenuOpcaoObjeto(IMenuOpcaoTipo tipo, string codigo, string descricao, UserControl userControl, IMenuResolverObjeto resolver,
            IList<IMenuOpcao> subMenuOpcao = null) : base(tipo, codigo, descricao, subMenuOpcao)
        {
            _userControl = userControl ?? throw new ArgumentNullException(nameof(userControl));
            _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public override void Executar() => _resolver.Executar(_userControl);
    }

    public class MenuOpcaoTipo<TObject> : MenuOpcao, IMenuOpcaoTipo<TObject>
        where TObject : class
    {
        private readonly IMenuResolverTipo _resolver;

        public MenuOpcaoTipo(IMenuOpcaoTipo tipo, string codigo, string descricao, IMenuResolverTipo resolver, 
            IList<IMenuOpcao> subMenuOpcao = null) : base(tipo, codigo, descricao, subMenuOpcao)
        {
            _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public override void Executar() => _resolver.Executar<TObject>();
    }
}