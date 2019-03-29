using System.Net.Http.Headers;

namespace WonderTools.FakeHttpClient.ResponseRules
{
    public static class RuleResponseHeadersExtension
    {
        public static Rule SetAcceptRangeInResponse(this Rule rule, string range)
        {
            rule.AddModifier((request, response) => response.Headers.AcceptRanges.Add(range));
            return rule;
        }

        public static Rule SetTransferEncodingInResponse(this Rule rule, string encoding)
        {
            rule.AddModifier((request, response) => response.Headers.TransferEncoding.Add(new TransferCodingHeaderValue(encoding)));
            return rule;
        }

        public static Rule SetServerInResponse(this Rule rule, string productName)
        {
            rule.AddModifier((request, response) => response.Headers.Server.Add(new ProductInfoHeaderValue(new ProductHeaderValue(productName))));
            return rule;
        }

        public static Rule SetProxyAuthenticateInResponse(this Rule rule, string scheme)
        {
            rule.AddModifier((request, response) => response.Headers.ProxyAuthenticate.Add(new AuthenticationHeaderValue(scheme)));
            return rule;
        }

        public static Rule SetPragmaInResponse(this Rule rule, string name,string value)
        {
            rule.AddModifier((request, response) => response.Headers.Pragma.Add(new NameValueHeaderValue(name,value)));
            return rule;
        }
    }
}
