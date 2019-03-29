using System.Net.Http;

namespace WonderTools.FakeHttpClient.RequestRules
{
    public static class RuleRequestBodyExtension
    {
        public static Rule WithRequestContent(this Rule rule, HttpContent content)
        {
            rule.AddEntryCondition(x => x.Content.Equals(content));
            return rule;
        }
    }
}
