using System;
using System.Net.Http.Headers;

namespace WonderTools.Flug
{
    public static class RequestHeaderExtensions
    {
        public static IRequestMatchingRuleBuilder WithAcceptHeader(this IRequestMatchingRuleBuilder ruleBuilder, string mediaType)
        {
            ruleBuilder.With(x => x.Headers.Accept.Contains(new MediaTypeWithQualityHeaderValue(mediaType)));
            return ruleBuilder;
        }

        public static IRequestMatchingRuleBuilder WithAcceptCharsetHeader(this IRequestMatchingRuleBuilder ruleBuilder, string headerValue)
        {
            ruleBuilder.With(x => x.Headers.AcceptCharset.Contains(new StringWithQualityHeaderValue(headerValue)));
            return ruleBuilder;
        }

        public static IRequestMatchingRuleBuilder WithAcceptEncodingHeader(this IRequestMatchingRuleBuilder ruleBuilder, string headerValue)
        {
            ruleBuilder.With(x => x.Headers.AcceptEncoding.Contains(new StringWithQualityHeaderValue(headerValue)));
            return ruleBuilder;
        }

        public static IRequestMatchingRuleBuilder WithAcceptLanguageHeader(this IRequestMatchingRuleBuilder ruleBuilder, string headerValue)
        {
            ruleBuilder.With(x => x.Headers.AcceptLanguage.Contains(new StringWithQualityHeaderValue(headerValue)));
            return ruleBuilder;
        }

        public static IRequestMatchingRuleBuilder WithAuthenticationHeader(this IRequestMatchingRuleBuilder ruleBuilder, string scheme,string parameter)
        {
            ruleBuilder.With(x => x.Headers.Authorization.Equals(new AuthenticationHeaderValue(scheme,parameter)));
            return ruleBuilder;
        }

        public static IRequestMatchingRuleBuilder WithHeader(this IRequestMatchingRuleBuilder ruleBuilder, Func<HttpRequestHeaders, bool> predicate)
        {
            ruleBuilder.With(x => predicate(x.Headers));
            return ruleBuilder;
        }
    }
}
