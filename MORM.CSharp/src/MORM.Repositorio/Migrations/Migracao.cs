using MORM.CrossCutting;
using MORM.Dominio.Entidades;
using MORM.Dominio.Extensions;
using MORM.Dominio.Interfaces;
using MORM.Dominio.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Repositorio.Migrations
{
    public class Migracao : IMigracao
    {
        private readonly IAbstractDataContext _dataContext;
        private IDbSet<MigracaoEnt> _dbSet => _dataContext.Set<MigracaoEnt>();
        private IConexao _conexao => _dataContext.GetConexao();
        private TipoDatabase _tipoDatabase => _dataContext.GetTipoDatabase();
        private List<string> _dropForeigns = new List<string>();
        private List<string> _foreigns = new List<string>();

        public Func<Exception, Type, object> LogErro { get; set; }

        public Migracao(IAbstractDataContext dataContext)
        {
            _dataContext = dataContext;
        }

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

            var migracaoEnt = new MigracaoEnt { Codigo = tabela };
            var versaoBase = _dbSet.GetById(migracaoEnt)?.Versao;

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
                var dropForeigns = _tipoDatabase.GetListaDeDropForeignCmd(type);
                if (dropForeigns.Any())
                    _dropForeigns.AddRange(dropForeigns);

                var foreigns = _tipoDatabase.GetListaDeForeignCmd(type);
                if (foreigns.Any())
                    _foreigns.AddRange(foreigns);
            }
            catch (Exception ex)
            {
                LogErro?.Invoke(ex, type);
            }

            //-- salvar versao base

            _dbSet.AddOrUpdate(new MigracaoEnt(tabela, versaoModel));
        }

        public void CreateOrAlter<TObject>() => CreateOrAlter(typeof(TObject));

        private void Create(Type type)
        {
            var createCmd = _tipoDatabase.GetCreateCmd(type);

            try
            {
                _conexao.ExecComando(createCmd);
            }
            catch (Exception ex)
            {
                Logger.Erro("erro create", ex: ex);
                throw;
            }
        }

        private void Alter(Type type)
        {
            var listaAlterCmd = _tipoDatabase.GetListaAlterCmd(type);

            foreach (var cmd in listaAlterCmd)
            {
                try
                {
                    _conexao.ExecComando(cmd);
                }
                catch (Exception ex)
                {
                    Logger.Erro("erro alter", ex: ex);
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
                    _conexao.ExecComando(dropForeign);
                }
                catch (Exception ex)
                {
                    Logger.Erro("erro drop foreing", ex: ex);
                }
            }
        }

        public void CreateForeigns()
        {
            foreach (var foreign in _foreigns)
            {
                try
                {
                    _conexao.ExecComando(foreign);
                }
                catch (Exception ex)
                {
                    Logger.Erro("erro create foreigns", ex: ex);
                }
            }
        }
    }
}