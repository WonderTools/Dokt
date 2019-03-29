using System.Net;

namespace WonderTools.FakeHttpClient.ResponseRules
{
    public static class RuleStatusCodeExtensions
    {
        public static IResponseMakingRuleBuilder UsingStatusCode(this IResponseMakingRuleBuilder ruleBuilder, HttpStatusCode statusCode)
        {
            ruleBuilder.Using((request, response) => { response.StatusCode = statusCode; });
            return ruleBuilder;
        }
    }
}
