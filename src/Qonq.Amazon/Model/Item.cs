using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Qonq.Amazon.Model
{
    public class Item
    {
        public string? ASIN { get; set; }
        public string? ParentASIN { get; set; }
        public string? DetailPageURL { get; set; }
        public ItemInfo? ItemInfo { get; set; }
        public Images? Images { get; set; }
        public Offers? Offers { get; set; }
        public VariationAttribute[]? VariationAttributes { get; set; }
        public BrowseNodeInfo? BrowseNodeInfo { get; set; }
    }
}
