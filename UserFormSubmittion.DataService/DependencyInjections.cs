using Microsoft.Extensions.DependencyInjection;
using UserFormSubmittion.DataService.Data;
using UserFormSubmittion.DataService.Interfaces;
using UserFormSubmittion.DataService.Respositories;

namespace UserFormSubmission.DataService;

public static class DependencyInjections
{
    public static IServiceCollection AddDataService(this IServiceCollection services)
    {
         services.AddDbContext<UserDbContext>();
         services.AddScoped<IApplicantRepository, ApplicantRepository>();
         services.AddScoped<IQuestionRepository, QuestionRepository>();

         return services;
    }
}