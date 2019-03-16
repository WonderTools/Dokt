using System.Net.Http;
using System.Net.Http.Headers;

namespace WonderTools.FakeHttpClient
{
    public static class HttpContentExtension
    {
        public static HttpContent CreateContent(this string content)
        {
            var httpContent = new StringContent(content);
            return httpContent;
        }

        public static HttpContent WithContentType(this HttpContent content, string mediaType)
        {
            content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
            return content;
        }

        public static HttpContent WithContentRange(this HttpContent content, long from,long to)
        {
            content.Headers.ContentRange = new ContentRangeHeaderValue(from,to);
            return content;
        }
    }
}