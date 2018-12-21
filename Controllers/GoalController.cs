using EPiServer.Shell.Navigation;
using EPiServer.Shell.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPiServerResearch.Controllers
{
    public class GoalController : Controller
    {
        private readonly IBootstrapper _bootstrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GoalController"/> class.
        /// </summary>
        /// <param name="bootstrapper">The bootstrapper.</param>
        public GoalController(IBootstrapper bootstrapper)
        {
            _bootstrapper = bootstrapper;
        }

        /// <summary>
        /// Returns the Goal view.
        /// </summary>
        /// <returns>The Goal view</returns>
        [MenuItem(MenuPaths.Global + "/cms/goal", SortIndex = SortIndex.Last, Text = "Goal1")]
        public ActionResult Index()
        {
            // TODO: Use constant for "/episerver/personalization/goal"
            return View(_bootstrapper.BootstrapperViewName, _bootstrapper.CreateViewModel("/episerver/personalization/goal", ControllerContext, "App"));
           // review View();
        }
    }
}