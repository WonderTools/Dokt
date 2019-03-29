using System.Linq;

namespace WonderTools.FakeHttpClient.RequestRules
{
    public static class RuleUriExtensions
    {
        public static IRequestMatchingRuleBuilder WithUri(this IRequestMatchingRuleBuilder ruleBuilder, string uri)
        {
            ruleBuilder.With(x => x.RequestUri.AbsoluteUri == uri);
            return ruleBuilder;
        }

        public static IRequestMatchingRuleBuilder WithUriStartingWith(this IRequestMatchingRuleBuilder ruleBuilder, string segment)
        {
            ruleBuilder.With(x => x.RequestUri.OriginalString.StartsWith(segment));
            return ruleBuilder;
        }

        public static IRequestMatchingRuleBuilder WithUriContaining(this IRequestMatchingRuleBuilder ruleBuilder, string segment)
        {
            ruleBuilder.With(x => x.RequestUri.AbsoluteUri.Contains(segment));
            return ruleBuilder;
        }

        public static IRequestMatchingRuleBuilder WithUriPort(this IRequestMatchingRuleBuilder ruleBuilder, int port)
        {
            ruleBuilder.With(x => x.RequestUri.Port.Equals(port));
            return ruleBuilder;
        }

        public static IRequestMatchingRuleBuilder WhenUriScheme(this IRequestMatchingRuleBuilder ruleBuilder, string scheme)
        {
            ruleBuilder.With(x => x.RequestUri.Scheme.Equals(scheme));
            return ruleBuilder;
        }

        public static IRequestMatchingRuleBuilder WhenUriAuthority(this IRequestMatchingRuleBuilder ruleBuilder, string authority)
        {
            ruleBuilder.With(x => x.RequestUri.Authority.Equals(authority));
            return ruleBuilder;
        }

        public static IRequestMatchingRuleBuilder WhenUriWithQuery(this IRequestMatchingRuleBuilder ruleBuilder, string query)
        {
            ruleBuilder.With(x => x.RequestUri.Query.Equals(query));
            return ruleBuilder;
        }

        public static IRequestMatchingRuleBuilder WhenUriHasSegment(this IRequestMatchingRuleBuilder ruleBuilder, string segment)
        {
            ruleBuilder.With(x => x.RequestUri.Segments.Contains(segment));
            return ruleBuilder;
        }
    }
}
