using System;
using System.Net.Http;

namespace WonderTools.Dokt
{
    public interface IResponseMakingRuleBuilder : IRuleBuilder
    {
        RuleBuilder Using(Action<HttpRequestMessage, HttpResponseMessage> modifier);
    }
}