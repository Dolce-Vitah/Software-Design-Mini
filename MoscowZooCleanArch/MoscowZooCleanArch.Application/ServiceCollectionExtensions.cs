using Microsoft.Extensions.DependencyInjection;
using MoscowZooCleanArch.Application.Factories;
using MoscowZooCleanArch.Application.Interfaces;
using MoscowZooCleanArch.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Application
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds application services to the service collection.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Services for managing animals
            services.AddSingleton<IAnimalFactory, AnimalFactory>();
            services.AddSingleton<IAnimalsStatisticsService, AnimalsStatisticsService>();
            services.AddSingleton<IAnimalTransferService, AnimalTransferService>();

            // Services for managing enclosures
            services.AddSingleton<IEnclosureFactory, EnclosureFactory>();
            services.AddSingleton<IEnclosureStatisticsService, EnclosureStatisticsService>();
            services.AddSingleton<IEnclosureManagementService, EnclosureManagementService>();

            // Services for managing feeding schedules
            services.AddSingleton<IFeedingScheduleFactory, FeedingScheduleFactory>();
            services.AddSingleton<IFeedingScheduleInformationService, FeedingScheduleInformationService>();
            services.AddSingleton<IFeedingScheduleStatisticsService, FeedingScheduleStatisticsService>();
            services.AddSingleton<IFeedingOrganizationService, FeedingOrganizationService>();

            // Services for managing domain events
            services.AddSingleton<IDomainEventService, DomainEventService>();

            return services;
        }
    }
}
