using MORM.Repositorio.Services;
using MORM.Repositorio.Tests.Models;
using MORM.Utilidade.Interfaces;

namespace MORM.Repositorio.Tests.Servicos
{
    //-- galeg - 31/03/2018 13:19:06
    public class TesteService : AbstractService<TesteModel>
    {
        public TesteService(IAmbiente ambiente) : base(ambiente)
        {
        }
    }
}