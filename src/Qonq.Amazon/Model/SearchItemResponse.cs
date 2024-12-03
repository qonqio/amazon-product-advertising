using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qonq.Amazon.Model
{
    public class SearchItemResponse : AmazonResponse
    {
        public SearchResult SearchResult { get; set; } = default!;
    }
}
