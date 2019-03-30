using System;
using System.Net.Http;

namespace WonderTools.Flug
{
    public interface IRequestMatchingRuleBuilder : IRuleBuilder
    {
        RuleBuilder With(Predicate<HttpRequestMessage> entryCondition);
    }
}