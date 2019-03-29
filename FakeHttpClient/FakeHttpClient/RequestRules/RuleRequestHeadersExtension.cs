using System.Net.Http.Headers;

namespace WonderTools.FakeHttpClient.RequestRules
{
    public static class RuleRequestHeadersExtension
    {
        public static Rule WithAcceptHeader(this Rule rule, string mediaType)
        {
            rule.AddEntryCondition(x => x.Headers.Accept.Contains(new MediaTypeWithQualityHeaderValue(mediaType)));
            return rule;
        }

        public static Rule WithAcceptCharsetHeader(this Rule rule, string headerValue)
        {
            rule.AddEntryCondition(x => x.Headers.AcceptCharset.Contains(new StringWithQualityHeaderValue(headerValue)));
            return rule;
        }

        public static Rule WithAcceptEncodingHeader(this Rule rule, string headerValue)
        {
            rule.AddEntryCondition(x => x.Headers.AcceptEncoding.Contains(new StringWithQualityHeaderValue(headerValue)));
            return rule;
        }

        public static Rule WithAcceptLanguageHeader(this Rule rule, string headerValue)
        {
            rule.AddEntryCondition(x => x.Headers.AcceptLanguage.Contains(new StringWithQualityHeaderValue(headerValue)));
            return rule;
        }

        public static Rule WithAuthenticationHeader(this Rule rule, string scheme,string parameter)
        {
            rule.AddEntryCondition(x => x.Headers.Authorization.Equals(new AuthenticationHeaderValue(scheme,parameter)));
            return rule;
        }
    }
}
