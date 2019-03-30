using System;
using System.IO;

namespace WonderTools.Dokt
{
    public static class RequestBodyExtensions
    {
        public static IRequestMatchingRuleBuilder WithBody(this IRequestMatchingRuleBuilder ruleBuilder,
            Func<string, bool> bodyPredicate)
        {
            return ruleBuilder.With(x =>
            {
                var bodyString = x.Content.ReadAsStringAsync().Result;
                return bodyPredicate.Invoke(bodyString);
            });
        }

        public static IRequestMatchingRuleBuilder WithBody(this IRequestMatchingRuleBuilder ruleBuilder,
            Func<Stream, bool> bodyPredicate)
        {
            return ruleBuilder.With(x =>
            {
                var bodyStream = x.Content.ReadAsStreamAsync().Result;
                return bodyPredicate.Invoke(bodyStream);
            });
        }

        public static IRequestMatchingRuleBuilder WithBody(this IRequestMatchingRuleBuilder ruleBuilder,
            Func<byte[], bool> bodyPredicate)
        {
            return ruleBuilder.With(x =>
            {
                var bodyArray = x.Content.ReadAsByteArrayAsync().Result;
                return bodyPredicate.Invoke(bodyArray);
            });
        }
    }
}