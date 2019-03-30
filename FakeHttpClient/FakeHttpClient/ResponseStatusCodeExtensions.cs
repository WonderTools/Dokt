using System.Net;

namespace WonderTools.Flug
{
    public static class ResponseStatusCodeExtensions
    {
        public static IResponseMakingRuleBuilder UsingStatusCode(this IResponseMakingRuleBuilder ruleBuilder, HttpStatusCode statusCode)
        {
            ruleBuilder.Using((request, response) => { response.StatusCode = statusCode; });
            return ruleBuilder;
        }
    }
}
