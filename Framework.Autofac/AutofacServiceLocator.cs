using Autofac;
using Framework.Core;

namespace Framework.Autofac
{
    public class AutofacServiceLocator : IServiceLocator
    {
        //private readonly IContainer _container;
        private readonly ILifetimeScope _scope;
        public AutofacServiceLocator(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public T GetInstance<T>() where T : class
        {
            return _scope.Resolve<T>();
            //return _container.Resolve<T>();
        }
    }
}
