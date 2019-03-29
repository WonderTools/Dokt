using System;
using System.Net.Http;

namespace WonderTools.FakeHttpClient
{
    public interface IResponseMakingRuleBuilder : IRuleBuilder
    {
        RuleBuilder Use(Action<HttpRequestMessage, HttpResponseMessage> modifier);
    }
}