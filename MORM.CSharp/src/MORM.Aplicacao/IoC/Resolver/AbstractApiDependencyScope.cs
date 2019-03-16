using Castle.Windsor;
using MORM.Ioc.Container;

namespace MORM.Aplicacao.Ioc.Container
{
    public class AbstractApiDependencyScope : AbstractDependencyScope
    {
        public AbstractApiDependencyScope(IWindsorContainer container) : base(container)
        {
        }
    }
}