using System.Net.Http;

namespace WonderTools.FakeHttpClient
{
    public static class RequestMethodExtensions
    {
        public static IRequestMatchingRuleBuilder WhenRequest(this MockableHttpMessageHandler messageHandler, HttpMethod method)
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

        public static IRequestMatchingRuleBuilder WhenPost(this MockableHttpMessageHandler handler)
        {
            return handler.WhenRequest(HttpMethod.Post);
        }


        public static IRequestMatchingRuleBuilder WithGet(this IRequestMatchingRuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithMethod(HttpMethod.Get);
        }

        public static IRequestMatchingRuleBuilder WhenGet(this MockableHttpMessageHandler handler)
        {
            return handler.WhenRequest(HttpMethod.Get);
        }


        public static IRequestMatchingRuleBuilder WithOption(this IRequestMatchingRuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithMethod(HttpMethod.Options);
        }

        public static IRequestMatchingRuleBuilder WhenOption(this MockableHttpMessageHandler handler)
        {
            return handler.WhenRequest(HttpMethod.Options);
        }

        public static IRequestMatchingRuleBuilder WithDelete(this IRequestMatchingRuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithMethod(HttpMethod.Delete);
        }

        public static IRequestMatchingRuleBuilder WhenDelete(this MockableHttpMessageHandler handler)
        {
            return handler.WhenRequest(HttpMethod.Delete);
        }

        public static IRequestMatchingRuleBuilder WithPut(this IRequestMatchingRuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithMethod(HttpMethod.Put);
        }

        public static IRequestMatchingRuleBuilder WhenPut(this MockableHttpMessageHandler handler)
        {
            return handler.WhenRequest(HttpMethod.Put);
        }

        public static IRequestMatchingRuleBuilder WithPatch(this IRequestMatchingRuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithMethod(HttpMethod.Patch);
        }

        public static IRequestMatchingRuleBuilder WhenPatch(this MockableHttpMessageHandler handler)
        {
            return handler.WhenRequest(HttpMethod.Patch);
        }

        public static IRequestMatchingRuleBuilder WithHead(this IRequestMatchingRuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithMethod(HttpMethod.Head);
        }

        public static IRequestMatchingRuleBuilder WhenHead(this MockableHttpMessageHandler handler)
        {
            return handler.WhenRequest(HttpMethod.Head);
        }

        public static IRequestMatchingRuleBuilder WithTrace(this IRequestMatchingRuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithMethod(HttpMethod.Trace);
        }

        public static IRequestMatchingRuleBuilder WhenTrace(this MockableHttpMessageHandler handler)
        {
            return handler.WhenRequest(HttpMethod.Trace);
        }
    }
}