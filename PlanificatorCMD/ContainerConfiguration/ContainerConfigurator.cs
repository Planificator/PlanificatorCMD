using Autofac;
using Microsoft.EntityFrameworkCore;
using PlanificatorCMD.DataProcessing;
using PlanificatorCMD.Managers;
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
//presentation add
            builder.RegisterType<PresentationManager>().As<IPresentationManager>();
            builder.RegisterType<PresentationRepository>().As<IPresentationRepository>();
            builder.RegisterType<AddPresentationVerb>().As<IAddPresentationVerb>();
            builder.RegisterType<AddPresentationVerbValidator>().As<IAddPresentationVerbValidator>();
            builder.RegisterType<PresentationMapper>().As<IPresentationMapper>();
//presentation show

//speaker add
            builder.RegisterType<AddSpeakerVerb>().As<IAddSpeakerVerb>();
            builder.RegisterType<AddSpeakerVerbProcessing>().As<IAddSpeakerVerbProcessing>();
            builder.RegisterType<AddSpeakerVerbValidator>().As<IAddSpeakerVerbValidator>();
            builder.RegisterType<PhotoPathProcessing>().As<IPhotoPathProcessing>();
//speaker show
            builder.RegisterType<ShowAllSpeakersVerb>().As<IShowAllSpeakersVerb>();
            builder.RegisterType<DisplaySpeakers>().As<IDisplaySpeakers>();
            builder.RegisterType<SpeakerManager>().As<ISpeakerManager>();
            builder.RegisterType<SpeakerProfileMapper>().As<ISpeakerProfileMapper>();
            builder.RegisterType<SpeakerRepository>().As<ISpeakerRepository>();

            builder.RegisterType<DbContextOptions<PlanificatorDbContext>>();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<PlanificatorDbContext>().SingleInstance();

            return builder.Build();
        }
    }
}
