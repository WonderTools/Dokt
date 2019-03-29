using System.Net.Http;

namespace WonderTools.FakeHttpClient.ResponseRules
{
    public static class RuleResponseBodyExtension
    {
        public static IResponseMakingRuleBuilder UsingContent(this IResponseMakingRuleBuilder ruleBuilder,HttpContent content)
        {
            ruleBuilder.Using((request, response) =>
            {
                response.Content = content;
            });
            return ruleBuilder;
        }
    }
}
