using System.Net.Http;

namespace WonderTools.FakeHttpClient.RequestRules
{
    public static class RuleRequestBodyExtension
    {
        public static IRequestMatchingRuleBuilder WithRequestContent(this IRequestMatchingRuleBuilder ruleBuilder, HttpContent content)
        {
            ruleBuilder.With(x => x.Content.Equals(content));
            return ruleBuilder;
        }
    }
}
