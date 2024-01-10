using SUSS.DAL.Repositories;
using SussBookingAppointment.Services;

namespace SussBookingAppointment.Configuration
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set your desired session timeout
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddScoped<IHttpContextAccessorService, HttpContextAccessorService>();
            //MappingConfig.RegisterMappings();
            services.AddSingleton<ICounsellingType, CounsellingType>();
            services.AddSingleton<IAuthenticationServices, AuthenticationServices>();
            services.AddAutoMapper(typeof(MappingConfig));
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(Program).Assembly));
            services.AddScoped<ISmtpServices, SmtpServices>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IEncryptionService, EncryptionService>();
            services.AddScoped<ICookiesService,CookiesService>();
            services.AddTransient<ICommonRepository, CommonRepository>();
            services.AddTransient<IUserRepositry, UserRepositry>();
            services.AddTransient<IBooking, Booking>();
            services.AddTransient<IFormNRepositry, FormNRepositry>();
            services.AddTransient<IFormORepositry, FormORepositry>();
            services.AddTransient<IApproverRepository, ApproverRepository>();
            services.AddTransient<ICunsultancyType, CunsultancyTypeRepositry>();
            return services;
        }
    }
}
