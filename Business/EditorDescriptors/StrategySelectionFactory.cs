
using EPiServer.Shell.ObjectEditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EPiServerResearch.Business.EditorDescriptors
{
    /// <summary>
    /// Provider a list of strategies
    /// </summary>
    public class StrategySelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var strategyList = new List<Strategy>
            {
                new Strategy()
                {
                    Name = "A",
                  //  Id = Guid.Parse("b5b2d5f9-bcd1-4ec6-8f15-dc730411371c")
                  Id = 1
                },

                new Strategy()
                {
                    Name = "B",
                  //  Id = Guid.Parse("b5b2d5f9-bcd1-4ec6-8f15-dc730411382d")
                          Id = 2
                },

                new Strategy()
                {
                    Name = "C",
                  //  Id = Guid.Parse("b5b2d5f9-bcd1-4ec6-8f15-cd820411382d")
                          Id = 3
                }
            };

            return new List<SelectItem>(strategyList.Select(item => new SelectItem { Value = item.Id.ToString(), Text = item.Name }));
        }
    }

    public class Strategy
    {
        public virtual string Name { get; set; }
        public virtual int Id{ get; set; }
    }
}