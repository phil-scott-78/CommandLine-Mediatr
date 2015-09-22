using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac;
using Autofac.Features.Variance;
using CommandLine;
using Console.Mediatr.Verbs;
using MediatR;

namespace Console.Mediatr
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = BuildMediator();
            var allTheCommands = (typeof(AddVerb).Assembly.GetTypes().Where(type => (typeof (IRequest).IsAssignableFrom(type)))).ToArray();

            var parser = new Parser(with => {
                with.EnableDashDash = true;
                with.CaseSensitive = false;
                with.HelpWriter = System.Console.Out;
            });

            var result = parser.ParseArguments(args, allTheCommands) as Parsed<object>;
            if (result != null)
            {
                mediator.Send((IRequest) result.Value);
            }
            else
            {
                Environment.Exit(1229);
            }
        }

        private static IMediator BuildMediator()
        {
            var builder = new ContainerBuilder();
            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(AddVerb).Assembly).AsImplementedInterfaces();
            builder.Register(context => System.Console.Out).As<TextWriter>();

            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });

            var mediator = builder.Build().Resolve<IMediator>();

            return mediator;
        }
    }
}
