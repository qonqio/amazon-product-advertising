﻿namespace Qonq.Amazon.Model
{
    public class GetVariationsRequest : AmazonRequest
    {
        public string ASIN { get; set; }

        public GetVariationsRequest(string aSIN, string partnerTag, string partnerType, string marketplace) : base(partnerTag, partnerType, marketplace)
        {
            ASIN = aSIN;
        }
    }
}
