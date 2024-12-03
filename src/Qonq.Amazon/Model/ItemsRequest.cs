﻿namespace Qonq.Amazon.Model
{
    public class ItemsRequest
    {
        public string[] ItemIds { get; set; }
        public string[]? Resources { get; set; }
        public Merchant? Merchant { get; set; }
        public Condition? Condition { get; set; }
        public ItemsRequest(string[] itemIds)
        {
            ItemIds = itemIds;
        }

    }
}
