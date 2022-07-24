using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Persistance.Contexts;
using Mc2.CrudTest.Persistance.Repositories;
using Mc2.CrudTest.Shared.Data;
using Mc2.CrudTest.Shared.Dispatching;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Persistance
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //register data layer
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer( connectionString));
            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //register repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();

        }

        public static void AddEventsDispatcher(this IServiceCollection services)
        {
            services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();

        }
    }
}
