using System;
using System.Net.Http;

namespace WonderTools.FakeHttpClient
{
    public interface IRequestMatchingRuleBuilder : IRuleBuilder
    {
        RuleBuilder With(Predicate<HttpRequestMessage> entryCondition);
    }
}