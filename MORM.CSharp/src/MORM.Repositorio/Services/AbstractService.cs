using MORM.Repositorio.Context;
using MORM.Repositorio.Repositories;
using MORM.Utilidade.Interfaces;
using System;
using System.Collections.Generic;

namespace MORM.Repositorio.Services
{
    //-- galeg - 01/05/2018 11:14:23
    public class AbstractService : IAbstractService
    {
        public AbstractService(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
        }

        public IAmbiente Ambiente { get; }
    }

    public class AbstractService<TObject> : AbstractService, IAbstractService<TObject> where TObject : class
    {
        public AbstractService(IAmbiente ambiente) : base(ambiente)
        {
            AbstractRepository = new AbstractRepository<TObject>(new DataContext(ambiente));
        }

        public IAbstractRepository<TObject> AbstractRepository { get; }

        //-- listar

        public IList<TObject> ListarF(Func<TObject, string> filtro, int qtde = -1, int pagina = 0)
        {
            return AbstractRepository.ListarF(filtro, qtde, pagina);
        }

        public IList<TObject> ListarO(object objeto, int qtde = -1, int pagina = 0)
        {
            return AbstractRepository.ListarO(objeto, qtde, pagina);
        }

        public IList<TObject> ListarW(string where, int qtde = -1, int pagina = 0)
        {
            return AbstractRepository.ListarW(where, qtde, pagina);
        }

        //-- consultar

        public TObject ConsultarF(Func<TObject, string> filtro)
        {
            return AbstractRepository.ConsultarF(filtro);
        }

        public TObject ConsultarO(object objeto)
        {
            return AbstractRepository.ConsultarO(objeto);
        }

        public TObject ConsultarW(string where)
        {
            return AbstractRepository.ConsultarW(where);
        }

        //-- salvar

        public void Salvar(IList<TObject> lista)
        {
            AbstractRepository.Salvar(lista);
        }

        public void Salvar(TObject objeto)
        {
            AbstractRepository.Salvar(objeto);
        }

        //-- excluir

        public void Excluir(IList<TObject> lista)
        {
            AbstractRepository.Excluir(lista);
        }

        public void Excluir(TObject objeto)
        {
            AbstractRepository.Excluir(objeto);
        }

        //-- sequencia

        public int SequenciaGen()
        {
            return AbstractRepository.SequenciaGen();
        }

        //-- select max

        public int SequenciaMaxF(Func<TObject, string> filtro)
        {
            return AbstractRepository.SequenciaMaxF(filtro);
        }

        public int SequenciaMaxO(object objeto)
        {
            return AbstractRepository.SequenciaMaxO(objeto);
        }

        public int SequenciaMaxW(string where)
        {
            return AbstractRepository.SequenciaMaxW(where);
        }
    }
}