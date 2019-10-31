using Autofac;
using PlanificatorCMD.Persistence;
using PlanificatorCMD.Validators;
using PlanificatorCMD.Verbs;
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

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<Validator>().As<IValidator>();
            builder.RegisterType<AddSpeakerVerb>().As<IAddSpeakerVerb>();
            builder.RegisterType<SpeakerManager>().As<ISpeakerManager>();
            builder.RegisterType<SpeakerRepository>().As<ISpeakerRepository>();
            builder.RegisterType<PlanificatorDbContext>().SingleInstance();
            //builder.RegisterType<PresentationValidator>().As<IPresentationValidator>();
            builder.RegisterType<ShowAllSpeakersVerb>().As<IShowAllSpeakersVerb>();

            return builder.Build();
        }
    }
}
