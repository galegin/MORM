﻿namespace MORM.Dominio.Interfaces
{
    public interface IAbstractAppService
    {
        //IAbstractUnityOfWork AbstractUnityOfWork { get; }
        void SetAmbiente(IAmbiente ambiente);
    }

    public interface IAbstractAmbAppService
    {
        IAmbiente Ambiente { get; }
    }

    public interface IAbstractAppService<TObject> : IAbstractAppService where TObject : class
    {
        //IAbstractService<TObject> AbstractService { get; }
        IRepository<TObject> Repository { get; }
        object Listar(TObject filtro);
        object Consultar(TObject filtro);
        object Incluir(TObject objeto);
        object Alterar(TObject objeto);
        object Salvar(TObject objeto);
        object Excluir(TObject objeto);
        object Sequencia(TObject filtro);
    }
}