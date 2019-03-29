using System.Net.Http;

namespace WonderTools.FakeHttpClient.RequestRules
{
    public static class RuleRequestBodyExtension
    {
        public static IRequestMatchingRuleBuilder WithContent(this IRequestMatchingRuleBuilder ruleBuilder, HttpContent content)
        {
            ruleBuilder.With(x => x.Content.Equals(content));
            return ruleBuilder;
        }
    }
}
