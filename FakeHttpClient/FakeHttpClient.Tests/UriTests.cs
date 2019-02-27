using System;
using System.Net;
using System.Net.Http;
using NUnit.Framework;

namespace FakeHttpClient.Tests
{
    public class UriTests
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
        public void When_uri_then_status_code()
        {
            var uri = @"https://www.google.com/";
            var responseHttpCode = HttpStatusCode.Accepted;

            _messageHandler.BuildRule().WhenUri(uri)
                .UseStatusCode(responseHttpCode);
            
            var response = _client.SendAsync(new HttpRequestMessage() { RequestUri = new Uri("https://www.google.com") })
                .Result;
            Assert.AreEqual(responseHttpCode, response.StatusCode);
            
        }

        [Test]
        public void When_uri_starts_with_rule_created_then_rule_works()
        {
            var uriStarting = "https://www.go";
            var responseHttpCode = HttpStatusCode.Accepted;

            _messageHandler.BuildRule().WhenUriStartsWith(uriStarting)
                .UseStatusCode(HttpStatusCode.Accepted);
            var response = _client.SendAsync(new HttpRequestMessage() { RequestUri = new Uri(uriStarting + "anything") })
                .Result;

            Assert.AreEqual(responseHttpCode, response.StatusCode);
        }

        [Test]
        public void When_uri_contains_with_then_status_code()
        {
            _messageHandler.BuildRule().WhenUriContains("test")
                .UseStatusCode(HttpStatusCode.Accepted);

            var response = _client.SendAsync(new HttpRequestMessage() { RequestUri = new Uri("https://www.test.com") })
                .Result;
            Assert.AreEqual(HttpStatusCode.Accepted, response.StatusCode);
            
        }

        [Test]
        public void When_uri_port_then_status_code()
        {
            var requestUri = new Uri("https://ip:80//www.test.com");
            var responseHttpCode = HttpStatusCode.Accepted;

            _messageHandler.BuildRule().WhenUriPort(80)
                .UseStatusCode(HttpStatusCode.Accepted);
            

            var response1 = _client.SendAsync(new HttpRequestMessage() { RequestUri = requestUri })
                .Result;
            Assert.AreEqual(responseHttpCode, response1.StatusCode);
            
        }
    }
}