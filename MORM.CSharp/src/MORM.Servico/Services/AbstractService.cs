using MORM.Dominio.Interfaces;
using MORM.Repositorio.Repositories;
using MORM.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Servico.Services
{
    public class AbstractService : IAbstractService
    {
        public IAbstractUnityOfWork AbstractUnityOfWork { get; }

        public AbstractService(IAbstractUnityOfWork abstractUnityOfWork)
        {
            AbstractUnityOfWork = abstractUnityOfWork ?? throw new ArgumentNullException(nameof(abstractUnityOfWork));
        }
    }

    public class AbstractAmbService : IAbstractAmbService
    {
        public IAmbiente Ambiente { get; }

        public AbstractAmbService(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
        }
    }

    public class AbstractService<TObject> : AbstractService, IAbstractService<TObject>
    {
        public IAbstractRepository<TObject> AbstractRepository { get; }

        public AbstractService(IAbstractUnityOfWork abstractUnityOfWork) : base(abstractUnityOfWork)
        {
            AbstractRepository = new AbstractRepository<TObject>(abstractUnityOfWork.DataContext);
        }

        //-- listar

        public List<TObject> Listar(TObject filtro) => AbstractRepository.ListarO(filtro).ToList();

        //-- consultar

        public TObject Consultar(TObject filtro) => AbstractRepository.ConsultarO(filtro);

        //-- incluir

        public void Incluir(TObject objeto) => AbstractRepository.Incluir(objeto);

        //-- alterar

        public void Alterar(TObject objeto) =>  AbstractRepository.Alterar(objeto);

        //-- salvar

        public void Salvar(TObject objeto) => AbstractRepository.Salvar(objeto);

        //-- excluir

        public void Excluir(TObject objeto) => AbstractRepository.Excluir(objeto);

        //-- sequencia

        public int Sequencia(TObject filtro)
        {
            var sequencia = 0;

            // generator

            try
            {
                sequencia = AbstractRepository.SequenciaGen();
            }
            catch { sequencia = -1; }

            // select max

            if (sequencia <= 0)
            {
                try
                {
                    sequencia = AbstractRepository.SequenciaMaxO(filtro);
                }
                catch { sequencia = -1; }
            }

            return sequencia;
        }
    }
}