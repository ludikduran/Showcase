using System;
using System.Web.Caching;
using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Content;

namespace LD2.Showcase.Components
{
    [TableName("LD2_Showcase")]
    [PrimaryKey("Itm", AutoIncrement = true)]
    [Cacheable("LD2_Showcase", CacheItemPriority.Default, 20)]
    [Scope("Itm")]
    public class Item
    {
        public int Itm { get; set; }

        public int LogoID { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public int ScreenshotID { get; set; }
    }
}