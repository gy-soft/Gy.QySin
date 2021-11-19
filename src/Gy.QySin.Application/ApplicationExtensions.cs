using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation;
using Gy.QySin.Application.Common;

namespace Gy.QySin.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}