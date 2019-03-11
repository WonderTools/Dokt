using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using NUnit.Framework;

namespace WonderTools.FakeHttpClient.Tests
{
    public class RequestHeaderTests
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
        public void When_accept_header_then_status_code()
        {
            var uri = @"https://www.google.com/";
            var responseHttpCode = HttpStatusCode.Accepted;
            var acceptHeader = new MediaTypeWithQualityHeaderValue("application/json");
            _messageHandler.BuildRule().WhenUri(uri).WithAcceptHeader("application/json").UseStatusCode(responseHttpCode);
            _client.DefaultRequestHeaders.Accept.Add(acceptHeader);

            var response = _client.GetAsync(new Uri("https://www.google.com")).Result;

            Assert.AreEqual(responseHttpCode, response.StatusCode);
        }

        [Test]
        public void When_accept_charset_header_then_status_code()
        {
            var uri = @"https://www.google.com/";
            var responseHttpCode = HttpStatusCode.Accepted;
            var charsetHeader = new StringWithQualityHeaderValue("iso-8859-5");
            _messageHandler.BuildRule().WhenUri(uri).WithAcceptCharsetHeader("iso-8859-5").UseStatusCode(responseHttpCode);
            _client.DefaultRequestHeaders.AcceptCharset.Add(charsetHeader);

            var response = _client.GetAsync(new Uri("https://www.google.com")).Result;

            Assert.AreEqual(responseHttpCode, response.StatusCode);

        }

        [Test]
        public void When_accept_encoding_header_then_status_code()
        {
            var uri = @"https://www.google.com/";
            var responseHttpCode = HttpStatusCode.Accepted;
            var encodingHeader = new StringWithQualityHeaderValue("gzip");
            _messageHandler.BuildRule().WhenUri(uri).WithAcceptEncodingHeader("gzip").UseStatusCode(responseHttpCode);
            _client.DefaultRequestHeaders.AcceptEncoding.Add(encodingHeader);

            var response = _client.GetAsync(new Uri("https://www.google.com")).Result;

            Assert.AreEqual(responseHttpCode, response.StatusCode);
        }

        [Test]
        public void When_accept_language_header_then_status_code()
        {
            var uri = @"https://www.google.com/";
            var responseHttpCode = HttpStatusCode.Accepted;
            var languageHeader = new StringWithQualityHeaderValue("en-US");
            _messageHandler.BuildRule().WhenUri(uri).WithAcceptLanguageHeader("en-US").UseStatusCode(responseHttpCode);
            _client.DefaultRequestHeaders.AcceptLanguage.Add(languageHeader);

            var response = _client.GetAsync(new Uri("https://www.google.com")).Result;

            Assert.AreEqual(responseHttpCode, response.StatusCode);
        }

        [Test]
        public void When_authentication_header_then_status_code()
        {
            var uri = @"https://www.google.com/";
            var responseHttpCode = HttpStatusCode.Accepted;
            var authenticationHeader = new AuthenticationHeaderValue("http","test");
            _messageHandler.BuildRule().WhenUri(uri).WithAuthenticationHeader("http", "test").UseStatusCode(responseHttpCode);
            _client.DefaultRequestHeaders.Authorization = authenticationHeader;

            var response = _client.DeleteAsync(new Uri("https://www.google.com")).Result;

            Assert.AreEqual(responseHttpCode, response.StatusCode);
        }
    }
}
