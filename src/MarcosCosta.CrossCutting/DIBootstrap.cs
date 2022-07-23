using MarcosCosta.Domain.Interfaces.Repositories;
using MarcosCosta.Domain.Interfaces.Repositories.Externals;
using MarcosCosta.Domain.Interfaces.Services;
using MarcosCosta.Domain.Options;
using MarcosCosta.Repository.Channel;
using MarcosCosta.Repository.Externals;
using MarcosCosta.Repository.Item;
using MarcosCosta.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace MarcosCosta.CrossCutting
{
    public static class DIBootstrap
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IFeedRDFService, FeedRDFService>();
            services.AddSingleton<IFeedRDFRepository, FeedRDFRepository>();
            services.AddSingleton<IChannelRepository, ChannelRepository>(provider => new ChannelRepository(configuration.GetConnectionString("FeedRDF")));
            services.AddSingleton<IItemRepository, ItemRepository>(provider => new ItemRepository(configuration.GetConnectionString("FeedRDF")));

            services.Configure<AppSettings>(options =>
            {
                configuration.GetSection("AppSettings").Bind(options);
            });
        }
    }
}