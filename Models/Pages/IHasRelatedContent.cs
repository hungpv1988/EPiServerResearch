using EPiServer.Core;

namespace EPiServerResearch.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
