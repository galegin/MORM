using MORM.Dominio.Extensions;
using MORM.Dominio.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MORM.Repositorio.Repositories
{
    public class AbstractRepository : IAbstractRepository
    {
        protected readonly IAbstractDataContext _dataContext;

        public AbstractRepository(IAbstractDataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }
    }

    public class AbstractRepository<TObject> : AbstractRepository, IAbstractRepository<TObject>
    {
        public IDbSet<TObject> DbSet { get; }

        public AbstractRepository(IAbstractDataContext context) : base(context)
        {
            DbSet = context.Set<TObject>();
        }

        // listar

        public IList<TObject> ListarF(Func<TObject, string> filtro, int qtde = -1, int pagina = 0, bool relacao = false)
        {
            return _dataContext.GetListaF(filtro, qtde: qtde, pagina: pagina, relacao: relacao);
        }

        public IList<TObject> ListarO(object objeto, int qtde = -1, int pagina = 0, bool relacao = false)
        {
            return _dataContext.GetListaO<TObject>(objeto, qtde: qtde, pagina: pagina, relacao: relacao);
        }


        public IList<TObject> ListarW(string where, int qtde = -1, int pagina = 0, bool relacao = false)
        {
            return _dataContext.GetListaW<TObject>(where, qtde: qtde, pagina: pagina, relacao: relacao);
        }

        // consultar

        public TObject ConsultarF(Func<TObject, string> filtro, bool relacao = true)
        {
            return _dataContext.GetObjetoF(filtro, relacao: relacao);
        }

        public TObject ConsultarO(object objeto, bool relacao = true)
        {
            return _dataContext.GetObjetoO<TObject>(objeto, relacao: relacao);
        }

        public TObject ConsultarW(string where, bool relacao = true)
        {
            return _dataContext.GetObjetoW<TObject>(where, relacao: relacao);
        }

        // incluir

        public void Incluir(IList<TObject> lista, bool relacao = true)
        {
            try
            {
                _dataContext.BeginTransaction();
                _dataContext.InsLista(lista as IList, relacao: relacao);
                _dataContext.CommitTransaction();
            }
            catch
            {
                _dataContext.RoolBackTransaction();
                throw;
            }
        }

        public void Incluir(TObject objeto, bool relacao = true)
        {
            try
            {
                _dataContext.BeginTransaction();
                _dataContext.InsObjeto(objeto, relacao: relacao);
                _dataContext.CommitTransaction();
            }
            catch
            {
                _dataContext.RoolBackTransaction();
                throw;
            }
        }

        // alterar

        public void Alterar(IList<TObject> lista, bool relacao = true)
        {
            try
            {
                _dataContext.BeginTransaction();
                _dataContext.UpdLista(lista as IList, relacao: relacao);
                _dataContext.CommitTransaction();
            }
            catch
            {
                _dataContext.RoolBackTransaction();
                throw;
            }
        }

        public void Alterar(TObject objeto, bool relacao = true)
        {
            try
            {
                _dataContext.BeginTransaction();
                _dataContext.UpdObjeto(objeto, relacao: relacao);
                _dataContext.CommitTransaction();
            }
            catch
            {
                _dataContext.RoolBackTransaction();
                throw;
            }
        }

        // salvar

        public void Salvar(IList<TObject> lista, bool relacao = true)
        {
            try
            {
                _dataContext.BeginTransaction();
                _dataContext.SetLista(lista as IList, relacao: relacao);
                _dataContext.CommitTransaction();
            }
            catch
            {
                _dataContext.RoolBackTransaction();
                throw;
            }
        }

        public void Salvar(TObject objeto, bool relacao = true)
        {
            try
            {
                _dataContext.BeginTransaction();
                _dataContext.SetObjeto(objeto, relacao: relacao);
                _dataContext.CommitTransaction();
            }
            catch
            {
                _dataContext.RoolBackTransaction();
                throw;
            }
        }

        // excluir

        public void Excluir(IList<TObject> lista, bool relacao = true)
        {
            try
            {
                _dataContext.BeginTransaction();
                _dataContext.RemLista(lista as IList, relacao: relacao);
                _dataContext.CommitTransaction();
            }
            catch
            {
                _dataContext.RoolBackTransaction();
                throw;
            }
        }

        public void Excluir(TObject objeto, bool relacao = true)
        {
            try
            {
                _dataContext.BeginTransaction();
                _dataContext.RemObjeto(objeto, relacao: relacao);
                _dataContext.CommitTransaction();
            }
            catch
            {
                _dataContext.RoolBackTransaction();
                throw;
            }
        }

        // sequencia

        public int Sequencia(TObject objeto)
        {
            // generator

            try
            {
                return SequenciaGen();
            }
            catch { }

            // select max

            try
            {
                return SequenciaMaxO(objeto);
            }
            catch { }

            return -1;
        }

        private int SequenciaGen() => _dataContext.GetSequenciaGen<TObject>();
        private int SequenciaMaxF(Func<TObject, string> filtro) => _dataContext.GetSequenciaMaxF(filtro);
        private int SequenciaMaxO(object objeto) => _dataContext.GetSequenciaMaxO<TObject>(objeto);
        private int SequenciaMaxW(string where) => _dataContext.GetSequenciaMaxW<TObject>(where);

        // gatilhos

        public virtual void preIncluir(TObject objeto) { }
        public virtual void posIncluir(TObject objeto) { }
        public virtual void preAlterar(TObject objeto) { }
        public virtual void posAlterar(TObject objeto) { }
        public virtual void preSalvar(TObject objeto) { }
        public virtual void posSalvar(TObject objeto) { }
        public virtual void preExcluir(TObject objeto) { }
        public virtual void posExcluir(TObject objeto) { }
    }
}