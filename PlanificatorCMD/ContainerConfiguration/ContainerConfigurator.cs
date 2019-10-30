using Autofac;
using PlanificatorCMD.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanificatorCMD.ContainerConfiguration
{
    public static class ContainerConfigurator
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SpeakerManager>().As<ISpeakerManager>();
            builder.RegisterType<SpeakerRepository>().As<ISpeakerRepository>();
            builder.RegisterType<PlanificatorDbContext>().SingleInstance();

            return builder.Build();
        }
    }
}
