using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.AspNetCore.Http;
using DAL.UserDAL;
using DAL.TournamentDAL;
using BLL.UserBLL;
using BLL.TournamentBLL;
using BLL.Interfaces;
using BLL.TeamBLL;
using DAL.TeamDAL;
using DAL.PlayerDAL;
using BLL.PlayerBLL;
using BLL.MatchBLL;
using DAL.MatchDAL;
using BLL.LocationBLL;
using DAL.LocationDAL;
using BLL.NationalityBLL;
using DAL.NationalityDAL;
using BLL.TournamentTypeBLL;
using DAL.TournamentTypeDAL;

namespace TournamentDesktop_S2
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }
        static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<IConfiguration>(sp =>
            {
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFile("C:\\Users\\user\\Desktop\\semester2-tournaments\\Tournament-S2\\Tournament-S2\\appsettings.json");
                return configurationBuilder.Build();
            });

            services.AddScoped<IUserRepository, UserDataAccessLayer>();
            services.AddScoped<UserLogicLayer>();
            services.AddScoped<ITournamentRepository, TournamentDataAccessLayer>();
            services.AddScoped<TournamentLogicLayer>();
            services.AddScoped<ITeamRepository, TeamDataAccessLayer>();
            services.AddScoped<TeamLogicLayer>();
            services.AddScoped<IPlayerRepository, PlayerDataAccessLayer>();
            services.AddScoped<PlayerLogicLayer>();
            services.AddScoped<MatchLogicLayer>();
            services.AddScoped<IMatchRepository, MatchDataAccessLayer>();
            services.AddScoped<LocationLogicLayer>();
            services.AddScoped<ILocationRepository, LocationDataAccessLayer>();
            services.AddScoped<NationalityLogicLayer>();
            services.AddScoped<INationalityRepository, NationalityDataAccessLayer>();
            services.AddScoped<TournamentTypeLogicLayer>();
            services.AddScoped<ITournamentTypeRepository, TournamentTypeDataAccessLayer>();

            ServiceProvider = services.BuildServiceProvider();
        }

        public static T? GetService<T>() where T : class
        {
            return (T?)ServiceProvider.GetService(typeof(T));
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices(); // Call configurations before running application
            Application.Run(new Form1());
        }
    }
}