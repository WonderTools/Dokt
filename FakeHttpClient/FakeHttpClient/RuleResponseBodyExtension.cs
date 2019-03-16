using System.Collections.Generic;
using System.Net.Http;

namespace WonderTools.FakeHttpClient
{
    public static class RuleResponseBodyExtension
    {
        public static Rule UseResponseContent(this Rule rule,HttpContent content)
        {
            rule.AddModifier((request, response) =>
            {
                response.Content = content;
            });
            return rule;
        }
    }
}
