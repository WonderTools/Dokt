using System;
using System.Collections.Generic;
using System.Net.Http;

namespace WonderTools.FakeHttpClient
{
    public class Rule
    {
        List<Action<HttpResponseMessage, HttpRequestMessage>> 
            _responseModifiers = new List<Action<HttpResponseMessage, HttpRequestMessage>>();
        List<Predicate<HttpRequestMessage>> _entryConditions = new List<Predicate<HttpRequestMessage>>();
        List<Action<HttpRequestMessage>> _callBacks = new List<Action<HttpRequestMessage>>();
        private Func<HttpRequestMessage, Exception> _exceptionGenerator;

        public void AddEntryCondition(Predicate<HttpRequestMessage> entryCondition)
        {
            _entryConditions.Add(entryCondition);
        }

        public void AddModifier(Action<HttpResponseMessage, HttpRequestMessage> modifier)
        {
            _responseModifiers.Add(modifier);
        }

        public void AddCallBack(Action<HttpRequestMessage> action)
        {
            _callBacks.Add(action);
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

        public void BuildResponse(HttpResponseMessage response, HttpRequestMessage request)
        {
            foreach (var modifier in _responseModifiers)
            {
                modifier.Invoke(response, request);
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
            _exceptionGenerator?.Invoke(request);
        }
    }
}