using Microsoft.Extensions.DependencyInjection;
using IssueManager.Application.Interfaces;
using IssueManager.Application.Services;
using IssueManager.Domain.Interfaces;
using IssueManager.Infra.Data.Repositories;
using IssueManager.Domain.Model;

namespace IssueManager.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IBaseRepository<Ticket>, TicketRepository>();
        }
    }
}