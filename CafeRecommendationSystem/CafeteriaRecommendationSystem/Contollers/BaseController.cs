using Microsoft.Extensions.DependencyInjection;

namespace CafeteriaRecommendationSystem.Contollers
{
    public abstract class BaseController
    {
        protected IServiceProvider ServiceProvider { get; private set; }

        protected BaseController(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        protected T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
