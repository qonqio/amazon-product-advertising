﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qonq.Amazon.Model
{
    public class SearchResult
    {
        public Item[]? Items { get; set; }
        public SearchRefinements? SearchRefinements { get; set; }
        public string? SearchURL { get; set; }
        public int TotalResultCount { get; set; }
    }
}
