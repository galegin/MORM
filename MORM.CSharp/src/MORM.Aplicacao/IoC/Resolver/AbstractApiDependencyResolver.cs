using Castle.Windsor;
using MORM.Ioc.Container;

namespace MORM.Aplicacao.Ioc.Container
{
    public class AbstractApiDependencyResolver : AbstractDependencyResolver
    {
        public AbstractApiDependencyResolver(IWindsorContainer container) : base(container)
        {
        }
    }
}