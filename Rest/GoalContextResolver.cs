using EPiServer.ServiceLocation;
using EPiServer.Shell.Rest;
using EPiServer.Web;
using System;

namespace EPiServerResearch
{
    /// <summary>
    /// The context resolver for the Goal view.
    /// </summary>
    [ServiceConfiguration(typeof(IUriContextResolver))]
    public class GoalContextResolver : IUriContextResolver
    {
        private readonly SiteDefinition _siteDefinition;

        /// <summary>
        /// Initializes a new instance of <see cref="GoalContextResolver"/>.
        /// </summary>
        /// <param name="siteDefinition">The site definition.</param>
        public GoalContextResolver(SiteDefinition siteDefinition)
        {
            _siteDefinition = siteDefinition;
        }

        /// <summary>
        /// Get the name for this resolver
        /// </summary>
        public string Name
        {
            get { return "epi.personalization.goal"; }
        }

        /// <summary>
        /// This will always resolve the Uri for the GoalManager widget.
        /// </summary>
        /// <param name="uri">The URI that should be resolved</param>
        /// <param name="instance">The instance to return.</param>
        /// <returns></returns>
        public bool TryResolveUri(Uri uri, out ClientContextBase instance)
        {
            instance = ResolvePath(uri.LocalPath);
            return instance != null;
        }
        
        private ClientContextBase ResolvePath(string path)
        {
            return new GoalContext()
            {
                CustomViewType = "alloy/Menu/GoalManager",
                Uri = new Uri(Name + "://" + path),
                PublicUrl = _siteDefinition.SiteUrl == null ? string.Empty : _siteDefinition.SiteUrl.AbsolutePath
            };
        }

    }

    /// <summary>
    /// The client context for the Goal view.
    /// </summary>
    public class GoalContext : ClientContextBase
    {
        /// <summary>
        /// Gets or sets the custom view type associated with this context.
        /// </summary>
        public string CustomViewType { get; set; }

        /// <summary>
        /// Gets or sets the data type associated with this context.
        /// </summary>
        public override string DataType { get; set; }

        /// <summary>
        /// Gets or sets the url that will be used when transfering to view mode from the Goal view.
        /// </summary>
        public string PublicUrl { get; set; }
    }
}