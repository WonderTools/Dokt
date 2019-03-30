using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;
using WonderTools.FakeHttpClient.RequestRules;

namespace WonderTools.FakeHttpClient.Tests
{
    public class RequestHeaderTests
    {
        MockableHttpMessageHandler _messageHandler;
        HttpClient _client;
        private string _defaultUri = @"https://www.google.com/";

        [SetUp]
        public void SetUp()
        {
            _messageHandler = new MockableHttpMessageHandler();
            _client = new HttpClient(_messageHandler);
        }

        [Test]
        public void When_accept_header_then_status_code()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var acceptHeader = new MediaTypeWithQualityHeaderValue("application/json");
            _messageHandler
                .WhenRequest()
                    .WithUri(_defaultUri).WithAcceptHeader("application/json").Respond().UsingStatusCode(responseHttpCode);
            _client.DefaultRequestHeaders.Accept.Add(acceptHeader);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;

            Assert.AreEqual(responseHttpCode, response.StatusCode);
        }

        [Test]
        public void When_accept_charset_header_then_status_code()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var charsetHeader = new StringWithQualityHeaderValue("iso-8859-5");
            _messageHandler.WhenRequest().WithUri(_defaultUri).WithAcceptCharsetHeader("iso-8859-5").Respond().UsingStatusCode(responseHttpCode);
            _client.DefaultRequestHeaders.AcceptCharset.Add(charsetHeader);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;

            Assert.AreEqual(responseHttpCode, response.StatusCode);

        }

        [Test]
        public void When_accept_encoding_header_then_status_code()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var encodingHeader = new StringWithQualityHeaderValue("gzip");
            _messageHandler.WhenRequest().WithUri(_defaultUri).WithAcceptEncodingHeader("gzip").Respond().UsingStatusCode(responseHttpCode);
            _client.DefaultRequestHeaders.AcceptEncoding.Add(encodingHeader);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;

            Assert.AreEqual(responseHttpCode, response.StatusCode);
        }

        [Test]
        public void When_accept_language_header_then_status_code()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var languageHeader = new StringWithQualityHeaderValue("en-US");
            _messageHandler.WhenRequest().WithUri(_defaultUri).WithAcceptLanguageHeader("en-US").Respond().UsingStatusCode(responseHttpCode);
            _client.DefaultRequestHeaders.AcceptLanguage.Add(languageHeader);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;

            Assert.AreEqual(responseHttpCode, response.StatusCode);
        }

        [Test]
        public void When_authentication_header_then_status_code()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var authenticationHeader = new AuthenticationHeaderValue("http","test");
            _messageHandler.WhenRequest().WithUri(_defaultUri).WithAuthenticationHeader("http", "test").Respond().UsingStatusCode(responseHttpCode);
            _client.DefaultRequestHeaders.Authorization = authenticationHeader;

            var response = _client.DeleteAsync(new Uri(_defaultUri)).Result;

            Assert.AreEqual(responseHttpCode, response.StatusCode);
        }
    }
}
