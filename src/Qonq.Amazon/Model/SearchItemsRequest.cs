using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qonq.Amazon.Model
{
    public class SearchItemsRequest
    {
        public string Keywords { get; set; }
        public string PartnerTag { get; set; }
        public string PartnerType { get; set; }
        public string SearchIndex { get; set; }
        public List<string> Resources { get; set; }
    }
}
