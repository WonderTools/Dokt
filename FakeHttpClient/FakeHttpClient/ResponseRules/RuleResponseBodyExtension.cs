using System.Net.Http;

namespace WonderTools.FakeHttpClient.ResponseRules
{
    public static class RuleResponseBodyExtension
    {
        public static IResponseMakingRuleBuilder SetResponseContent(this IResponseMakingRuleBuilder ruleBuilder,HttpContent content)
        {
            ruleBuilder.Use((request, response) =>
            {
                response.Content = content;
            });
            return ruleBuilder;
        }
    }
}
