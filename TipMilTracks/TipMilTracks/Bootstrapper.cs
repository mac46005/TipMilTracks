using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using TipMilTracks.ModelViews;
using TipMilTracks.Repositories;

namespace TipMilTracks
{
    public abstract class Bootstrapper
    {
        protected ContainerBuilder ContainerBuilder { get; set; }
        public Bootstrapper()
        {
            Initialize();
            FinishInitialization();
        }

        

        private void Initialize()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            ContainerBuilder = new ContainerBuilder();
            foreach (var type in currentAssembly.DefinedTypes
                .Where(e => 
                e.IsSubclassOf(typeof(Page)) ||
                e.IsSubclassOf(typeof(ViewModel))))
            {
                ContainerBuilder.RegisterType(type.AsType());
            };
            ContainerBuilder.RegisterType<TrackItemRepository>().SingleInstance();
        }
        private void FinishInitialization()
        {
            var container = ContainerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}
