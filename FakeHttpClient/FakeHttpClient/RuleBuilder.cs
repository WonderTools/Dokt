using System;
using System.Collections.Generic;
using System.Net.Http;

namespace WonderTools.FakeHttpClient
{
    public class RuleBuilder : IRequestMatchingRuleBuilder, IResponseMakingRuleBuilder
    {
        List<Action<HttpRequestMessage, HttpResponseMessage>>
            _responseModifiers = new List<Action<HttpRequestMessage, HttpResponseMessage>>();

        List<Predicate<HttpRequestMessage>> _entryConditions = new List<Predicate<HttpRequestMessage>>();
        List<Action<HttpRequestMessage>> _callBacks = new List<Action<HttpRequestMessage>>();
        private Func<HttpRequestMessage, Exception> _exceptionGenerator;

        public RuleBuilder With(Predicate<HttpRequestMessage> entryCondition)
        {
            _entryConditions.Add(entryCondition);
            return this;
        }

        public RuleBuilder Using(Action<HttpRequestMessage, HttpResponseMessage> modifier)
        {
            _responseModifiers.Add(modifier);
            return this;
        }

        public IResponseMakingRuleBuilder Respond(string body = "")
        {
            _responseModifiers.Add((req, res) => { res.Content = new StringContent(body);});
            return this;
        }
        
        public IRuleBuilder Execute(Action<HttpRequestMessage> action)
        {
            _callBacks.Add(action);
            return this;
        }

        public void Throw(Func<HttpRequestMessage, Exception> exceptionGenerator)
        {
            _exceptionGenerator = exceptionGenerator;
        }

        public bool IsMatch(HttpRequestMessage request)
        {
            foreach (var entryCondition in _entryConditions)
            {
                var result = entryCondition.Invoke(request);
                if (result == false)
                {
                    return false;
                }
            }

            return true;
        }

        public void BuildResponse(HttpRequestMessage request, HttpResponseMessage response)
        {
            foreach (var modifier in _responseModifiers)
            {
                modifier.Invoke(request, response);
            }
        }

        public void ExecuteCallBacks(HttpRequestMessage request)
        {
            foreach (var callBack in _callBacks)
            {
                callBack.Invoke(request);
            }
        }

        public void ThrowExceptionIfNeeded(HttpRequestMessage request)
        {
            if (_exceptionGenerator != null)
            {
                var exception = _exceptionGenerator.Invoke(request);
                throw exception;
            }
        }
    }
}