using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AlloyDemo1.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;

namespace AlloyDemo1.Controllers
{
    [TemplateDescriptor(TagString ="text", AvailableWithoutTag = false)]
    public class TextStartPageController : PageController<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            return Content(currentPage.Name);
        }
    }
}