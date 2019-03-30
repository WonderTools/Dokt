using System;
using System.Net.Http;

namespace WonderTools.Dokt
{
    public interface IRequestMatchingRuleBuilder : IRuleBuilder
    {
        RuleBuilder With(Predicate<HttpRequestMessage> entryCondition);
    }
}