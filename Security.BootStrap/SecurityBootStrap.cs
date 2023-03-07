using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Security.Bussiness.Implementations;
using Security.BussinessServiceContract.Services;
using Security.DataAccess.Repositories;
using Security.DataAccessServiceContract.Repositories;
using Security.Domain.Models;

namespace Security.BootStrap
{
    public static class SecurityBootStrap
    {
        public static void WireUP(IServiceCollection services, string ConnectionString)
        {
            services.AddDbContext<SecurityContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(ConnectionString);
            }, ServiceLifetime.Scoped);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleActionRepository, RoleActionRepository>();
            services.AddScoped<IProjectActionRepository, ProjectActionRepository>();
            services.AddScoped<IProjectControllerRepository, ProjectControllerRepository>();
            services.AddScoped<IProjectAreaRepository, ProjectAreaRepository>();

            services.AddScoped<IUserBuss, UserBuss>();
            services.AddScoped<IRoleBuss, RoleBuss>();
            services.AddScoped<IRoleActionBuss, RoleActionBuss>();
            services.AddScoped<IProjectActionBuss, ProjectActionBuss>();
            services.AddScoped<IProjectControllerBuss, ProjectControllerBuss>();
            services.AddScoped<IProjectAreaBuss, ProjectAreaBuss>();


        }
    }
}