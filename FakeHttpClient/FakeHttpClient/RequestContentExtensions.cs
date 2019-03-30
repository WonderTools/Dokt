using System.Net.Http;

namespace WonderTools.FakeHttpClient
{
    public static class RequestContentExtensions
    {
        public static IRequestMatchingRuleBuilder WithContent(this IRequestMatchingRuleBuilder ruleBuilder, HttpContent content)
        {
            ruleBuilder.With(x => x.Content.Equals(content));
            return ruleBuilder;
        }
    }
}
