﻿namespace Qonq.Amazon.Model
{
    public class BrowseNode
    {
        public string? Id { get; set; }
        public bool IsRoot { get; set; }
        public string? ContextFreeName { get; set; }
        public string? DisplayName { get; set; }
        public AncestorInfo? Ancestor { get; set; }
        public int SalesRank { get; set; }
        public Bin[]? Bins { get; set; }
    }
}
