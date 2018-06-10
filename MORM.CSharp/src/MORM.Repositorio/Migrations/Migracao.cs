using MORM.Repositorio.Interfaces;
using MORM.Utilidade.Entidades;
using MORM.Utilidade.Extensoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Repositorio.Migrations
{
    //-- galeg - 31/03/2018 11:49:20
    public class Migracao : IMigracao
    {
        public Migracao(IDataContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IDataContext Context { get; }

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

            var versaoBase = Context.GetObjetoF<MigracaoVersao>((f) => $"{nameof(f.Codigo)} = '{tabela}'")?.Versao;

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

            Context.SetObjeto(new MigracaoVersao(tabela, versaoModel));
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
                Console.WriteLine(nameof(Migracao) + ".Create() -> Message: " + 
                    ex.Message + " / StackTrace: " + ex.StackTrace);
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
                    Console.WriteLine(nameof(Migracao) + ".Alter() -> Message: " + 
                        ex.Message + " / StackTrace: " + ex.StackTrace);
                }
            }
        }

        private static string GetMd5(Type type)
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
                    Console.WriteLine(nameof(Migracao) + ".DropForeigns() -> Message: " +
                        ex.Message + " / StackTrace: " + ex.StackTrace);
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
                    Console.WriteLine(nameof(Migracao) + ".CreateForeigns() -> Message: " +
                        ex.Message + " / StackTrace: " + ex.StackTrace);
                }
            }
        }
    }
}