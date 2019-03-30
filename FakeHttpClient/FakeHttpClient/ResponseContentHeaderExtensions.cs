using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WonderTools.FakeHttpClient
{
    public static class ResponseContentHeaderExtensions
    {
        public static IResponseMakingRuleBuilder UsingContentTypeHeader(this IResponseMakingRuleBuilder ruleBuilder, string mediaType)
        {
            ruleBuilder.Using((req, res) => { res.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType); });
            return ruleBuilder;
        }

        public static IResponseMakingRuleBuilder UsingContentRangeHeader(this IResponseMakingRuleBuilder ruleBuilder, long from,long to)
        {
            ruleBuilder.Using((req, res) => { res.Content.Headers.ContentRange = new ContentRangeHeaderValue(from, to); });
            return ruleBuilder;
        }

        public static IResponseMakingRuleBuilder UsingContentEncodingHeader(this IResponseMakingRuleBuilder ruleBuilder, string encoding)
        {
            ruleBuilder.Using((req, res) => { res.Content.Headers.ContentEncoding.Add(encoding);});
            return ruleBuilder;
        }

        public static IResponseMakingRuleBuilder UsingContentLanguageHeader(this IResponseMakingRuleBuilder ruleBuilder, string language)
        {

            ruleBuilder.Using((req, res) => { res.Content.Headers.ContentLanguage.Add(language); });
            return ruleBuilder;
            
        }
    }
}