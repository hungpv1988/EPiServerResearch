using System.Collections.Generic;
using EPiServer.Framework.Localization;
using EPiServer.Shell.Web;
using EPiServer.Shell.ViewComposition;
using EPiServer.Shell.ViewComposition.Containers;

namespace EPiServerResearch.CompositeView
{
    /// <summary>
    /// The view definition for the Goal view.
    /// </summary>
    [CompositeView]
    public class GoalView : ICompositeView, ICustomGlobalNavigationMenuBehavior, IRestrictedComponentCategoryDefinition
    {
        private readonly LocalizationService _localizationService;
        private IContainer _rootContainer = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="GoalView"/> class.
        /// </summary>
        /// <param name="localizationService">The localization service used for getting localized resources.</param>
        public GoalView(LocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        /// <summary>
        /// Gets the root <see cref="IContainer"/> that contains the different panels for the view.
        /// </summary>
        /// <value>The container.</value>
        public IContainer RootContainer
        {
            get
            {
                if (_rootContainer == null)
                {
                    var navigation = new CustomContainer("alloy/Menu/GoalNavigation");

                    var content = new BorderContainer()
                        .Add(new ContentPane { PlugInArea = "/episerver/cms/maincontent" }, new BorderSettingsDictionary(BorderContainerRegion.Center));

                    _rootContainer = new BorderContainer()
                        .Add(navigation, new BorderSettingsDictionary(BorderContainerRegion.Leading,
                                                160, // initial size
                                                130, // min size
                                                null, // max size
                                                new Setting("splitter", "true"),
                                                new Setting("liveSplitters", "false"),
                                                new Setting("id", "navigation")))
                        .Add(content, new BorderSettingsDictionary(BorderContainerRegion.Center));

                    _rootContainer.Settings["id"] = Name + "_rootContainer";
                }
                return _rootContainer;
            }
        }

        /// <summary>
        /// Gets the name of the view. Used or finding views.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            // TODO: Use constant for this
            get { return "/episerver/personalization/goal"; }
        }

        /// <summary>
        /// Creates a new instance of the view.
        /// </summary>
        /// <returns>A new instance of the view.</returns>
        public ICompositeView CreateView()
        {
            return new GoalView(_localizationService);
        }

        /// <summary>
        /// Gets a localized title for this view
        /// </summary>
        public string Title
        {
            get { return "Goal"; }
        }

        /// <summary>
        ///     Defines the global menu to be a pull down menu.
        /// </summary>
        public GlobalNavigationMenuType MenuType
        {
            get { return GlobalNavigationMenuType.PullDown; }
        }

        /// <summary>
        /// Gets the categories for this view.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetComponentCategories()
        {
            return new string[] { "goal" };
        }

        /// <summary>
        /// The default context for this view.
        /// </summary>
        public string DefaultContext
        {
            get { return "epi.personalization.goal:///goal"; }
        }

    }
}