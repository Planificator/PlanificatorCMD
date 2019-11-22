using Autofac;
using PlanificatorCMD.ContainerConfiguration;

namespace PlanificatorCMD
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = ContainerConfigurator.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();

                app.Run(args);
            }
        }
    }
}