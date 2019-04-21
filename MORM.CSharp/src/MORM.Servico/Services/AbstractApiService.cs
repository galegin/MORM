using MORM.Dominio.Interfaces;
using MORM.Dtos;
using MORM.Repositorio.Repositories;
using MORM.Repositorio.Uow;
using MORM.Servico.Interfaces;
using System;
using System.Linq;

namespace MORM.Servico.Services
{
    public class AbstractApiService : IAbstractApiService
    {
        public AbstractApiService(IAbstractUnityOfWork abstractUnityOfWork)
        {
            AbstractUnityOfWork = abstractUnityOfWork ?? throw new ArgumentNullException(nameof(abstractUnityOfWork));
        }

        public IAbstractUnityOfWork AbstractUnityOfWork { get; }
        public void SetAmbiente(IAmbiente ambiente) => AbstractUnityOfWork.SetAmbiente(ambiente);
    }

    public class AbstractAmbApiService : IAbstractAmbApiService
    {
        public AbstractAmbApiService(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
        }

        public IAmbiente Ambiente { get; }
    }

    public class AbstractApiService<TObject> : AbstractApiService, IAbstractApiService<TObject> 
        where TObject : class
    {
        public AbstractApiService(IAbstractUnityOfWork abstractUnityOfWork) : base(abstractUnityOfWork)
        {
            AbstractRepository = new AbstractRepository<TObject>(abstractUnityOfWork.DataContext);
        }

        public IAbstractRepository<TObject> AbstractRepository { get; }

        //-- listar

        public AbstractListarDto.Retorno<TObject> Listar(AbstractListarDto.Envio<TObject> dto)
        {
            return new AbstractListarDto.Retorno<TObject>
            {
               Lista = AbstractRepository
                    .ListarO(dto.Filtro, qtde: dto.QtdeRegistro, pagina: dto.NumeroPagina)
                    .ToList()
            };
        }

        //-- consultar

        public AbstractConsultarDto.Retorno<TObject> Consultar(AbstractConsultarDto.Envio<TObject> dto)
        {
            return new AbstractConsultarDto.Retorno<TObject>(AbstractRepository.ConsultarO(dto.Filtro));
        }

        //-- incluir

        public void Incluir(AbstractIncluirDto.Envio<TObject> dto)
        {
            AbstractRepository.Incluir(dto.Objeto);
        }

        //-- alterar

        public void Alterar(AbstractAlterarDto.Envio<TObject> dto)
        {
            AbstractRepository.Alterar(dto.Objeto);
        }

        //-- salvar

        public void Salvar(AbstractSalvarDto.Envio<TObject> dto)
        {
            AbstractRepository.Salvar(dto.Objeto);
        }

        //-- excluir

        public void Excluir(AbstractExcluirDto.Envio<TObject> dto)
        {
            AbstractRepository.Excluir(dto.Objeto);
        }

        //-- sequencia

        public int Sequencia(AbstractSequenciaDto.Envio<TObject> dto)
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
                    sequencia = AbstractRepository.SequenciaMaxO(dto.Filtro);
                }
                catch { sequencia = -1; }
            }

            return sequencia;
        }
    }
}