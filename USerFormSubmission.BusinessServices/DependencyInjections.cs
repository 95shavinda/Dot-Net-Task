using Microsoft.Extensions.DependencyInjection;
using USerFormSubmission.BusinessServices.Interfaces;
using USerFormSubmission.BusinessServices.Services;

namespace UserFormSubmission.BusinessServices;

public static class DependencyInjections
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
         services.AddScoped<IApplicantService, ApplicantService>();
         services.AddScoped<IQuestionService, QuestionService>();

         return services;
    }
}