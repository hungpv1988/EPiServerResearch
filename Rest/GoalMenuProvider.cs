using EPiServer.Shell;
using EPiServer.Shell.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPiServerResearch.Rest
{
    [MenuProvider]
    public class GoalMenuProvider : IMenuProvider
    {
        public IEnumerable<MenuItem> GetMenuItems()
        {
            var url = Paths.ToResource(GetType(), "Goal");
            var goalItem = new UrlMenuItem("Goal2", "/global/cms/goal", url)
            {
                SortIndex = 15,
                Alignment = MenuItemAlignment.Left
            };

            var menus = new List<MenuItem>();
            menus.Add(goalItem);

            return menus;
        }
    }
}