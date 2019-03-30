using System.Net.Http;
using WonderTools.Dokt;

namespace WonderTools.Flug
{
    public static class RequestMethodExtensions
    {
        public static IRequestMatchingRuleBuilder WhenRequest(this DoktHttpMessageHandler messageHandler, HttpMethod method)
        {
            return messageHandler.WhenRequest().WithMethod(method);
        }

        public static IRequestMatchingRuleBuilder WithMethod(this IRequestMatchingRuleBuilder ruleBuilder, HttpMethod httpMethod)
        {
            return ruleBuilder.With(req => req.Method == httpMethod);
        }

        public static IRequestMatchingRuleBuilder WithPost(this IRequestMatchingRuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithMethod(HttpMethod.Post);
        }

        public static IRequestMatchingRuleBuilder WhenPost(this DoktHttpMessageHandler handler)
        {
            return handler.WhenRequest(HttpMethod.Post);
        }


        public static IRequestMatchingRuleBuilder WithGet(this IRequestMatchingRuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithMethod(HttpMethod.Get);
        }

        public static IRequestMatchingRuleBuilder WhenGet(this DoktHttpMessageHandler handler)
        {
            return handler.WhenRequest(HttpMethod.Get);
        }


        public static IRequestMatchingRuleBuilder WithOption(this IRequestMatchingRuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithMethod(HttpMethod.Options);
        }

        public static IRequestMatchingRuleBuilder WhenOption(this DoktHttpMessageHandler handler)
        {
            return handler.WhenRequest(HttpMethod.Options);
        }

        public static IRequestMatchingRuleBuilder WithDelete(this IRequestMatchingRuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithMethod(HttpMethod.Delete);
        }

        public static IRequestMatchingRuleBuilder WhenDelete(this DoktHttpMessageHandler handler)
        {
            return handler.WhenRequest(HttpMethod.Delete);
        }

        public static IRequestMatchingRuleBuilder WithPut(this IRequestMatchingRuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithMethod(HttpMethod.Put);
        }

        public static IRequestMatchingRuleBuilder WhenPut(this DoktHttpMessageHandler handler)
        {
            return handler.WhenRequest(HttpMethod.Put);
        }

        public static IRequestMatchingRuleBuilder WithPatch(this IRequestMatchingRuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithMethod(HttpMethod.Patch);
        }

        public static IRequestMatchingRuleBuilder WhenPatch(this DoktHttpMessageHandler handler)
        {
            return handler.WhenRequest(HttpMethod.Patch);
        }

        public static IRequestMatchingRuleBuilder WithHead(this IRequestMatchingRuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithMethod(HttpMethod.Head);
        }

        public static IRequestMatchingRuleBuilder WhenHead(this DoktHttpMessageHandler handler)
        {
            return handler.WhenRequest(HttpMethod.Head);
        }

        public static IRequestMatchingRuleBuilder WithTrace(this IRequestMatchingRuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithMethod(HttpMethod.Trace);
        }

        public static IRequestMatchingRuleBuilder WhenTrace(this DoktHttpMessageHandler handler)
        {
            return handler.WhenRequest(HttpMethod.Trace);
        }
    }
}