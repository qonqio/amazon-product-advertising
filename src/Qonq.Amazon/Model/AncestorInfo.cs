﻿namespace Qonq.Amazon.Model
{
    public class AncestorInfo
    {
        public string? Id { get; set; }
        public string? ContextFreeName { get; set; }
        public string? DisplayName { get; set; }
        public AncestorInfo? Ancestor { get; set; }
    }
}
