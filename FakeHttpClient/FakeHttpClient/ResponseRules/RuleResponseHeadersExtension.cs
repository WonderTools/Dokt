using System.Net.Http.Headers;

namespace WonderTools.FakeHttpClient.ResponseRules
{
    public static class RuleResponseHeadersExtension
    {
        public static IResponseMakingRuleBuilder SetAcceptRangeInResponse(this IResponseMakingRuleBuilder ruleBuilder, string range)
        {
            ruleBuilder.Use((request, response) => response.Headers.AcceptRanges.Add(range));
            return ruleBuilder;
        }

        public static IResponseMakingRuleBuilder SetTransferEncodingInResponse(this IResponseMakingRuleBuilder ruleBuilder, string encoding)
        {
            ruleBuilder.Use((request, response) => response.Headers.TransferEncoding.Add(new TransferCodingHeaderValue(encoding)));
            return ruleBuilder;
        }

        public static IResponseMakingRuleBuilder SetServerInResponse(this IResponseMakingRuleBuilder ruleBuilder, string productName)
        {
            ruleBuilder.Use((request, response) => response.Headers.Server.Add(new ProductInfoHeaderValue(new ProductHeaderValue(productName))));
            return ruleBuilder;
        }

        public static IResponseMakingRuleBuilder SetProxyAuthenticateInResponse(this IResponseMakingRuleBuilder ruleBuilder, string scheme)
        {
            ruleBuilder.Use((request, response) => response.Headers.ProxyAuthenticate.Add(new AuthenticationHeaderValue(scheme)));
            return ruleBuilder;
        }

        public static IResponseMakingRuleBuilder SetPragmaInResponse(this IResponseMakingRuleBuilder ruleBuilder, string name,string value)
        {
            ruleBuilder.Use((request, response) => response.Headers.Pragma.Add(new NameValueHeaderValue(name,value)));
            return ruleBuilder;
        }
    }
}
