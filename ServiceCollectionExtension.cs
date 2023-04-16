using CQRSWithoutMediator.Domain.Handlers;
using CQRSWithoutMediator.Domain.Handlers.Interfaces;
using CQRSWithoutMediator.Domain.Services;
using CQRSWithoutMediator.Domain.Services.Interfaces;
using CQRSWithoutMediator.Infra.Interfaces;
using CQRSWithoutMediator.Infra.Repositorys;

namespace CQRSWithoutMediator
{
    public static class ServiceCollectionExtension 
    {
        /// <summary>
        /// Application Handlers 
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureHandlers(IServiceCollection services)
        {
            services.AddTransient<ICreateProductHandler, CreateProductHandler>();
        }

        /// <summary>
        /// Application Services 
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
        }

        /// <summary>
        /// Repositorys Application
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRepositorys(IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, ProductRepository>();
        }
    }
}
