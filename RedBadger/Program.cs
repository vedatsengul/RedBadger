using Microsoft.Extensions.DependencyInjection;
using RedBadger.Business.Business;
using RedBadger.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedBadger
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();

            List<string> lines = new List<string>();
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                if(string.IsNullOrEmpty(line))
                {
                    break;
                }

                lines.Add(line);
            }

            if (lines.Any())
            {
                var planetSize = lines[0].Split(' ');

                var planet = new Mars
                {
                    X = Convert.ToInt32(planetSize[0]),
                    Y = Convert.ToInt32(planetSize[1])
                };

                IServiceScope scope = _serviceProvider.CreateScope();
                var robotBusiness = scope.ServiceProvider.GetRequiredService<IRobotBusiness>();

                List<string> result = new List<string>();
                for (int i = 1; i < lines.Count;)
                {
                    var robotCoordinates = lines[i].Split(' ');

                    var robot = new Robot
                    {
                        X = Convert.ToInt32(robotCoordinates[0]),
                        Y = Convert.ToInt32(robotCoordinates[1]),
                        Direction = robotCoordinates[2]
                    };

                    foreach (var command in lines[i + 1])
                    {
                        robotBusiness.MoveRobot(planet, robot, command.ToString());
                    }

                    result.Add(robot.PrintLocation());

                    i += 2;
                }

                result.ForEach(x => Console.WriteLine(x));
            }


            DisposeServices();
        }
        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IRobotBusiness, RobotBusiness>();
            _serviceProvider = services.BuildServiceProvider(true);
        }
        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
