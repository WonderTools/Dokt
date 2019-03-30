using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WonderTools.Flug;

namespace WonderTools.Dokt
{
    public class DoktHttpMessageHandler : HttpMessageHandler
    {
        private readonly List<RuleBuilder> _rules = new List<RuleBuilder>();

        public IRequestMatchingRuleBuilder WhenRequest()
        {
            var rule = new RuleBuilder();
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