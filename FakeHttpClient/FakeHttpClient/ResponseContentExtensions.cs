using System.Net.Http;

namespace WonderTools.FakeHttpClient
{
    public static class ResponseContentExtensions
    {
        public static IResponseMakingRuleBuilder UsingContent(this IResponseMakingRuleBuilder ruleBuilder,HttpContent content)
        {
            ruleBuilder.Using((request, response) =>
            {
                response.Content = content;
            });
            return ruleBuilder;
        }

        public static IResponseMakingRuleBuilder UsingContent(this IResponseMakingRuleBuilder ruleBuilder, string content)
        {
            ruleBuilder.Using((request, response) =>
            {
                response.Content = new StringContent(content);
            });
            return ruleBuilder;
        }
    }
}
