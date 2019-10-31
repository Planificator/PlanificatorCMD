using Autofac;
using Microsoft.Extensions.Configuration;
using PlanificatorCMD.ContainerConfiguration;
using System;
using System.IO;

namespace PlanificatorCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfigurator.Configure();

            using(var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();

                app.Run(args);
            }
        }
    }
}
