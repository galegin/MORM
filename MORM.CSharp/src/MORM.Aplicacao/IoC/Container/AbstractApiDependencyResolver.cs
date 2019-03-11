using Castle.Windsor;
using MORM.IoC.Container;

namespace MORM.Aplicacao.IoC.Container
{
    public class AbstractApiDependencyResolver : AbstractDependencyResolver
    {
        public AbstractApiDependencyResolver(IWindsorContainer container) : base(container)
        {
        }
    }
}