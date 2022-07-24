using Mc2.CrudTest.Shared.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(typeof(ServiceCollectionExtensions));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


        }


    }
}
