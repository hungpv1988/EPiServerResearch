using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using EPiServerResearch.Business.EditorDescriptors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPiServerResearch.Models.Blocks
{
    [ContentType(DisplayName = "Strategy Block", GUID = "b5b2d5f9-bcd1-4ec6-8f15-dc730411371c", Description = "")]
    public class StrategyBlock: SiteBlockData
    {

        [Display(Order = 2, GroupName = SystemTabNames.Content)]
        [SelectOne(SelectionFactoryType = typeof(StrategySelectionFactory))]
        public virtual string DefaultStrategy { get; set; }

        [Display(Order = 2, GroupName = SystemTabNames.Content)]
        [DefaultValue(3)]
        [Range(1,10)]
        public virtual int RecommendationCount { get; set; }
    }
}