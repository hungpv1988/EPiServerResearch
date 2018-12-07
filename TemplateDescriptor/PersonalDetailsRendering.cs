using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServerResearch.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPiServerResearch.TemplateDescriptor
{
    [ServiceConfiguration(typeof(IViewTemplateModelRegistrator))]
    public class PersonalDetailsRendering : IViewTemplateModelRegistrator
    {
        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            viewTemplateModelRegistrator.Add(
                typeof(PersonDetails),
                    new EPiServer.DataAbstraction.TemplateModel()
                    {
                        Name = "StudentDetails",
                        Description = "Personal Details for Students",
                        Path = "~/Views/Shared/Blocks/PersonDetails.cshtml",
                        AvailableWithoutTag = true
                    },
                    new EPiServer.DataAbstraction.TemplateModel()
                    {
                        Name = "AdultDetails",
                        Description = "Personal Details for Adults",
                        Path = "~/Views/Shared/Blocks/PersonDetailsForAdult.cshtml",
                        Tags = new string[] { "Adults" }
                    }
           );

            //viewTemplateModelRegistrator.Add(
            //        typeof(StrategyBlock),
            //        new EPiServer.DataAbstraction.TemplateModel()
            //        {
            //            Name = "StrategyBlock",
            //            Description = "Strategy block",
            //            Path = "~/Views/Shared/Blocks/StrategyBlock.cshtml",
                        
            //            AvailableWithoutTag = true
            //        }
            //);
        }
    }
}