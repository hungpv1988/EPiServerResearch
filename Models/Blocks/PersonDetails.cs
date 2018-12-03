using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPiServerResearch.Models.Blocks
{
    [SiteContentType(GUID = "537CF12F-1F01-4EA0-922F-0778314DDAF1")]
    [SiteImageUrl]
    public class PersonDetails : SiteBlockData
    {
        public virtual string Name { get; set; }

        public virtual string Id { get; set; }

        public virtual string Company { get; set; }

        public virtual string School { get; set; }

        public virtual string Parent { get; set; }

        public virtual string Wife { get; set; }

        public virtual string Interest { get; set; }
    }
}