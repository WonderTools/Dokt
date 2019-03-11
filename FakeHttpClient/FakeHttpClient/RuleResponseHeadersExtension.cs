using System.Net.Http.Headers;

namespace WonderTools.FakeHttpClient
{
    public static class RuleResponseHeadersExtension
    {
        public static Rule UseAcceptRangeInResponse(this Rule rule, string range)
        {
            rule.AddModifier(x => x.Headers.AcceptRanges.Add(range));
            return rule;
        }

        public static Rule UseTransferEncodingInResponse(this Rule rule, string encoding)
        {
            rule.AddModifier(x => x.Headers.TransferEncoding.Add(new TransferCodingHeaderValue(encoding)));
            return rule;
        }
    }
}
