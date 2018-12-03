using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Web;
using EPiServerResearch.Models.Pages;
using System.ComponentModel.DataAnnotations;

namespace EPiServerResearch.Models.Blocks
{
    [SiteContentType(GUID = "426CF12F-1F01-4EA0-922F-0778315AEAF0")]
    [SiteImageUrl]
    public class HungPhanBlock : SiteBlockData
    {
        [Display(Order = 1, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual string ButtonText { get { return "Hung Block"; } set { } }

        [Display(Order = 2, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual Url ButtonLink { get; set; }

        [Display(Order = 2, GroupName = SystemTabNames.Content)]
        public virtual string Company { get; set; }

        [Display(Order = 2, GroupName = SystemTabNames.Content)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference CompanyImage { get; set; }

        [Display(Order = 2, GroupName = SystemTabNames.Content)]
        public virtual string Heading { get; set; }

        /// <summary>
        /// Gets or sets the contact page from which contact information should be retrieved
        /// </summary>
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 3)]
        [UIHint(Global.SiteUIHints.Contact)]
        public virtual PageReference ContactPageLink { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 3)]
        [UIHint(UIHint.PreviewableText)]
        public virtual string TextArea { get; set; }
    }

    public class HungPhanBlockViewModel
    {
        public virtual string BlockHeading { get; set; }

        public virtual string Text { get; set; }

        public virtual string BlockCompany { get; set; }

        public virtual Url Link { get; set; }

        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [Display(
             GroupName = SystemTabNames.Content,
             Order = 3)]
        [UIHint(Global.SiteUIHints.Contact)]
        public virtual ContactPage ContactPageLink { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 3)]
        [UIHint(UIHint.PreviewableText)]
        public virtual string TextArea { get; set; }
    }
}