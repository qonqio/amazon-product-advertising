using Qonq.Amazon.Model;
using RestSharp;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Qonq.Amazon
{
    public class AmazonClient
    {
        private readonly string _partnerTag;
        private readonly string _accessKey;
        private readonly string _secretKey;
        private readonly AmazonEndpointConfig _amazonEndpointConfig;
        private readonly AmazonResourceValidator _amazonResourceValidator;
        private readonly AmazonLanguageValidator _amazonLanguageValidator;
        private readonly AmazonEndpoint _amazonEndpoint;
        private readonly IAwsSigner _awsSigner;
        private readonly string Path = "/paapi5/";
        private readonly string PartnerType = "Associates";
        private readonly string ServiceName = "ProductAdvertisingAPI";
        private readonly string _marketplace;
        private readonly RestClient _restClient;

        public AmazonClient(
            IAwsSigner awsSigner, 
            string accessKey, string secretKey, 
            AmazonEndpoint amazonEndpoint, 
            string partnerTag, 
            string? userAgent = null
            )
        {
            _awsSigner = awsSigner;
            _accessKey = accessKey;
            _secretKey = secretKey;
            _restClient = new RestClient(new LoggingHandler(new HttpClientHandler()));
            _restClient.AddDefaultHeader("User-Agent", userAgent ?? "Nager.AmazonProductAdvertising");
            
            _amazonEndpoint = amazonEndpoint;
            _partnerTag = partnerTag;

            var amazonConfigEndpointConfigRepository = new AmazonEndpointConfigRepository();
            _amazonEndpointConfig = amazonConfigEndpointConfigRepository.Get(amazonEndpoint);

            _amazonResourceValidator = new AmazonResourceValidator();
            _amazonLanguageValidator = new AmazonLanguageValidator();
            _marketplace = $"www.{_amazonEndpointConfig.Host}";
        }


        public async Task<SearchItemResponse> SearchItemsAsync(string keyword)
        {
            var request = new SearchRequest(keyword)
            {
                Resources = new[]
                {
                    "BrowseNodeInfo.BrowseNodes",
                    "BrowseNodeInfo.BrowseNodes.Ancestor",
                    "BrowseNodeInfo.BrowseNodes.SalesRank",

                    "Images.Primary.Small",
                    "Images.Primary.Medium",
                    "Images.Primary.Large",

                    "Images.Variants.Small",
                    "Images.Variants.Medium",
                    "Images.Variants.Large",

                    "ItemInfo.ByLineInfo",
                    "ItemInfo.Classifications",
                    "ItemInfo.ContentInfo",
                    "ItemInfo.ContentRating",
                    "ItemInfo.ExternalIds",
                    "ItemInfo.Features",
                    "ItemInfo.ProductInfo",
                    "ItemInfo.TechnicalInfo",
                    "ItemInfo.Title",
                    "ItemInfo.TradeInInfo",

                    "Offers.Listings.Availability.MinOrderQuantity",
                    "Offers.Listings.Availability.MaxOrderQuantity",
                    "Offers.Listings.Availability.Message",
                    "Offers.Listings.Availability.Type",
                    "Offers.Listings.Condition",
                    "Offers.Listings.Condition.SubCondition",
                    "Offers.Listings.DeliveryInfo.IsAmazonFulfilled",
                    "Offers.Listings.DeliveryInfo.IsFreeShippingEligible",
                    "Offers.Listings.DeliveryInfo.IsPrimeEligible",
                    "Offers.Listings.IsBuyBoxWinner",
                    "Offers.Listings.LoyaltyPoints.Points",
                    "Offers.Listings.MerchantInfo",
                    "Offers.Listings.Price",
                    "Offers.Listings.ProgramEligibility.IsPrimeExclusive",
                    "Offers.Listings.ProgramEligibility.IsPrimePantry",
                    "Offers.Listings.Promotions",
                    "Offers.Listings.SavingBasis",
                    "Offers.Summaries.HighestPrice",
                    "Offers.Summaries.LowestPrice",
                    "Offers.Summaries.OfferCount",

                    "ParentASIN",
                    "SearchRefinements",
                },
            };

            return await SearchItemsAsync(request);
        }

        /// <summary>
        /// Search items with a search request
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public async Task<SearchItemResponse> SearchItemsAsync(SearchRequest searchRequest)
        {
            if (!_amazonResourceValidator.IsResourcesValid(searchRequest.Resources, "SearchItems"))
            {
                return new SearchItemResponse { Successful = false, ErrorMessage = "Resources has wrong values" };
            }

            var request = new SearchItemRequest(_partnerTag, PartnerType, _marketplace, keywords: searchRequest.Keywords)
            {
                Brand = searchRequest.Brand,
                Title = searchRequest.Title,
                Author = searchRequest.Author,
                Actor = searchRequest.Actor,
                Artist = searchRequest.Artist,
                Resources = searchRequest.Resources,
                ItemPage = searchRequest.ItemPage,
                SortBy = searchRequest.SortBy,
                BrowseNodeId = searchRequest.BrowseNodeId,
                Merchant = searchRequest.Merchant,
                SearchIndex = searchRequest.SearchIndex,
                Condition = searchRequest.Condition,
            };

            var json = JsonSerializer.Serialize(request);
            if (string.IsNullOrEmpty(json))
            {
                return new SearchItemResponse { Successful = false, ErrorMessage = "Cannot serialize object" };
            }

            var response = await RequestAsync("SearchItems", json);
            SearchItemResponse? test = null;

            try
            {
                test = JsonSerializer.Deserialize<SearchItemResponse>(response);
            }
            catch (Exception ex)
            {
                var z = ex.Message;
                throw;
            }
            return test;
        }

        private async Task<string> RequestAsync(string type, string json)
        {
            var host = $"webservices.{_amazonEndpointConfig.Host}";
            var date = DateTime.UtcNow;
            var amzTarget = $"com.amazon.paapi5.v1.ProductAdvertisingAPIv1.{type}";

            var headerToSign = new Dictionary<string, string>
            {
                { "Content-Encoding", "amz-1.0" },
                { "Host", host },
                { "X-Amz-Target", amzTarget },
                { "X-Amz-Date", date.ToAmzDateStr() },
            };
            var authorization = _awsSigner.CreateAuthorizationHeader(date, _accessKey, _secretKey, headerToSign, "POST", $"{Path}{type.ToLower()}", json, _amazonEndpointConfig.Region, ServiceName);

            var requestUri = $"https://webservices.{_amazonEndpointConfig.Host}{Path}{type.ToLower()}";

            var request = new RestRequest(new Uri(requestUri), Method.Post);
            request.AddJsonBody(json);
            request.AddHeader("Authorization", authorization);
            request.AddHeader("Content-Encoding", "amz-1.0");
            request.AddHeader("Host", host);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-Amz-Target", amzTarget);
            request.AddHeader("x-Amz-Date", date.ToAmzDateStr());

            var responseMessage = await _restClient.ExecuteAsync(request);
            //System.IO.File.WriteAllText($"{DateTime.Now:hhmmssfff}.json", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return responseMessage.Content;
            } 
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}