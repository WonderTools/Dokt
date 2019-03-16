using System.Net.Http.Headers;

namespace WonderTools.FakeHttpClient
{
    public static class RuleResponseHeadersExtension
    {
        public static Rule UseAcceptRangeInResponse(this Rule rule, string range)
        {
            rule.AddModifier((request, response) => response.Headers.AcceptRanges.Add(range));
            return rule;
        }

        public static Rule UseTransferEncodingInResponse(this Rule rule, string encoding)
        {
            rule.AddModifier((request, response) => response.Headers.TransferEncoding.Add(new TransferCodingHeaderValue(encoding)));
            return rule;
        }

        public static Rule UseServerInResponse(this Rule rule, string productName)
        {
            rule.AddModifier((request, response) => response.Headers.Server.Add(new ProductInfoHeaderValue(new ProductHeaderValue(productName))));
            return rule;
        }

        public static Rule UseProxyAuthenticateInResponse(this Rule rule, string scheme)
        {
            rule.AddModifier((request, response) => response.Headers.ProxyAuthenticate.Add(new AuthenticationHeaderValue(scheme)));
            return rule;
        }

        public static Rule UsePragmaInResponse(this Rule rule, string name,string value)
        {
            rule.AddModifier((request, response) => response.Headers.Pragma.Add(new NameValueHeaderValue(name,value)));
            return rule;
        }
    }
}
