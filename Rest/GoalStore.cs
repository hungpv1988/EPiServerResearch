using System.Collections.Generic;
using System.Web.Mvc;
using EPiServer.Shell.Services.Rest;

namespace EPiServerResearch
{
    [RestStore("goal")]
    public class GoalStore : RestControllerBase
    {
        [HttpGet]
        public virtual RestResultBase Get()
        {
            var items = new List<GoalModel>()
            {
                new GoalModel() { Id = 1, Name = "Goal 1", Type = "Type 1" },
                new GoalModel() { Id = 2, Name = "Goal 2", Type = "Type 2" }
            };

            return Rest(items);
        }
    }

    /// <summary>
    /// Model for Goal
    /// </summary>
    public class GoalModel
    {
        /// <summary>
        /// Goal's Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Goal's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Goal's type
        /// </summary>
        public string Type { get; set; }
    }
}