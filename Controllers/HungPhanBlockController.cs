using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServerResearch.Models.Blocks;
using EPiServerResearch.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPiServerResearch.Controllers
{
    public class HungPhanBlockController : BlockController<HungPhanBlock>
    {
        private readonly IContentLoader _contentLoader;
        private readonly IPermanentLinkMapper _permanentLinkMapper;

        public HungPhanBlockController(IContentLoader contentLoader, IPermanentLinkMapper permanentLinkMapper)
        {
            _contentLoader = contentLoader;
            _permanentLinkMapper = permanentLinkMapper;
        }

        public override ActionResult Index(HungPhanBlock currentContent)
        {
            ContactPage contactPage = null;
            if (!ContentReference.IsNullOrEmpty(currentContent.ContactPageLink))
            {
                contactPage = _contentLoader.Get<ContactPage>(currentContent.ContactPageLink);
            }

            HungPhanBlockViewModel viewModel = new HungPhanBlockViewModel()
            {
                BlockCompany = currentContent.Company,
                BlockHeading = currentContent.Heading,
                Link = currentContent.ButtonLink,
                Image = currentContent.CompanyImage,
                ContactPageLink = contactPage,
                Text = currentContent.ButtonText,
                TextArea = currentContent.TextArea
            };

            ViewData.GetEditHints<HungPhanBlockViewModel, HungPhanBlock>()
                    .AddConnection(x => x.Link, x => x.ButtonLink)
                    .AddConnection(x => x.BlockCompany, x => x.Company)
                    .AddConnection(x => x.BlockHeading, x => x.Heading)
                    .AddConnection(x => x.Text, x => x.ButtonText)
                    .AddConnection(x => x.Image, x => x.CompanyImage)
                    .AddConnection(x => (object)x.ContactPageLink, x => (object)x.ContactPageLink)
                    .AddConnection(x => x.TextArea, x => x.TextArea);

            return PartialView(viewModel);
        }
    }
}