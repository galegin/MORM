using MORM.Repositorio.Extensions;
using MORM.Repositorio.Interfaces;
using MORM.Dominio.Entidades;
using MORM.Dominio.Extensoes;
using MORM.Utils.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Repositorio.Migrations
{
    public class MigracaoEntidade : IMigracaoEntidade
    {
        public MigracaoEntidade(IAbstractDataContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IAbstractDataContext Context { get; }

        public Func<Exception, Type, object> LogErro { get; set; }

        private List<string> _dropForeigns = new List<string>();
        private List<string> _foreigns = new List<string>();

        public void Clear()
        {
            _dropForeigns.Clear();
            _foreigns.Clear();
        }

        //-- create or alter

        public void CreateOrAlter(Type type)
        {
            //-- tabela

            var tabela = type.GetTabela().Nome;

            //-- versao base

            var versaoBase = Context
                .GetObjetoF<Migracao>(f => $"{nameof(f.Codigo)} = '{tabela}'")?.Versao;

            //-- versao model

            var versaoModel = GetMd5(type);
            if (versaoModel.CompareTo(versaoBase) == 0)
                return;

            //-- create or alter

            try
            {
                if (string.IsNullOrWhiteSpace(versaoBase))
                    Create(type);
                else
                    Alter(type);
            }
            catch
            {
                Alter(type);
            }

            //-- foreigns

            try
            {
                var dropForeigns = Context.Ambiente.TipoDatabase.GetListaDeDropForeignCmd(type);
                if (dropForeigns.Any())
                    _dropForeigns.AddRange(dropForeigns);

                var foreigns = Context.Ambiente.TipoDatabase.GetListaDeForeignCmd(type);
                if (foreigns.Any())
                    _foreigns.AddRange(foreigns);
            }
            catch (Exception ex)
            {
                LogErro?.Invoke(ex, type);
            }

            //-- salvar versao base

            Context.SetObjeto(new Migracao(tabela, versaoModel));
        }

        public void CreateOrAlter<TObject>() => CreateOrAlter(typeof(TObject));

        private void Create(Type type)
        {
            var createCmd = Context.Ambiente.TipoDatabase.GetCreateCmd(type);

            try
            {
                Context.Conexao.ExecComando(createCmd);
            }
            catch (Exception ex)
            {
                Logger.ErroException(ex);
                throw;
            }
        }

        private void Alter(Type type)
        {
            var listaAlterCmd = Context.Ambiente.TipoDatabase.GetListaAlterCmd(type);

            foreach (var cmd in listaAlterCmd)
            {
                try
                {
                    Context.Conexao.ExecComando(cmd);
                }
                catch (Exception ex)
                {
                    Logger.ErroException(ex);
                }
            }
        }

        public static string GetMd5(Type type)
        {
            var strMd5 = new List<string>();

            var campos = type.GetCampos();
            foreach (var campo in campos)
                strMd5.Add(campo.OwnerProp.Name + ":" + campo.OwnerProp.PropertyType.Name);

            var relacoes = type.GetRelacoesGet();
            foreach (var relacao in relacoes)
                strMd5.Add(relacao.OwnerProp.Name + ":" + relacao.OwnerProp.PropertyType.Name);

            return string.Join(",", strMd5).GerarHashMd5();
        }

        //-- foreign

        public void DropForeigns()
        {
            foreach (var dropForeign in _dropForeigns)
            {
                try
                {
                    Context.Conexao.ExecComando(dropForeign);
                }
                catch (Exception ex)
                {
                    Logger.ErroException(ex);
                }
            }
        }

        public void CreateForeigns()
        {
            foreach (var foreign in _foreigns)
            {
                try
                {
                    Context.Conexao.ExecComando(foreign);
                }
                catch (Exception ex)
                {
                    Logger.ErroException(ex);
                }
            }
        }
    }
}