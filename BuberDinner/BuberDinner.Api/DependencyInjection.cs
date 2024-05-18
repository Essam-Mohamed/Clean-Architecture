using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentaion(this IServiceCollection services)
        {
            services.AddControllers(/*options => options.Filters.Add<ErrorHandlingFilterAttribute>()*/);
            services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
            services.AddMapping();

            return services;

        }
    }
}
