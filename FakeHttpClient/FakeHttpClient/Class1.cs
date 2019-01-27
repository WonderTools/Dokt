using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FakeHttpClient
{
    public class Class1
    {
    }


    public class Rule
    {
        List<Func<HttpRequestMessage, bool>> _entryConditions = new List<Func<HttpRequestMessage, bool>>();
        List<Action<HttpResponseMessage>> _modifiers = new List<Action<HttpResponseMessage>>();
        private Func<Exception> _exceptionFactory;

        public Rule Use(Action<HttpResponseMessage> responseModifier)
        {
            _modifiers.Add(responseModifier);
            return this;
        }

        public Rule When(Func<HttpRequestMessage, bool> uriValidator)
        {
            _entryConditions.Add(uriValidator);
            return this;
        }

        public bool IsMatch(HttpRequestMessage request)
        {
            foreach (var entryCondition in _entryConditions)
            {
                var re = entryCondition.Invoke(request);
                if (re == false) return false;
            }

            return true;
        }

        public void BuildResponse(HttpResponseMessage response)
        {
            foreach (var modifier in _modifiers)
            {
                modifier.Invoke(response);
            }
        }
    }


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
                    rule.BuildResponse(response);
                    return response;
                }
            }
            throw new Exception("no rule matched");
        }
    }
}
