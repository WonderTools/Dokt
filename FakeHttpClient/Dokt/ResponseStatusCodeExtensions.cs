using System.Net;

namespace WonderTools.Dokt
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
