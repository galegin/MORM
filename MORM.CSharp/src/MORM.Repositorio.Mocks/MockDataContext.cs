using MORM.Dominio.Extensions;
using MORM.Dominio.Interfaces;
using MORM.CrossCutting;
using MORM.Repositorio.Context;
using MORM.Repositorio.Factories;
using MORM.Repositorio.Migrations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Repositorio.Mocks
{
    public class MockDataContext : IAbstractDataContext, IDisposable
    {
        public IAmbiente Ambiente { get; private set; }
        public IConexao Conexao { get; private set; }
        public IComando Comando { get; private set; }
        public IMigracao Migracao { get; private set; }

        private Dictionary<Type, List<object>> _dados = new Dictionary<Type, List<object>>();

        public MockDataContext(IAmbiente ambiente)
        {
            SetAmbiente(ambiente);
        }

        //-- ambiente

        public void SetAmbiente(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
            Conexao = ConexaoFactory.GetConexao(ambiente);
            Comando = new Comando(ambiente.TipoDatabase);
            Migracao = new Migracao(this);
        }
        
        // dicionario

        private List<object> GetLista(Type type)
        {
            var lista = _dados.ContainsKey(type) ? _dados[type] : null;
            if (lista == null)
            {
                _dados[type] = lista = new List<object>();
            }
            return lista;
        }

        // lista

        public void GetLista(IList lista, string where = null, bool relacao = false, int qtde = -1, int pagina = 0)
        {
            var type = lista.GetType().GetGenericArguments().Single();

            GetLista(type).ForEach(itemLista =>
            {
                var item = Activator.CreateInstance(type);
                item.CloneInstancePropOrFieldAll(itemLista);
                lista.Add(item);
            });
        }

        // objeto

        public void GetObjeto(object obj, string where = null, bool relacao = true)
        {
            var objConsulta = GetLista(obj.GetType()).FirstOrDefault();
            obj.CloneInstancePropOrFieldAll(objConsulta);
        }

        // salvar

        public void SetObjeto(object obj, bool relacao = true)
        {
            UpdObjeto(obj);
        }

        // incluir

        public void InsObjeto(object obj, bool relacao = true)
        {
            UpdObjeto(obj);
        }

        // alterar

        public void UpdObjeto(object obj, bool relacao = true)
        {
            RemObjeto(obj);
            GetLista(obj.GetType()).Add(obj);
        }

        // remover

        public void RemObjeto(object obj, bool relacao = true)
        {
            GetLista(obj.GetType()).Remove(obj);
        }

        // dispose

        public void Dispose()
        {
            //this.DesConectar();
            GC.SuppressFinalize(this);
        }

        static MockDataContext()
        {
        }

        ~MockDataContext()
        {
            Dispose();
        }
    }
}