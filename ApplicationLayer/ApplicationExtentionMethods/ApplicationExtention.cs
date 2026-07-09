using ApplicationLayer.Interfaces;
using ApplicationLayer.Services;
using DomainLayer.DomainRules;
using DomainLayer.PurchaseRules;
using DomainLayer.PurchaseRules.Rules;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationLayer.ApplicationExtentionMethods
{
    public static class ApplicationExtention
    {
        public static void AddApplicationDependensies( this IServiceCollection services)
        {
            services.AddScoped<IRuleExecuter,RulesExecuter>();
            services.AddScoped<IRequestResults, BudgetExceededRule>();
            services.AddScoped<IRequestResults, SeniorEmployeeRule>();
            services.AddScoped<IRequestResults, DepartmentRule>();
            services.AddScoped<IRequestResults, EmployeeSeniorityRule>();
            services.AddScoped<IRequestResults, PurchasesTypeRule>();



            services.AddScoped<IPurshasesServices, PurshasesServices>();
        }
    }
}
