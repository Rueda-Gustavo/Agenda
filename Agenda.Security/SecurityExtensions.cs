using Agenda.Security.Database;
using Agenda.Security.Interfaces;
using Agenda.Security.Repositories;
using Agenda.Security.Services;
using Agenda.Security.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Agenda.Security
{
    public static class SecurityExtensions
    {
        public static IServiceCollection AddAgendaSecurity(this IServiceCollection service, IConfiguration configuration)
        {
            var tokenConfig = configuration.GetSection(nameof(TokenConfiguration)).Get<TokenConfiguration>();
            var key = Encoding.ASCII.GetBytes(tokenConfig.Key);
            service.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            service.AddScoped<ITokenService, TokenService>();
            return service;
        }

        public static IServiceCollection AddSecurityDatabase(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<UsuarioDataContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
            service.AddDbContext<UsuarioTesteDataContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
            service.AddScoped<IUsuarioRepository, UsuarioRepository>();
            service.AddScoped<IUsuarioService, UsuarioService>();            
            service.AddScoped<IUsuarioTesteRepository, UsuarioTesteRepository>();
            service.AddScoped<IUsuarioTesteService, UsuarioTesteService>();
                        
            return service;
        }
    }
}