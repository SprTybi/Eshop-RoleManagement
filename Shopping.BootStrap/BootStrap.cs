using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shopping.Bussiness.Implementations;
using Shopping.BussinessServiceContract.Services;
using Shopping.DataAcceServiceContract.Repositories;
using Shopping.DataAccess.Repositories;
using Shopping.DomainModel.Models;

namespace Shopping.BootStrap
{
    public static class BootStrap
    {
        public static void WireUP(IServiceCollection services,string ConnectionString)
        {
            services.AddDbContext<EshopMashtiHasanContext>(optionsAction =>
                {
                    optionsAction.UseSqlServer(ConnectionString);
                },ServiceLifetime.Scoped);
            services.AddScoped<ICategoryBuss, CategoryBuss>();
            services.AddScoped<ISupplierBuss, SupplierBuss>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

        }
    }
}
