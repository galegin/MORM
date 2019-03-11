using Castle.Windsor;
using MORM.IoC.Container;

namespace MORM.Aplicacao.IoC.Container
{
    public class AbstractApiDependencyScope : AbstractDependencyScope
    {
        public AbstractApiDependencyScope(IWindsorContainer container) : base(container)
        {
        }
    }
}