using System.Net;

namespace WonderTools.FakeHttpClient
{
    public static class RuleStatusCodeExtensions
    {
        public static Rule UseStatusCode(this Rule rule, HttpStatusCode statusCode)
        {
            rule.AddModifier(x => { x.StatusCode = statusCode; });
            return rule;
        }
    }
}
