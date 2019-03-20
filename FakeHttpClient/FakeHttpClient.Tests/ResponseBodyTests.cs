using System;
using System.Net;
using System.Net.Http;
using NUnit.Framework;

namespace WonderTools.FakeHttpClient.Tests
{
    public class ResponseBodyTests
    {
        MockableHttpMessageHandler _messageHandler;
        HttpClient _client;

        [SetUp]
        public void SetUp()
        {
            _messageHandler = new MockableHttpMessageHandler();
            _client = new HttpClient(_messageHandler);
        }

        [Test]
        public void When_request_then_use_content_response()
        {
            var uri = @"https://www.google.com/";
            var responseHttpCode = HttpStatusCode.Accepted;
            var content = "test";
            _messageHandler.BuildRule().WhenUri(uri).UseResponseContent(content.CreateContent()).UseStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri("https://www.google.com")).Result;
            var result = response.Content.ReadAsStringAsync().Result;

             Assert.AreEqual(content, result);
        }

        [Test]
        public void When_request_then_use_content_type_response()
        {
            var uri = @"https://www.google.com/";
            var responseHttpCode = HttpStatusCode.Accepted;
            var content = "test";
            var contentType = "text/html";
            _messageHandler.BuildRule().WhenUri(uri).UseResponseContent(content.CreateContent().WithContentType(contentType)).UseStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri("https://www.google.com")).Result;

            Assert.AreEqual(contentType, response.Content.Headers.ContentType.ToString());
        }

        [Test]
        public void When_request_then_use_content_range_response()
        {
            var uri = @"https://www.google.com/";
            var responseHttpCode = HttpStatusCode.Accepted;
            var content = "test";
            _messageHandler.BuildRule().WhenUri(uri).UseResponseContent(content.CreateContent().WithContentRange(22234, 62887922)).UseStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri("https://www.google.com")).Result;

            Assert.AreEqual("bytes 22234-62887922/*", response.Content.Headers.ContentRange.ToString());
        }
    }
}
