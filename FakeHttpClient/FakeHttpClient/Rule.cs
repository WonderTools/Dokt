using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace FakeHttpClient
{
    public class Rule
    {
        List<Predicate<HttpRequestMessage>> _entryConditions = new List<Predicate<HttpRequestMessage>>();
        List<Action<HttpResponseMessage>> _modifiers = new List<Action<HttpResponseMessage>>();
        private Func<Exception> _exceptionFactory;

        public Rule WhenUri(string uri)
        {
            _entryConditions.Add(x=>x.RequestUri.AbsoluteUri==uri);
            return this;
        }

        public Rule WhenUriStartsWith(string segment)
        {
            _entryConditions.Add(x => x.RequestUri.OriginalString.StartsWith(segment));
            return this;
        }

        public Rule WhenUriContains(string segment)
        {
            _entryConditions.Add(x => x.RequestUri.AbsoluteUri.Contains(segment));
            return this;
        }

        public Rule WhenUriPort(int port)
        {
            _entryConditions.Add(x => x.RequestUri.Port.Equals(port));
            return this;
        }
        
        //When Uri Predicate<string>
        //When Uri Scheme


        public Rule UseStatusCode(HttpStatusCode statusCode)
        {
            _modifiers.Add(x => { x.StatusCode = statusCode; });
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
}