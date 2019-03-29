using System;
using System.Net;
using System.Net.Http;
using NUnit.Framework;
using WonderTools.FakeHttpClient.RequestRules;
using WonderTools.FakeHttpClient.ResponseRules;

namespace WonderTools.FakeHttpClient.Tests
{
    public class ResponseBodyTests
    {
        MockableHttpMessageHandler _messageHandler;
        HttpClient _client;
        string _defaultUri = @"https://www.google.com/";

        [SetUp]
        public void SetUp()
        {
            _messageHandler = new MockableHttpMessageHandler();
            _client = new HttpClient(_messageHandler);
        }

        [Test]
        public void When_request_then_use_content_response()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var content = "test";
            _messageHandler.BuildRule().WhenUri(_defaultUri).SetResponseContent(content.CreateContent()).UseStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;
            var result = response.Content.ReadAsStringAsync().Result;

             Assert.AreEqual(content, result);
        }

        [Test]
        public void When_request_then_use_content_type_response()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var content = "test";
            var contentType = "text/html";
            _messageHandler.BuildRule().WhenUri(_defaultUri).SetResponseContent(content.CreateContent().WithContentType
                (contentType)).UseStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;

            Assert.AreEqual(contentType, response.Content.Headers.ContentType.ToString());
        }

        [Test]
        public void When_request_then_use_content_range_response()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var content = "test";
            _messageHandler.BuildRule().WhenUri(_defaultUri).SetResponseContent(content.CreateContent().WithContentRange(22234, 62887922)).UseStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;

            Assert.AreEqual("bytes 22234-62887922/*", response.Content.Headers.ContentRange.ToString());
        }

        [Test]
        public void When_request_then_use_content_encoding_response()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var content = "test";
            var contentEncoding = "gzip";
            _messageHandler.BuildRule().WhenUri(_defaultUri).SetResponseContent(content.CreateContent().WithContentRange(22234, 62887922).WithContentEncoding(contentEncoding)).UseStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;

            Assert.AreEqual(contentEncoding, response.Content.Headers.ContentEncoding.ToString());
        }

        [Test]
        public void When_request_then_use_content_language_response()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var content = "test";
            var contentEncoding = "gzip";
            var contentLanguage = "de";
            _messageHandler.BuildRule().WhenUri(_defaultUri).SetResponseContent(content.CreateContent().WithContentRange(22234, 62887922).WithContentEncoding(contentEncoding).WithContentLanguage(contentLanguage)).UseStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;

            Assert.AreEqual(contentLanguage, response.Content.Headers.ContentLanguage.ToString());
        }
    }
}
