﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao
{
    public abstract class MenuOpcao : IMenuOpcao
    {
        public MenuOpcao(MenuOpcaoTipo tipo, string codigo, string descricao, 
            IList<IMenuOpcao> subMenuOpcao = null, MenuOpcaoPermissao? permissao = null)
        {
            Tipo = tipo;
            Codigo = codigo ?? throw new ArgumentNullException(nameof(codigo));
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            Image = tipo.GetImagem();
            SubMenuOpcao = subMenuOpcao;
            Permissao = permissao ?? MenuOpcaoPermissao.Operador;
        }

        public MenuOpcaoTipo Tipo { get; }
        public string Codigo { get; }
        public string Descricao { get; }
        public string Image { get; }
        public IList<IMenuOpcao> SubMenuOpcao { get; }
        public MenuOpcaoPermissao Permissao { get; }
        public abstract void Executar();
    }

    public class MenuOpcaoAcao : MenuOpcao
    {
        private readonly Action _acao;

        public MenuOpcaoAcao(MenuOpcaoTipo tipo, string codigo, string descricao, Action acao, 
            IList<IMenuOpcao> subMenuOpcao = null, MenuOpcaoPermissao? permissao = null) 
            : base(tipo, codigo, descricao, subMenuOpcao, permissao)
        {
            _acao = acao ?? throw new ArgumentNullException(nameof(acao));
        }

        public override void Executar() => _acao.Invoke();
    }

    public class MenuOpcaoDescr : MenuOpcao
    {
        public MenuOpcaoDescr(MenuOpcaoTipo tipo, string codigo, string descricao, 
            IList<IMenuOpcao> subMenuOpcao = null, MenuOpcaoPermissao? permissao = null)
            : base(tipo, codigo, descricao, subMenuOpcao, permissao)
        {
        }

        public override void Executar() { }
    }

    public class MenuOpcaoMetodo : MenuOpcao
    {
        private readonly RoutedEventHandler _metodo;

        public MenuOpcaoMetodo(MenuOpcaoTipo tipo, string codigo, string descricao, RoutedEventHandler metodo,
            IList<IMenuOpcao> subMenuOpcao = null, MenuOpcaoPermissao? permissao = null) 
            : base(tipo, codigo, descricao, subMenuOpcao, permissao)
        {
            _metodo = metodo ?? throw new ArgumentNullException(nameof(metodo));
        }

        public override void Executar() => _metodo(null, null);
    }

    public class MenuOpcaoClasse : MenuOpcao
    {
        private readonly Type _classe;
        private readonly IMenuResolver _resolver;

        public MenuOpcaoClasse(MenuOpcaoTipo tipo, string codigo, string descricao, Type classe, IMenuResolver resolver, 
            IList<IMenuOpcao> subMenuOpcao = null, MenuOpcaoPermissao? permissao = null) 
            : base(tipo, codigo, descricao, subMenuOpcao, permissao)
        {
            _classe = classe ?? throw new ArgumentNullException(nameof(classe));
            _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public override void Executar() => _resolver.Executar(_classe);
    }

    public class MenuOpcaoObjeto : MenuOpcao
    {
        private readonly UserControl _userControl;
        private readonly IMenuResolver _resolver;

        public MenuOpcaoObjeto(MenuOpcaoTipo tipo, string codigo, string descricao, UserControl userControl, IMenuResolver resolver,
            IList<IMenuOpcao> subMenuOpcao = null, MenuOpcaoPermissao? permissao = null) 
            : base(tipo, codigo, descricao, subMenuOpcao, permissao)
        {
            _userControl = userControl ?? throw new ArgumentNullException(nameof(userControl));
            _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public override void Executar() => _resolver.Executar(_userControl);
    }

    public class MenuOpcaoTipo<TObject> : MenuOpcao
        where TObject : class
    {
        private readonly IMenuResolver _resolver;

        public MenuOpcaoTipo(MenuOpcaoTipo tipo, string codigo, string descricao, IMenuResolver resolver, 
            IList<IMenuOpcao> subMenuOpcao = null, MenuOpcaoPermissao? permissao = null) 
            : base(tipo, codigo, descricao, subMenuOpcao, permissao)
        {
            _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public override void Executar() => _resolver.Executar<TObject>();
    }
}