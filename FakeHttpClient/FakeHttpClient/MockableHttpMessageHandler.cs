using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WonderTools.FakeHttpClient
{
    public class MockableHttpMessageHandler : HttpMessageHandler
    {
        private List<Rule> rules = new List<Rule>();

        public Rule BuildRule()
        {
            var rule = new Rule();
            rules.Add(rule);
            return rule;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            foreach (var rule in rules)
            {
                if (rule.IsMatch(request))
                {
                    var response = new HttpResponseMessage();
                    rule.BuildResponse(response, request);
                    return response;
                }
            }
            throw new Exception("no rule matched");
        }
    }
}