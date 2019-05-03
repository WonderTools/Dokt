using System;
using System.Net.Http;

namespace WonderTools.Dokt
{
    public static class RequestContentExtensions
    {
        //public static IRequestMatchingRuleBuilder WithContent(this IRequestMatchingRuleBuilder ruleBuilder, HttpContent content)
        //{
        //    return ruleBuilder.With(x => x.Content.Equals(content));
        //}

        public static IRequestMatchingRuleBuilder WithContent(this IRequestMatchingRuleBuilder ruleBuilder, Func<HttpContent, bool> contentPredicate)
        {
            return ruleBuilder.With(x => contentPredicate(x.Content));
        }
    }
}
