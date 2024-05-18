using BuberDinner.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuberDinner.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            service.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return service;
        }
    }
}
