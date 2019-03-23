using MORM.Repositorio.Extensions;
using MORM.Repositorio.Interfaces;
using MORM.Repositorio.Queries;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MORM.Repositorio.Repositories
{
    public class AbstractRepository : IAbstractRepository
    {
        public AbstractRepository(IAbstractDataContext context)
        {
            DataContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IAbstractDataContext DataContext { get; }
    }

    public class AbstractRepository<TObject> : AbstractRepository, IAbstractRepository<TObject> where TObject : class
    {
        public AbstractRepository(IAbstractDataContext context) : base(context)
        {
        }

        // query

        public IQueryableObject<TObject> AsQueryable()
        {
            return new QueryableObject<TObject>(DataContext);
        }

        // listar

        public IList<TObject> ListarF(Func<TObject, string> filtro, int qtde = -1, int pagina = 0, bool relacao = false)
        {
            return DataContext.GetListaF(filtro, qtde: qtde, pagina: pagina, relacao: relacao);
        }

        public IList<TObject> ListarO(object objeto, int qtde = -1, int pagina = 0, bool relacao = false)
        {
            return DataContext.GetListaO<TObject>(objeto, qtde: qtde, pagina: pagina, relacao: relacao);
        }


        public IList<TObject> ListarW(string where, int qtde = -1, int pagina = 0, bool relacao = false)
        {
            return DataContext.GetListaW<TObject>(where, qtde: qtde, pagina: pagina, relacao: relacao);
        }

        // consultar

        public TObject ConsultarF(Func<TObject, string> filtro, bool relacao = true)
        {
            return DataContext.GetObjetoF(filtro, relacao: relacao);
        }

        public TObject ConsultarO(object objeto, bool relacao = true)
        {
            return DataContext.GetObjetoO<TObject>(objeto, relacao: relacao);
        }

        public TObject ConsultarW(string where, bool relacao = true)
        {
            return DataContext.GetObjetoW<TObject>(where, relacao: relacao);
        }

        // incluir

        public void Incluir(IList<TObject> lista, bool relacao = true)
        {
            try
            {
                DataContext.BeginTransaction();
                DataContext.InsLista(lista as IList, relacao: relacao);
                DataContext.CommitTransaction();
            }
            catch
            {
                DataContext.RoolBackTransaction();
                throw;
            }
        }

        public void Incluir(TObject objeto, bool relacao = true)
        {
            try
            {
                DataContext.BeginTransaction();
                DataContext.InsObjeto(objeto, relacao: relacao);
                DataContext.CommitTransaction();
            }
            catch
            {
                DataContext.RoolBackTransaction();
                throw;
            }
        }

        // alterar

        public void Alterar(IList<TObject> lista, bool relacao = true)
        {
            try
            {
                DataContext.BeginTransaction();
                DataContext.UpdLista(lista as IList, relacao: relacao);
                DataContext.CommitTransaction();
            }
            catch
            {
                DataContext.RoolBackTransaction();
                throw;
            }
        }

        public void Alterar(TObject objeto, bool relacao = true)
        {
            try
            {
                DataContext.BeginTransaction();
                DataContext.UpdObjeto(objeto, relacao: relacao);
                DataContext.CommitTransaction();
            }
            catch
            {
                DataContext.RoolBackTransaction();
                throw;
            }
        }

        // salvar

        public void Salvar(IList<TObject> lista, bool relacao = true)
        {
            try
            {
                DataContext.BeginTransaction();
                DataContext.SetLista(lista as IList, relacao: relacao);
                DataContext.CommitTransaction();
            }
            catch
            {
                DataContext.RoolBackTransaction();
                throw;
            }
        }

        public void Salvar(TObject objeto, bool relacao = true)
        {
            try
            {
                DataContext.BeginTransaction();
                DataContext.SetObjeto(objeto, relacao: relacao);
                DataContext.CommitTransaction();
            }
            catch
            {
                DataContext.RoolBackTransaction();
                throw;
            }
        }

        // excluir

        public void Excluir(IList<TObject> lista, bool relacao = true)
        {
            try
            {
                DataContext.BeginTransaction();
                DataContext.RemLista(lista as IList, relacao: relacao);
                DataContext.CommitTransaction();
            }
            catch
            {
                DataContext.RoolBackTransaction();
                throw;
            }
        }

        public void Excluir(TObject objeto, bool relacao = true)
        {
            try
            {
                DataContext.BeginTransaction();
                DataContext.RemObjeto(objeto, relacao: relacao);
                DataContext.CommitTransaction();
            }
            catch
            {
                DataContext.RoolBackTransaction();
                throw;
            }
        }

        // sequencia

        public int SequenciaGen()
        {
            return DataContext.GetSequenciaGen<TObject>();
        }

        public int SequenciaMaxF(Func<TObject, string> filtro)
        {
            return DataContext.GetSequenciaMaxF(filtro);
        }

        public int SequenciaMaxO(object objeto)
        {
            return DataContext.GetSequenciaMaxO<TObject>(objeto);
        }

        public int SequenciaMaxW(string where)
        {
            return DataContext.GetSequenciaMaxW<TObject>(where);
        }

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