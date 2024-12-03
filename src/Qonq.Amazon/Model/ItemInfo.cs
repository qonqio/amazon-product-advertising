using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qonq.Amazon.Model
{
    public class ItemInfo
    {
        public ByLineInfo? ByLineInfo { get; set; }
        public Classifications? Classifications { get; set; }
        public DisplayValuesItem<string[]>? Features { get; set; }
        public ProductInfo? ProductInfo { get; set; }
        public DisplayValueItem<string>? Title { get; set; }
        public ExternalIds? ExternalIds { get; set; }
        public ContentInfo? ContentInfo { get; set; }
        public ContentRating? ContentRating { get; set; }
        public TechnicalInfo? TechnicalInfo { get; set; }
        public ManufactureInfo? ManufactureInfo { get; set; }
    }
}
