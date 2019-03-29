using System;
using System.Net.Http;

namespace WonderTools.FakeHttpClient
{
    public interface IResponseMakingRuleBuilder : IRuleBuilder
    {
        RuleBuilder Using(Action<HttpRequestMessage, HttpResponseMessage> modifier);
    }
}