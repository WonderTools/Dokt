using System;
using System.Net.Http;

namespace WonderTools.Dokt
{
    public interface IRuleBuilder
    {
        IResponseMakingRuleBuilder Respond(string body = "");
        void Throw(Func<HttpRequestMessage, Exception> exceptionGenerator);
        IRuleBuilder Execute(Action<HttpRequestMessage> action);
    }
}