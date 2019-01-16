using System;
using System.Linq;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace AlloyDemo1.Business
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class InitializationModule1 : IInitializableModule
    {



        public void Initialize(InitializationEngine context)
        {
            var events = ServiceLocator.Current.GetInstance<IContentEvents>();

            events.MovingContent += MovingContent;
        }

        private void MovingContent(object sender, EPiServer.ContentEventArgs e)
        {
            if (e.Content.Name.StartsWith("Fredrik"))
            {
                e.CancelAction = true;
                e.CancelReason = "Man får inte flytta på Fredrik hur som helst...";
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }
    }
}