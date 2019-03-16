using System.Net.Http.Headers;

namespace WonderTools.FakeHttpClient
{
    public static class RuleResponseHeadersExtension
    {
        public static Rule UseAcceptRangeInResponse(this Rule rule, string range)
        {
            rule.AddModifier((response, request) => response.Headers.AcceptRanges.Add(range));
            return rule;
        }

        public static Rule UseTransferEncodingInResponse(this Rule rule, string encoding)
        {
            rule.AddModifier((response, request) => response.Headers.TransferEncoding.Add(new TransferCodingHeaderValue(encoding)));
            return rule;
        }
    }
}
