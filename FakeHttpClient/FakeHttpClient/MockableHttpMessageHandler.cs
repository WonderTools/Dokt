using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WonderTools.FakeHttpClient
{
    public class MockableHttpMessageHandler : HttpMessageHandler
    {
        private readonly List<Rule> _rules = new List<Rule>();

        public Rule WhenRequest()
        {
            var rule = new Rule();
            _rules.Add(rule);
            return rule;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            foreach (var rule in _rules)
            {
                if (rule.IsMatch(request))
                {
                    rule.ExecuteCallBacks(request);
                    rule.ThrowExceptionIfNeeded(request);
                    var response = new HttpResponseMessage();
                    rule.BuildResponse(request,response);
                    return response;
                }
            }
            throw new Exception("no rule matched");
        }
    }
}