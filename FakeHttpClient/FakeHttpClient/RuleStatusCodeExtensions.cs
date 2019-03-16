using System.Net;

namespace WonderTools.FakeHttpClient
{
    public static class RuleStatusCodeExtensions
    {
        public static Rule UseStatusCode(this Rule rule, HttpStatusCode statusCode)
        {
            rule.AddModifier((request, response) => { response.StatusCode = statusCode; });
            return rule;
        }
    }
}
