using MORM.Repositorio.Repositories;
using MORM.Utilidade.Interfaces;
using System;
using System.Collections.Generic;

namespace MORM.Repositorio.Services
{
    //-- galeg - 01/05/2018 11:38:32
    public interface IAbstractService
    {
        IAmbiente Ambiente { get; }
    }

    public interface IAbstractService<TObject> : IAbstractService where TObject : class
    {
        IAbstractRepository<TObject> AbstractRepository { get; }
        IList<TObject> ListarF(Func<TObject, string> filtro, int qtde = -1, int pagina = 0);
        IList<TObject> ListarO(object objeto, int qtde = -1, int pagina = 0);
        IList<TObject> ListarW(string where, int qtde = -1, int pagina = 0);
        TObject ConsultarF(Func<TObject, string> filtro);
        TObject ConsultarO(object objeto);
        TObject ConsultarW(string where);
        void Salvar(IList<TObject> lista);
        void Salvar(TObject objeto);
        void Excluir(IList<TObject> lista);
        void Excluir(TObject objeto);
        int SequenciaGen();
        int SequenciaMaxF(Func<TObject, string> filtro);
        int SequenciaMaxO(object objeto);
        int SequenciaMaxW(string where);
    }
}