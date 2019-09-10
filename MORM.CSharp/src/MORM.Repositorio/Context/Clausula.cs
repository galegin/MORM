using MORM.Dominio.Tipagens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MORM.Repositorio.Context
{
    /// <summary>
    /// classe para geração de clausula para consulta
    /// 
    /// ex.:
    ///     var comando = new Clausula(TipoDatabase.Oracle)
    ///         .And("codigo").Igual(1)
    ///         .And("descricao").Igual("TESTE")
    ///         .And("data").Igual(DateTime.Today)
    ///         .And("nome").Qualquer("jose")
    ///         .And("tipo").Contem(new List<int> { 1, 2, 3 })
    ///         .And("tipo").NaoContem(new List<string> { "A", "B", "C" })
    ///         .ToString();
    /// 
    /// </summary>
    public class Clausula
    {
        public Clausula(TipoDatabase tipoDatabase)
        {
            TipoDatabase = tipoDatabase;
        }

        public TipoDatabase TipoDatabase { get; private set; }

        public List<string> _wheres = new List<string>();

        public override string ToString()
        {
            return 
                _wheres.Any() ? string.Join(" ", _wheres) : string.Empty;
        }

        public bool Any() => _wheres.Any();

        public Clausula Add(string where)
        {
            _wheres.Add(where);
            return this;
        }

        public Clausula Add(Clausula clausula)
        {
            return clausula.Any() ? Add(clausula.ToString()) : this;
        }

        //-- and / or

        public Clausula And(string where)
        {
            return Add((Any() ? " and " : string.Empty) + where);
        }

        public Clausula Or(string where)
        {
            return Add((Any() ? " or " : string.Empty) + where);
        }

        //-- clausula

        public Clausula And(Clausula clausula)
        {
            return (clausula.Any() ? And(clausula.ToString()) : this);
        }

        public Clausula Or(Clausula clausula)
        {
            return (clausula.Any() ? Or(clausula.ToString()) : this);
        }

        //-- parentese

        public Clausula AbrePar()
        {
            return Add("(");
        }

        public Clausula FechaPar()
        {
            return Add(")");
        }

        //-- condicao

        public Clausula ENulo()
        {
            return Add("is null");
        }

        public Clausula EDiferente(object value)
        {
            return Add("!= " + ValueToString(value));
        }

        public Clausula EDiferenteDeNulo()
        {
            return Add("is not null");
        }

        public Clausula Igual(object value)
        {
            return Add("= " + ValueToString(value));
        }

        public Clausula Maior(object value)
        {
            return Add("> " + ValueToString(value));
        }

        public Clausula MaiorOuIgual(object value)
        {
            return Add(">= " + ValueToString(value));
        }

        public Clausula Menor(object value)
        {
            return Add("< " + ValueToString(value));
        }

        public Clausula MenorOuIgual(object value)
        {
            return Add("<= " + ValueToString(value));
        }

        //-- qualquer

        public Clausula Qualquer(string valor)
        {
            return Add("like '%" + valor.Replace(" ", "%") + "%'");
        }

        //-- entre

        public Clausula Entre(object inicial, object final)
        {
            return Add("between " + ValueToString(inicial) + " and " + ValueToString(final));
        }

        //-- contem / nao contem

        public Clausula Contem<TValue>(List<TValue> lista)
        {
            return Add("in (" + string.Join(",", ListaToString(lista)) + ")");
        }

        public Clausula NaoContem<TValue>(List<TValue> lista)
        {
            return Add("not in (" + string.Join(",", ListaToString(lista)) + ")");
        }

        //-- converter
        
        private string ValueToString(object value)
        {
            return (
                value is DateTime ? TipoDatabase.GetValueData((DateTime)value) :
                value is double ? ((double)value).ToString(CultureInfo.InvariantCulture) :
                value is decimal ? ((decimal)value).ToString(CultureInfo.InvariantCulture) :
                value is float ? ((float)value).ToString(CultureInfo.InvariantCulture) :
                value is long ? ((long)value).ToString() :
                value is int ? ((int)value).ToString() :
                value is short ? ((short)value).ToString() :
                value is string[] ? "'" + string.Join("|", value as string[]).Replace("'", "''") + "'" :
                value is string ? "'" + ((string)value).Replace("'", "''") + "'" : string.Empty);
        }

        private List<string> ListaToString<TValue>(List<TValue> lista)
        {
            return lista.ConvertAll(x => ValueToString(x));
        }
    }
}