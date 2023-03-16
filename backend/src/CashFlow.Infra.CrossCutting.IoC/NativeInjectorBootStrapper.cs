using CashFlow.Application.Interfaces;
using CashFlow.Application.Services;
using CashFlow.Domain.Commands;
using CashFlow.Domain.Interfaces;
using CashFlow.Infra.CrossCutting.Bus;
using CashFlow.Infra.Data.Repository;
using CashFlow.Infra.Data.Settings;
using Equinox.Domain.Commands;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NetDevPack.Mediator;

namespace CashFlow.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // Settings
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

            services.AddSingleton(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<ITransactionAppService, TransactionAppService>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewTransactionCommand, ValidationResult>, TransactionCommandHandler>();

            // Infra - Data
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}