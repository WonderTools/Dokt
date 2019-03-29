using System.Net;

namespace WonderTools.FakeHttpClient.ResponseRules
{
    public static class RuleStatusCodeExtensions
    {
        public static IResponseMakingRuleBuilder UseStatusCode(this IResponseMakingRuleBuilder ruleBuilder, HttpStatusCode statusCode)
        {
            ruleBuilder.Use((request, response) => { response.StatusCode = statusCode; });
            return ruleBuilder;
        }
    }
}
