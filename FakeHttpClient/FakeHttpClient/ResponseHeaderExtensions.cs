using System.Net.Http.Headers;

namespace WonderTools.FakeHttpClient
{
    public static class ResponseHeaderExtensions
    {
        public static IResponseMakingRuleBuilder UsingAcceptRangeHeader(this IResponseMakingRuleBuilder ruleBuilder, string range)
        {
            ruleBuilder.Using((request, response) => response.Headers.AcceptRanges.Add(range));
            return ruleBuilder;
        }

        public static IResponseMakingRuleBuilder UsingTransferEncodingHeader(this IResponseMakingRuleBuilder ruleBuilder, string encoding)
        {
            ruleBuilder.Using((request, response) => response.Headers.TransferEncoding.Add(new TransferCodingHeaderValue(encoding)));
            return ruleBuilder;
        }

        public static IResponseMakingRuleBuilder UsingServerHeader(this IResponseMakingRuleBuilder ruleBuilder, string productName)
        {
            ruleBuilder.Using((request, response) => response.Headers.Server.Add(new ProductInfoHeaderValue(new ProductHeaderValue(productName))));
            return ruleBuilder;
        }

        public static IResponseMakingRuleBuilder UsingProxyAuthenticateHeader(this IResponseMakingRuleBuilder ruleBuilder, string scheme)
        {
            ruleBuilder.Using((request, response) => response.Headers.ProxyAuthenticate.Add(new AuthenticationHeaderValue(scheme)));
            return ruleBuilder;
        }

        public static IResponseMakingRuleBuilder UsingPragmaHeader(this IResponseMakingRuleBuilder ruleBuilder, string name,string value)
        {
            ruleBuilder.Using((request, response) => response.Headers.Pragma.Add(new NameValueHeaderValue(name,value)));
            return ruleBuilder;
        }
    }
}
