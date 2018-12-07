using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiServerResearch.Models.Blocks
{
    [ContentType(DisplayName = "StrongTypeBlock", GUID = "a4a1f5f9-bcd1-4ec6-8f15-dc730411371c", Description = "")]
    public class StrongTypeBlock : BlockData
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Name",
                    Description = "Name field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual string Name { get; set; }
         */
    }

    public class MyPage : PageData
    {
        public virtual XhtmlString MainBody { get; set; }
        //public virtual PageList MainList { get; set; }
    }
    public partial class MyTemplate : TemplatePage<MyPage>
    {

    }
}