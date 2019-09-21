using System;
using System.Collections.Generic;
using System.Linq;
using MORM.Dominio.Atributos;
using MORM.Dominio.Extensions;
using MORM.Dominio.Interfaces;
using MORM.Dominio.Types;
using MORM.CrossCutting;

namespace MORM.Repositorio.Context
{
    public class Comando : IComando
    {
        public Comando(TipoDatabase tipoDatabase)
        {
            _tipoDatabase = tipoDatabase;
        }

        //-- tipo database

        private TipoDatabase _tipoDatabase;
        private Type _tipoObjeto;
        private object _objeto;
        private IList<IParametro> _parametros;
        private CampoTipo[] _campoTipos;
        private string _where;
        private int _qtde = -1;
        private int _pagina = 0;

        //-- tabela / campos

        private TabelaAttribute _tabela => _objeto?.GetTabela() ?? _tipoObjeto.GetTabela();
        private IEnumerable<CampoAttribute> _campos => _objeto?.GetCampos() ?? _tipoObjeto.GetCampos();
        private IEnumerable<CampoAttribute> _camposKey => _campos?.Where(x => x.IsKey);
        private IEnumerable<CampoAttribute> _camposReq => _campos?.Where(x => x.IsReq);

        //-- bulider

        public IComando ComTipoDatabase(TipoDatabase tipoDatabase)
        {
            _tipoDatabase = tipoDatabase;
            return this;
        }

        private void ResetarCampos()
        {
            _tipoObjeto = null;
            _objeto = null;
            _parametros = null;
            _campoTipos = null;
        }

        public IComando ComTipoObjeto(Type tipoObjeto)
        {
            ResetarCampos();
            _tipoObjeto = tipoObjeto;
            return this;
        }

        public IComando ComObjeto(object Objeto)
        {
            ResetarCampos();
            _objeto = Objeto;
            return this;
        }

        public IComando ComParametros(IList<IParametro> parametros)
        {
            _parametros = parametros;
            return this;
        }

        public IComando ComTipoCampo(CampoTipo[] campoTipos)
        {
            _campoTipos = campoTipos;
            return this;
        }

        public IComando ComWhere(string where)
        {
            _where = where;
            return this;
        }

        public IComando ComQtde(int qtde = -1)
        {
            _qtde = qtde;
            return this;
        }

        public IComando ComPagina(int pagina = 0)
        {
            _pagina = pagina;
            return this;
        }

        //-- value

        private string GetValueStr(object value)
        {
            return _tipoDatabase.GetValueStr(value);
        }

        private string GetValueStr(string atributo)
        {
            var value = _objeto.GetInstancePropOrField(atributo);

            if (_parametros != null)
            {
                _parametros.Add(new Parametro(atributo, value));
                return _tipoDatabase.GetNameParameter(atributo);
            }

            return GetValueStr(value);
        }

        private bool IsValueNull(string atributo)
        {
            return _objeto.GetInstancePropOrField(atributo)?.IsValueNull() ?? true;
        }

        //-- where

        private string GetWhereTip(Func<CampoAttribute, bool> filtro, bool isKeyOnly = false)
        {
            var campos = filtro != null ? _campos.Where(filtro) : _campos;

            var wheres = new List<string>();

            foreach (var campo in campos)
            {
                var valueObj = campo.OwnerProp.GetValue(_objeto);
                if (isKeyOnly || (!valueObj.IsValueNull()))
                    wheres.Add($"{campo.Atributo} = {GetValueStr(valueObj)}");
            }

            return 
                wheres.Any() ? string.Join(" and ", wheres) : string.Empty;
        }

        public string GetWhereKey() => GetWhereTip((f) => f.IsKey);

        public string GetWhereAll() => GetWhereTip(null);

        public string GetWhereObj()
        {
            var isKeyOnly = _campoTipos.Length == 1 && _campoTipos.Contains(CampoTipo.Key);

            return GetWhereTip((f) => _campoTipos.Contains(f.Tipo), isKeyOnly);
        }

        //-- select

        public string GetSelect()
        {
            var fieldsAtr = new List<string>();
            var fields = new List<string>();

            foreach (var campo in _campos)
            {
                fieldsAtr.Add($"{campo.Atributo} as \"{campo.Atributo}\"");
                fields.Add($"{campo.Nome} as {campo.Atributo}");
            }

            var sql =
                $"select {string.Join(", ", fieldsAtr)}" +
                $" from (select {string.Join(", ", fields)} from {_tabela.Nome})" +
                (!string.IsNullOrWhiteSpace(_where) ? $" where {_where}" : string.Empty);

            if (_qtde != -1)
            {
                sql = _tipoDatabase.GetSelectLim(sql, _qtde, _pagina);
            }

            return sql;
        }

        public string GetSelectKey()
        {
            return ComWhere(GetWhereKey()).GetSelect();
        }

        //-- insert

        public string GetInsert()
        {
            var fields = new List<string>();
            var values = new List<string>();

            foreach (var campo in _campos)
            {
                fields.Add(campo.Nome);
                values.Add(GetValueStr(campo.Atributo));
            }

            return 
                $"insert into {_tabela.Nome} ({string.Join(", ", fields)})" + 
                $" values ({string.Join(", ", values)})";
        }

        //-- update

        public string GetUpdate()
        {
            var sets = new List<string>();
            var wheres = new List<string>();

            foreach (var campo in _campos)
                if (campo.IsKey)
                    wheres.Add($"{campo.Nome} = {GetValueStr(campo.Atributo)}");
                else
                    sets.Add($"{campo.Nome} = {GetValueStr(campo.Atributo)}");

            return
                $"update {_tabela.Nome}" +
                $" set {string.Join(", ", sets)}" +
                $" where {string.Join(" and ", wheres)}";
        }

        //-- delete

        public string GetDelete()
        {
            var wheres = new List<string>();

            foreach (var campo in _camposKey)
                wheres.Add($"{campo.Nome} = {GetValueStr(campo.Atributo)}");

            return
                $"delete from {_tabela.Nome}" + 
                $" where {string.Join(" and ", wheres)}";
        }

        public string GetSequencia()
        {
            var fieldsAtr = new List<string>();
            var fields = new List<string>();

            var campoSelectMax = _tipoObjeto.GetCampoSelectMax();
            if (campoSelectMax == null)
                return _tipoDatabase.GetSequenceGen(_tabela.Nome);

            return
                _tipoDatabase.GetSelectMax(GetSelect(), $"\"{campoSelectMax.Name}\"");
        }
    }
}