using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPiServerResearch.Models.Pages
{
    /// <summary>
    /// Used primarily for publishing news articles on the website
    /// </summary>
    [SiteContentType(
        GroupName = Global.GroupNames.News,
        GUID = "BCCDADF3-3E89-4117-ADEB-F8D43565D2F4")]
    [SiteImageUrl(Global.StaticGraphicsFolderPath + "page-type-thumbnail-article.png")]
    public class EmployeePage : SitePageData
    {

    }
}