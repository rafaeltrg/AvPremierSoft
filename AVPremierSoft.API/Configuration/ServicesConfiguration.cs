using AVPremierSoft.Domain.Colaborador.Interface;
using AVPremierSoft.Domain.Colaborador.Service;
using AVPremierSoft.Domain.Equipe.Interface;
using AVPremierSoft.Domain.Equipe.Service;
using AVPremierSoft.Domain.EquipeProjeto.Interface;
using AVPremierSoft.Domain.EquipeProjeto.Service;
using AVPremierSoft.Domain.Projeto.Interface;
using AVPremierSoft.Domain.Projeto.Service;
using AVPremierSoft.Domain.Token.Interface;
using AVPremierSoft.Domain.Token.Service;
using AVPremierSoft.Domain.Usuario.Interface;
using AVPremierSoft.Domain.Usuario.Service;
using AVPremierSoft.Infrastructure.Data;
using AVPremierSoft.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AVPremierSoft.API.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection GetServiceProvider(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton((IConfigurationRoot)configuration)
            .AddSingleton<DatabaseConnection>();

            services.AddTransient<IColaboradorService, ColaboradorService>();
            services.AddTransient<IColaboradorRepository, ColaboradorRepository>();
            services.AddTransient<IEquipeProjetoService, EquipeProjetoService>();
            services.AddTransient<IEquipeProjetoRepository, EquipeProjetoRepository>();
            services.AddTransient<IEquipeService, EquipeService>();
            services.AddTransient<IEquipeRepository, EquipeRepository>();
            services.AddTransient<IProjetoService, ProjetoService>();
            services.AddTransient<IProjetoRepository, ProjetoRepository>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
