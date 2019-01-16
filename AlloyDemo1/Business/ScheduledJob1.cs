using System;
using AlloyDemo1.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;

namespace AlloyDemo1.Business
{
    [ScheduledPlugIn(DisplayName = "Dummy Job Special")]
    public class ScheduledJob1 : ScheduledJobBase
    {
        private bool _stopSignaled;

        public ScheduledJob1()
        {
            IsStoppable = true;
        }

        /// <summary>
        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            _stopSignaled = true;
        }

        /// <summary>
        /// Called when a scheduled job executes
        /// </summary>
        /// <returns>A status message to be stored in the database log and visible from admin mode</returns>
        public override string Execute()
        {
            //TODO: Do work...

            var repo = ServiceLocator.Current.GetInstance<IContentRepository>();

            var start = repo.Get<StartPage>(ContentReference.StartPage);
            var partentId = start.ContactsPageLink;

            var page = repo.GetDefault<ContactPage>(partentId);

            page.Name = "Test " + Guid.NewGuid();

            repo.Save(page, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);



            return "OK "+DateTime.Now;
        }
    }
}
