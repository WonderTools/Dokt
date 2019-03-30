using System;
using System.Net.Http.Headers;

namespace WonderTools.FakeHttpClient
{
    public static class RequestContentHeaderExtensions
    {
        public static IRequestMatchingRuleBuilder WithContentHeader(this IRequestMatchingRuleBuilder ruleBuilder, Func<HttpContentHeaders, bool> predicate)
        {
            ruleBuilder.With(x => predicate(x.Content.Headers));
            return ruleBuilder;
        }
    }
}