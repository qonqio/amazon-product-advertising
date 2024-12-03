using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qonq.Amazon
{
    public interface IAwsSigner
    {
        string CreateAuthorizationHeader(DateTime date, string accessKey, string secretKey, Dictionary<string, string> requestHeaders, string httpMethod, string path, string payload, string region, string service);
    }
}