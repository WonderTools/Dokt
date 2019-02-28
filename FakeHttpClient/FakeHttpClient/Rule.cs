using System;
using System.Collections.Generic;
using System.Net.Http;

namespace FakeHttpClient
{
    public class Rule
    {
        Func<Exception> _exceptionFactory;
        List<Action<HttpResponseMessage>> _modifiers = new List<Action<HttpResponseMessage>>();
        List<Predicate<HttpRequestMessage>> _entryConditions = new List<Predicate<HttpRequestMessage>>();

        public void AddEntryCondition(Predicate<HttpRequestMessage> entryCondition)
        {
            _entryConditions.Add(entryCondition);
        }

        public void AddModifier(Action<HttpResponseMessage> modifier)
        {
            _modifiers.Add(modifier);
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