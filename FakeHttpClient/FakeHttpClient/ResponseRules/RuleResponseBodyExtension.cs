using System.Net.Http;

namespace WonderTools.FakeHttpClient.ResponseRules
{
    public static class RuleResponseBodyExtension
    {
        public static Rule SetResponseContent(this Rule rule,HttpContent content)
        {
            rule.AddModifier((request, response) =>
            {
                response.Content = content;
            });
            return rule;
        }
    }
}
