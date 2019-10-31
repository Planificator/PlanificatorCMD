using Autofac;
using PlanificatorCMD.DataProcessing;
using PlanificatorCMD.Persistence;
using PlanificatorCMD.Utils;
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

            builder.RegisterType<SpeakerProfileMapper>().As<ISpeakerProfileMapper>();
            builder.RegisterType<PhotoPathProcessing>().As<IPhotoPathProcessing>();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<Validator>().As<IValidator>();
            builder.RegisterType<AddSpeakerVerb>().As<IAddSpeakerVerb>();
            builder.RegisterType<SpeakerManager>().As<ISpeakerManager>();
            builder.RegisterType<SpeakerRepository>().As<ISpeakerRepository>();
            builder.RegisterType<PlanificatorDbContext>().SingleInstance();

            return builder.Build();
        }
    }
}
