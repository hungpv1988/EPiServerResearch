using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServerResearch.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPiServerResearch.Controllers
{
    [TemplateDescriptor(Inherited = true)]
    public class PagePartialController : PartialContentController<SitePageData>
    {
        //
        // GET: /PagePartial/
        public override ActionResult Index(SitePageData currentContent)
        {
            return PartialView("/Views/Shared/PagePartials/Page.cshtml", currentContent);
        }
    }
}